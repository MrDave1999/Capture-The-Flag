namespace CTF.Application.Players.Accounts.Systems;

public class SkinSystem(IPlayerRepository playerRepository) : ISystem
{
    [PlayerCommand("skin")]
    public void SetSkin(Player player, int skinId)
    {
        PlayerInfo playerInfo = player.GetInfo();
        Result result = playerInfo.SetSkin(skinId);
        if (result.IsFailed)
        {
            player.SendClientMessage(Color.Red, result.Message);
            return;
        }

        player.Skin = skinId;
        player.GameText($"Skin ID {skinId}", 3000, 4);
        playerRepository.UpdateSkin(playerInfo);
        var message = Smart.Format(Messages.SavedSkin, new { playerInfo.SkinId });
        player.SendClientMessage(Color.Yellow, message);
    }
}
