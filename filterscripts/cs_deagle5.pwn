#include <a_samp>
#define FILTER_SCRIPT_NAME "cs_deagle5"
#include "objects"

public OnFilterScriptInit()
{
	new objectId;
	objectId = CreateObject(19538, 70.6275, 2477.4343, 18.3309, -89.9000, 0.0000, 89.9999); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 4552, "ammu_lan2", "sl_lavicdtwall1", 0xFFFFFFFF);
	objectId = CreateObject(2395, 1647.1451, -1668.1219, 21.2219, 0.0000, 0.0000, 0.0000); //CJ_SPORTS_WALL
	SetObjectMaterial(objectId, 0, 17545, "burnsground", "newall1-1128", 0xFFFFFFFF);
	objectId = CreateObject(19538, 8.2573, 2474.3498, 18.3288, -89.9000, 0.0000, 0.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 4552, "ammu_lan2", "sl_lavicdtwall1", 0xFFFFFFFF);
	objectId = CreateObject(19538, -50.9649, 2527.5170, 18.3264, -89.9000, 0.0000, -90.9999); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 4552, "ammu_lan2", "sl_lavicdtwall1", 0xFFFFFFFF);
	objectId = CreateObject(19538, 11.4673, 2536.8486, 18.3376, -89.9000, 0.0000, 180.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 4552, "ammu_lan2", "sl_lavicdtwall1", 0xFFFFFFFF);
	objectId = CreateObject(19538, 8.2573, 2505.5979, 15.6857, 0.0000, 0.0000, 0.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 14789, "ab_sfgymmain", "gym_floor6", 0xFFFFFFFF);
	objectId = CreateObject(19538, 8.2573, 2568.0297, 49.3958, 0.0000, 0.0000, 0.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 14387, "dr_gsnew", "mp_gs_kitchfloor", 0xFFFFFFFF);
	objectId = CreateObject(19538, 8.2573, 2509.8715, 49.3558, -179.9998, 0.0000, 0.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 14387, "dr_gsnew", "mp_gs_kitchfloor", 0xFFFFFFFF);
	objectId = CreateObject(19466, -1.5176, 2536.8679, 36.3022, 0.0000, 0.0000, 89.8000); //window001
	SetObjectMaterialText(objectId, "R", 0, 10, "Comic Sans MS", 24, 1, 0xFF840410, 0x0, 0);
	objectId = CreateObject(19538, 8.2573, 2447.4633, 49.3558, -179.9998, 0.0000, 0.0000); //Plane62_5x125Conc1
	SetObjectMaterial(objectId, 0, 14387, "dr_gsnew", "mp_gs_kitchfloor", 0xFFFFFFFF);
	objectId = CreateObject(19466, -0.7376, 2536.8771, 36.3022, 0.0000, 0.0000, 90.0000); //window001
	SetObjectMaterialText(objectId, "S", 0, 10, "Comic Sans MS", 24, 1, 0xFFD78E10, 0x0, 0);
	objectId = CreateObject(19466, 22.8115, 2536.8435, 18.2987, 0.0000, 0.0000, 89.9999); //window001
	SetObjectMaterialText(objectId, "pentru RSS!", 0, 90, "Comic Sans MS", 23, 1, 0xFFD78E10, 0x0, 2);
	objectId = CreateObject(19466, -0.0776, 2536.8771, 36.3022, 0.0000, 0.0000, 90.0000); //window001
	SetObjectMaterialText(objectId, "S", 0, 10, "Comic Sans MS", 24, 1, 0xFF263739, 0x0, 0);
	objectId = CreateObject(19466, 21.8717, 2536.8435, 18.2987, 0.0000, 0.0000, 89.9999); //window001
	SetObjectMaterialText(objectId, "Creata de SENiOR din inima", 0, 90, "Comic Sans MS", 23, 1, 0xFFD78E10, 0x0, 2);
	objectId = CreateObject(19790, 48.6304, 2504.1799, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 33.6304, 2504.1799, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 16.0403, 2504.1799, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 16.0403, 2494.1682, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 6.0503, 2486.6267, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 7.9703, 2501.6083, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 7.9703, 2511.5886, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -2.0594, 2524.0712, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -7.0995, 2536.1416, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -12.0993, 2526.1687, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -22.3994, 2518.5888, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -32.4095, 2508.6086, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -22.4095, 2500.6279, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -13.5693, 2500.6279, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -5.4394, 2495.6386, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -15.4495, 2476.8591, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -24.6294, 2485.4785, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -24.6294, 2493.2478, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -36.2597, 2481.7463, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -41.2498, 2491.7336, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(10009, 65.4979, 2499.9934, 19.7973, 0.0000, 0.0000, 179.0000); //fer_cars3_sfe
	objectId = CreateObject(19790, -48.8198, 2505.1760, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -48.5396, 2520.1679, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -38.5396, 2530.1594, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -30.8097, 2534.3496, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 21.0403, 2514.4404, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 31.0303, 2524.4204, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 44.2904, 2524.4204, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 44.2904, 2534.3503, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 17.0904, 2534.3295, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 7.1304, 2524.3298, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 34.2904, 2514.4389, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 57.9603, 2509.4492, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 68.1502, 2523.1201, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 68.1502, 2491.4589, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 56.2803, 2486.4965, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 54.0204, 2478.9172, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 44.0601, 2478.9172, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 39.0703, 2493.2055, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 26.7402, 2493.2055, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, 26.7402, 2482.7353, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -2.0694, 2481.8857, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19790, -8.9393, 2509.2709, 15.6784, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1706, "kbcouch1", "kbwood_panel4_128", 0xFFFFFFFF);
	objectId = CreateObject(19449, 58.2187, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 48.5787, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 38.9486, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 29.3187, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 19.7087, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 10.0887, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, 0.4787, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, -9.1512, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, -18.7611, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(19449, -28.3911, 2499.5637, 22.9176, 0.0000, -89.9000, -89.9999); //wall089
	SetObjectMaterial(objectId, 0, 10806, "airfence_sfse", "ws_griddyfence", 0xFFFFFFFF);
	objectId = CreateObject(10009, -38.3420, 2500.0319, 19.8050, 0.0000, 0.0000, 0.0000); //fer_cars3_sfe
	return 1;
}