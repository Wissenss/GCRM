WITH citizen_contact_numbers AS (
	SELECT 
		cn.entity_id AS citizen_id,
		string_agg(cn.number || (CASE WHEN cn.extension <> '' THEN ' Ext. ' || cn.extension ELSE '' END), ', ') AS contact_numbers
	FROM
		contact_numbers cn
	WHERE
		cn.entity_type = 1001
		AND cn.number <> ''
	GROUP BY
		cn.entity_id
)

SELECT 
	c.id,
	c.name,
	c.paternal_name,
	c.maternal_name,
	to_char(c.birthday, 'DD') AS birth_day,
	to_char(c.birthday, 'MM') AS birth_month,
	(CASE WHEN c.birthday > DATE('1900-01-01 00:00:00') THEN to_char(c.birthday, 'YYYY') ELSE '' END) AS birth_year,
	COALESCE(ccn.contact_numbers, '') AS contact_numbers
FROM
	citizens c 
	LEFT JOIN citizen_contact_numbers ccn ON c.id = ccn.citizen_id
ORDER BY
	c.name, c.paternal_name, c.maternal_name;