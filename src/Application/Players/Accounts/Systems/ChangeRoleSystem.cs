namespace CTF.Application.Players.Accounts.Systems;

public class ChangeRoleSystem(IPlayerRepository playerRepository) : ISystem
{
    [PlayerCommand("setrole")]
    public void SetRole(
        Player currentPlayer, 
        [CommandParameter(Name = "playerId")]Player targetPlayer, 
        int roleId)
    {
        if (currentPlayer.HasLowerRoleThan(RoleId.Admin))
            return;

        if(currentPlayer == targetPlayer)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerIsEqualsToTargetPlayer);
            return;
        }

        if(targetPlayer.IsUnauthenticated())
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.UnauthenticatedPlayer);
            return;
        }

        PlayerInfo targetPlayerInfo = targetPlayer.GetInfo();
        RoleId newRoleId = (RoleId)roleId;
        RoleId oldRoleId = targetPlayerInfo.RoleId;
        Result result = targetPlayerInfo.SetRole(newRoleId);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        if (oldRoleId == newRoleId)
        {
            currentPlayer.SendClientMessage(Color.Red, Messages.PlayerAlreadyHasThatRole);
            return;
        }

        var gameText = newRoleId > oldRoleId ?
            Smart.Format(Messages.PromotedToRole, new { RoleName = newRoleId }) :
            Smart.Format(Messages.DemotedToRole,  new { RoleName = newRoleId });

        var message = Smart.Format(Messages.RoleSuccessfullyChanged, new
        {
            RoleName = newRoleId,
            PlayerName = targetPlayer.Name
        });

        playerRepository.UpdateRole(targetPlayerInfo);
        targetPlayer.GameText(gameText, 4000, 3);
        currentPlayer.SendClientMessage(Color.Yellow, message);
    }
}
