using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
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
                issuerid.UpdateData("headshots", ++issuerid.Data.Headshots);
                player.GameText("Headshot", 3000, 3);
            }
            if ((issuerid == null) || (issuerid.Team != player.Team))
                player.UpdateBarHealth(e);
        }
    }
}