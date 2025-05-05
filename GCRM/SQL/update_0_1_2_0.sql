CREATE TABLE public.citizen_relationship_roles
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying NOT NULL DEFAULT '',
    PRIMARY KEY (id)
);

CREATE TABLE public.citizen_relationships
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    citizen_id bigint NOT NULL DEFAULT 0,
    related_citizen_id bigint NOT NULL DEFAULT 0,
    citizen_relationship_role_id bigint NOT NULL DEFAULT 0,
    affinity_score numeric NOT NULL DEFAULT 0,
    known_start_date boolean NOT NULL DEFAULT false,
    known_end_date boolean NOT NULL DEFAULT false,
    start_date date NOT NULL DEFAULT '0001-01-01',
    end_date date NOT NULL DEFAULT '0001-01-01',
    notes character varying NOT NULL DEFAULT '',
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.citizen_relationships
    ADD COLUMN enabled boolean NOT NULL DEFAULT false;

ALTER TABLE IF EXISTS public.citizen_relationships
    ADD COLUMN user_id bigint NOT NULL DEFAULT 0;

ALTER TABLE IF EXISTS public.users
    ADD COLUMN citizen_id bigint NOT NULL DEFAULT 0;

-- default values for citizen tables
ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN name SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN paternal_name SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN maternal_name SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN title_type SET DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN curp SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN birthday SET DEFAULT '0001-01-01';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN observations SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN sex_type SET DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN address_id SET DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN assistant_id SET DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN phone SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN phone_extension SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN cellphone SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN political_party_type SET DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ALTER COLUMN email SET DEFAULT '';

-- default field for addresses table
ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN street SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN "number" SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN interior_number SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN postal_code SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN state SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN city SET DEFAULT '';

ALTER TABLE IF EXISTS public.addresses
    ALTER COLUMN country_type SET DEFAULT 0;

-- defaults for institutions table
ALTER TABLE IF EXISTS public.institutions
    ALTER COLUMN name SET DEFAULT '';

ALTER TABLE IF EXISTS public.institutions
    ALTER COLUMN society_sector_type SET DEFAULT 0;

ALTER TABLE IF EXISTS public.institutions
    ALTER COLUMN category_id SET DEFAULT 0;

ALTER TABLE IF EXISTS public.institutions
    ALTER COLUMN description SET DEFAULT '';

-- default for institution roles table
ALTER TABLE IF EXISTS public.institution_roles
    ALTER COLUMN name SET DEFAULT '';

ALTER TABLE IF EXISTS public.institution_roles
    ALTER COLUMN institution_id SET DEFAULT 0;

ALTER TABLE IF EXISTS public.institution_roles
    ALTER COLUMN parent_role_id SET DEFAULT 0;

ALTER TABLE IF EXISTS public.institution_roles
    ALTER COLUMN description SET DEFAULT '';

-- default for citizen categories table
ALTER TABLE IF EXISTS public.citizen_categories
    ALTER COLUMN name SET DEFAULT '';

ALTER TABLE IF EXISTS public.citizen_categories
    ALTER COLUMN description SET DEFAULT '';

-- update client version
UPDATE settings SET string_value = '0.1.2.0-alpha' WHERE name = 'client_version';