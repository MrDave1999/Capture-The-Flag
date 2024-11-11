using ConnectedPlayer = SampSharp.Entities.SAMP.Player;

namespace CTF.Application.Players.Accounts.Systems;

public class AccountSystem(
    IDialogService dialogService,
    IPlayerRepository playerRepository,
    LoginDialogViewer loginDialogViewer) : ISystem
{
    private readonly InputDialog _signupDialog = new()
    {
        IsPassword = true,
        Caption = "Signup",
        Content = "Enter a password",
        Button1 = "Accept"
    };

    [Event]
    public void OnPlayerConnect(ConnectedPlayer connectedPlayer)
    {
        AddDefaultAccount(connectedPlayer);
        PlayerInfo playerInfo = playerRepository.GetOrDefault(connectedPlayer.Name);
        if(playerInfo is null)
        {
            ShowSignupDialog(connectedPlayer);
            return;
        }
        loginDialogViewer.View(connectedPlayer, playerInfo);
    }

    private static void AddDefaultAccount(ConnectedPlayer connectedPlayer)
    {
        var playerInfo = new PlayerInfo();
        bool isAuthenticated = false;
        playerInfo.SetName(connectedPlayer.Name);
        connectedPlayer.AddComponent<AccountComponent>(playerInfo, isAuthenticated);
    }

    private async void ShowSignupDialog(ConnectedPlayer connectedPlayer)
    {
        InputDialogResponse response = await dialogService.ShowAsync(connectedPlayer, _signupDialog);
        if (response.Response == DialogResponse.Disconnected)
            return;

        if (response.Response == DialogResponse.RightButtonOrCancel)
        {
            ShowSignupDialog(connectedPlayer);
            return;
        }

        var enteredPassword = response.InputText ?? string.Empty;
        CreatePlayerAccount(connectedPlayer, enteredPassword);
    }

    private void CreatePlayerAccount(ConnectedPlayer connectedPlayer, string enteredPassword)
    {
        PlayerInfo playerInfo = connectedPlayer.GetInfo();
        Result passwordResult = playerInfo.SetPassword(enteredPassword);
        if (passwordResult.IsFailed)
        {
            connectedPlayer.SendClientMessage(Color.Red, passwordResult.Message);
            ShowSignupDialog(connectedPlayer);
            return;
        }

        bool isAuthenticated = true;
        connectedPlayer.GetComponent<AccountComponent>().Destroy();
        connectedPlayer.AddComponent<AccountComponent>(playerInfo, isAuthenticated);
        var message = Smart.Format(Messages.CreatePlayerAccount, new { Password = enteredPassword });
        connectedPlayer.SendClientMessage(Color.Red, message);
        playerInfo.SetName(connectedPlayer.Name);
        playerRepository.Create(playerInfo);
    }
}
