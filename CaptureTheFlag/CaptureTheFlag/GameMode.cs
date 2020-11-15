using System;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Textdraw;
using SampSharp.Streamer.World;
using CaptureTheFlag.Command;
using CaptureTheFlag.Controller;

namespace CaptureTheFlag
{
    public class GameMode : BaseMode
    {
        public static Team TeamAlpha { get; set; }
        public static Team TeamBeta { get; set; }
        public static TextDrawGlobal TdGlobal { get; set; }
        

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e); 
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" GameMode Capture The Flag");
            Console.WriteLine("     Team DeathMatch");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("Capture The Flag");
            Server.SendRconCommand("hostname .:: Capture The Flag ::. |Team DeathMatch|");
            Server.SendRconCommand("mapname RC Battlefield");
            Server.SendRconCommand("weburl www.");
            Server.SendRconCommand("language  Español Latino");
            UsePlayerPedAnimations();
            DisableInteriorEnterExits();

            AddPlayerClass(SkinTeam.Alpha, new Vector3(0, 0, 0), 0);
            AddPlayerClass(SkinTeam.Beta, new Vector3(0, 0, 0), 0);

            TdGlobal = new TextDrawGlobal();
            TeamAlpha = new Team(SkinTeam.Alpha, "{FF2040}", "~r~", TdGlobal.TdScoreAlpha, TeamID.Alpha, "Alpha", "Roja", new Flag(FlagID.Alpha, Color.Red, new Vector3(-1131.7461, 1029.1383, 1345.7311)));
            TeamBeta =  new Team(SkinTeam.Beta,  "{0088FF}", "~b~", TdGlobal.TdScoreBeta,  TeamID.Beta,  "Beta",  "Azul", new Flag(FlagID.Beta, Color.Blue, new Vector3(-974.7156, 1089.7988, 1344.9755)));
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
        }

        protected override void OnDialogResponse(BasePlayer player, DialogResponseEventArgs e)
        {
            base.OnDialogResponse(player, e);
            player.PlaySound(e.DialogButton == DialogButton.Left ? (1083) : (1084));
        }

        protected override void OnPlayerConnected(BasePlayer sender, EventArgs e)
        {
            var player = sender as Player;
            player.SendClientMessage(Color.Red, "=======================================================================");
            player.SendClientMessage(Color.Yellow, "     Bienvenido a .:: Capture The Flag ::. |Team DeathMatch|");
            player.SendClientMessage(Color.Yellow, "     ¿No sabes cuales son los comandos? Usa /cmds");
            player.SendClientMessage(Color.Yellow, "     ¿No sabes como jugar? Usa /help");
            player.SendClientMessage(Color.Red, "=======================================================================");
            player.Color = Color.White;
            player.Team = BasePlayer.NoTeam;
            player.IsSelectionClass = true;
            BasePlayer.SendDeathMessageToAll(null, player, Weapon.Connect);
        }

        protected override void OnPlayerDisconnected(BasePlayer sender, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(sender, e);
            var player = sender as Player;
            BasePlayer.SendDeathMessageToAll(null, player, Weapon.Disconnect);
            if (player.IsCapturedFlag())
                player.Drop();
            if (player.Team != BasePlayer.NoTeam)
            {
                --player.PlayerTeam.Members;
                TdGlobal.UpdateCountUsers();
            }
            TextDrawPlayer.Destroy(player);
        }

        protected override void OnPlayerPickUpPickup(BasePlayer sender, PickUpPickupEventArgs e)
        {
            base.OnPlayerPickUpPickup(sender, e);
            var player = sender as Player;
            (e.Pickup.Model == FlagID.Alpha ? TeamAlpha : TeamBeta).ExecuteAction(player, e.Pickup);
        }

        protected override void OnPlayerRequestClass(BasePlayer sender, RequestClassEventArgs e)
        {
            var player = sender as Player;
            if (player.IsStateUser == StateUser.Kill)
            {
                player.IsStateUser = StateUser.None;
                player.SetSpawnInfo(0, 0, new Vector3(0, 0, 0), 0);
                player.Spawn();
                return;
            }
            player.Color = Color.White;
            player.Team = BasePlayer.NoTeam;
            player.IsSelectionClass = true;
            player.Position = new Vector3(512.993041, -17.125566, 1001.565307);
            player.CameraPosition = new Vector3(513.012329, -12.488013, 1001.565307);
            player.SetCameraLookAt(new Vector3(512.993041, -17.125566, 1001.565307));
            player.Angle = 0.131221f;
            player.Interior = 3;
            player.PlayerTeam = (e.ClassId == 0) ? (TeamAlpha) : (TeamBeta);
            player.PlayerTeam.GetMessageTeamEnable(out var msg);
            player.GameText(msg, 999999999, 6);
            player.PlaySound(1132);
        }   
         
        protected override void OnPlayerRequestSpawn(BasePlayer sender, RequestSpawnEventArgs e)
        {
            var player = sender as Player;

            if (player.PlayerTeam.GetMessageTeamEnable(out var msg))
            {
                e.PreventSpawning = true;
                player.GameText(msg, 999999999, 6);
                return;
            }
            player.IsSelectionClass = false;
            player.GameText("_", 1000, 4);
            player.PlayerTeam.Members++;
            BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se añadió al equipo {player.PlayerTeam.NameTeam}.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Captura la bandera del equipo contrario.");
            if (player.PlayerTeam.Id == TeamID.Alpha)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamBeta.OtherColor}ícono Azul {Color.White}que aparece en el mapa radar.");
            else
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamAlpha.OtherColor}ícono Rojo {Color.White}que aparece en el mapa radar.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Luego lleva la bandera a tu base.");
            if (player.PlayerTeam.Flag.PlayerCaptured != null)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}{player.PlayerTeam.Flag.PlayerCaptured.Name} capturó la bandera de tu equipo, debes recuperarla.");
            TdGlobal.Show(player);
            TdGlobal.UpdateCountUsers();
            TextDrawPlayer.UpdateTdStats(player);
            TextDrawPlayer.Show(player);
        }

        protected override void OnPlayerSpawned(BasePlayer sender, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(sender, e);
            var player = sender as Player;
            player.Health = 100;
            player.TArmour.Hide();
            player.GiveWeapon(Weapon.Deagle, 3000);
            player.GiveWeapon(Weapon.Shotgun, 3000);
            player.GiveWeapon(Weapon.Sniper, 3000);
            player.GiveWeapon(Weapon.Knife, 1);
            player.Team = (int)player.PlayerTeam.Id;
            player.Skin = player.PlayerTeam.Skin;

            if (player.PlayerTeam.Id == TeamID.Alpha)
            {
                player.SetPositionEx(new Vector3(-1131.5371, 1057.5098, 1346.4138), 270.4092f, 10);
                player.Color = 0xFF000000;
            }
            else
            {
                player.SetPositionEx(new Vector3(-975.9757, 1060.9830, 1345.6719), 83.9741f, 10);
                player.Color = 0x0000FF00;
            }
        }

        protected override void OnPlayerDied(BasePlayer sender, DeathEventArgs e)
        {
            base.OnPlayerDied(sender, e);
            var player = sender as Player;
            var killer = e.Killer as Player;
            ++player.Data.TotalDeaths;
            ++player.Deaths;
            ++player.PlayerTeam.Deaths;
            player.KillingSprees = 0;
            BasePlayer.SendDeathMessageToAll(killer, player, e.DeathReason);
            if (player.IsStateUser == StateUser.Force)
                player.IsStateUser = StateUser.Kill;

            if (player.IsCapturedFlag())
                player.PlayerTeam.TeamRival.Drop(player, killer);

            if (killer != null)
            {
                ++killer.PlayerTeam.Kills;
                ++killer.Data.TotalKills;
                ++killer.Kills;
                ++killer.Adrenaline;
                ++killer.KillingSprees;
                killer.ShowKillingSprees();
                killer.SetNextRank();
                TextDrawPlayer.UpdateTdStats(killer);
            }
            TextDrawPlayer.UpdateTdStats(player);
        }

        protected override void OnPlayerTakeDamage(BasePlayer sender, DamageEventArgs e)
        {
            base.OnPlayerTakeDamage(sender, e);
            var player = sender as Player;
            var issuerid = (Player)e.OtherPlayer;
            int weaponid = (int)e.Weapon;
            if ((weaponid >= 0 && weaponid <= 15) || (weaponid >= 22 && weaponid <= 34))
                player.PlaySound(17802);
            if (issuerid != null && weaponid == 34 && e.BodyPart == BodyPart.Head)
            {
                player.Health = 0;
                ++issuerid.Data.Headshot;
                player.GameText("Headshot", 3000, 3);
            }
            player.UpdateBarHealth(e);
        }

        protected override void OnPlayerText(BasePlayer sender, TextEventArgs e)
        {
            base.OnPlayerText(sender, e);
            var player = sender as Player;
            e.SendToPlayers = false;
            Chat.WriteText(player, e.Text);
        }

        protected override void OnPlayerCommandText(BasePlayer sender, CommandTextEventArgs e)
        {
            base.OnPlayerCommandText(sender, e);
            if (!e.Success)
            {
                sender.SendClientMessage(Color.Red, $"Error: El comando {e.Text} es incorrecto. Usa /cmds para saber los comandos disponibles.");
                sender.PlaySound(1140);
            }
            e.Success = true;
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            controllers.Override(new PlayerController());
        }
    }
}