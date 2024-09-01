namespace CTF.Application.Common.NativeObjects;

public class ServerTimeNativeObject : NativeObjectSingleton<ServerTimeNativeObject>
{
    #pragma warning disable IDE1006
    [NativeMethod]
    public virtual int gettime(out int hour, out int minute, out int second)
        => throw new NativeNotImplementedException();
}
