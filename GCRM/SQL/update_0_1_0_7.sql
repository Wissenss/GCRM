-- carddav sync files
ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_sync_enabled boolean DEFAULT false;

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_url character varying DEFAULT '';

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_username character varying DEFAULT '';

ALTER TABLE IF EXISTS public.users
    ADD COLUMN carddav_password character varying DEFAULT '';

-- secondary, tertiary institution / roles
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution2_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution2_role_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution3_id bigint DEFAULT 0;

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN institution3_role_id bigint DEFAULT 0;

-- create tables for user groups

CREATE TABLE public.user_groups
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    name character varying DEFAULT '',
    PRIMARY KEY (id)
);

CREATE TABLE public.user_group_permissions
(
    id bigint NOT NULL,
    user_group_id bigint NOT NULL,
    permited boolean NOT NULL DEFAULT false
);

-- user stores its group id
ALTER TABLE IF EXISTS public.users
    ADD COLUMN user_group_id bigint DEFAULT 0;

-- update client version
UPDATE settings SET string_value = '0.1.0.7-alpha' WHERE name = 'client_version';