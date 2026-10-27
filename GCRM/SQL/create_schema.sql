--
-- PostgreSQL database dump
--

-- Dumped from database version 18.4
-- Dumped by pg_dump version 18.4

-- Started on 2026-09-01 20:11:21

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2 (class 3079 OID 23417)
-- Name: fuzzystrmatch; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS fuzzystrmatch WITH SCHEMA public;


--
-- TOC entry 909 (class 1247 OID 23430)
-- Name: setting_datatype; Type: TYPE; Schema: public; Owner: -
--

CREATE TYPE public.setting_datatype AS ENUM (
    'string',
    'boolean',
    'numeric',
    'blob'
);


--
-- TOC entry 220 (class 1259 OID 23439)
-- Name: addresses; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.addresses (
    id bigint NOT NULL,
    street character varying DEFAULT ''::character varying,
    number character varying DEFAULT ''::character varying,
    interior_number character varying DEFAULT ''::character varying,
    postal_code character varying DEFAULT ''::character varying,
    state character varying DEFAULT ''::character varying,
    city character varying DEFAULT ''::character varying,
    country_type integer DEFAULT 0,
    district character varying DEFAULT ''::character varying
);


--
-- TOC entry 221 (class 1259 OID 23453)
-- Name: addresses_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.addresses ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.addresses_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 222 (class 1259 OID 23454)
-- Name: citizen_categories; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_categories (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying,
    description character varying DEFAULT ''::character varying
);


--
-- TOC entry 223 (class 1259 OID 23462)
-- Name: citizen_categories_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizen_categories ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizen_categories_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 224 (class 1259 OID 23463)
-- Name: citizen_group_citizens; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_group_citizens (
    id bigint NOT NULL,
    group_id bigint DEFAULT 0,
    citizen_id bigint DEFAULT 0
);


--
-- TOC entry 225 (class 1259 OID 23469)
-- Name: citizen_group_citizens_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizen_group_citizens ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizen_group_citizens_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 226 (class 1259 OID 23470)
-- Name: citizen_groups; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_groups (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying,
    description character varying DEFAULT ''::character varying
);


--
-- TOC entry 227 (class 1259 OID 23478)
-- Name: citizen_groups_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizen_groups ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizen_groups_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 228 (class 1259 OID 23479)
-- Name: citizen_institution_roles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_institution_roles (
    id integer NOT NULL,
    "position" integer,
    citizen_id integer NOT NULL,
    institution_id integer NOT NULL,
    institution_role_id integer,
    institution_template_role_id integer,
    is_institution_template_role boolean DEFAULT false,
    is_active boolean DEFAULT true,
    is_start_defined boolean DEFAULT false,
    started_at date,
    is_end_defined boolean DEFAULT false,
    ended_at date,
    institution_role_variation_id bigint
);


--
-- TOC entry 229 (class 1259 OID 23489)
-- Name: citizen_institution_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.citizen_institution_roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 5315 (class 0 OID 0)
-- Dependencies: 229
-- Name: citizen_institution_roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.citizen_institution_roles_id_seq OWNED BY public.citizen_institution_roles.id;


--
-- TOC entry 230 (class 1259 OID 23490)
-- Name: citizen_relationship_roles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_relationship_roles (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying NOT NULL
);


--
-- TOC entry 231 (class 1259 OID 23498)
-- Name: citizen_relationship_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizen_relationship_roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizen_relationship_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 232 (class 1259 OID 23499)
-- Name: citizen_relationships; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizen_relationships (
    id bigint NOT NULL,
    citizen_id bigint DEFAULT 0 NOT NULL,
    related_citizen_id bigint DEFAULT 0 NOT NULL,
    citizen_relationship_role_id bigint DEFAULT 0 NOT NULL,
    affinity_score numeric DEFAULT 0 NOT NULL,
    known_start_date boolean DEFAULT false NOT NULL,
    known_end_date boolean DEFAULT false NOT NULL,
    start_date date DEFAULT '0001-01-01'::date NOT NULL,
    end_date date DEFAULT '0001-01-01'::date NOT NULL,
    notes character varying DEFAULT ''::character varying NOT NULL,
    enabled boolean DEFAULT false NOT NULL,
    user_id bigint DEFAULT 0 NOT NULL,
    priority_score numeric DEFAULT 0
);


