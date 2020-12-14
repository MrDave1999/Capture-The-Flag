using System;
using System.Diagnostics.Tracing;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.World;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using static CaptureTheFlag.GameMode;
using System.Collections.Generic;
using CaptureTheFlag.Constants;

namespace CaptureTheFlag
{
    public class Player : BasePlayer
    {
        private int adrenaline;
        
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int KillingSprees { get; set; }
        public bool IsSelectionClass { get; set; } 
        public StateUser IsStateUser { get; set; }
        public PlayerData Data { get; set; }
        public Team PlayerTeam { get; set; }
        public PlayerTextDraw Stats { get; set; }
        public PlayerTextDraw THealth { get; set; }
        public PlayerTextDraw TArmour { get; set; }
        public PlayerTextDraw TdRank { get; set; }
        public double JumpTime { get; set; }
        public double SpeedTime { get; set; }

        public Player()
        {
            Data = new PlayerData();
            IsStateUser = StateUser.None;
            Stats = new PlayerTextDraw(this);
            THealth = new PlayerTextDraw(this);
            TArmour = new PlayerTextDraw(this);
            TdRank = new PlayerTextDraw(this);
            TextDrawPlayer.CreateTDStats(Stats);
            TextDrawPlayer.CreateTDHealth(THealth);
            TextDrawPlayer.CreateTDArmour(TArmour);
            TextDrawPlayer.CreateTDRank(TdRank);
        }

        public List<Gun> ListGuns { get; set; } = new List<Gun>(10)
        {
            new Gun(Weapon.Deagle),
            new Gun(Weapon.Shotgun),
            new Gun(Weapon.Sniper)
        };

        public int Adrenaline
        {
            get { return adrenaline; }
            set 
            {
                /* This is used when adrenaline resets to zero. */
                if (value == 0)
                {
                    adrenaline = 0;
                    if (!IsSelectionClass)
                        TextDrawPlayer.UpdateTdStats(this);
                }
                else if (value < 0)
                {
                    adrenaline -= -value;
                    TextDrawPlayer.UpdateTdStats(this);
                }
                else if (adrenaline < 100)
                {
                    /* The percentage of adrenaline that the player won. */
                    int won_adrenaline = value - adrenaline;
                    /* The percentage of adrenaline the player lacks to complete 100 percent. */
                    int missing_adrenaline = 100 - adrenaline;
                    adrenaline = (won_adrenaline <= missing_adrenaline) ? (value) : (adrenaline + missing_adrenaline);
                    if (adrenaline == 100)
                        SendClientMessage(Color.Yellow, message: $"** Tu adrenalina está al 100 porciento ({Color.Red}usa /combos {Color.Yellow}para poder canjear la adrenalina por algún {Color.Red}beneficio{Color.Yellow}).");
                }
            }
        }

        public override float Health
        {
            get { return base.Health; }
            set
            {
                HealthBar(THealth, value);
                base.Health = value;
            }
        }

        public override float Armour
        {
            get { return base.Armour; }
            set
            {
                HealthBar(TArmour, value);
                base.Armour = value;
            }
        }

        public void RemoveWeapon(int index)
        {
            ResetWeapons();
            ListGuns.RemoveAt(index);
            foreach (Gun gun in ListGuns)
                GiveWeapon(gun.Weapon);
        }

        public bool IsEnableJump()
        {
            return JumpTime > Time.GetTime();
        }

        public bool IsEnableSpeed()
        {
            return SpeedTime > Time.GetTime();
        }

        public void HealthBar(PlayerTextDraw bar, float value)
        {
            bar.Text = $"{value:F0}";
            bar.Show();
        }

