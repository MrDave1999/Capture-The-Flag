-- name: InitializeSeedData
DELETE FROM players;
ALTER TABLE players AUTO_INCREMENT = 1;
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
VALUES 
('Admin_Player','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',0,0,0,0,0,0,0,0,'Admin',146,0,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Moderator_Player','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',0,0,0,0,0,0,0,0,'Moderator',146,0,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('VIP_Player','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',0,0,0,0,0,0,0,0,'VIP',146,0,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',0,0,0,0,0,0,0,0,'Basic',146,0,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(2)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',150,0,10,0,0,0,0,0,'Basic',131,3,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(3)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',160,0,15,0,0,0,0,0,'Basic',140,3,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(4)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',170,0,20,0,0,0,0,0,'Basic',137,3,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(5)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',200,0,25,0,0,0,0,0,'Basic',100,4,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(6)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',251,0,50,0,0,0,0,0,'Basic',98,5,'2023-10-12 12:19:24','2023-10-13 12:19:24'),
('Basic_Player(7)','$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW',200,0,30,0,0,0,0,0,'Basic',150,4,'2023-10-12 12:19:24','2023-10-13 12:19:24')
;

-- name: RemoveSeedData
DELETE FROM players;