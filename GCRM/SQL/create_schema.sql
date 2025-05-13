-- este script esta actualizado con la versión 0.1.2.0 del gcrm

--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-05-06 02:44:39

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

SET default_tablespace = '';

SET default_table_access_method = heap;

-- Type: setting_datatype

-- DROP TYPE IF EXISTS public.setting_datatype;

CREATE TYPE public.setting_datatype AS ENUM
    ('string', 'boolean', 'numeric', 'blob');

ALTER TYPE public.setting_datatype
    OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 52505)
-- Name: addresses; Type: TABLE; Schema: public; Owner: postgres
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


ALTER TABLE public.addresses OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 52511)
-- Name: addresses_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 221 (class 1259 OID 52512)
-- Name: citizen_categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.citizen_categories (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying,
    description character varying DEFAULT ''::character varying
);


ALTER TABLE public.citizen_categories OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 52517)
-- Name: citizen_categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 254 (class 1259 OID 52752)
-- Name: citizen_relationship_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.citizen_relationship_roles (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying NOT NULL
);


ALTER TABLE public.citizen_relationship_roles OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 52751)
-- Name: citizen_relationship_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 252 (class 1259 OID 52735)
-- Name: citizen_relationships; Type: TABLE; Schema: public; Owner: postgres
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
    user_id bigint DEFAULT 0 NOT NULL
);


ALTER TABLE public.citizen_relationships OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 52734)
-- Name: citizen_relationships_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 223 (class 1259 OID 52518)
-- Name: citizennetwork_citizens; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.citizennetwork_citizens (
    id bigint NOT NULL,
    citizennetwork_id bigint NOT NULL,
    citizen_id bigint NOT NULL,
    citizennetwork_citizen_role_id bigint DEFAULT 0,
    parent_member_id bigint DEFAULT 0
);


ALTER TABLE public.citizennetwork_citizens OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 52523)
-- Name: citizennetwork_citizens_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 225 (class 1259 OID 52524)
-- Name: citizennetwork_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.citizennetwork_roles (
    id bigint NOT NULL,
    citizennetwork_id bigint DEFAULT 0 NOT NULL,
    name character varying,
    description character varying,
    nivel integer DEFAULT 0
);


ALTER TABLE public.citizennetwork_roles OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 52531)
-- Name: citizennetwork_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 227 (class 1259 OID 52532)
-- Name: citizennetworks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.citizennetworks (
    id bigint NOT NULL,
    lead_citizen_id bigint DEFAULT 0,
    parent_network_id bigint DEFAULT 0,
    name character varying,
    description character varying
);


ALTER TABLE public.citizennetworks OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 52539)
-- Name: citizennetworks_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 229 (class 1259 OID 52540)
-- Name: citizens; Type: TABLE; Schema: public; Owner: postgres
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
    phone character varying DEFAULT ''::character varying,
    phone_extension character varying DEFAULT ''::character varying,
    cellphone character varying DEFAULT ''::character varying,
    political_party_type integer DEFAULT 0,
    institution_id bigint DEFAULT 0,
    institution_role_id bigint DEFAULT 0,
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
    institution2_id bigint DEFAULT 0,
    institution2_role_id bigint DEFAULT 0,
    institution3_id bigint DEFAULT 0,
    institution3_role_id bigint DEFAULT 0,
    attention_required boolean DEFAULT false,
    is_political_activist boolean DEFAULT false,
    political_register_date date DEFAULT '1753-01-01'::date,
    phone2 character varying DEFAULT ''::character varying,
    phone2_extension character varying DEFAULT ''::character varying,
    phone3 character varying DEFAULT ''::character varying,
    phone3_extension character varying DEFAULT ''::character varying,
    institution_template_role_id bigint DEFAULT 0,
    institution2_template_role_id bigint DEFAULT 0,
    institution3_template_role_id bigint DEFAULT 0,
    known_birthday boolean DEFAULT true,
    known_birthyear boolean DEFAULT true,
    known_political_register_date boolean DEFAULT false
);


