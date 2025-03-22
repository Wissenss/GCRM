-- add citizen categories table
CREATE TABLE public.citizen_categories
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying,
    description character varying
);

ALTER TABLE IF EXISTS public.citizen_categories
    OWNER to postgres;

-- save citizen category
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN citizen_category_id bigint DEFAULT 0;

-- audit create / edit operations for institutions
ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN created_by_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN created_date date DEFAULT '0001-01-01';

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN edit_by_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN edit_date date DEFAULT '0001-01-01';

-- update client version
UPDATE settings SET string_value = '0.1.0.3-alpha' WHERE name = 'client_version';