--
-- TOC entry 233 (class 1259 OID 23528)
-- Name: citizen_relationships_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizen_relationships ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizen_relationships_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 234 (class 1259 OID 23529)
-- Name: citizennetwork_citizens; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizennetwork_citizens (
    id bigint NOT NULL,
    citizennetwork_id bigint NOT NULL,
    citizen_id bigint NOT NULL,
    citizennetwork_citizen_role_id bigint DEFAULT 0,
    parent_member_id bigint DEFAULT 0
);


--
-- TOC entry 235 (class 1259 OID 23537)
-- Name: citizennetwork_citizens_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizennetwork_citizens ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizennetwork_citizens_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 236 (class 1259 OID 23538)
-- Name: citizennetwork_roles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizennetwork_roles (
    id bigint NOT NULL,
    citizennetwork_id bigint DEFAULT 0 NOT NULL,
    name character varying,
    description character varying,
    nivel integer DEFAULT 0
);


--
-- TOC entry 237 (class 1259 OID 23547)
-- Name: citizennetwork_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizennetwork_roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizennetwork_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 238 (class 1259 OID 23548)
-- Name: citizennetworks; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizennetworks (
    id bigint NOT NULL,
    lead_citizen_id bigint DEFAULT 0,
    parent_network_id bigint DEFAULT 0,
    name character varying,
    description character varying
);


--
-- TOC entry 239 (class 1259 OID 23556)
-- Name: citizennetworks_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizennetworks ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizennetworks_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 240 (class 1259 OID 23557)
-- Name: citizens; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.citizens (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying,
    paternal_name character varying DEFAULT ''::character varying,
    maternal_name character varying DEFAULT ''::character varying,
    title_type integer DEFAULT 0,
    curp character varying DEFAULT ''::character varying,
    birthday date DEFAULT '0001-01-01'::date,
    observations character varying DEFAULT ''::character varying,
    sex_type integer DEFAULT 0,
    address_id bigint DEFAULT 0,
    assistant_id bigint DEFAULT 0,
    political_party_type integer DEFAULT 0,
    email character varying DEFAULT ''::character varying,
    created_by_id bigint DEFAULT 0,
    created_date date DEFAULT '0001-01-01'::date,
    edit_by_id bigint DEFAULT 0,
    edit_date date DEFAULT '0001-01-01'::date,
    voter_code character varying DEFAULT ''::character varying,
    voter_ocr character varying DEFAULT ''::character varying,
    voter_cic character varying DEFAULT ''::character varying,
    voter_section character varying DEFAULT ''::character varying,
    citizen_category_id bigint DEFAULT 0,
    attention_required boolean DEFAULT false,
    is_political_activist boolean DEFAULT false,
    political_register_date date DEFAULT '1753-01-01'::date,
    known_birthday boolean DEFAULT true,
    known_birthyear boolean DEFAULT true,
    known_political_register_date boolean DEFAULT false,
    verified_by_id bigint,
    verified_at timestamp without time zone,
    verified boolean DEFAULT false,
    attention_required_reason character varying DEFAULT ''::character varying
);


--
-- TOC entry 241 (class 1259 OID 23592)
-- Name: citizens_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.citizens ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.citizens_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 242 (class 1259 OID 23593)
-- Name: contact_numbers; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.contact_numbers (
    id bigint NOT NULL,
    entity_id bigint DEFAULT 0 NOT NULL,
    entity_type integer DEFAULT 0,
    contact_number_type integer DEFAULT 0,
    number character varying DEFAULT ''::character varying,
    extension character varying DEFAULT ''::character varying,
    country integer DEFAULT 0,
    carddav_sync boolean DEFAULT false
);


