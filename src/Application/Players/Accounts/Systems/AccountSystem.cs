namespace CTF.Application.Players.Accounts.Systems;

public class AccountSystem(
    IDialogService dialogService,
    IPlayerRepository playerRepository,
    IPasswordHasher passwordHasher) : ISystem
{
    private Player _connectedPlayer;
    private readonly InputDialog _signupDialog = new()
    {
        IsPassword = true,
        Caption = "Signup",
        Content = "Enter a password",
        Button1 = "Accept"
    };
    private readonly InputDialog _loginDialog = new()
    {
        IsPassword = true,
        Caption = "Login",
        Content = "Enter your password",
        Button1 = "Accept"
    };

    [Event]
    public void OnPlayerConnect(Player player)
    {
        _connectedPlayer = player;
        PlayerInfo playerInfo = playerRepository.GetOrDefault(player.Entity, player.Name);
        if(playerInfo is null)
        {
            ShowSignupDialog(new PlayerInfo(_connectedPlayer.Entity));
            return;
        }
        ShowLoginDialog(playerInfo);
    }

    private async void ShowSignupDialog(PlayerInfo playerInfo)
    {
        InputDialogResponse response = await dialogService.ShowAsync(_connectedPlayer, _signupDialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
        {
            ShowSignupDialog(playerInfo);
            return;
        }

        var enteredPassword = response.InputText;
        CreatePlayerAccount(playerInfo, enteredPassword);
    }

    private void CreatePlayerAccount(PlayerInfo playerInfo, string enteredPassword)
    {
        Result passwordResult = playerInfo.SetPassword(enteredPassword);
        if (passwordResult.IsFailed)
        {
            _connectedPlayer.SendClientMessage(Color.Red, passwordResult.Message);
            ShowSignupDialog(playerInfo);
            return;
        }

        _connectedPlayer.AddComponent<AccountComponent>(playerInfo);
        var message = Smart.Format(Messages.CreatePlayerAccount, new { Password = enteredPassword });
        _connectedPlayer.SendClientMessage(Color.Red, message);
        playerInfo.SetName(_connectedPlayer.Name);
        playerRepository.Create(playerInfo);
    }

    private async void ShowLoginDialog(PlayerInfo playerInfo)
    {
        InputDialogResponse response = await dialogService.ShowAsync(_connectedPlayer, _loginDialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
        {
            ShowLoginDialog(playerInfo);
            return;
        }

        bool isWrongPassword = !passwordHasher.Verify(response.InputText, passwordHash: playerInfo.Password);
        if (isWrongPassword) 
        {
            _connectedPlayer.SendClientMessage(Color.Red, Messages.WrongPassword);
            ShowLoginDialog(playerInfo);
            return;
        }

        _connectedPlayer.AddComponent<AccountComponent>(playerInfo);
        _connectedPlayer.SendClientMessage(Color.Red, Messages.SuccessfulLogin);
    }
}
