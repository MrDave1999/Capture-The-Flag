namespace CaptureTheFlag.Controller;

[Controller]
public class MyCommandController : CommandController
{
    public override void RegisterServices(BaseMode gameMode, GameModeServiceContainer serviceContainer)
    {
        CommandsManager = new MyCommandsManager(gameMode);
        serviceContainer.AddService(CommandsManager);
        CommandsManager.RegisterCommands(gameMode.GetType());
    }
}

public class MyCommandsManager : CommandsManager
{
    public MyCommandsManager(BaseMode gameMode) : base(gameMode)
    {
    }

    protected override ICommand CreateCommand(CommandPath[] commandPaths, string displayName, bool ignoreCase, IPermissionChecker[] permissionCheckers, MethodInfo method, string usageMessage)
        => new MyCommand(commandPaths, displayName, ignoreCase, permissionCheckers, method, $"{Color.Red}Usage: {usageMessage}");
}

public class MyCommand : DefaultCommand
{
    public MyCommand(CommandPath[] names, string displayName, bool ignoreCase,
        IPermissionChecker[] permissionCheckers, MethodInfo method, string usageMessage)
        : base(names, displayName, ignoreCase, permissionCheckers, method, usageMessage)
    {
    }

    protected override bool SendPermissionDeniedMessage(IPermissionChecker permissionChecker, BasePlayer sender)
    {
        var player = sender as Player;
        if (player.IsSelectionClass)
            player.SendClientMessage(Color.Red, "Error: No puedes usar comandos en la selección de clases.");
        else if (CurrentMap.IsLoading)
            player.SendClientMessage(Color.Red, "Error: No puedes usar comandos mientras el mapa se está cargando.");
        return true;
    }
}