--
-- TOC entry 243 (class 1259 OID 23607)
-- Name: contact_numbers_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.contact_numbers ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.contact_numbers_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 244 (class 1259 OID 23608)
-- Name: event_logs; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.event_logs (
    id bigint NOT NULL,
    user_id bigint DEFAULT 0,
    message character varying DEFAULT ''::character varying,
    primary_entity_id bigint DEFAULT 0,
    primary_entity_type bigint DEFAULT 0,
    datetime timestamp without time zone,
    type bigint DEFAULT 0,
    version character varying DEFAULT ''::character varying
);


--
-- TOC entry 245 (class 1259 OID 23620)
-- Name: event_logs_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.event_logs ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.event_logs_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 246 (class 1259 OID 23621)
-- Name: institution_categories; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institution_categories (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description character varying
);


--
-- TOC entry 247 (class 1259 OID 23628)
-- Name: institution_categories_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.institution_categories ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.institution_categories_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 248 (class 1259 OID 23629)
-- Name: institution_role_variations; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institution_role_variations (
    id bigint NOT NULL,
    institution_role_id bigint NOT NULL,
    name character varying NOT NULL
);


--
-- TOC entry 249 (class 1259 OID 23637)
-- Name: institution_role_variations_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.institution_role_variations_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 5316 (class 0 OID 0)
-- Dependencies: 249
-- Name: institution_role_variations_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.institution_role_variations_id_seq OWNED BY public.institution_role_variations.id;


--
-- TOC entry 250 (class 1259 OID 23638)
-- Name: institution_roles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institution_roles (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying NOT NULL,
    institution_id bigint DEFAULT 0 NOT NULL,
    parent_role_id bigint DEFAULT 0,
    description character varying DEFAULT ''::character varying
);


--
-- TOC entry 251 (class 1259 OID 23650)
-- Name: institution_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.institution_roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.institution_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 252 (class 1259 OID 23651)
-- Name: institution_template_roles; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institution_template_roles (
    id bigint NOT NULL,
    institution_template_id bigint,
    name character varying,
    description character varying
);


--
-- TOC entry 253 (class 1259 OID 23657)
-- Name: institution_template_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.institution_template_roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.institution_template_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 254 (class 1259 OID 23658)
-- Name: institution_templates; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institution_templates (
    id bigint NOT NULL,
    name character varying,
    description character varying
);


--
-- TOC entry 255 (class 1259 OID 23664)
-- Name: institution_templates_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.institution_templates ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.institution_templates_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 256 (class 1259 OID 23665)
-- Name: institutions; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.institutions (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying,
    society_sector_type integer DEFAULT 0,
    category_id bigint DEFAULT 0,
    description character varying DEFAULT ''::character varying,
    parent_institution_id bigint DEFAULT 0,
    created_by_id bigint DEFAULT 0,
    created_date date DEFAULT '0001-01-01'::date,
    edit_by_id bigint DEFAULT 0,
    edit_date date DEFAULT '0001-01-01'::date,
    acronym character varying DEFAULT ''::character varying,
    attention_required boolean DEFAULT false,
    institution_template_id bigint DEFAULT 0,
    address_id bigint,
    attention_required_reason character varying DEFAULT ''::character varying
);


--
-- TOC entry 257 (class 1259 OID 23684)
-- Name: institutions_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.institutions ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.institutions_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 258 (class 1259 OID 23685)
-- Name: settings; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.settings (
    id bigint NOT NULL,
    user_id bigint DEFAULT 0,
    string_value character varying DEFAULT ''::character varying,
    boolean_value boolean DEFAULT false,
    numeric_value numeric DEFAULT 0,
    datatype public.setting_datatype NOT NULL,
    name character varying NOT NULL,
    blob_value bytea
);


