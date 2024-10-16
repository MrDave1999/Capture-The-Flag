﻿using ConnectedPlayer = SampSharp.Entities.SAMP.Player;

namespace CTF.Application.Players.Accounts.Systems;

public class AccountSystem(
    IDialogService dialogService,
    IPlayerRepository playerRepository,
    IPasswordHasher passwordHasher) : ISystem
{
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
    public void OnPlayerConnect(ConnectedPlayer connectedPlayer)
    {
        AddDefaultAccount(connectedPlayer);
        PlayerInfo playerInfo = playerRepository.GetOrDefault(connectedPlayer.Name);
        if(playerInfo is null)
        {
            ShowSignupDialog(connectedPlayer);
            return;
        }
        connectedPlayer.AddComponent<FailedAttemptCountComponent>();
        ShowLoginDialog(connectedPlayer, playerInfo);
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

    private async void ShowLoginDialog(ConnectedPlayer connectedPlayer, PlayerInfo playerInfo)
    {
        InputDialogResponse response = await dialogService.ShowAsync(connectedPlayer, _loginDialog);
        if (response.Response == DialogResponse.Disconnected)
            return;

        if (response.Response == DialogResponse.RightButtonOrCancel)
        {
            ShowLoginDialog(connectedPlayer, playerInfo);
            return;
        }

        var enteredPassword = response.InputText ?? string.Empty;
        bool isWrongPassword = !passwordHasher.Verify(enteredPassword, passwordHash: playerInfo.Password);
        if (isWrongPassword) 
        {
            const int MaxFailedAttempts = 4;
            var failedAttemptCount = connectedPlayer.GetComponent<FailedAttemptCountComponent>();
            failedAttemptCount.Value++;
            if (failedAttemptCount.Value == MaxFailedAttempts)
            {
                connectedPlayer.Kick();
                return;
            }
            connectedPlayer.SendClientMessage(Color.Red, Messages.WrongPassword);
            ShowLoginDialog(connectedPlayer, playerInfo);
            return;
        }

        bool isAuthenticated = true;
        connectedPlayer.GetComponent<FailedAttemptCountComponent>().Destroy();
        connectedPlayer.GetComponent<AccountComponent>().Destroy();
        connectedPlayer.AddComponent<AccountComponent>(playerInfo, isAuthenticated);
        connectedPlayer.SendClientMessage(Color.Red, Messages.SuccessfulLogin);
    }

    private class FailedAttemptCountComponent : Component
    {
        public int Value { get; set; } = 0;
    }
}
