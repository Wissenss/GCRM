
-- create new schema 

ALTER TABLE institution_template_roles ADD PRIMARY KEY (id);

CREATE TABLE citizen_institution_roles (
	id SERIAL PRIMARY KEY,
	position INT,
	citizen_id INT NOT NULL REFERENCES citizens(id) ON DELETE CASCADE,
	institution_id INT NOT NULL REFERENCES institutions(id) ON DELETE CASCADE,
	institution_role_id INT REFERENCES institution_roles(id) ON DELETE CASCADE,
	institution_template_role_id INT REFERENCES institution_template_roles(id) ON DELETE CASCADE,
	is_institution_template_role BOOLEAN DEFAULT FALSE,
	is_active BOOLEAN DEFAULT TRUE,
	is_start_defined BOOLEAN DEFAULT FALSE,
	started_at DATE,
	is_end_defined BOOLEAN DEFAULT FALSE,
	ended_at DATE
);

CREATE INDEX idx_citizen_institution_roles_x_citizen_id ON citizen_institution_roles(citizen_id);
CREATE INDEX idx_citizen_institution_roles_x_institution_id ON citizen_institution_roles(institution_id);
CREATE INDEX idx_citizen_institution_roles_x_institution_role_id ON citizen_institution_roles(institution_role_id);
CREATE INDEX idx_citizen_institution_roles_x_institution_template_role_id ON citizen_institution_roles(institution_template_role_id);

-- migrate to new schema

WITH ds1 AS (
    SELECT
      c.id AS citizen_id,
	  1 AS position,
      c.institution_id AS institution_id,
      c.institution_role_id AS institution_role_id,
      c.institution_template_role_id AS institution_template_role_id
    FROM
      citizens c
	WHERE
	  c.institution_id <> 0
),
ds2 AS (
    SELECT
      c.id AS citizen_id,
	  2 AS position,
      c.institution2_id AS institution_id,
      c.institution2_role_id AS institution_role_id,
      c.institution2_template_role_id AS institution_template_role_id
    FROM
      citizens c
	WHERE
	  c.institution2_id <> 0
),
ds3 AS (
    SELECT
      c.id AS citizen_id,
	  3 AS position,
      c.institution3_id AS institution_id,
      c.institution3_role_id AS institution_role_id,
      c.institution3_template_role_id AS institution_template_role_id
    FROM
      citizens c
	WHERE
	  c.institution3_id <> 0
),
ds4 AS (
    SELECT * FROM ds1 
    UNION 
    SELECT * FROM ds2 
    UNION 
    SELECT * FROM ds3
),
ds5 AS (
	SELECT
		citizen_id,
		position,
		institution_id,
		(CASE WHEN institution_role_id <> 0 THEN institution_role_id ELSE NULL END) AS institution_role_id,
		(CASE WHEN institution_template_role_id <> 0 THEN institution_template_role_id ELSE NULL END) AS institution_template_role_id,
		(CASE WHEN institution_role_id = 0 THEN TRUE ELSE FALSE END) AS is_institution_template_role,
		TRUE AS is_active,
		FALSE AS is_start_defined,
		NULL::date AS started_at,
		FALSE AS is_end_defined,
		NULL::date AS ended_at
	FROM
		ds4
)

INSERT INTO citizen_institution_roles (
	citizen_id, 
	position,
	institution_id, 
	institution_role_id, 
	institution_template_role_id, 
	is_institution_template_role, 
	is_active, 
	is_start_defined, 
	started_at, 
	is_end_defined, 
	ended_at
)
SELECT * FROM ds5;

-- drop old schema

ALTER TABLE citizens DROP COLUMN institution_id;
ALTER TABLE citizens DROP COLUMN institution_role_id;
ALTER TABLE citizens DROP COLUMN institution_template_role_id;
ALTER TABLE citizens DROP COLUMN institution2_id;
ALTER TABLE citizens DROP COLUMN institution2_role_id;
ALTER TABLE citizens DROP COLUMN institution2_template_role_id;
ALTER TABLE citizens DROP COLUMN institution3_id;
ALTER TABLE citizens DROP COLUMN institution3_role_id;
ALTER TABLE citizens DROP COLUMN institution3_template_role_id;

-- drop legacy contact number columns, this are now stored in the contact_numbers table

ALTER TABLE citizens DROP COLUMN phone;
ALTER TABLE citizens DROP COLUMN phone_extension;
ALTER TABLE citizens DROP COLUMN cellphone;
ALTER TABLE citizens DROP COLUMN phone2;
ALTER TABLE citizens DROP COLUMN phone2_extension;
ALTER TABLE citizens DROP COLUMN phone3;
ALTER TABLE citizens DROP COLUMN phone3_extension;

-- add address info to institutions table

ALTER TABLE institutions ADD COLUMN address_id BIGINT REFERENCES addresses(id) ON DELETE CASCADE;

-- update client version
UPDATE public.settings SET string_value = '0.1.3.1-alpha' WHERE name = 'client_version';