--
-- TOC entry 259 (class 1259 OID 23697)
-- Name: settings_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.settings ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.settings_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 260 (class 1259 OID 23698)
-- Name: user_group_permissions; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.user_group_permissions (
    id bigint NOT NULL,
    user_group_id bigint NOT NULL,
    permited boolean DEFAULT false NOT NULL
);


--
-- TOC entry 261 (class 1259 OID 23705)
-- Name: user_groups; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.user_groups (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying
);


--
-- TOC entry 262 (class 1259 OID 23712)
-- Name: user_groups_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.user_groups ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_groups_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 263 (class 1259 OID 23713)
-- Name: user_permissions; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.user_permissions (
    id bigint NOT NULL,
    user_id bigint NOT NULL,
    permited boolean DEFAULT false NOT NULL
);


--
-- TOC entry 264 (class 1259 OID 23720)
-- Name: users; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.users (
    id bigint NOT NULL,
    name character varying NOT NULL,
    username character varying NOT NULL,
    password_hash character varying NOT NULL,
    carddav_sync_enabled boolean DEFAULT false,
    carddav_url character varying DEFAULT ''::character varying,
    carddav_username character varying DEFAULT ''::character varying,
    carddav_password character varying DEFAULT ''::character varying,
    user_group_id bigint DEFAULT 0,
    enabled boolean DEFAULT true,
    citizen_id bigint DEFAULT 0 NOT NULL
);


--
-- TOC entry 265 (class 1259 OID 23737)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public.users ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 4998 (class 2604 OID 23738)
-- Name: citizen_institution_roles id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles ALTER COLUMN id SET DEFAULT nextval('public.citizen_institution_roles_id_seq'::regclass);


--
-- TOC entry 5064 (class 2604 OID 23739)
-- Name: institution_role_variations id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_role_variations ALTER COLUMN id SET DEFAULT nextval('public.institution_role_variations_id_seq'::regclass);


--
-- TOC entry 5098 (class 2606 OID 23742)
-- Name: addresses addresses_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.addresses
    ADD CONSTRAINT addresses_pkey PRIMARY KEY (id);


--
-- TOC entry 5101 (class 2606 OID 23744)
-- Name: citizen_groups citizen_groups_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_groups
    ADD CONSTRAINT citizen_groups_pkey PRIMARY KEY (id);


--
-- TOC entry 5103 (class 2606 OID 23746)
-- Name: citizen_institution_roles citizen_institution_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 5109 (class 2606 OID 23748)
-- Name: citizen_relationship_roles citizen_relationship_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_relationship_roles
    ADD CONSTRAINT citizen_relationship_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 5111 (class 2606 OID 23750)
-- Name: citizen_relationships citizen_relationships_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_relationships
    ADD CONSTRAINT citizen_relationships_pkey PRIMARY KEY (id);


--
-- TOC entry 5114 (class 2606 OID 23752)
-- Name: citizennetwork_citizens citizennetwork_citizens_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizennetwork_citizens_pkey PRIMARY KEY (id);


--
-- TOC entry 5116 (class 2606 OID 23754)
-- Name: citizennetwork_roles citizennetwork_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizennetwork_roles
    ADD CONSTRAINT citizennetwork_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 5120 (class 2606 OID 23756)
-- Name: citizennetworks citizennetworks_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizennetworks
    ADD CONSTRAINT citizennetworks_pkey PRIMARY KEY (id);


--
-- TOC entry 5125 (class 2606 OID 23758)
-- Name: contact_numbers contact_numbers_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.contact_numbers
    ADD CONSTRAINT contact_numbers_pkey PRIMARY KEY (id);


--
-- TOC entry 5127 (class 2606 OID 23760)
-- Name: event_logs event_logs_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.event_logs
    ADD CONSTRAINT event_logs_pkey PRIMARY KEY (id);


