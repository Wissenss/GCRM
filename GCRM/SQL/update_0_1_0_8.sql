-- added atention required flag to citizen table
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN attention_required boolean DEFAULT false;

-- added enabled flag to users
ALTER TABLE IF EXISTS public.users
    ADD COLUMN enabled boolean DEFAULT true;

-- update client version
UPDATE settings SET string_value = '0.1.0.8-alpha' WHERE name = 'client_version';