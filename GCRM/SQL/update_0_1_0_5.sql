-- vamos a establecer el 0 como default para user_id 
-- y en todos los registros que tengan 'null' en esa variable se le aplicara un UPDATE para que tenga 0 
ALTER TABLE IF EXISTS public.settings
    ALTER COLUMN user_id SET DEFAULT 0;

UPDATE settings SET user_id = 0 where user_id IS NULL;

-- event log table
CREATE TABLE public.event_logs
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    user_id bigint DEFAULT 0,
    message character varying DEFAULT '',
    primary_entity_id bigint DEFAULT 0,
    primary_entity_type bigint DEFAULT 0,
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.event_logs
    ADD COLUMN datetime timestamp without time zone;

ALTER TABLE IF EXISTS public.event_logs
    ADD COLUMN type bigint DEFAULT 0;

-- #65 acronym field
ALTER TABLE IF EXISTS public.institutions
    ADD COLUMN acronym character varying DEFAULT '';

-- update client version
UPDATE settings SET string_value = '0.1.0.5-alpha' WHERE name = 'client_version';