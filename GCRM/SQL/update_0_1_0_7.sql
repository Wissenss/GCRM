-- carddav sync files
ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_sync_enabled boolean DEFAULT false;

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_url character varying DEFAULT '';

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_username character varying DEFAULT '';

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_password character varying DEFAULT '';

-- update client version
UPDATE settings SET string_value = '0.1.0.7-alpha' WHERE name = 'client_version';