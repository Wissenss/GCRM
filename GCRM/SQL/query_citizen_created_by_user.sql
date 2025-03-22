SELECT
	COUNT(*) AS ciudadanos,
	u.name AS registrados_por
FROM 
	citizens c 
	LEFT JOIN users u ON (c.created_by_id = u.id)
GROUP BY
  u.name
ORDER BY
	ciudadanos DESC;