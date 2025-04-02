ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN is_political_activist boolean DEFAULT false;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN political_register_date date DEFAULT '1753-01-01';

-- update client version
UPDATE settings SET string_value = '0.1.1.1-alpha' WHERE name = 'client_version';