-- added atention required flag to citizen table
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN attention_required boolean DEFAULT false;

-- added enabled flag to users
ALTER TABLE IF EXISTS public.users
    ADD COLUMN enabled boolean DEFAULT true;

-- attention required flag for institutions
ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN attention_required boolean DEFAULT false;

-- version field for event logs
ALTER TABLE IF EXISTS public.event_logs
    ADD COLUMN version character varying DEFAULT '';

-- update client version
UPDATE settings SET string_value = '0.1.0.8-alpha' WHERE name = 'client_version';