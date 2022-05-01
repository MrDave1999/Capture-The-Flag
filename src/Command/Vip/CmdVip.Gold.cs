namespace CaptureTheFlag.Command.Vip;

public partial class CmdVip
{
    static readonly int TIME = 4;

    private static void IsWaitTime(Player player, int time)
    {
        if (time > Time.GetTime())
        {
            player.SendClientMessage(Color.Red, $"Error: Debes esperar {TIME} minutos para poder volver a usar este comando (Tiempo faltante: {Time.Show(time)}).");
            throw new Exception();
        }
    }

    [Command("health", Shortcut = "health")]
    private static void Health(Player player)
    {
        if (player.IsVipLevel(2)) return;
        IsWaitTime(player, player.HealthTime);
        player.Health = 100f;
        player.HealthTime = Time.GetTime() + (TIME * 60);
        player.SendClientMessage(Color.Yellow, "* Te has regenerado la salud al 100 %");
    }

    [Command("armour", Shortcut = "armour")]
    private static void Armour(Player player)
    {
        if (player.IsVipLevel(2)) return;
        IsWaitTime(player, player.ArmourTime);
        player.Armour = 100f;
        player.ArmourTime = Time.GetTime() + (TIME * 60);
        player.SendClientMessage(Color.Yellow, "* Obtuviste un chaleco AntiBalas.");
    }

    [Command("jumpon", Shortcut = "jumpon")]
    private static void JumpOn(Player player)
    {
        if (player.IsVipLevel(2)) return;
        if (player.JumpOn)
        {
            player.SendClientMessage(Color.Red, "Error: Ya tienes activado los saltos.");
            return;
        }
        player.JumpOn = true;
        player.SendClientMessage(Color.Yellow, "* Has activado los saltos mortales.");
    }

    [Command("jumpoff", Shortcut = "jumpoff")]
    private static void JumpOff(Player player)
    {
        if (player.IsVipLevel(2)) return;
        if(!player.JumpOn)
        {
            player.SendClientMessage(Color.Red, "Error: Ya tienes desactivado los saltos.");
            return;
        }
        player.JumpOn = false;
        player.SendClientMessage(Color.Yellow, "* Has desactivado los saltos mortales.");
    }

    [Command("p", Shortcut = "p")]
    private static void Parachute(Player player)
    {
        if (player.IsVipLevel(2)) return;
        player.GiveWeapon(Weapon.Parachute, 1);
    }

    [Command("nsay", Shortcut = "nsay", UsageMessage = "/nsay [message]")]
    public static void Nsay(Player player, string message)
    {
        if (player.IsVipLevel(2)) return;
        BasePlayer.SendClientMessageToAll($"{Color.Orange}.:: Usuario Anónimo: {Color.White}| {message}");
    }
}
