ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN assistant_name character varying DEFAULT '';

-- update client version
UPDATE public.settings SET string_value = '0.1.3.4-alpha' WHERE name = 'client_version';