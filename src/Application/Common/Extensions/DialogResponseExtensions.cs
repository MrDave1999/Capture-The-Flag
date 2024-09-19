namespace CTF.Application.Common.Extensions;

public static class DialogResponseExtensions
{
    public static bool IsRightButtonOrDisconnected(this ListDialogResponse response)
        => response.Response.IsRightButtonOrDisconnected();

    public static bool IsRightButtonOrDisconnected(this TablistDialogResponse response)
        => response.Response.IsRightButtonOrDisconnected();

    public static bool IsRightButtonOrDisconnected(this InputDialogResponse response)
        => response.Response.IsRightButtonOrDisconnected();

    private static bool IsRightButtonOrDisconnected(this DialogResponse response)
        => response == DialogResponse.RightButtonOrCancel ||
           response == DialogResponse.Disconnected;
}