ALTER TABLE public.citizens OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 52573)
-- Name: citizens_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 231 (class 1259 OID 52574)
-- Name: event_logs; Type: TABLE; Schema: public; Owner: postgres
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


ALTER TABLE public.event_logs OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 52585)
-- Name: event_logs_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 233 (class 1259 OID 52586)
-- Name: institution_categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.institution_categories (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description character varying
);


ALTER TABLE public.institution_categories OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 52591)
-- Name: institution_categories_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 235 (class 1259 OID 52592)
-- Name: institution_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.institution_roles (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying NOT NULL,
    institution_id bigint DEFAULT 0 NOT NULL,
    parent_role_id bigint DEFAULT 0,
    description character varying DEFAULT ''::character varying
);


ALTER TABLE public.institution_roles OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 52597)
-- Name: institution_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 237 (class 1259 OID 52598)
-- Name: institution_template_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.institution_template_roles (
    id bigint NOT NULL,
    institution_template_id bigint,
    name character varying,
    description character varying
);


ALTER TABLE public.institution_template_roles OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 52603)
-- Name: institution_template_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 239 (class 1259 OID 52604)
-- Name: institution_templates; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.institution_templates (
    id bigint NOT NULL,
    name character varying,
    description character varying
);


ALTER TABLE public.institution_templates OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 52609)
-- Name: institution_templates_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 241 (class 1259 OID 52610)
-- Name: institutions; Type: TABLE; Schema: public; Owner: postgres
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
    institution_template_id bigint DEFAULT 0
);


ALTER TABLE public.institutions OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 52623)
-- Name: institutions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 243 (class 1259 OID 52624)
-- Name: settings; Type: TABLE; Schema: public; Owner: postgres
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


ALTER TABLE public.settings OWNER TO postgres;

--
-- TOC entry 244 (class 1259 OID 52633)
-- Name: settings_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 245 (class 1259 OID 52634)
-- Name: user_group_permissions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_group_permissions (
    id bigint NOT NULL,
    user_group_id bigint NOT NULL,
    permited boolean DEFAULT false NOT NULL
);


ALTER TABLE public.user_group_permissions OWNER TO postgres;

--
-- TOC entry 246 (class 1259 OID 52638)
-- Name: user_groups; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_groups (
    id bigint NOT NULL,
    name character varying DEFAULT ''::character varying
);


ALTER TABLE public.user_groups OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 52644)
-- Name: user_groups_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 248 (class 1259 OID 52645)
-- Name: user_permissions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_permissions (
    id bigint NOT NULL,
    user_id bigint NOT NULL,
    permited boolean DEFAULT false NOT NULL
);


ALTER TABLE public.user_permissions OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 52649)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
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


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 250 (class 1259 OID 52660)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
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
-- TOC entry 4877 (class 2606 OID 52663)
-- Name: addresses addresses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.addresses
    ADD CONSTRAINT addresses_pkey PRIMARY KEY (id);


--
-- TOC entry 4914 (class 2606 OID 52759)
-- Name: citizen_relationship_roles citizen_relationship_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizen_relationship_roles
    ADD CONSTRAINT citizen_relationship_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 4912 (class 2606 OID 52750)
-- Name: citizen_relationships citizen_relationships_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizen_relationships
    ADD CONSTRAINT citizen_relationships_pkey PRIMARY KEY (id);


--
-- TOC entry 4881 (class 2606 OID 52665)
-- Name: citizennetwork_citizens citizennetwork_citizens_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizennetwork_citizens_pkey PRIMARY KEY (id);


--
-- TOC entry 4883 (class 2606 OID 52667)
-- Name: citizennetwork_roles citizennetwork_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizennetwork_roles
    ADD CONSTRAINT citizennetwork_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 4887 (class 2606 OID 52669)
-- Name: citizennetworks citizennetworks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizennetworks
    ADD CONSTRAINT citizennetworks_pkey PRIMARY KEY (id);


--
-- TOC entry 4892 (class 2606 OID 52671)
-- Name: event_logs event_logs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.event_logs
    ADD CONSTRAINT event_logs_pkey PRIMARY KEY (id);


