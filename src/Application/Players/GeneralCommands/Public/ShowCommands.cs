namespace CTF.Application.Players.GeneralCommands.Public;

public class ShowCommands(IDialogService dialogService) : ISystem
{
    [PlayerCommand("cmds")]
    public async void ShowFirstDialog(Player player)
    {
        var content = Smart.Format(DetailedCommandInfo.Public1, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White
        });
        var firstDialog = new MessageDialog(
            caption: "Commands [1/2]", 
            content, 
            button1: "Next", 
            button2: "Close"
        );
        var response = await dialogService.ShowAsync(player, firstDialog);
        if (response.Response == DialogResponse.LeftButton)
            ShowNextDialog(player);
    }

    private async void ShowNextDialog(Player player)
    {
        var content = Smart.Format(DetailedCommandInfo.Public2, new
        {
            Color1 = Color.Yellow,
            Color2 = Color.White
        });
        var nextDialog = new MessageDialog(
            caption: "Commands [2/2]", 
            content, 
            button1: "Previous", 
            button2: "Close"
        );
        var response = await dialogService.ShowAsync(player, nextDialog);
        if (response.Response == DialogResponse.LeftButton)
            ShowFirstDialog(player);
    }
}
