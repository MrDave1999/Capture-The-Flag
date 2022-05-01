namespace CaptureTheFlag.Command.Vip;

public partial class CmdVip
{
    [Command("skin", Shortcut = "skin", UsageMessage = "/skin [skinid]")]
    private static void Skin(Player player, int skinid)
    {
        if (player.IsVipLevel(1)) return;
        if (skinid < 0 || skinid > 299)
        {
            player.SendClientMessage(Color.Red, "Error: Ingrese un id válido (0/299).");
            return;
        }
        player.Skin = skinid;
        player.GameText($"Skin ID {skinid}", 3000, 4);
    }

    [Command("sskin", Shortcut = "sskin")]
    private static void SaveSkin(Player player)
    {
        if (player.IsVipLevel(1)) return;
        if (player.Skin == player.Data.SkinId)
        {
            player.SendClientMessage(Color.Red, $"Error: El skin (id:{player.Skin}) ya se encuentra guardado en la base de datos.");
            return;
        }
        player.UpdateSkin(player.Skin);
        player.GameText("Skin saved", 3000, 4);
        player.SendClientMessage(Color.Yellow, $"** El skin (id:{player.Skin}) se guardó en la base de datos de forma exitosa.");
        player.SendClientMessage(Color.Orange, "* Por cada re-spawn, aparecerás con el skin que hayas guardado.");
        player.Data.SkinId = player.Skin;

    }

    [Command("rskin", Shortcut = "rskin")]
    private static void RemoveSkin(Player player)
    {
        if (player.IsVipLevel(1)) return;
        if (player.Data.SkinId == -1)
        {
            player.SendClientMessage(Color.Red, "Error: No has guardado ningún skin (use /sskin).");
            return;
        }
        player.UpdateSkin(-1);
        player.GameText("Skin removed", 3000, 4);
        player.SendClientMessage(Color.Yellow, $"** El skin (id:{player.Skin}) fue removido, ya no aparecerás con este skin.");
        player.Data.SkinId = -1;
        player.Skin = player.PlayerTeam.Skin;
    }

    [Command("saw", Shortcut = "saw")]
    private static void Saw(Player player)
    {
        if (player.IsVipLevel(1)) return;
        player.GiveWeapon(Weapon.Chainsaw, 1);
    }

    [Command("spray", Shortcut = "spray")]
    private static void Spray(Player player)
    {
        if (player.IsVipLevel(1)) return;
        player.GiveWeapon(Weapon.Spraycan);
    }

    [Command("weather", Shortcut = "weather")]
    private static void Weather(Player player)
    {
        if (player.IsVipLevel(1)) return;
        var dweather = new ListDialog("Climas", "Aceptar", "Cerrar");
        dweather.AddItems(new[] {
            "Restaurar día y sol",
            "Noche",
            "Madrugada",
            "Mañana",
            "Día",
            "Tarde",
            "Lluvia",
            "Soleado",
            "Niebla",
            "Tormenta de Arena",
            "Cielo Gris",
            "Cielo Rojo",
            "Cielo Purpura"
        });
        dweather.Show(player);
        dweather.Response += (sender, e) =>
        {
            if(e.DialogButton == DialogButton.Left)
            {
                switch(e.ListItem)
                {
                    case 0:
                        player.SetWeather(1);
                        player.SetTime(12, 0);
                        player.SendClientMessage(Color.Yellow, "* Día Restaurado.");
                        break;
                    case 1:
                        player.SetTime(3, 0);
                        player.SendClientMessage(Color.Yellow, "* Clima cambiado a la noche.");
                        break;
                    case 2:
                        player.SetTime(22, 0);
                        player.SendClientMessage(Color.Yellow, "* Clima cambiado a la madrugada.");
                        break;
                    case 3:
                        player.SetTime(8, 0);
                        player.SendClientMessage(Color.Yellow, "* Clima cambiado a la mañana.");
                        break;
                    case 4:
                        player.SetTime(12, 0);
                        player.SendClientMessage(Color.Yellow, "* Clima cambiado al día.");
                        break;
                    case 5:
                        player.SetTime(16, 0);
                        player.SendClientMessage(Color.Yellow, "* Clima cambiado a la tarde.");
                        break;
                    case 6:
                        player.SetWeather(8);
                        player.SendClientMessage(Color.Yellow, "* Has hecho llover.");
                        break;
                    case 7:
                        player.SetWeather(1);
                        player.SendClientMessage(Color.Yellow, "* Has hecho salir el sol.");
                        break;
                    case 8:
                        player.SetWeather(9);
                        player.SendClientMessage(Color.Yellow, "* Nieve activada.");
                        break;
                    case 9:
                        player.SetWeather(19);
                        player.SendClientMessage(Color.Yellow, "* Tormenta de arena seleccionada.");
                        break;
                    case 10:
                        player.SetWeather(21);
                        player.SendClientMessage(Color.Yellow, "* Cielo gris seleccionado.");
                        break;
                    case 11:
                        player.SetWeather(382);
                        player.SendClientMessage(Color.Yellow, "* Cielo rojo seleccionado.");
                        break;
                    case 12:
                        player.SetWeather(953);
                        player.SendClientMessage(Color.Yellow, "* Cielo color purpura seleccionado.");
                        break;
                }
            }
        };
    }

    [Command("vc", Shortcut = "vc", UsageMessage = "/vc [message]")]
    public static void VipChat(Player player, string msg)
    {
        if (player.IsVipLevel(1)) return;
            foreach (Player player1 in Player.Vips)
                player1.SendClientMessage($"{{8b0000}}[Vip Chat] {player.Name} [{player.Id}]: {msg}");
    }

    [Command("vsay", Shortcut = "vsay", UsageMessage = "/vsay [message]")]
    public static void Vsay(Player player, string msg)
    {
        if (player.IsVipLevel(1)) return;
        BasePlayer.SendClientMessageToAll($"{Colors.GetColorVip(player.Data.LevelVip)}>>| {Rank.GetRankVip(player.Data.LevelVip)} |<< {player.Name}: {Color.White}{msg}");
    }
}
