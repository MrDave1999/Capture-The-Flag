using System;
using System.Collections.Generic;
using System.Text;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Controllers;

namespace CaptureTheFlag.Controller
{
    public class PlayerController : BasePlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}
