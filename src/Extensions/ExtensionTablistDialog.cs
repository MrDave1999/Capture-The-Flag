namespace CaptureTheFlag.Dialogs.Extensions;

public static class ExtensionTablistDialog
{
    public static void SetInfo(this TablistDialog vs)
    {
        vs.Clear();
        TeamAlpha.GetMessageTeamEnable(out var msgAlpha, false);
        TeamBeta.GetMessageTeamEnable(out var msgBeta, false);
        vs.Add(new[]
        {
            $"{TeamAlpha.OtherColor}{TeamAlpha.NameTeam}",
            $"{TeamAlpha.OtherColor}{TeamAlpha.Members}",
            $"{TeamAlpha.OtherColor}{msgAlpha}"
        });
        vs.Add(new[]
        {
            $"{TeamBeta.OtherColor}{TeamBeta.NameTeam}",
            $"{TeamBeta.OtherColor}{TeamBeta.Members}",
            $"{TeamBeta.OtherColor}{msgBeta}"
        });
    }

    public static void ShowDialog(this TablistDialog vs, Player player)
    {
        vs.SetInfo();
        vs.Show(player);
    }
}
