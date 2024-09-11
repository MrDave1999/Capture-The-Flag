namespace CTF.Application.Players;

public class ClassSelectionSystem : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.AddComponent<ClassSelectionComponent>();
    }

    [Event]
    public void OnPlayerRequestClass(Player player, int classId)
    {
        if(player.HasForcedClassSelectionAfterDeath()) 
        {
            player.SetSpawnInfo(player.Team, player.Skin, player.Position, player.Angle);
            player.Spawn();
            return;
        }

        player.Color = Color.White;
        player.Position = new Vector3(-1389.137451, 3314.043701, 20.493314);
        player.CameraPosition = new Vector3(-1399.776000, 3310.254150, 21.525623);
        player.SetCameraLookAt(new Vector3(-1395.072143, 3311.873291, 22.027709));
        player.Angle = 111.68f;
        player.Interior = 0;
        player.PlaySound(soundId: 1132);
        Team selectedTeam = classId == (int)TeamId.Alpha ? Team.Alpha : Team.Beta;
        string gameText = selectedTeam.GetAvailabilityMessage();
        player.GameText(gameText, 999999999, 3);
        player.Team = (int)selectedTeam.Id;
    }
}
