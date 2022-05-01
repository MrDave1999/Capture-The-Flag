namespace CaptureTheFlag.PropertiesPlayer;

public partial class Player
{
    public static void ModifyText(string text, char c)
    {
        unsafe
        {
            fixed (char* str = text)
                str[0] = c;
        }
    }

    public void SendMessageToChat(string text)
    {
        char symbol = text[0];
        ModifyText(text, ' ');
        switch (symbol)
        {
            case '!': //TeamChat
                if (Team != NoTeam)
                {
                    TeamChat(this, text);
                    return;
                }
                break;
            case '$': //VipChat
                if (Data.LevelVip > 0)
                {
                    VipChat(this, text);
                    return;
                }
                break;
            case '#': //AdminChat
                if (Data.LevelAdmin > 0)
                {
                    AdminChat(this, text);
                    return;
                }
                break;
            case '&': //Asay
                if(Data.LevelAdmin > 0)
                {
                    Asay(this, text);
                    return;
                }
                break;
            case '@': //Vsay
                if(Data.LevelVip > 0)
                {
                    Vsay(this, text);
                    return;
                }
                break;
            case '~': //Nsay
                if(Data.LevelVip >= 2)
                {
                    Nsay(this, text);
                    return;
                }
                break;
        }
        ModifyText(text, symbol);
        if (Data.LevelAdmin >= 1)
            SendClientMessageToAll($"{Color}{Name} {{00FF00}}[{Id}]: {Color.White}{text}");
        else if (Data.LevelVip >= 1)
            SendClientMessageToAll($"{Color}{Name} {Color.Yellow}[{Id}]: {Color.White}{text}");
        else
            SendClientMessageToAll($"{Color}{Name} {Color.White}[{Id}]: {text}");
    }
}
