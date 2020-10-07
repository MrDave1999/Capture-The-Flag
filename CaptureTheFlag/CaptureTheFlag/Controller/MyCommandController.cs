using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.SAMP.Commands.PermissionCheckers;
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
            return new DefaultCommand(commandPaths, displayName, ignoreCase, permissionCheckers, method, $"{Color.Red}Uso: {usageMessage}");
        }
    }
}
