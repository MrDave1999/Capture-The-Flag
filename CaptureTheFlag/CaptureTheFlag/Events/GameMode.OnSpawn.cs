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
            if (player.Armour == 0)
                player.TArmour.Hide();
            else
                player.TArmour.Show();
            foreach (Gun gun in player.ListGuns)
                player.GiveWeapon(gun.Weapon);
            player.Team = (int)player.PlayerTeam.Id;
            player.Skin = player.PlayerTeam.Skin;
            player.Color = player.Team == (int)TeamID.Alpha ? 0xFF000000 : 0x0000FF00;
            CurrentMap.SetPlayerPosition(player);
            player.IsDead = false;
            if (player.Data.SkinId != -1)
                player.Skin = player.Data.SkinId;
            if(player.IsInvisible)
                player.EnableInvisibility();
            if (player.IsEnableInvisible())
                player.InvisibleTime = 0;
            if (player.IsFreeze)
                player.ToggleControllable(false); 
        }
    }
}