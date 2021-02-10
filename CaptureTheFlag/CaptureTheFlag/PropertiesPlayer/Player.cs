using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.World;
using SampSharp.GameMode.SAMP;
using CaptureTheFlag.Constants;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int KillingSprees { get; set; }
        public bool IsSelectionClass { get; set; } 
        public bool IsDead { get; set; }
        public int Warns { get; set; }
        public bool IsMuted { get; set; }
        public bool IsFreeze { get; set; }
        public StateUser IsStateUser { get; set; }
        public PlayerData Data { get; set; }
        public Team PlayerTeam { get; set; }
        public AccountState Account { get; set; } = AccountState.None;

        public Player()
        {
            Data = new PlayerData();
            IsStateUser = StateUser.None;
            CreateTextDraw();
        }

        public void ShowKillingSprees()
        {
            if (KillingSprees >= 2)
            {
                GameText($"KILL X{KillingSprees}", 3000, 3);
                Adrenaline += (4 + KillingSprees);
                if (Health < 100)
                    /* The ternary operator condition is necessary so that it does not exceed the maximum health which is 100 percent. */
                    Health += (10 <= (100 - Health)) ? (10) : (100 - Health);

                if (KillingSprees > Data.KillingSprees)
                {
                    Data.KillingSprees = KillingSprees;
                    UpdateData("killingSprees", Data.KillingSprees);
                }

                if (KillingSprees % 3 == 0)
                    SendClientMessageToAll(Color.Red, $"[Killing-Sprees]: {Color.Orange}{Name} lleva {KillingSprees} asesinatos seguidos sin morir.");
            }
        }

        public void SetNextRank()
        {
            if(Data.LevelGame != Rank.MAX_RANK && Data.TotalKills >= Rank.GetRequiredKills(Data.LevelGame + 1))
            {
                UpdateData("levelGame", ++Data.LevelGame);
                SendClientMessage(Color.Red, $"[Rank]: {Color.Orange}Subiste al rango {Rank.GetRankLevel(Data.LevelGame)} {Color.Red}¡Felicidades!");
                SendClientMessage(Color.Red, $"[!]: {Color.White} Ganaste +100 de Adrenalina + Chaleco + Regeneración de salud.");
                Adrenaline = 100;
                Armour = 100;
                Health = 100;
                TextDrawPlayer.UpdateTdRank(this);
            }
        }

        public void SetForceClass()
        {
            TextDrawGlobal.Hide(this);
            TextDrawPlayer.Hide(this);
            TextDrawEntry.Show(this);
            ForceClassSelection();
            ToggleSpectating(true);
            ToggleSpectating(false);
            IsStateUser = StateUser.Force;
        }

        public bool IsAdminLevel(int levelid)
        {
            if (Data.LevelAdmin < levelid)
            {
                SendClientMessage(Color.Red, $"Error: Debes ser nivel {levelid} (Rango: {Rank.GetRankAdmin(levelid)}) para usar este comando.");
                return true;
            }
            return false;
        }

        public bool IsVipLevel(int levelid)
        {
            if (Data.LevelVip < levelid)
            {
                SendClientMessage(Color.Red, $"Error: Debes ser nivel {levelid} (Rango: {Rank.GetRankVip(levelid)}) para usar este comando.");
                return true;
            }
            return false;
        }

        public bool IsGameLevel(int levelid)
        {
            if(Data.LevelGame < levelid)
            {
                SendClientMessage(Color.Red, $"Error: Debes ser nivel {levelid} (Rango: {Rank.GetRankLevel(levelid)}) para usar este comando.");
                return true;
            }
            return false;
        }

        public void Drop() => PlayerTeam.TeamRival.Drop(this);
        public bool IsCapturedFlag() => this == PlayerTeam.TeamRival.Flag.PlayerCaptured;

        public new string[] ToString()
        {
             return new[]
            {
                $"{PlayerTeam.OtherColor}{Id}",
                $"{PlayerTeam.OtherColor}{Name}",
                $"{PlayerTeam.OtherColor}{Kills}",
                $"{PlayerTeam.OtherColor}{Deaths}"
            };
        }

        public override void ClearAnimations()
        {
            /* credits to simonepri (https://github.com/simonepri/) */
            base.ClearAnimations();
            ApplyAnimation("PED", "IDLE_STANCE", 4.0f, false, false, false, false, 1);
            ApplyAnimation("PED", "IDLE_CHAT", 4.0f, false, false, false, false, 1);
            ApplyAnimation("PED", "WALK_PLAYER", 4.0f, false, false, false, false, 1);
            /* *** */
        }

        public void UpdateData<T>(string campus, T newvalue) => DataBase.Account.Update(campus, newvalue, Name);

        public bool Equals(Player player, string msg)
        {
            if (this == player)
            {
                SendClientMessage(Color.Red, "Error: " + msg);
                return true;
            }
            return false;
        }

        public override void Kick() => new Timer(500, false).Tick += (sender, e) => base.Kick();
        public override void Ban(string reason) => new Timer(500, false).Tick += (sender, e) => base.Ban(reason);

        public override int Skin
        {
            get => base.Skin;
            set
            {
                if(SpecialAction == SampSharp.GameMode.Definitions.SpecialAction.Duck)
                    ToggleControllable(true);
                base.Skin = value;
            }
        }
    }
}