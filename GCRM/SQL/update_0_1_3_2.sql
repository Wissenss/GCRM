-- add attention required reason column to citizens and institutions tables

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN attention_required_reason character varying DEFAULT '';

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN attention_required_reason character varying DEFAULT '';

-- new table: institution_role_variations for different superficial variations of institution roles (waiter, waitress, sales executive, customer executive... and so on)

CREATE TABLE institution_role_variations (
    id BIGSERIAL PRIMARY KEY,
    institution_role_id BIGINT NOT NULL REFERENCES institution_roles(id) ON DELETE CASCADE,
    name VARCHAR NOT NULL
);

-- allow a citizen's institution role assignment to optionally reference a role variation

ALTER TABLE IF EXISTS public.citizen_institution_roles
    ADD COLUMN institution_role_variation_id BIGINT REFERENCES institution_role_variations(id) ON DELETE SET NULL;

-- update client version
UPDATE public.settings SET string_value = '0.1.3.2-alpha' WHERE name = 'client_version';