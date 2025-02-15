-- setting_datatype enum

CREATE TYPE setting_datatype AS ENUM(
  'string',
  'boolean',
  'numeric'
);

-- addresses table

CREATE TABLE addresses (
    id bigint NOT NULL,
    street character varying,
    number character varying,
    interior_number character(1),
    postal_code character varying,
    state character varying,
    city character varying,
    country_type integer
);

ALTER TABLE addresses ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME addresses_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY addresses ADD CONSTRAINT addresses_pkey PRIMARY KEY (id);

-- citizens table

CREATE TABLE citizens (
    id bigint NOT NULL,
    name character varying,
    paternal_name character varying,
    maternal_name character varying,
    title_type integer,
    curp character varying NOT NULL,
    birthday date,
    observations character varying,
    sex_type integer,
    address_id bigint,
    assistant_id bigint,
    phone character varying,
    phone_extension character varying,
    cellphone character varying,
    political_party_type integer,
		institution_id bigint DEFAULT 0,
    institution_role_id bigint DEFAULT 0,
    email character varying
);

ALTER TABLE citizens ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME citizens_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY citizens ADD CONSTRAINT id_pk PRIMARY KEY (id);
ALTER TABLE ONLY citizens ADD CONSTRAINT curp_unique UNIQUE (curp);
ALTER TABLE ONLY citizens ADD CONSTRAINT address_id_fk FOREIGN KEY (address_id) REFERENCES addresses(id) NOT VALID;

-- institutions

CREATE TABLE institutions (
    id bigint NOT NULL,
    name character varying,
    society_sector_type integer,
    category_id bigint,
    description character varying
);

ALTER TABLE institutions ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME institutions_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY institutions ADD CONSTRAINT institutions_pkey PRIMARY KEY (id);

-- institution_roles table

CREATE TABLE institution_roles (
    id bigint NOT NULL,
    name character varying NOT NULL,
    institution_id bigint NOT NULL,
    parent_role_id bigint,
    description character varying
);

ALTER TABLE institution_roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME institution_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY institution_roles ADD CONSTRAINT institution_roles_pkey PRIMARY KEY (id);
ALTER TABLE ONLY institution_roles ADD CONSTRAINT institution_id_fk FOREIGN KEY (institution_id) REFERENCES institutions(id) NOT VALID;

-- institution_categories table

CREATE TABLE institution_categories (
    id bigint NOT NULL,
    name character varying NOT NULL,
    description character varying
);

ALTER TABLE institution_categories ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME institution_categories_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY institution_categories ADD CONSTRAINT institution_categories_pkey PRIMARY KEY (id);

-- settings table

CREATE TABLE settings (
    id bigint NOT NULL,
    user_id bigint,
    string_value character varying,
    boolean_value boolean,
    numeric_value numeric,
    datatype setting_datatype NOT NULL,
    name character varying NOT NULL
);

ALTER TABLE settings ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME settings_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY settings ADD CONSTRAINT settings_pkey PRIMARY KEY (id);

-- users table

CREATE TABLE users (
    id bigint NOT NULL,
    name character varying NOT NULL,
    username character varying NOT NULL,
    password_hash character varying NOT NULL
);

ALTER TABLE users ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);

ALTER TABLE ONLY users ADD CONSTRAINT users_pkey PRIMARY KEY (id);

CREATE INDEX "user_id+name" ON settings USING btree (user_id, name) WITH (deduplicate_items='true');


-- user_permissions table

CREATE TABLE user_permissions (
    id bigint NOT NULL,
    user_id bigint NOT NULL,
    permited boolean DEFAULT false NOT NULL
);

ALTER TABLE ONLY user_permissions ADD CONSTRAINT user_id_fk FOREIGN KEY (user_id) REFERENCES users(id);