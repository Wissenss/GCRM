-- citizen groups

CREATE TABLE public.citizen_groups
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying DEFAULT '',
    description character varying DEFAULT '',
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.citizen_group_citizens
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    group_id bigint DEFAULT 0,
    citizen_id bigint DEFAULT 0
);

-- update client version
UPDATE settings SET string_value = '0.1.2.4-alpha' WHERE name = 'client_version';