namespace Persistence.Tests.Common;

public class FakePasswordHasher : IPasswordHasher
{
    public string HashPassword(string text) => text;
    public bool Verify(string text, string passwordHash) => text == passwordHash;
}
