-- add citizen networks table
CREATE TABLE public.citizennetworks
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    lead_citizen_id bigint DEFAULT 0,
    parent_network_id bigint DEFAULT 0,
    name character varying,
    description character varying,
    PRIMARY KEY (id)
);

-- add citizen network roles
CREATE TABLE public.citizennetwork_roles
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    citizennetwork_id bigint NOT NULL DEFAULT 0,
    name character varying,
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.citizennetwork_roles -- forgot to add this :p
    ADD COLUMN description character varying;

ALTER TABLE IF EXISTS public.citizennetwork_roles
    ADD COLUMN nivel integer DEFAULT 0;

-- add citizen network - citizens table
CREATE TABLE public.citizennetwork_citizens
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    citizennetwork_id bigint NOT NULL,
    citizen_id bigint NOT NULL,
    citizennetwork_citizen_role_id bigint DEFAULT 0,
    PRIMARY KEY (id),
    CONSTRAINT citizennetwork_id_fk FOREIGN KEY (citizennetwork_id)
        REFERENCES public.citizennetworks (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT citizen_id_fk FOREIGN KEY (citizen_id)
        REFERENCES public.citizens (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
);

ALTER TABLE IF EXISTS public.citizennetwork_citizens -- forgot to add this (again) :pp
    ADD COLUMN parent_member_id bigint DEFAULT 0;

-- fix interior number not accespting more then one char
ALTER TABLE public.addresses
    ALTER COLUMN interior_number TYPE character varying COLLATE pg_catalog."default";

-- added several more fields to citizens table
ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN voter_code character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN voter_ocr character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN voter_cic character varying DEFAULT '';

ALTER TABLE IF EXISTS public.citizens
    ADD COLUMN voter_section character varying DEFAULT '';