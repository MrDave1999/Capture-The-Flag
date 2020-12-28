#if defined _Objects_included
  #endinput
#endif
#define _Objects_included

#if !defined NAME_FS
	#error "You must define the macro NAME_FS"
#endif
#define endID objectid
static countObjects;
static initId; /* Initial ID is stored */
static objectid;

stock CreateObjectEx(modelid, Float:X, Float:Y, Float:Z, Float:rX, Float:rY, Float:rZ)
{
	objectid = CreateObject(modelid, X, Y, Z, rX, rY, rZ, 300.0);
	++countObjects;
	if(countObjects == 1)
		initId = objectid;
	return objectid;
}

stock DestroyAllObjects()
{
	for(new i = initId, total = i + countObjects; i < total; ++i)
		DestroyObject(i);
	return 1;
}

#define CreateObject CreateObjectEx

public OnFilterScriptInit()
{
	OnFilterScriptInitEx();
	printf("  %s map was load successfully!", NAME_FS);
	printf("  Total [CreateObjects]: %d / Initial ID: %d / End ID: %d", countObjects, initId, endID);
	return 1;
}

#define OnFilterScriptInit OnFilterScriptInitEx
forward OnFilterScriptInitEx();

public OnFilterScriptExit()
{
	#if defined OnFilterScriptExitEx
		OnFilterScriptExitEx();
	#endif
    DestroyAllObjects();
    printf("  %s map was unload successfully!", NAME_FS);
	return 1;
}

#define OnFilterScriptExit OnFilterScriptExitEx
#if defined OnFilterScriptExitEx
	forward OnFilterScriptExitEx();
#endif