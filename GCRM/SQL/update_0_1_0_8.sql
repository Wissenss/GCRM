-- added atention required to citizen table
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN attention_required boolean DEFAULT false;

-- update client version
UPDATE settings SET string_value = '0.1.0.8-alpha' WHERE name = 'client_version';