--
-- TOC entry 4890 (class 2606 OID 52673)
-- Name: citizens id_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizens
    ADD CONSTRAINT id_pk PRIMARY KEY (id);


--
-- TOC entry 4894 (class 2606 OID 52675)
-- Name: institution_categories institution_categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.institution_categories
    ADD CONSTRAINT institution_categories_pkey PRIMARY KEY (id);


--
-- TOC entry 4898 (class 2606 OID 52677)
-- Name: institution_roles institution_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.institution_roles
    ADD CONSTRAINT institution_roles_pkey PRIMARY KEY (id);


--
-- TOC entry 4901 (class 2606 OID 52679)
-- Name: institutions institutions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.institutions
    ADD CONSTRAINT institutions_pkey PRIMARY KEY (id);


--
-- TOC entry 4903 (class 2606 OID 52681)
-- Name: settings settings_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.settings
    ADD CONSTRAINT settings_pkey PRIMARY KEY (id);


--
-- TOC entry 4906 (class 2606 OID 52683)
-- Name: user_groups user_groups_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_groups
    ADD CONSTRAINT user_groups_pkey PRIMARY KEY (id);


--
-- TOC entry 4910 (class 2606 OID 52685)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4875 (class 1259 OID 52686)
-- Name: address_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX address_id ON public.addresses USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4878 (class 1259 OID 52687)
-- Name: citizen_category_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX citizen_category_id ON public.citizen_categories USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4888 (class 1259 OID 52688)
-- Name: citizen_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX citizen_id ON public.citizens USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4879 (class 1259 OID 52689)
-- Name: citizennetwork_citizen_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX citizennetwork_citizen_id ON public.citizennetwork_citizens USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4885 (class 1259 OID 52690)
-- Name: citizennetwork_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX citizennetwork_id ON public.citizennetworks USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4884 (class 1259 OID 52691)
-- Name: citzennetwork_role_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX citzennetwork_role_id ON public.citizennetwork_roles USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4895 (class 1259 OID 52692)
-- Name: institution_category_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX institution_category_id ON public.institution_categories USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4899 (class 1259 OID 52693)
-- Name: institution_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX institution_id ON public.institutions USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4896 (class 1259 OID 52694)
-- Name: institution_role_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX institution_role_id ON public.institution_roles USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4908 (class 1259 OID 52695)
-- Name: user_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX user_id ON public.users USING btree (id) WITH (deduplicate_items='true');


--
-- TOC entry 4904 (class 1259 OID 52696)
-- Name: user_id+name; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "user_id+name" ON public.settings USING btree (user_id, name) WITH (deduplicate_items='true');


--
-- TOC entry 4907 (class 1259 OID 52697)
-- Name: user_id+user_permission_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "user_id+user_permission_id" ON public.user_permissions USING btree (user_id, id) WITH (deduplicate_items='true');


--
-- TOC entry 4917 (class 2606 OID 52698)
-- Name: citizens address_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizens
    ADD CONSTRAINT address_id_fk FOREIGN KEY (address_id) REFERENCES public.addresses(id) NOT VALID;


--
-- TOC entry 4915 (class 2606 OID 52703)
-- Name: citizennetwork_citizens citizen_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizen_id_fk FOREIGN KEY (citizen_id) REFERENCES public.citizens(id);


--
-- TOC entry 4916 (class 2606 OID 52708)
-- Name: citizennetwork_citizens citizennetwork_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.citizennetwork_citizens
    ADD CONSTRAINT citizennetwork_id_fk FOREIGN KEY (citizennetwork_id) REFERENCES public.citizennetworks(id);


--
-- TOC entry 4918 (class 2606 OID 52713)
-- Name: institution_roles institution_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.institution_roles
    ADD CONSTRAINT institution_id_fk FOREIGN KEY (institution_id) REFERENCES public.institutions(id) NOT VALID;


--
-- TOC entry 4919 (class 2606 OID 52718)
-- Name: user_permissions user_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_permissions
    ADD CONSTRAINT user_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


-- Completed on 2025-05-06 02:44:39

--
-- PostgreSQL database dump complete
--

