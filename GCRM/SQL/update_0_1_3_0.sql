-- update client version
UPDATE public.settings SET string_value = '0.1.3.0-alpha' WHERE name = 'client_version';