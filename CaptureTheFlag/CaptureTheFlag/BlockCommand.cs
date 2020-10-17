using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands.PermissionCheckers;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class BlockCommand : IPermissionChecker
    {
        public string Message
        {
            get { return $"{Color.Red}No puedes usar comandos en la selección de clases."; }
        }

        public bool Check(BasePlayer player)
        {
            return !((Player)player).IsSelectionClass;
        }
    }
}
