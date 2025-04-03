-- added fields for extra phones
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone2 character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone2_extension character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone3 character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN phone3_extension character varying DEFAULT '';

-- update client version
UPDATE settings SET string_value = '0.1.1.2-alpha' WHERE name = 'client_version';