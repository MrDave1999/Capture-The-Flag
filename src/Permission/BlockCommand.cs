namespace CaptureTheFlag.Permission;

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
