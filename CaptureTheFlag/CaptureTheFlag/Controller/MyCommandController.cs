using CaptureTheFlag.Map;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.SAMP.Commands.ParameterTypes;
using SampSharp.GameMode.SAMP.Commands.PermissionCheckers;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CaptureTheFlag.Controller
{
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
        {
            return new MyCommand(commandPaths, displayName, ignoreCase, permissionCheckers, method, $"{Color.Red}Usage: {usageMessage}");
        }
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

}