--
-- TOC entry 5123 (class 2606 OID 23762)
-- Name: citizens id_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizens
    ADD CONSTRAINT id_pk PRIMARY KEY (id);


--
-- TOC entry 5129 (class 2606 OID 23764)
-- Name: institution_categories institution_categories_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_categories
    ADD CONSTRAINT institution_categories_pkey PRIMARY KEY (id);


--
-- TOC entry 5132 (class 2606 OID 23766)
-- Name: institution_role_variations institution_role_variations_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_role_variations
    ADD CONSTRAINT institution_role_variations_pkey PRIMARY KEY (id);


--
-- TOC entry 5135 (class 2606 OID 23768)
-- Name: institution_roles institution_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_roles
    ADD CONSTRAINT institution_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 5137 (class 2606 OID 23770)
-- Name: institution_template_roles institution_template_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_template_roles
    ADD CONSTRAINT institution_template_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 5140 (class 2606 OID 23772)
-- Name: institutions institutions_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institutions
    ADD CONSTRAINT institutions_pkey PRIMARY KEY (id);


--
-- TOC entry 5142 (class 2606 OID 23774)
-- Name: settings settings_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.settings
    ADD CONSTRAINT settings_pkey PRIMARY KEY (id);


--
-- TOC entry 5145 (class 2606 OID 23776)
-- Name: user_groups user_groups_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.user_groups
    ADD CONSTRAINT user_groups_pkey PRIMARY KEY (id);


--
-- TOC entry 5149 (class 2606 OID 23778)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 5096 (class 1259 OID 23779)
-- Name: address_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX address_id ON public.addresses USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5099 (class 1259 OID 23780)
-- Name: citizen_category_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX citizen_category_id ON public.citizen_categories USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5121 (class 1259 OID 23781)
-- Name: citizen_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX citizen_id ON public.citizens USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5112 (class 1259 OID 23782)
-- Name: citizennetwork_citizen_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX citizennetwork_citizen_id ON public.citizennetwork_citizens USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5118 (class 1259 OID 23783)
-- Name: citizennetwork_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX citizennetwork_id ON public.citizennetworks USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5117 (class 1259 OID 23784)
-- Name: citzennetwork_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX citzennetwork_role_id ON public.citizennetwork_roles USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5104 (class 1259 OID 23785)
-- Name: idx_citizen_institution_roles_x_citizen_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_citizen_institution_roles_x_citizen_id ON public.citizen_institution_roles USING btree (citizen_id);


--
-- TOC entry 5105 (class 1259 OID 23786)
-- Name: idx_citizen_institution_roles_x_institution_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_citizen_institution_roles_x_institution_id ON public.citizen_institution_roles USING btree (institution_id);


--
-- TOC entry 5106 (class 1259 OID 23787)
-- Name: idx_citizen_institution_roles_x_institution_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_citizen_institution_roles_x_institution_role_id ON public.citizen_institution_roles USING btree (institution_role_id);


--
-- TOC entry 5107 (class 1259 OID 23788)
-- Name: idx_citizen_institution_roles_x_institution_template_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX idx_citizen_institution_roles_x_institution_template_role_id ON public.citizen_institution_roles USING btree (institution_template_role_id);


--
-- TOC entry 5130 (class 1259 OID 23789)
-- Name: institution_category_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX institution_category_id ON public.institution_categories USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5138 (class 1259 OID 23790)
-- Name: institution_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX institution_id ON public.institutions USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5133 (class 1259 OID 23791)
-- Name: institution_role_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX institution_role_id ON public.institution_roles USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5147 (class 1259 OID 23792)
-- Name: user_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX user_id ON public.users USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 5143 (class 1259 OID 23793)
-- Name: user_id+name; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "user_id+name" ON public.settings USING btree (user_id, name) WITH (deduplicate_items='true');


