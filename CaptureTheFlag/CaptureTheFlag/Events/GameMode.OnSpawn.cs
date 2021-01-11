using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using CaptureTheFlag.Map;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerSpawned(BasePlayer sender, SpawnEventArgs e)
        {
            base.OnPlayerSpawned(sender, e);
            var player = sender as Player;
            player.Health = 100;
            player.TArmour.Hide();
            foreach (Gun gun in player.ListGuns)
                player.GiveWeapon(gun.Weapon);
            player.Team = (int)player.PlayerTeam.Id;
            player.Skin = player.PlayerTeam.Skin;
            player.Color = player.Team == (int)TeamID.Alpha ? 0xFF000000 : 0x0000FF00;
            CurrentMap.SetPlayerPosition(player);
            player.IsDead = false;
        }
    }
}