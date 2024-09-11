namespace CTF.Application.Players.Extensions;

public static class ClassSelectionExtensions
{
    public static bool IsInClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection;

    public static bool IsNotInClassSelection(this Player player)
        => !player.IsInClassSelection();

    public static bool HasForcedClassSelectionAfterDeath(this Player player)
        => !player.IsInClassSelection();

    public static void SetInClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection = true;

    public static void RemoveFromClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection = false;
}
