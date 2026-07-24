WITH citizen_count AS (
	SELECT
		c.citizen_category_id,
		COUNT(*) AS citzen_count_per_category
	FROM
		citizens c
	GROUP BY
		c.citizen_category_id
)

SELECT
	c_cat.name AS Categoria,
	cc.citzen_count_per_category AS Ciudadanos
FROM
	citizen_count cc
	LEFT JOIN citizen_categories c_cat ON cc.citizen_category_id = c_cat.id
;