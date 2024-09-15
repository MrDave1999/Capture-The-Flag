namespace CTF.Application.Teams.ClassSelection;

public static class ClassSelectionExtensions
{
    public static bool IsInClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection;

    public static bool IsNotInClassSelection(this Player player)
        => !player.IsInClassSelection();

    public static bool HasForcedClassSelectionAfterDeath(this Player player)
        => !player.IsInClassSelection();

    public static void EnableClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection = true;

    public static void DisableClassSelection(this Player player)
        => player.GetComponent<ClassSelectionComponent>().IsInClassSelection = false;

    public static void RedirectToClassSelection(this Player player)
    {
        player.EnableClassSelection();
        player.ForceClassSelection();
        player.ToggleSpectating(true);
        player.ToggleSpectating(false);
    }
}
