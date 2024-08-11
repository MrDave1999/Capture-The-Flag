namespace CTF.Application.Players.Accounts;

internal class RoleCollection
{
    private RoleCollection() { }
    private static readonly RoleId[] s_roles = Enum.GetValues<RoleId>();
    public static IReadOnlyList<RoleId> GetAll() => s_roles;
    public static int Max => s_roles.Length;
}
