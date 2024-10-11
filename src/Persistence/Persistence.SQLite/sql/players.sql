-- name: CreatePlayer
INSERT INTO players 
(
	name,
	password,
	total_kills,
	total_deaths,
	max_killing_spree,
	brought_flags,
	captured_flags,
	dropped_flags,
	returned_flags,
	head_shots,
	role_id,
	skin_id,
	rank_id,
	created_at,
	last_connection
)
VALUES (
	$name,
	$password,
	$total_kills,
	$total_deaths,
	$max_killing_spree,
	$brought_flags,
	$captured_flags,
	$dropped_flags,
	$returned_flags,
	$head_shots,
	$role_id,
	$skin_id,
	$rank_id,
	$created_at,
	$last_connection
);
select last_insert_rowid()

-- name: GetPlayerByName
SELECT *
FROM players
WHERE name = $name

-- name: PlayerExists
SELECT 1
FROM players
WHERE name = $name