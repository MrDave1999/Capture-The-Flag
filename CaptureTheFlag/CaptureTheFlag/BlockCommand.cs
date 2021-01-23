using CaptureTheFlag.Map;
using CaptureTheFlag.PropertiesPlayer;
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
            get { return " ";  }
        }

        public bool Check(BasePlayer sender)
        {
            var player = sender as Player;
            if (player.IsSelectionClass) 
                return false;
            if (CurrentMap.IsLoading) 
                return false;
            return true;
        }
    }
}
