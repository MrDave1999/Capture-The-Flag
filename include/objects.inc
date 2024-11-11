#if defined _Objects_included
  #endinput
#endif
#define _Objects_included

#if !defined FILTER_SCRIPT_NAME
	#error "You must define the macro FILTER_SCRIPT_NAME"
#endif
static CountObjects;
static InitialObjectId;
static EndObjectId;

stock CreateObjectEx(modelid, Float:X, Float:Y, Float:Z, Float:rX, Float:rY, Float:rZ)
{
	EndObjectId = CreateObject(modelid, X, Y, Z, rX, rY, rZ, 300.0);
	++CountObjects;
	if(CountObjects == 1)
		InitialObjectId = EndObjectId;
	return EndObjectId;
}

stock DestroyAllObjects()
{
	for(new i = InitialObjectId, total = i + CountObjects; i < total; ++i)
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
