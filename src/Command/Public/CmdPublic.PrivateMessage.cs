namespace CaptureTheFlag.Command.Public;

public partial class PrivateMessage
{

    public static void SentMessagePrivate(Player sender, string message, Player receiver)
    {
        string msg = $"[PM]: {sender.Name}({sender.Id}) te dice: {message}";
        receiver.SendClientMessage(Color.Yellow, msg);
        sender.GameText("Mensaje enviado!", 3000, 4);
        sender.PlaySound(1058);
        receiver.PlaySound(1058);
        receiver.LastPlayerPM = sender;
    }

    [Command("pm", Shortcut = "pm", UsageMessage = "/pm [playerid] [message]")]
    private static void PM(Player player, int playerid, string message)
    {
        Player receiver = Player.Find(player, playerid);
        if (player.Equals(receiver, "No te puedes enviar un mensaje privado a ti mismo.")) return;
        if(!receiver.IsEnablePrivateMessage)
        {
            player.SendClientMessage(Color.Red, "Error: Ese jugador tiene los mensajes privados inhabilitado.");
            return;
        }
        SentMessagePrivate(player, message, receiver);
    }

    [Command("ypm", Shortcut = "ypm")]
    private static void EnablePrivateMessage(Player player)
    {
        if(player.IsEnablePrivateMessage)
        {
            player.SendClientMessage(Color.Red, "Error: Usted ya tiene los mensajes privados habilitado.");
            return;
        }
        player.IsEnablePrivateMessage = true;
        player.GameText("PM HABILITADO", 3000, 4);
        player.SendClientMessage(Color.Orange, "** Ahora los jugadores podrán enviarte un mensaje privado.");
        player.PlaySound(1139);
    }

    [Command("npm", Shortcut = "npm")]
    private static void DisablePrivateMessage(Player player)
    {
        if (!player.IsEnablePrivateMessage)
        {
            player.SendClientMessage(Color.Red, "Error: Usted ya tiene los mensajes privados inhabilitado.");
            return;
        }
        player.IsEnablePrivateMessage = false;
        player.GameText("PM INHABILITADO", 3000, 4);
        player.SendClientMessage(Color.Orange, "** Ahora los jugadores no podrán enviarte un mensaje privado.");
        player.PlaySound(1139);
    }

    [Command("r", Shortcut = "r", UsageMessage = "/r [message]")]
    private static void AnswerPrivateMessage(Player player, string message)
    {
        Player receiver = player.LastPlayerPM;
        if(receiver == null)
        {
            player.SendClientMessage(Color.Red, "Error: Nadie te ha enviado un mensaje privado.");
            return;
        }
        if(!receiver.IsConnected)
        {
            player.SendClientMessage(Color.Red, "Error: El jugador no se encuentra conectado.");
            player.LastPlayerPM = null;
            return;
        }
        if(!receiver.IsEnablePrivateMessage)
        {
            player.SendClientMessage(Color.Red, "Error: Ese jugador tiene los mensajes privados inhabilitado.");
            return;
        }
        SentMessagePrivate(player, message, receiver);
    }
}
