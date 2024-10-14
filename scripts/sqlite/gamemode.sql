BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "players" (
	"id"	INTEGER,
	"name"	TEXT NOT NULL UNIQUE COLLATE NOCASE,
	"password"	TEXT NOT NULL,
	"total_kills"	INTEGER NOT NULL,
	"total_deaths"	INTEGER NOT NULL,
	"max_killing_spree"	INTEGER NOT NULL,
	"brought_flags"	INTEGER NOT NULL,
	"captured_flags"	INTEGER NOT NULL,
	"dropped_flags"	INTEGER NOT NULL,
	"returned_flags"	INTEGER NOT NULL,
	"head_shots"	INTEGER NOT NULL,
	"role_id"	INTEGER NOT NULL,
	"skin_id"	INTEGER NOT NULL,
	"rank_id"	INTEGER NOT NULL,
	"created_at"	TEXT NOT NULL,
	"last_connection"	TEXT NOT NULL,
	PRIMARY KEY("id")
);
COMMIT;
