namespace CTF.Application.Players;

public class PlayerCommandTextSystem(
    IPlayerCommandService playerCommandService,
    IServiceProvider serviceProvider) : ISystem
{
    /// <summary>
    /// This callback is called when a player enters a command into the client chat window. 
    /// Commands are anything that start with a forward slash, e.g. /help.
    /// </summary>
    /// <param name="player">
    /// The player that entered a command.
    /// </param>
    /// <param name="text">
    /// The command that was entered (including the forward slash).
    /// </param>
    /// <returns>
    /// <c>true</c> if the command was processed, otherwise <c>false</c>; If the command was not found both in 
    /// filterscripts and in gamemode, the player will be received a message: 'SERVER: Unknown command'.
    /// </returns>
    [Event]
    public bool OnPlayerCommandText(Player player, string text)
    {
        bool invokeResult = playerCommandService.Invoke(serviceProvider, player, text);
        if (!invokeResult)
            player.SendClientMessage(Color.Red, Messages.CommandNotFound);

        return true;
    }
}
