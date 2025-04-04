-- added fields for extra phones
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone2 character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone2_extension character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone3 character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone3_extension character varying DEFAULT '';

-- tables for institution templates
CREATE TABLE public.institution_templates
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying,
    description character varying
);

CREATE TABLE public.institution_template_roles
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    institution_template_id bigint,
    name character varying,
    description character varying
);

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN institution_template_id bigint DEFAULT 0;

-- fields to track if the role assigned to the citizen come from a template
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution_template_role_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution2_template_role_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution3_template_role_id bigint DEFAULT 0;

-- update client version
UPDATE settings SET string_value = '0.1.1.2-alpha' WHERE name = 'client_version';