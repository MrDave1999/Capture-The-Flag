using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerText(BasePlayer sender, TextEventArgs e)
        {
            base.OnPlayerText(sender, e);
            var player = sender as Player;
            e.SendToPlayers = false;
            if (player.IsSelectionClass)
            {
                player.SendClientMessage(Color.Red, "Error: No puedes escribir en el chat estando en la selección de clases.");
                return;
            }
            if (player.IsMuted)
            {
                player.SendClientMessage(Color.Red, "Error: Usted se encuentra silenciado.");
                return;
            }
            player.SendMessageToChat(e.Text);
        }
    }
}