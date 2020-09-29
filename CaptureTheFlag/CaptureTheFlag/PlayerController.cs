using System;
using System.Collections.Generic;
using System.Text;
using SampSharp.GameMode.Controllers;

namespace CaptureTheFlag
{
    public class PlayerController : BasePlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}
