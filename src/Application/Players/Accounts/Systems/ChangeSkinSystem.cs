namespace CTF.Application.Players.Accounts.Systems;

public class ChangeSkinSystem(IPlayerRepository playerRepository) : ISystem
{
    [PlayerCommand("skin")]
    public void SetSkin(Player player, [CommandParameter(Name = "skinId")]int newSkinId)
    {
        PlayerInfo playerInfo = player.GetInfo();
        Result result = playerInfo.SetSkin(newSkinId);
        if (result.IsFailed)
        {
            player.SendClientMessage(Color.Red, result.Message);
            return;
        }

        player.Skin = newSkinId;
        player.GameText($"Skin ID {newSkinId}", 3000, 4);
        playerRepository.UpdateSkin(playerInfo);
        var message = Smart.Format(Messages.SavedSkin, new { playerInfo.SkinId });
        player.SendClientMessage(Color.Yellow, message);
    }
}
