#if defined _Objects_included
  #endinput
#endif
#define _Objects_included

#if !defined NAME_FS
	#error "You must define the macro NAME_FS"
#endif
#define endID objectid
static countObjects;
static initId;
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
	return 1;
}

#define OnFilterScriptExit OnFilterScriptExitEx
#if defined OnFilterScriptExitEx
	forward OnFilterScriptExitEx();
#endif