        public void UpdateBarHealth(DamageEventArgs e)
        {
            if (State == PlayerState.Wasted)
            {
                Armour = 0;
                TArmour.Hide();
                HealthBar(THealth, 0);
            }
            else if (e.Weapon != Weapon.Collision && Armour != 0)
            {
                /* Calculate the player's current armour. */
                float armour = (float)(Armour - Math.Ceiling(e.Amount));
                if (armour > 0)
                    HealthBar(TArmour, armour);
                else
                {
                    TArmour.Hide();
                    HealthBar(THealth, 100.0f - Math.Abs(armour));
                }
            }
            else
            {
                /* Calculate the player's current health. */
                float health = (float)(Health - Math.Ceiling(e.Amount));
                HealthBar(THealth, health >= 0 ? health : 0);
            }
        } 

        public void UpdateAdrenaline(int won_adrenaline, string reason)
        {
            if (adrenaline < 100)
            {
                Adrenaline += won_adrenaline;
                SendClientMessage(Color.Pink, $"[!]{Color.White} Obtuviste +{won_adrenaline} de {Color.Pink}Adrenalina {Color.White}por {reason}.");
                TextDrawPlayer.UpdateTdStats(this);
            }
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
                    Data.KillingSprees = KillingSprees;

                if (KillingSprees % 3 == 0)
                    SendClientMessageToAll(Color.Red, $"[Killing-Sprees]: {Color.Orange}{Name} lleva {KillingSprees} asesinatos seguidos sin morir.");
            }
        }

        public void SetNextRank()
        {
            if(Data.LevelGame != Rank.MAX_RANK && Data.TotalKills >= Rank.GetRequiredKills(Data.LevelGame + 1))
            {
                ++Data.LevelGame;
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
            if(Team != NoTeam)
                --PlayerTeam.Members;
            TextDrawGlobal.Hide(this);
            TextDrawPlayer.Hide(this);
            TextDrawEntry.Show(this);
            ForceClassSelection();
            ToggleSpectating(true);
            ToggleSpectating(false);
            IsStateUser = StateUser.Force;
        }

        public void SetPositionEx(Vector3 vector3, float angle, int interior = 0, int virtualworld = 0)
        {
            Position = vector3;
            Angle = angle;
            Interior = interior;
            VirtualWorld = virtualworld;
        }

        public bool IsAdminLevel(int levelid)
        {
            if (Data.LevelAdmin < levelid)
                SendClientMessage($"Error: Debes ser nivel {levelid} (Rango: {Rank.GetRankAdmin(levelid)}) para usar este comando.");
            return Data.LevelAdmin >= levelid;
        }

        public bool IsVipLevel(int levelid)
        {
            if (Data.LevelVip < levelid)
                SendClientMessage($"Error: Debes ser nivel {levelid} (Rango: {Rank.GetRankVip(levelid)}) para usar este comando.");
            return Data.LevelVip >= levelid;
        }

        public void Drop()
        {
            PlayerTeam.TeamRival.Drop(this);
        }

        public bool IsCapturedFlag()
        {
            return this == PlayerTeam.TeamRival.Flag.PlayerCaptured;
        }

        public void GiveWeapon(Weapon weapon)
        {
            GiveWeapon(weapon, 99999999);
        }

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

        public void SetAutoAssign()
        {
            if (TeamAlpha.Members == TeamBeta.Members)
                PlayerTeam = (Rand.Next(2) == (int)TeamID.Alpha) ? TeamAlpha : TeamBeta;
            else
                PlayerTeam = TeamAlpha.IsFull() ? TeamBeta : TeamAlpha;
            ++PlayerTeam.Members;
            TextDrawGlobal.UpdateCountUsers();
            Spawn();
        }

        public void HasAdrenaline(int amount)
        {
            if (Adrenaline < amount)
            {
                SendClientMessage(Color.Red, "Error: No tienes suficiente adrenalina.");
                throw new Exception();
            }
        }

        public void SetWeapon(Weapon weapon, int ammo)
        {
            SetAmmo(weapon, 0);
            GiveWeapon(weapon, ammo);
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

        public static Player Find(Player player, int playerid)
        {
            Player player1 = (Player)Find(playerid);
            if(player1 == null)
            {
                player.SendClientMessage(Color.Red, "Error: El jugador no está conectado.");
                throw new Exception();
            }
            return player1;
        }
    }
}