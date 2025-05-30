-- create the contact_numbers table

CREATE TABLE public.contact_numbers
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    entity_id bigint NOT NULL DEFAULT 0,
    entity_type integer DEFAULT 0,
    contact_number_type integer DEFAULT 0,
    "number" character varying DEFAULT '',
    extension character varying DEFAULT '',
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.contact_numbers
    ADD COLUMN country integer DEFAULT 0;

ALTER TABLE IF EXISTS public.contact_numbers
    ADD COLUMN carddav_sync boolean DEFAULT false;

-- move data from the citizens table to the contact_numbers table

-- first phone
INSERT INTO contact_numbers(
entity_id, 
entity_type,
contact_number_type,
"number",
"extension")
SELECT 
id,
1001,
21,
phone,
phone_extension
FROM citizens;

-- second phone 
INSERT INTO contact_numbers(
entity_id, 
entity_type,
contact_number_type,
"number",
"extension")
SELECT 
id,
1001,
21,
phone2,
phone2_extension
FROM citizens;

-- third phone
INSERT INTO contact_numbers(
entity_id, 
entity_type,
contact_number_type,
"number",
"extension")
SELECT 
id,
1001,
21,
phone3,
phone3_extension
FROM citizens;

-- cellphone
INSERT INTO contact_numbers(
entity_id, 
entity_type,
contact_number_type,
"number",
"extension")
SELECT 
id,
1001,
20,
cellphone,
''
FROM citizens;

-- TODO: delete deprecated columns, the contact columns

-- update client version
UPDATE settings SET string_value = '0.1.2.5-alpha' WHERE name = 'client_version';