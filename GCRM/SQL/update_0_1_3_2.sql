-- update client version
UPDATE public.settings SET string_value = '0.1.3.2-alpha' WHERE name = 'client_version';