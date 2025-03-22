SELECT
	COUNT(*) AS instituciones,
	u.name AS registradas_por
FROM 
	institutions i 
	LEFT JOIN users u ON (i.created_by_id = u.id)
GROUP BY
  u.name
ORDER BY
	instituciones DESC;