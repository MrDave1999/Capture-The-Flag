#include <open.mp>
#define FILTER_SCRIPT_NAME "Simpson"
#include "objects"

public OnFilterScriptInit()
{
	new objectId;
	objectId = CreateObject(18981, 638.6561, 1719.2890, 484.5446, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 13295, "ce_terminal", "des_adobewall2", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.6966, 1706.8703, 496.5546, 0.0000, 90.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 11425, "des_clifftown", "des_adobewall1", 0xFFFFFFFF);
	objectId = CreateObject(19604, 639.0688, 1720.6423, 492.2246, 0.0000, 0.0000, 90.0000); //WaterPlane2
	objectId = CreateObject(18981, 613.7261, 1719.2890, 497.8649, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6519, 1741.3360, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.6966, 1735.7403, 496.5546, 0.0000, 90.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 11425, "des_clifftown", "des_adobewall1", 0xFFFFFFFF);
	objectId = CreateObject(19604, 619.0693, 1720.6423, 492.2246, 0.0000, 0.0000, 90.0000); //WaterPlane2
	objectId = CreateObject(19604, 629.0695, 1720.6423, 492.2246, 0.0000, 0.0000, 90.0000); //WaterPlane2
	objectId = CreateObject(18981, 625.6966, 1718.8691, 483.7146, 0.0000, 0.0000, 90.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 13295, "ce_terminal", "des_adobewall2", 0xFFFFFFFF);
	objectId = CreateObject(18981, 613.7361, 1719.2890, 484.5446, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 13295, "ce_terminal", "des_adobewall2", 0xFFFFFFFF);
	objectId = CreateObject(18981, 613.7261, 1744.2885, 497.8649, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 613.7261, 1694.2987, 497.8649, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.7164, 1693.8892, 497.8645, 0.0000, 0.0000, 90.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.7164, 1748.6494, 497.8640, 0.0000, 0.0000, 90.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 638.6760, 1735.9086, 497.8645, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 638.6761, 1710.9288, 497.8649, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(18981, 638.6761, 1685.9289, 497.8640, 0.0000, 0.0000, 0.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(19790, 614.6934, 1707.9929, 494.7000, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1426, "break_scaffold", "cheerybox03", 0xFFFFFFFF);
	objectId = CreateObject(19790, 637.9835, 1708.0731, 494.7000, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1426, "break_scaffold", "cheerybox03", 0xFFFFFFFF);
	objectId = CreateObject(19790, 614.6934, 1734.9831, 494.7000, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1426, "break_scaffold", "cheerybox03", 0xFFFFFFFF);
	objectId = CreateObject(19790, 637.9835, 1734.9831, 494.7000, 0.0000, 0.0000, 0.0000); //Cube5mx5m
	SetObjectMaterial(objectId, 0, 1426, "break_scaffold", "cheerybox03", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2025, 1740.4063, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2025, 1738.3575, 498.5082, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 625.2826, 1740.4067, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.1925, 1740.3863, 499.4881, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2025, 1741.3360, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6524, 1740.4063, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6524, 1740.4063, 499.4983, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 630.6221, 1736.4210, 500.0315, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 627.5520, 1736.4210, 500.0304, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 621.4520, 1736.4210, 500.0304, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 623.1419, 1735.9306, 500.0314, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(1437, 624.5335, 1741.7770, 495.5811, 0.0000, 0.0000, 180.0000); //DYN_LADDER_2
	objectId = CreateObject(18762, 630.1825, 1740.3764, 498.5082, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6524, 1740.4063, 498.5082, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.1925, 1733.3780, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2025, 1728.9671, 498.5082, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2025, 1726.6367, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 628.1928, 1724.6367, 497.5083, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.6966, 1723.7095, 483.7146, 0.0000, 0.0000, 90.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 13295, "ce_terminal", "des_adobewall2", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.1926, 1731.8662, 501.2081, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6526, 1733.3773, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6728, 1728.9671, 499.4682, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 623.5031, 1724.6463, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2028, 1737.4365, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2025, 1738.3565, 499.4980, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2030, 1728.9676, 499.5082, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2028, 1727.5975, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 630.6223, 1728.9199, 500.0310, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 621.4520, 1728.9113, 500.0325, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 625.9226, 1728.9113, 500.0320, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18762, 625.2826, 1724.6469, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 624.6326, 1724.6367, 497.5083, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2026, 1724.6367, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 632.2028, 1732.4670, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6525, 1737.4365, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6524, 1738.3571, 498.5082, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6524, 1738.3571, 499.4981, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6525, 1727.5178, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6925, 1726.6367, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6525, 1732.4670, 497.5083, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 620.6728, 1728.9671, 498.5082, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 629.2827, 1724.6463, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6425, 1724.6367, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(1347, 631.4304, 1731.6833, 500.9993, 0.0000, 0.0000, 0.0000); //CJ_WASTEBIN
	objectId = CreateObject(18762, 622.1225, 1731.8757, 501.2081, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 628.2028, 1728.8769, 501.2090, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 624.1326, 1728.8759, 501.2098, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 625.0923, 1728.8763, 503.2699, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1127, 1728.8763, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2030, 1728.8764, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 627.2022, 1728.8774, 503.2697, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2030, 1731.8657, 504.0697, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2030, 1731.8659, 503.0798, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2030, 1731.8660, 502.2098, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1225, 1731.8757, 502.1981, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1225, 1731.8757, 503.1781, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1225, 1731.8757, 504.1281, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 629.2231, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 628.2333, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 623.1032, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 624.0833, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 626.1423, 1733.8764, 504.0697, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 626.1221, 1731.8807, 504.1414, 90.0000, 90.0000, 90.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(18766, 626.1226, 1730.8208, 504.1424, 90.0000, 90.0000, 90.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFF991E1E);
	objectId = CreateObject(1428, 623.1900, 1734.7751, 502.9566, 0.0000, 0.0000, 180.0000); //DYN_LADDER
	objectId = CreateObject(18762, 625.0633, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.6583, 1736.9361, 496.9349, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 629.2084, 1736.9361, 496.9349, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 625.6384, 1736.9361, 496.9339, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 625.6384, 1731.0163, 496.9349, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.6583, 1731.0067, 496.9354, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 629.2883, 1731.0067, 496.9354, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 629.2084, 1727.1162, 496.9339, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.6285, 1727.1162, 496.9349, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 626.5686, 1727.1077, 496.9335, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19430, 626.4361, 1720.0957, 496.9679, 0.0000, 90.0000, 90.0000); //wall070
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19430, 626.4353, 1722.3875, 496.9690, 0.0000, 90.0000, 90.0000); //wall070
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19789, 624.7652, 1729.0773, 504.5921, 0.0000, 0.0000, 151.4999); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(19789, 625.9905, 1729.1839, 504.5928, 0.0000, 0.0000, 133.7999); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(19789, 625.3105, 1729.1040, 505.5429, 0.0000, 0.0000, -167.5000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(19789, 623.1386, 1734.8714, 500.5129, 0.0000, 0.0000, 0.0000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(19789, 624.0786, 1734.8714, 500.5129, 0.0000, 0.0000, 0.0000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18981, 625.6966, 1718.8691, 491.6947, 0.0000, 90.0000, 90.0000); //Concrete1mx25mx25m
	SetObjectMaterial(objectId, 0, 13295, "ce_terminal", "des_adobewall2", 0xFFFFFFFF);
	objectId = CreateObject(18762, 624.1334, 1728.8764, 500.8898, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 628.0739, 1728.8771, 500.8898, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1235, 1731.7966, 500.8898, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.1935, 1731.7966, 500.8898, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 630.2033, 1733.8666, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 629.2827, 1717.9256, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 628.1928, 1717.9262, 497.5083, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 625.2826, 1717.9256, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.6425, 1717.9256, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2026, 1717.9256, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 623.5026, 1717.9256, 499.8481, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 624.6426, 1717.9262, 497.5083, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6525, 1715.8984, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6525, 1715.9284, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2021, 1715.9284, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2028, 1715.9176, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2028, 1704.6274, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2028, 1709.6076, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2022, 1712.4571, 497.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2022, 1712.4571, 498.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2022, 1712.4571, 499.4969, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2021, 1710.9393, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2021, 1705.9699, 499.8481, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2021, 1704.6303, 499.8476, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2022, 1703.7066, 498.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 632.2022, 1703.7155, 499.4769, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2025, 1701.7055, 498.5082, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2025, 1701.7055, 497.5082, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2025, 1701.7055, 499.4982, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2020, 1701.7060, 499.8370, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.6524, 1701.7054, 497.5183, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.6524, 1701.7054, 498.5082, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.6524, 1701.7054, 499.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.6618, 1701.7060, 499.8370, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 625.2826, 1701.7049, 499.8370, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6523, 1712.4571, 497.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6523, 1712.4571, 498.4970, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6523, 1712.4571, 499.4970, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6527, 1712.4576, 499.8370, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6529, 1709.6076, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6526, 1704.6274, 497.5075, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6524, 1703.7066, 498.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6524, 1703.7066, 499.5069, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6524, 1703.7066, 499.8370, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 620.6524, 1708.5166, 499.8370, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(19464, 629.2084, 1715.4467, 496.9339, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 629.2084, 1709.5169, 496.9339, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 629.2084, 1705.1567, 496.9345, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.5384, 1705.1567, 496.9345, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.5384, 1715.4573, 496.9345, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 623.5384, 1710.7172, 496.9338, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 624.7885, 1705.1470, 496.9330, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 624.7885, 1711.0866, 496.9330, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 624.7885, 1715.4665, 496.9335, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.6519, 1700.7363, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2020, 1700.7363, 497.5083, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2030, 1715.1157, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18766, 630.6223, 1713.6694, 500.0310, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 630.6223, 1706.1898, 500.0317, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 625.6226, 1705.4699, 500.0317, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 625.6224, 1713.6694, 500.0304, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 621.6820, 1705.4699, 500.0310, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 621.6925, 1713.6694, 500.0320, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1127, 1715.1157, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 624.1334, 1715.1157, 500.8898, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 628.0739, 1715.1157, 500.8898, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 624.1326, 1715.1157, 501.2098, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 628.2028, 1715.1157, 501.2090, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 627.2022, 1715.1157, 503.2697, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 625.0923, 1715.1157, 503.2699, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.1235, 1712.1359, 500.8898, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.1235, 1712.1359, 501.8598, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.1235, 1712.1359, 502.8497, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.1235, 1712.1359, 503.8197, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2036, 1712.1359, 503.8197, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2036, 1712.1359, 502.8197, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2036, 1712.1359, 501.8297, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 630.2036, 1712.1359, 500.8597, 0.0000, 90.0000, 90.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(1347, 620.6205, 1712.5432, 500.9993, 0.0000, 0.0000, 0.0000); //CJ_WASTEBIN
	objectId = CreateObject(18762, 630.2033, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 629.2235, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 628.2235, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 622.1234, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 623.1233, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 624.1134, 1709.1473, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(18762, 626.1423, 1709.1463, 504.0697, 0.0000, 90.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(19464, 628.1282, 1731.3970, 500.4255, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 625.1487, 1731.3974, 500.4244, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 625.1487, 1711.6470, 500.4244, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(19464, 627.3182, 1711.6464, 500.4238, 0.0000, 90.0000, 0.0000); //wall104
	SetObjectMaterial(objectId, 0, 14530, "estate2", "man_parquet", 0xFFFFFFFF);
	objectId = CreateObject(18766, 626.1232, 1711.1116, 504.1429, 90.0000, 90.0000, 90.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18766, 626.1226, 1713.2714, 504.1424, 90.0000, 90.0000, 90.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(1437, 628.6336, 1700.1871, 495.5811, 0.0000, 0.0000, 0.0000); //DYN_LADDER_2
	objectId = CreateObject(18766, 631.6427, 1705.4997, 500.0321, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(19789, 629.1984, 1708.3314, 500.5129, 0.0000, 0.0000, 0.0000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(19789, 628.2285, 1708.3314, 500.5129, 0.0000, 0.0000, 0.0000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFF335F3F);
	objectId = CreateObject(1428, 629.3101, 1708.4044, 503.0358, 8.2999, 0.0000, 0.0000); //DYN_LADDER
	objectId = CreateObject(19789, 626.5082, 1714.2307, 505.5429, 0.0000, 0.0000, -167.5000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(19789, 627.0746, 1714.3560, 504.5929, 0.0000, 0.0000, 167.3000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(19789, 625.9557, 1714.2142, 504.5929, 0.0000, 0.0000, 117.4000); //Cube1mx1m
	SetObjectMaterial(objectId, 0, 1736, "cj_ammo", "CJ_SLATEDWOOD2", 0xFFFFFFFF);
	objectId = CreateObject(18766, 631.6629, 1713.6689, 500.0304, 90.0000, 90.0000, 0.0000); //Concrete10mx1mx5m
	SetObjectMaterial(objectId, 0, 3355, "cxref_savhus", "des_brick1", 0xFFFFFFFF);
	objectId = CreateObject(18762, 622.1231, 1733.8671, 502.0698, 0.0000, 0.0000, 0.0000); //Concrete1mx1mx5m
	SetObjectMaterial(objectId, 0, 16136, "des_telescopestuff", "ws_palebrickwall1", 0xFFFFFFFF);
	objectId = CreateObject(19790, 614.41949, 1720.63928, 488.95920,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	objectId = CreateObject(19790, 638.11603, 1721.27319, 488.95920,   0.00000, 0.00000, 0.00000);
	SetObjectMaterial(objectId, 0, 6867, "vgnpwrmainbld", "sw_wallbrick_02", 0xFFFFFFFF);
	return 1;
}