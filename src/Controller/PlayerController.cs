namespace CaptureTheFlag.Controller;

public class PlayerController : BasePlayerController
{
    public override void RegisterTypes() => Player.Register<Player>();
}
