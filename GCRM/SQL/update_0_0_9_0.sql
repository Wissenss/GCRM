-- set default for settings table
ALTER TABLE IF EXISTS public.settings
    ALTER COLUMN string_value SET DEFAULT '';

ALTER TABLE IF EXISTS public.settings
    ALTER COLUMN boolean_value SET DEFAULT false;

ALTER TABLE IF EXISTS public.settings
    ALTER COLUMN numeric_value SET DEFAULT 0;

-- update client version
UPDATE settings SET string_value = '0.0.9.0-alpha' WHERE name = 'client_version';

-- add audit records to citizens table
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN created_by_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN created_date date DEFAULT '0001-01-01';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN edit_by_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN edit_date date DEFAULT '0001-01-01';