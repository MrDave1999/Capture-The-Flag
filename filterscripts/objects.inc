#if defined _Objects_included
  #endinput
#endif
#define _Objects_included

static countObjects;

stock CreateObjectEx(modelid, Float:X, Float:Y, Float:Z, Float:rX, Float:rY, Float:rZ)
{
	CreateObject(modelid, X, Y, Z, rX, rY, rZ);
	++countObjects;
	return 1;
}

stock CountObjects()
{
	return countObjects;
}

stock DestroyAllObjects()
{
	for(new i = 1; i <= countObjects; ++i)
		DestroyObject(i);
	return 1;
}

#define CreateObject CreateObjectEx