--
-- TOC entry 5146 (class 1259 OID 23794)
-- Name: user_id+user_permission_id; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "user_id+user_permission_id" ON public.user_permissions USING btree (user_id, id) WITH (deduplicate_items='true');


--
-- TOC entry 5157 (class 2606 OID 23795)
-- Name: citizens address_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizens
    ADD CONSTRAINT address_id_fk FOREIGN KEY (address_id) REFERENCES public.addresses(id) NOT VALID;


--
-- TOC entry 5155 (class 2606 OID 23800)
-- Name: citizennetwork_citizens citizen_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizen_id_fk FOREIGN KEY (citizen_id) REFERENCES public.citizens(id);


--
-- TOC entry 5150 (class 2606 OID 23805)
-- Name: citizen_institution_roles citizen_institution_roles_citizen_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_citizen_id_fkey FOREIGN KEY (citizen_id) REFERENCES public.citizens(id) ON DELETE CASCADE;


--
-- TOC entry 5151 (class 2606 OID 23810)
-- Name: citizen_institution_roles citizen_institution_roles_institution_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_institution_id_fkey FOREIGN KEY (institution_id) REFERENCES public.institutions(id) ON DELETE CASCADE;


--
-- TOC entry 5152 (class 2606 OID 23815)
-- Name: citizen_institution_roles citizen_institution_roles_institution_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_institution_role_id_fkey FOREIGN KEY (institution_role_id) REFERENCES public.institution_roles(id) ON DELETE CASCADE;


--
-- TOC entry 5153 (class 2606 OID 23820)
-- Name: citizen_institution_roles citizen_institution_roles_institution_role_variation_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_institution_role_variation_id_fkey FOREIGN KEY (institution_role_variation_id) REFERENCES public.institution_role_variations(id) ON DELETE SET NULL;


--
-- TOC entry 5154 (class 2606 OID 23825)
-- Name: citizen_institution_roles citizen_institution_roles_institution_template_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizen_institution_roles
    ADD CONSTRAINT citizen_institution_roles_institution_template_role_id_fkey FOREIGN KEY (institution_template_role_id) REFERENCES public.institution_template_roles(id) ON DELETE CASCADE;


--
-- TOC entry 5156 (class 2606 OID 23830)
-- Name: citizennetwork_citizens citizennetwork_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizennetwork_id_fk FOREIGN KEY (citizennetwork_id) REFERENCES public.citizennetworks(id);


--
-- TOC entry 5158 (class 2606 OID 23835)
-- Name: citizens citizens_verified_by_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.citizens
    ADD CONSTRAINT citizens_verified_by_id_fkey FOREIGN KEY (verified_by_id) REFERENCES public.users(id);


--
-- TOC entry 5160 (class 2606 OID 23840)
-- Name: institution_roles institution_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_roles
    ADD CONSTRAINT institution_id_fk FOREIGN KEY (institution_id) REFERENCES public.institutions(id) NOT VALID;


--
-- TOC entry 5159 (class 2606 OID 23845)
-- Name: institution_role_variations institution_role_variations_institution_role_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institution_role_variations
    ADD CONSTRAINT institution_role_variations_institution_role_id_fkey FOREIGN KEY (institution_role_id) REFERENCES public.institution_roles(id) ON DELETE CASCADE;


--
-- TOC entry 5161 (class 2606 OID 23850)
-- Name: institutions institutions_address_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.institutions
    ADD CONSTRAINT institutions_address_id_fkey FOREIGN KEY (address_id) REFERENCES public.addresses(id) ON DELETE CASCADE;


--
-- TOC entry 5162 (class 2606 OID 23855)
-- Name: user_permissions user_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.user_permissions
    ADD CONSTRAINT user_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


-- Completed on 2026-09-01 20:11:21

--
-- PostgreSQL database dump complete
--

-- set client version
INSERT INTO public.settings(datatype, string_value, name) VALUES ('string', '0.1.3.3-alpha', 'client_version');