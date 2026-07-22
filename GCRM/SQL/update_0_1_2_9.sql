-- remove orphan contact_numbers
DELETE FROM public.contact_numbers WHERE entity_id = 0;

ALTER TABLE public.citizens ADD COLUMN verified_by_id BIGINT REFERENCES public.users(id);
ALTER TABLE public.citizens ADD COLUMN verified_at TIMESTAMP;
ALTER TABLE public.citizens ADD COLUMN verified BOOLEAN DEFAULT FALSE;

-- update client version
UPDATE public.settings SET string_value = '0.1.2.9-alpha' WHERE name = 'client_version';