-- update client version
UPDATE public.settings SET string_value = '0.1.2.8-alpha' WHERE name = 'client_version';