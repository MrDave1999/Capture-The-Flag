using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnRconLoginAttempt(RconLoginAttemptEventArgs e)
        {
            base.OnRconLoginAttempt(e);
            if (e.SuccessfulLogin)
            {
                foreach (Player player in BasePlayer.GetAll<Player>())
                {
                    if (player.IsConnected && e.IP == player.IP && player.Data.LevelAdmin != 4)
                    {
                        player.SendClientMessage(Color.Red, "Error: Usted no tiene el rango necesario para iniciar como RCON.");
                        player.Kick();
                        break;
                    }
                }
            }
        }
    }
}
