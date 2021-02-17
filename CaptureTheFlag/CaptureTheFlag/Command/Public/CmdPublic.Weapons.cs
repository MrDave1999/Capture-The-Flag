using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        static readonly int TIME = 1;

        [Command("weapons", Shortcut = "weapons")]
        public static void Weapons(Player player)
        {
            var weapons = new ListDialog("Weapons", "Seleccionar", "Cerrar");
            foreach (Gun gun in Gun.GetInstanceArray())
                weapons.AddItem(gun.Weapon.ToString());
            weapons.Show(player);
            weapons.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    int gunIndex;
                    /* Gets the weapon that the player selected in the dialog. */
                    var itemWeapon = Gun.GetWeapon(e.ListItem);
                    /* Check if the weapon the player selected is not in their current weapon pack. */
                    if (player.ListGuns.Find(gun => gun == itemWeapon) != null)
                    {
                        player.SendClientMessage(Color.Red, $"Error: {itemWeapon.Weapon} ya se encuentra en el paquete de armas.");
                        weapons.Show(player);
                        return;
                    }
                    /* Check if there is no weapon with the same category in the player's weapon pack. */
                    if ((gunIndex = player.ListGuns.FindIndex(gun => gun.Slot == itemWeapon.Slot)) != -1)
                        player.ListGuns[gunIndex] = itemWeapon;
                    else
                        player.ListGuns.Add(itemWeapon);
                    player.GiveWeapon(itemWeapon.Weapon);
                    player.SendClientMessage(Color.Red, $"[Weapon]: {Color.Yellow}{itemWeapon.Weapon} se agregó en tu paquete de armas.");
                    weapons.Show(player);
                }
            };
        }

        [Command("packet", Shortcut = "packet")]
        public static void PacketWeapons(Player player)
        {
            if (player.ListGuns.Count == 0)
            {
                player.SendClientMessage(Color.Red, "Error: No tienes ningún elemento en tu paquete de armas.");
                return;
            }
            var packet = new TablistDialog("Packet Weapons", 1, "Eliminar", "Cerrar");
            foreach (Gun gun in player.ListGuns)
                packet.Add(gun.Weapon.ToString());
            packet.Show(player);
            packet.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    player.SendClientMessage(Color.Red, $"[Weapon]: {Color.Yellow}{player.ListGuns[e.ListItem].Weapon} se eliminó de tu paquete de armas.");
                    player.RemoveWeapon(e.ListItem);
                    packet.Clear();
                    foreach (Gun gun in player.ListGuns)
                        packet.Add(gun.Weapon.ToString());
                    packet.Show(player);
                }
            };
        }

        [Command("combos", Shortcut = "combos")]
        public static void Combos(Player player)
        {
            var combos = new TablistDialog("Combos", new[] { "Combo", "Adrenalina" }, "Canjear", "Cerrar");
            combos.Add(new[] { "150% Health + 100% Armour", "100" });
            combos.Add(new[] { "Jumps", "100" });
            combos.Add(new[] { "Velocity", "100" });
            combos.Add(new[] { "Invisibility", "100" });
            combos.Add(new[] { "2 Grenades + 20% Armour", "25" });
            combos.Add(new[] { "2 Molotov cocktail + 20% Armour", "25" });
            combos.Add(new[] { "10 Tear gas", "10" });
            combos.Add(new[] { "3 Satchel charges + 30% Armour", "40" });
            combos.Show(player);
            combos.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                {
                    if((e.ListItem >= 1 && e.ListItem <= 3) && (player.IsCapturedFlag()))
                    {
                        player.SendClientMessage(Color.Red, "Error: Lleva la bandera de forma legal, no seas cobarde jeje!");
                        return;
                    }
                    switch (e.ListItem)
                    {
                        case 0:
                            player.HasAdrenaline(100);
                            player.Health = 150;
                            player.Armour = 100;
                            player.Adrenaline = 0;
                            break;
                        case 1:
                            player.HasAdrenaline(100);
                            player.SendClientMessage(Color.Yellow, "* En 1 minuto el beneficio se terminará.");
                            player.JumpTime = Time.GetTime() + (TIME * 60);
                            player.Adrenaline = 0;
                            player.GiveWeapon(Weapon.Parachute, 1);
                            break;
                        case 2:
                            player.HasAdrenaline(100);
                            player.SendClientMessage("* En 1 minuto el beneficio se terminará.");
                            player.SendClientMessage(Color.Yellow, $"[Uso]: {Color.White}Presiona y suelta la tecla [SPACE] para correr.");
                            player.SpeedTime = Time.GetTime() + (TIME * 60);
                            player.Adrenaline = 0;
                            break;
                        case 3:
                            player.HasAdrenaline(100);
                            player.SendClientMessage(Color.Yellow, "* En 1 minuto perderás la invisibilidad.");
                            player.InvisibleTime = Time.GetTime() + (TIME * 60);
                            player.Adrenaline = 0;
                            player.EnableInvisibility();
                            break;
                        case 4:
                            player.HasAdrenaline(25);
                            player.SetWeapon(Weapon.Grenade, 2);
                            player.Armour = 20;
                            player.Adrenaline = -25;
                            break;
                        case 5:
                            player.HasAdrenaline(25);
                            player.SetWeapon(Weapon.Moltov, 2);
                            player.Armour = 20;
                            player.Adrenaline = -25;
                            break;
                        case 6:
                            player.HasAdrenaline(10);
                            player.SetWeapon(Weapon.Teargas, 10);
                            player.Adrenaline = -10;
                            break;
                        default:
                            player.HasAdrenaline(40);
                            player.SetWeapon(Weapon.SatchelCharge, 3);
                            player.GiveWeapon(Weapon.Detonator, 1);
                            player.Armour = 30;
                            player.Adrenaline = -40;
                            break;
                    }
                    BasePlayer.SendClientMessageToAll(Color.Red, $"[Combo]: {Color.Yellow}{player.Name} canjeó su adrenalina por algún beneficio {Color.Red}(con /combos).");
                }
            };
        }
    }
}
