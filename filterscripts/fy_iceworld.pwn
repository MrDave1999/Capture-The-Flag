#include <open.mp>
#define FILTER_SCRIPT_NAME "fy_iceworld"
#include "objects"

public OnFilterScriptInit()
{
    new objectId;
	objectId = CreateObject(19890, -357.34769, 3175.88647, 23.20890,   180.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -399.32730, 3175.88647, 23.20890,   180.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -366.1741, 3175.8877, 45.1969,   0.00000, 90.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -390.33401, 3193.37280, 45.19690,   0.00000, 90.00000, 90.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -390.31561, 3148.49097, 45.19690,   0.00000, 90.00000, -90.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -419.31760, 3175.89355, 45.19690,   0.00000, 90.00000, 180.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -399.31741, 3175.83081, 43.20890,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(19890, -357.34769, 3175.88647, 43.20890,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 3902, "libertyhi3", "mp_snow", 0);

	objectId = CreateObject(3655, -382.70831, 3179.92749, 27.1242,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 9, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(3655, -382.77359, 3161.57373, 27.1242,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 9, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(3655, -403.13681, 3179.92749, 27.1242,   0.00000, 0.00000, 180.00000);
	SetObjectMaterial(objectId, 9, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(3655, -403.13681, 3161.57373, 27.1242,   0.00000, 0.00000, 180.00000);
	SetObjectMaterial(objectId, 9, 3902, "libertyhi3", "mp_snow", 0);

	objectId = CreateObject(3749, -364.19031, 3170.70923, 29.18910,   0.00000, 90.00000, 180.00000);
	SetObjectMaterial(objectId, 1, 3902, "libertyhi3", "mp_snow", 0);
	objectId = CreateObject(3749, -421.15390, 3170.70923, 29.18910,   0.00000, 90.00000, 0.00000);
	SetObjectMaterial(objectId, 1, 3902, "libertyhi3", "mp_snow", 0);

	objectId = CreateObject(19937, -410.02679, 3186.87891, 24.20660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -392.69312, 3150.45020, 25.23660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.82050, 3186.88892, 26.26060,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -392.69312, 3150.45020, 24.20960,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.88351, 3154.62256, 25.23660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.88351, 3154.62256, 26.26060,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -410.02679, 3154.61060, 24.20660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -410.02679, 3154.61060, 25.23360,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -410.02679, 3154.61060, 26.25760,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.88351, 3154.62256, 24.20960,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -410.02679, 3186.88892, 25.23360,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -410.02679, 3186.87891, 26.25760,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.82050, 3186.88892, 24.20960,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -375.82050, 3186.88892, 25.23660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -392.69312, 3191.41235, 24.20960,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);
	objectId = CreateObject(19937, -392.69312, 3191.41235, 25.23660,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 19890, "wssections", "wood1", 0);

	CreateObject(3524, -410.13440, 3168.01416, 26.19920,   0.00000, 0.00000, -90.00000);
	CreateObject(3524, -410.13440, 3173.37744, 26.19920,   0.00000, 0.00000, -90.00000);
	CreateObject(3524, -376.03931, 3168.01416, 26.19920,   0.00000, 0.00000, 90.00000);
	CreateObject(3524, -376.03931, 3173.37744, 26.19920,   0.00000, 0.00000, 90.00000);
	CreateObject(3524, -390.23929, 3155.72559, 26.19920,   0.00000, 0.00000, 0.00000);
	CreateObject(3524, -390.23929, 3185.76587, 26.19920,   0.00000, 0.00000, 180.00000);
	CreateObject(3524, -395.58060, 3155.72559, 26.19920,   0.00000, 0.00000, 0.00000);
	CreateObject(3524, -395.58060, 3185.76587, 26.19920,   0.00000, 0.00000, 180.00000);
	CreateObject(19890, -399.32730, 3175.88647, 0.20890,   180.00000, 0.00000, 0.00000);
	CreateObject(1344, -390.25565, 3161.33936, 25.00030,   0.00000, 0.00000, -90.00000);
	CreateObject(851, -395.32153, 3180.80225, 24.46100,   0.00000, 0.00000, 0.00000);
	CreateObject(910, -382.96631, 3168.17432, 25.47860,   0.00000, 0.00000, 180.00000);
	CreateObject(13187, -386.68759, 3192.41479, 25.50670,   0.00000, 0.00000, 90.00000);
	return 1;
}