using System;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Textdraw;
using SampSharp.Streamer.World;

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
            TeamAlpha = new Team(SkinTeam.Alpha, "{FF2040}", "~r~", TdGlobal.TdScoreAlpha, TeamID.Alpha, "Alpha", "Roja", new Flag(FlagID.Alpha, Color.Red, new Vector3(-1131.7461, 1029.1383, 1345.7311)), Color.LimeGreen);
            TeamBeta =  new Team(SkinTeam.Beta,  "{0088FF}", "~b~", TdGlobal.TdScoreBeta,  TeamID.Beta,  "Beta",  "Azul", new Flag(FlagID.Beta, Color.Blue, new Vector3(-974.7156, 1089.7988, 1344.9755)),  Color.Yellow);
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
        }

        protected override void OnPlayerConnected(BasePlayer sender, EventArgs e)
        {
            var player = sender as Player;
            player.SendClientMessage(Color.Red, "=======================================================================");
            player.SendClientMessage(Color.Yellow, "     Bienvenido a .:: Capture The Flag ::. |Team DeathMatch|");
            player.SendClientMessage(Color.Yellow, "     Comandos principales: /cmds o /ayuda");
            player.SendClientMessage(Color.Red, "=======================================================================");
            player.Color = Color.White;
            BasePlayer.SendDeathMessageToAll(null, player, Weapon.Connect);
        }

        protected override void OnPlayerDisconnected(BasePlayer sender, DisconnectEventArgs e)
        {
            base.OnPlayerDisconnected(sender, e);
            var player = sender as Player;
            BasePlayer.SendDeathMessageToAll(null, player, Weapon.Disconnect);

            if (player.IsCapturedFlag())
                player.PlayerTeam.TeamRival.Drop(player);

            if (player.PlayerTeam.Id != TeamID.None)
                player.PlayerTeam.Members--;
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
            player.IsSelectionClass = true;
            player.Position = new Vector3(-2112.2437, 176.7923, 35.3929);
            player.CameraPosition = new Vector3(-2112.2803, 181.6424, 36.3327);
            player.SetCameraLookAt(new Vector3(-2112.2437, 176.7923, 35.3929));
            player.Angle = 1.0000f;
            player.Interior = 0;
            player.PlayerTeam = (e.ClassId == 0) ? (TeamAlpha) : (TeamBeta);
            player.PlayerTeam.GetMessageTeamEnable(out var msg);
            player.GameText(msg, 999999999, 6);
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
            player.SendClientMessage("\n\n");
            player.SendClientMessage(Color.LimeGreen, $"[CTF]: Eres del equipo {player.PlayerTeam.NameTeam}!");
            player.SendClientMessage(Color.LimeGreen, "[CTF]: Captura la bandera del enemigo y llevala a tu base.");
            TdGlobal.Show(player);
        }

        protected override void OnPlayerSpawned(BasePlayer sender, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(sender, e);
            var player = sender as Player;
            player.GiveWeapon(Weapon.Deagle, 3000);
            player.GiveWeapon(Weapon.Shotgun, 3000);
            player.GiveWeapon(Weapon.Sniper, 3000);
            player.Team = (int)player.PlayerTeam.Id;
            player.Skin = player.PlayerTeam.Skin;
            player.Color = player.PlayerTeam.Flag.ColorHex;

            if(player.PlayerTeam.Id == TeamID.Alpha)
                player.SetPositionEx(new Vector3(-1131.5371, 1057.5098, 1346.4138), 270.4092f, 10);
            else
                player.SetPositionEx(new Vector3(-975.9757, 1060.9830, 1345.6719), 83.9741f, 10);
        }
        
        protected override void OnPlayerDied(BasePlayer sender, DeathEventArgs e)
        {
            base.OnPlayerDied(sender, e);
            var player = sender as Player;
            var killer = e.Killer as Player;
            ++player.Data.Deaths;
            BasePlayer.SendDeathMessageToAll(killer, player, e.DeathReason);
            if (player.IsStateUser == StateUser.Force)
                player.IsStateUser = StateUser.Kill;

            if (killer != null)
            {
                ++killer.Score;
                ++killer.Data.Kills;
            }

            if (player.IsCapturedFlag())
                player.PlayerTeam.TeamRival.Drop(player, killer);
        }

        protected override void OnPlayerTakeDamage(BasePlayer sender, DamageEventArgs e)
        {
            base.OnPlayerTakeDamage(sender, e);
            var player = sender as Player;
            int weaponid = (int)e.Weapon;
            if ((weaponid >= 0 && weaponid <= 15) || (weaponid >= 22 && weaponid <= 34))
                player.PlaySound(17802, new Vector3(0, 0, 0));

            if(e.OtherPlayer != null)
            {
                //code.
            }
        }

        protected override void OnPlayerText(BasePlayer player, TextEventArgs e)
        {
            base.OnPlayerText(player, e);
            BasePlayer.SendClientMessageToAll(Color.White, $"{player.Color}{player.Name} {Color.White}[{player.Id}]: {e.Text}");
            e.SendToPlayers = false;
        }

        protected override void OnPlayerCommandText(BasePlayer sender, CommandTextEventArgs e)
        {
            base.OnPlayerCommandText(sender, e);
            if (!e.Success)
                sender.SendClientMessage(Color.Red, "Error: Comando incorrecto.");
            e.Success = true;
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);
            controllers.Override(new PlayerController());
        }
    }
}