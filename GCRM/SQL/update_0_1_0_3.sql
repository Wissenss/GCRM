CREATE TABLE public.citizen_categories
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying,
    description character varying
);

ALTER TABLE IF EXISTS public.citizen_categories
    OWNER to postgres;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN citizen_category_id bigint DEFAULT 0;

-- update client version
UPDATE settings SET string_value = '0.1.0.3-alpha' WHERE name = 'client_version';