using System;
using System.Diagnostics.Tracing;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.World;

namespace CaptureTheFlag
{
    public class Player : BasePlayer
    {
        private int adrenaline;

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public bool IsSelectionClass { get; set; } 
        public StateUser IsStateUser { get; set; }
        public PlayerData Data { get; set; }
        public Team PlayerTeam { get; set; }
        public PlayerTextDraw Stats { get; set; }

        public int Adrenaline
        {
            get { return adrenaline; }
            set
            {
                if (value <= 100)
                    adrenaline = value;
            }
        }

        public Player()
        {
            Data = new PlayerData();
            IsStateUser = StateUser.None;
            Stats = new PlayerTextDraw(this);
            TextDrawPlayer.CreateTDStats(Stats);
        }

        public void UpdateAdrenaline(int adrenaline)
        {
            Adrenaline += adrenaline;
            if(Adrenaline <= 100)
                TextDrawPlayer.UpdateTdStats(this);
        }

        public void SetForceClass()
        {
            if(Team != NoTeam)
                --PlayerTeam.Members;
            GameMode.TdGlobal.Hide(this);
            TextDrawPlayer.Hide(this);
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
    }

    public enum StateUser
    {
        Force,
        Kill,
        None
    }
}