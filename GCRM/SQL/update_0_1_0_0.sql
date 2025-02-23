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