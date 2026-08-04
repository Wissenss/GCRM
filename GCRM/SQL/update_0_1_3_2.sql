ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN attention_required_reason character varying DEFAULT '';

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN attention_required_reason character varying DEFAULT '';

-- update client version
UPDATE public.settings SET string_value = '0.1.3.2-alpha' WHERE name = 'client_version';