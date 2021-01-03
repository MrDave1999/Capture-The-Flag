using System;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Textdraw;
using CaptureTheFlag.Command;
using CaptureTheFlag.Controller;
using CaptureTheFlag.Map;
using static CaptureTheFlag.Map.CurrentMap;
using SampSharp.GameMode.Tools;
using CaptureTheFlag.Constants;
using CaptureTheFlag.DataBase;

namespace CaptureTheFlag
{
    public class GameMode : BaseMode
    {
        public static Team TeamAlpha { get; set; }
        public static Team TeamBeta { get; set; }
        public static readonly uint ColorWhite = 0xFFFFFF00;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e); 
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" GameMode Capture The Flag");
            Console.WriteLine("     Team DeathMatch");
            Console.WriteLine("----------------------------------\n");

            SetGameModeText("CTF ~v4.6.2-beta");
            Server.SendRconCommand("hostname .:: Capture The Flag ::. |Team DeathMatch|");
            Server.SendRconCommand("weburl www.");
            Server.SendRconCommand("language  Español Latino");
            Server.SendRconCommand("loadfs EntryMap");
            Server.SendRconCommand("loadfs RemoveBuilding");
            //UsePlayerPedAnimations();
            DisableInteriorEnterExits();

            AddPlayerClass(SkinTeam.Alpha, new Vector3(0, 0, 0), 0);
            AddPlayerClass(SkinTeam.Beta, new Vector3(0, 0, 0), 0);

            StartTimer();
            TeamAlpha = new Team(SkinTeam.Alpha, "{FF2040}", "~r~", TextDrawGlobal.TdScoreAlpha, TeamID.Alpha, "Alpha", "Roja", new Flag(FlagID.Alpha, Color.Red, FileRead.FlagPositionRead("Red")), Interior);
            TeamBeta =  new Team(SkinTeam.Beta,  "{0088FF}", "~b~", TextDrawGlobal.TdScoreBeta,  TeamID.Beta,  "Beta",  "Azul", new Flag(FlagID.Beta, Color.Blue, FileRead.FlagPositionRead("Blue")), Interior);
            TeamAlpha.TeamRival = TeamBeta;
            TeamBeta.TeamRival = TeamAlpha;
            Server.SendRconCommand($"mapname {GetCurrentMap()}");
            Server.SendRconCommand($"loadfs {GetCurrentMap()}");

            new Account();
        }

        protected override void OnDialogResponse(BasePlayer player, DialogResponseEventArgs e)
        {
            base.OnDialogResponse(player, e);
            player.PlaySound(e.DialogButton == DialogButton.Left ? (1083) : (1084));
        }

        protected override void OnPlayerConnected(BasePlayer sender, EventArgs e)
        {
            base.OnPlayerConnected(sender, e);
            var player = sender as Player;
            player.PlayAudioStream("https://dl.dropboxusercontent.com/s/80g6s720ogyoy98/intro-cs.mp3");
            player.Color = ColorWhite;
            player.Team = BasePlayer.NoTeam;
            player.IsSelectionClass = true;
            BasePlayer.SendDeathMessageToAll(null, player, Weapon.Connect);
            TextDrawEntry.Show(player);
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
                Player.Remove(player);
                TextDrawGlobal.UpdateCountUsers();
            }
            TextDrawPlayer.Destroy(player);
        }

        protected override void OnPlayerPickUpPickup(BasePlayer sender, PickUpPickupEventArgs e)
        {
            base.OnPlayerPickUpPickup(sender, e);
            var player = sender as Player;
            (e.Pickup.Model == FlagID.Alpha ? TeamAlpha : TeamBeta).ExecuteAction(player, e.Pickup);
        }

        protected override void OnPlayerKeyStateChanged(BasePlayer sender, KeyStateChangedEventArgs e)
        {
            base.OnPlayerKeyStateChanged(sender, e);
            var player = sender as Player;

            if (KeyUtils.HasPressed(e, Keys.Yes))
                CmdPublic.Weapons(player);
            else if (KeyUtils.HasPressed(e, Keys.No))
                CmdPublic.UsersList(player);
            else if (KeyUtils.HasPressed(e, Keys.CtrlBack))
                CmdPublic.Combos(player);

            if (player.IsEnableJump() && KeyUtils.HasPressed(e, Keys.Jump))
                player.Velocity = new Vector3(player.Velocity.X, player.Velocity.Y, 0.24);

            if(player.IsEnableSpeed() && KeyUtils.HasPressed(e, Keys.Sprint))
                player.ApplyAnimation("PED", "sprint_civi", 100, true, true, true, true, 500);
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

            /* Check if the player has died before entering class selection. */
            if (player.IsDead)
            {
                Player.Remove(player);
                TextDrawGlobal.Hide(player);
                TextDrawPlayer.Hide(player);
            }

            player.Color = ColorWhite;
            player.Team = BasePlayer.NoTeam;
            player.IsSelectionClass = true;
            player.Position = new Vector3(-1389.137451, 3314.043701, 20.493314);
            player.CameraPosition = new Vector3(-1399.776000, 3310.254150, 21.525623);
            player.SetCameraLookAt(new Vector3(-1395.072143, 3311.873291, 22.027709));
            player.Angle = 111.68f;
            player.Interior = 0;
            player.PlayerTeam = (e.ClassId == 0) ? (TeamAlpha) : (TeamBeta);
            player.PlayerTeam.GetMessageTeamEnable(out var msg);
            player.GameText(msg, 999999999, 6);
            player.PlaySound(1132);
            player.IsDead = false;
        }   
         
        protected override void OnPlayerRequestSpawn(BasePlayer sender, RequestSpawnEventArgs e)
        {
            base.OnPlayerRequestSpawn(sender, e);
            var player = sender as Player;
            if (player.Account == AccountState.Login)
            {
                player.SendClientMessage(Color.Red, "Error: Debes iniciar sesión.");
                e.PreventSpawning = true;
                return;
            }
            if (player.Account == AccountState.Register)
            {
                player.SendClientMessage(Color.Red, "Error: Debes registrarte.");
                e.PreventSpawning = true;
                return;
            }
            if (IsLoading)
            {
                e.PreventSpawning = true;
                player.SendClientMessage(Color.Red, "Error: En 10 segundos se cargará el próximo mapa.");
                return;
            }
            if (player.PlayerTeam.GetMessageTeamEnable(out var msg))
            {
                e.PreventSpawning = true;
                player.GameText(msg, 999999999, 6);
                return;
            }
            player.StopAudioStream();
            player.PlayAudioStream("https://dl.dropboxusercontent.com/s/mzt9qnigsh7pdfs/soundtrack.mp3");
            player.IsSelectionClass = false;
            player.GameText("_", 1000, 4);
            Player.Add(player);
            BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se añadió al equipo {player.PlayerTeam.NameTeam}.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Captura la bandera del equipo contrario.");
            if (player.PlayerTeam.Id == TeamID.Alpha)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamBeta.OtherColor}ícono Azul {Color.White}que aparece en el mapa radar.");
            else
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamAlpha.OtherColor}ícono Rojo {Color.White}que aparece en el mapa radar.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Luego lleva la bandera a tu base.");
            if (player.PlayerTeam.Flag.PlayerCaptured != null)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}{player.PlayerTeam.Flag.PlayerCaptured.Name} capturó la bandera de tu equipo, debes recuperarla.");
            TextDrawGlobal.Show(player);
            TextDrawGlobal.UpdateCountUsers();
            TextDrawPlayer.UpdateTdStats(player);
            TextDrawPlayer.Show(player);
            TextDrawEntry.Hide(player);
        }

        protected override void OnPlayerSpawned(BasePlayer sender, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(sender, e);
            var player = sender as Player;
            player.Health = 100;
            player.TArmour.Hide();
            foreach(Gun gun in player.ListGuns)
                player.GiveWeapon(gun.Weapon);
            player.Team = (int)player.PlayerTeam.Id;
            player.Skin = player.PlayerTeam.Skin;
            player.Color = player.Team == (int)TeamID.Alpha ? 0xFF000000 : 0x0000FF00;
            SetPlayerPosition(player);
            player.IsDead = false;
        }
        protected override void OnPlayerDied(BasePlayer sender, DeathEventArgs e)
        {
            base.OnPlayerDied(sender, e);
            var player = sender as Player;
            var killer = e.Killer as Player;
            player.IsDead = true;
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
            if (issuerid != null && issuerid.Team != player.Team && weaponid == 34 && e.BodyPart == BodyPart.Head)
            {
                player.Health = 0;
                ++issuerid.Data.Headshots;
                player.GameText("Headshot", 3000, 3);
            }
            if((issuerid == null) || (issuerid.Team != player.Team))
                player.UpdateBarHealth(e);
        }

        protected override void OnPlayerText(BasePlayer sender, TextEventArgs e)
        {
            base.OnPlayerText(sender, e);
            var player = sender as Player;
            e.SendToPlayers = false;
            if (player.Account == AccountState.Login)
            {
                player.SendClientMessage(Color.Red, "Error: Debes iniciar sesión.");
                return;
            }
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

        protected override void OnPlayerUpdate(BasePlayer sender, PlayerUpdateEventArgs e)
        {
            var player = sender as Player;
            if(player.SpeedTime != 0 && player.SpeedTime < Time.GetTime())
            {
                player.ClearAnimations();
                player.SpeedTime = 0;
            }
        }
    }
}