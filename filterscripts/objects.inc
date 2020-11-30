#if defined _Objects_included
  #endinput
#endif
#define _Objects_included

static countObjects;

stock CreateObjectEx(modelid, Float:X, Float:Y, Float:Z, Float:rX, Float:rY, Float:rZ)
{
	++countObjects;
	return CreateObject(modelid, X, Y, Z, rX, rY, rZ);
}

stock CountObjects()
{
	return countObjects;
}

stock DestroyAllObjects()
{
	for(new i = 21, total = 20 + countObjects; i <= total; ++i)
		DestroyObject(i);
	return 1;
}

#define CreateObject CreateObjectEx

