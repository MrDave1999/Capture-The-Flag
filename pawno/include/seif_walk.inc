// Walk Styles
  // Spell - Seif


// --> Includes
#include <a_samp>

// --> Walk Styles
#define WALK_DEFAULT    0
#define WALK_NORMAL     1
#define WALK_PED        2
#define WALK_GANGSTA    3
#define WALK_GANGSTA2   4
#define WALK_OLD        5
#define WALK_FAT_OLD    6
#define WALK_FAT        7
#define WALK_LADY      	8
#define WALK_LADY2      9
#define WALK_WHORE      10
#define WALK_WHORE2     11
#define WALK_DRUNK     	12
#define WALK_BLIND     	13

// --> Variables
new
	walktime[MAX_PLAYERS],
	WalkStyle[MAX_PLAYERS];
	
static
	bool:walk_HasOPC,
	bool:walk_HasOPKSC;

// --> Forward
forward WALK_OnPlayerKeyStateChange(playerid, newkeys, oldkeys);
forward WALK_OnPlayerConnect(playerid);
forward WALK_OnGameModeInit();
forward WalkAnim(playerid);

//native SetPlayerWalkingStyle(playerid, style)
//native GetPlayerWalkingStyle(playerid)

public OnGameModeInit()
{
	walk_HasOPC = funcidx("WALK_OnPlayerConnect") != -1;
	walk_HasOPKSC = funcidx("WALK_OnPlayerKeyStateChange") != -1;

	return (funcidx("WALK_OnGameModeInit")) ? CallLocalFunction("WALK_OnGameModeInit", "") : 1;
}

#if defined _ALS_OnGameModeInit
	#undef OnGameModeInit
#else
	#define _ALS_OnGameModeInit
#endif

#define OnGameModeInit WALK_OnGameModeInit

public OnPlayerConnect(playerid)
{
    WalkStyle[playerid] = 0;
    return (walk_HasOPC) ? CallLocalFunction("WALK_OnPlayerConnect", "i", playerid) : 1;
}

#if defined _ALS_OnPlayerConnect
	#undef OnPlayerConnect
#else
	#define _ALS_OnPlayerConnect
#endif

#define OnPlayerConnect WALK_OnPlayerConnect

public OnPlayerKeyStateChange(playerid, newkeys, oldkeys)
{
	if(IsPlayerNPC(playerid)) return 1;
	new
	    Anim = GetPlayerAnimationIndex(playerid);
	    
	if(Anim == 1231 || Anim == 1189)
	{
	    if (((newkeys & KEY_WALK && newkeys & KEY_UP) || (newkeys & KEY_WALK && newkeys & KEY_DOWN) || (newkeys & KEY_WALK && newkeys & KEY_LEFT) || (newkeys & KEY_WALK && newkeys & KEY_RIGHT))
			|| ((oldkeys & KEY_WALK && newkeys & KEY_UP) || (oldkeys & KEY_WALK && newkeys & KEY_DOWN) || (oldkeys & KEY_WALK && newkeys & KEY_LEFT) || (oldkeys & KEY_WALK && newkeys & KEY_RIGHT))
			|| ((newkeys & KEY_WALK && oldkeys & KEY_UP) || (newkeys & KEY_WALK && oldkeys & KEY_DOWN) || (newkeys & KEY_WALK && oldkeys & KEY_LEFT) || (newkeys & KEY_WALK && oldkeys & KEY_RIGHT))
			&& GetPlayerState(playerid) == PLAYER_STATE_ONFOOT)
		{
			walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
		}
   	}

    return (walk_HasOPKSC) ? CallLocalFunction("WALK_OnPlayerKeyStateChange", "iii", playerid, newkeys, oldkeys) : 1;
}

#if defined _ALS_OnPlayerKeyStateChange
	#undef OnPlayerKeyStateChange
#else
	#define _ALS_OnPlayerKeyStateChange
#endif

#define OnPlayerKeyStateChange WALK_OnPlayerKeyStateChange

public WalkAnim(playerid)
{
	new keys, updown, leftright;
	GetPlayerKeys(playerid,keys,updown,leftright);
	switch(GetPlayerWalkingStyle(playerid))
	{
	    case WALK_NORMAL:
	    {
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_player",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_player",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_PED:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_civi",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_civi",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
	 	case WALK_GANGSTA:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_gang1",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_gang1",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_GANGSTA2:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_gang2",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_gang2",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_OLD:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_old",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_old",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_FAT_OLD:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_fatold",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_fatold",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_FAT:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_fat",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_fat",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_LADY:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WOMAN_walknorm",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WOMAN_walknorm",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_LADY2:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WOMAN_walkbusy",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WOMAN_walkbusy",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_WHORE:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WOMAN_walkpro",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WOMAN_walkpro",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_WHORE2:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WOMAN_walksexy",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WOMAN_walksexy",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_DRUNK:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","WALK_drunk",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","WALK_drunk",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
		case WALK_BLIND:
		{
	 	 	if ((keys & KEY_WALK && updown & KEY_UP) || (keys & KEY_WALK && updown & KEY_DOWN) || (keys & KEY_WALK && leftright & KEY_LEFT) || (keys & KEY_WALK && leftright & KEY_RIGHT))
			{
			   	KillTimer(walktime[playerid]);
				ApplyAnimation(playerid,"PED","Walk_Wuzi",4.1,1,1,1,1,1);
				walktime[playerid] = SetTimerEx("WalkAnim",200,0,"d",playerid);
			}
			else ApplyAnimation(playerid,"PED","Walk_Wuzi",4.0,0,0,0,0,1), KillTimer(walktime[playerid]);
		}
	}
	return 1;
}

stock SetPlayerWalkingStyle(playerid, style)
{
	WalkStyle[playerid] = style;
}

stock GetPlayerWalkingStyle(playerid)
{
	return WalkStyle[playerid];
}
