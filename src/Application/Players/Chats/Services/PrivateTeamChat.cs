namespace CTF.Application.Players.Chats.Services;

public class PrivateTeamChat : IChatMessage
{
    public char Id => '!';
    public bool SendToAllPlayers(PlayerInfo sender, string message)
    {
        if (sender.Team == Team.None)
            return false;

        Team currentTeam = sender.Team;
        TeamMembers players = currentTeam.Members;
        foreach (Player player in players) 
        {
            player.SendClientMessage(currentTeam.ColorHex, $"[Team Chat] {player.Name}: {message}");
        }
        return true;
    }
}
