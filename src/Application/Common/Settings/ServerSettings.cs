namespace CTF.Application.Common.Settings;

public class ServerSettings
{
    public string HostName { get; init; } = string.Empty;
    public string LanguageText { get; init; } = string.Empty;
    public string GameModeText { get; init; } = string.Empty;
    public string MapName { get; init; } = string.Empty;
    public string WebUrl { get; init; } = string.Empty;
    public string IntroAudioUrl { get; init; } = string.Empty;
    public string HeadshotAudioUrl { get; init; } = string.Empty;
    public int FlagAutoReturnTime { get; init; } = 120;
}
