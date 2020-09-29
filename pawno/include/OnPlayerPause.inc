#define IsPlayerPaused(%0) ((PlayerPaused[%0] == true) ? (1) : (0))
#define TIME_PAUSE_PLAYER (60 * 5 * 1000)// 5 minutos
#define TIME_PAUSE_PRESIDENT (60 * 2 * 1000) //2 minutos

new TimeOfLastUpdate[MAX_PLAYERS];
new bool:PlayerPaused[MAX_PLAYERS];

task BuscarPausados[500]()
{
    static PlayerState;
    foreach(new i : Player)
    {
        if(IsPlayerPaused(i) == 0)
        {
            if(IsPlayerInClassSelection(i) == 0)
            {
            	if((gettime()-TimeOfLastUpdate[i]) >= 2)
             	{
              		PlayerState = GetPlayerState(i);
                	if((PlayerState == PLAYER_STATE_ONFOOT) || (PlayerState == PLAYER_STATE_DRIVER) || (PlayerState == PLAYER_STATE_PASSENGER))
                 	{
                  		OnPlayerPause(i);
                  	}
                }
            }
        }
    }
}

forward OnPlayerPause(playerid);
forward OnPlayerUnpause(playerid);
forward OnPlPa_OnPlayerConnect(playerid);
forward OnPlPa_OnPlayerDisconnect(playerid, reason);

public OnPlayerConnect(playerid)
{
    PlayerPaused[playerid] = false;
	OnPlPa_OnPlayerConnect(playerid);
	return 1;
}
#if defined _ALS_OnPlayerConnect
    #undef OnPlayerConnect
#else
    #define _ALS_OnPlayerConnect
#endif
#define OnPlayerConnect OnPlPa_OnPlayerConnect

public OnPlayerDisconnect(playerid, reason)
{
    OnPlPa_OnPlayerDisconnect(playerid, reason);
   	if(IsPlayerPaused(playerid) != 0)
	    stop Data[playerid][ID_TimePause];
     PlayerPaused[playerid] = false;
	return 1;
}
#if defined _ALS_OnPlayerDisconnect
    #undef OnPlayerDisconnect
#else
    #define _ALS_OnPlayerDisconnect
#endif
#define OnPlayerDisconnect OnPlPa_OnPlayerDisconnect

public OnPlayerUpdate(playerid)
{
    TimeOfLastUpdate[playerid] = gettime();
    if(IsPlayerPaused(playerid) == 1)
    {
        OnPlayerUnpause(playerid);
    }
    return 1;
}

public OnPlayerPause(playerid)
{
    print("DEBUG: OnPlayerPause");
	PlayerPaused[playerid] = true;
	Data[playerid][ID_TimePause] = (((IsPlayerInClassSelection(playerid) == 0) && (Data[playerid][Teams] == PRESIDENT)) ? (defer TimePause_President(playerid)) : (defer TimePause_Player(playerid)));
    return 1;
}


public OnPlayerUnpause(playerid)
{
	print("DEBUG: OnPlayerUnpause");
	if(IsPlayerPaused(playerid) == 1)
	{
		stop Data[playerid][ID_TimePause];
		PlayerPaused[playerid] = false;
	}
    return 1;
}

timer TimePause_Player[TIME_PAUSE_PLAYER](playerid)/* Este procedimiento tipo temporizador se ejecutará en 5 minutos si un jugador no llega salir de la pausa antes de ese tiempo */
{
	new message_kick[MAX_PLAYER_NAME + 81];
	format(message_kick, sizeof(message_kick), "%s (ID: %d) fue etiquetado fuera del servidor por estar inactivo durante 5 minutos.", Name(playerid), playerid);
	SendClientMessageToAll(0xFF8000FF, message_kick);
	defer SendMessage(playerid, "_");
}

timer TimePause_President[TIME_PAUSE_PRESIDENT](playerid)/* Este procedimiento tipo temporizador se ejecutará en 2 minutos si el presidente no llega salir de la pausa antes de ese tiempo */
{
	new message_kick[MAX_PLAYER_NAME + 92];
	format(message_kick, sizeof(message_kick), "%s (ID: %d) fue etiquetado fuera del servidor por estar inactivo durante 2 minutos como líder.", Name(playerid), playerid);
	SendClientMessageToAll(0xFF8000FF, message_kick);
	defer SendMessage(playerid, "_");
}
