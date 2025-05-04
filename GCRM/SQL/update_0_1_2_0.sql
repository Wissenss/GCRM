CREATE TABLE public.citizen_relationship_roles
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying NOT NULL DEFAULT '',
    PRIMARY KEY (id)
);

CREATE TABLE public.citizen_relationships
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    citizen_id bigint NOT NULL DEFAULT 0,
    related_citizen_id bigint NOT NULL DEFAULT 0,
    citizen_relationship_role_id bigint NOT NULL DEFAULT 0,
    affinity_score numeric NOT NULL DEFAULT 0,
    known_start_date boolean NOT NULL DEFAULT false,
    known_end_date boolean NOT NULL DEFAULT false,
    start_date date NOT NULL DEFAULT '0001-01-01',
    end_date date NOT NULL DEFAULT '0001-01-01',
    notes character varying NOT NULL DEFAULT '',
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.citizen_relationships
    ADD COLUMN enabled boolean NOT NULL DEFAULT false;

ALTER TABLE IF EXISTS public.citizen_relationships
    ADD COLUMN user_id bigint NOT NULL DEFAULT 0;

ALTER TABLE IF EXISTS public.users
    ADD COLUMN citizen_id bigint NOT NULL DEFAULT 0;

-- update client version
UPDATE settings SET string_value = '0.1.2.0-alpha' WHERE name = 'client_version';