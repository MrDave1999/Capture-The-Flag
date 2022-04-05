using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerDied(BasePlayer sender, DeathEventArgs e)
        {
            base.OnPlayerDied(sender, e);
            var player = sender as Player;
            var killer = e.Killer as Player;
            player.IsDead = true;
            player.UpdateData("totalDeaths", ++player.Data.TotalDeaths);
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
                killer.UpdateData("totalKills", ++killer.Data.TotalKills);
                ++killer.Kills;
                ++killer.Adrenaline;
                ++killer.KillingSprees;
                killer.ShowKillingSprees();
                killer.SetNextRank();
                TextDrawPlayer.UpdateTdStats(killer);
            }
            TextDrawPlayer.UpdateTdStats(player);
        }
    }
}