//Rcon fix
//Returns 0 in OnRconCommand to allow gamemodes to process the commands
#include <open.mp>
public OnRconCommand(cmd[])
{
	return 0;
}
