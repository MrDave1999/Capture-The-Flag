#include <a_samp>
#include "objects"

public OnFilterScriptInit()
{
	CreateObject(19535, 268.05020, 1884.39893, 6.97360,   0.00000, 0.00000, 0.00000);
	CreateObject(975, 214.37840, 1875.68408, 13.81230,   0.02000, 0.00000, 0.00000);
	print("Area51 map was load successfully!");
	printf("Total Objects: %d", CountObjects());
	return 0;
}

public OnFilterScriptExit()
{
    DestroyAllObjects();
    print("Area51 map was unload successfully!");
	return 0;
}
