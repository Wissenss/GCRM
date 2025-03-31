-- blob field to settings type / table
ALTER TYPE public.setting_datatype
    ADD VALUE 'blob' AFTER 'numeric';

ALTER TABLE IF EXISTS public.settings
    ADD COLUMN blob_value bytea;

-- update client version
UPDATE settings SET string_value = '0.1.1.0-alpha' WHERE name = 'client_version';