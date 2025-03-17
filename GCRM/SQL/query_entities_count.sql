DROP TABLE IF EXISTS temp_entities_count;

CREATE TEMPORARY TABLE temp_entities_count(
	entidad character varying,
	cantidad integer
);

INSERT INTO temp_entities_count(
	entidad, 
	cantidad
)VALUES (
	'ciudadanos',
	(SELECT COUNT(*) FROM citizens)
);


SELECT * FROM temp_entities_count;