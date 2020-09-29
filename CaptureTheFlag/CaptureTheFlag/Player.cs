using System;
using System.Diagnostics.Tracing;
using SampSharp.GameMode;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;

namespace CaptureTheFlag
{
    public class Player : BasePlayer
    {
        public bool IsSelectionClass { get; set; } 
        public StateUser IsStateUser { get; set; }
        public PlayerData Data { get; set; }
        public Team PlayerTeam { get; set; }
 
        public Player()
        {
            Data = new PlayerData();
            IsStateUser = StateUser.None;
        }

        public void SetForceClass()
        {
            PlayerTeam.Members--;
            GameMode.TdGlobal.Hide(this);
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