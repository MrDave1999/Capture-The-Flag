namespace CTF.Application.Players.Accounts.Systems;

public class ChangePasswordSystem(
    IPlayerRepository playerRepository,
    IDialogService dialogService) : ISystem
{
    private readonly InputDialog _passwordDialog = new()
    {
        IsPassword = true,
        Caption = "Change Password",
        Content = "Enter your new password",
        Button1 = "Accept",
        Button2 = "Close"
    };

    [PlayerCommand("changepass")]
    public async void ShowPasswordDialog(Player player)
    {
        InputDialogResponse response = await dialogService.ShowAsync(player, _passwordDialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
            return;

        var enteredPassword = response.InputText ?? string.Empty;
        ChangePassword(player, enteredPassword);
    }

    private void ChangePassword(Player player, string enteredPassword)
    {
        PlayerInfo playerInfo = player.GetInfo();
        Result result = playerInfo.SetPassword(enteredPassword);
        if (result.IsFailed)
        {
            player.SendClientMessage(Color.Red, result.Message);
            ShowPasswordDialog(player);
            return;
        }

        var message = Smart.Format(Messages.PasswordSuccessfullyChanged, new { NewPassword = enteredPassword });
        player.SendClientMessage(Color.Yellow, message);
        playerRepository.UpdatePassword(playerInfo);
    }
}
