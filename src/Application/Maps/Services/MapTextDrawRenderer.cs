namespace CTF.Application.Maps.Services;

public class MapTextDrawRenderer
{
    private readonly IWorldService _worldService;
    private readonly MapInfoService _mapInfoService;
    private TextDraw _mapName;
    private TextDraw _timer;
    private TextDraw _timeLeft;

    public MapTextDrawRenderer(IWorldService worldService, MapInfoService mapInfoService)
    {
        _worldService = worldService;
        _mapInfoService = mapInfoService;
        Initialize();
    }

    public void Show(Player player)
    {
        _mapName.Show(player);
        _timer.Show(player);
        _timeLeft.Show(player);
    }

    public void Hide(Player player) 
    {
        _mapName.Hide(player);
        _timer.Hide(player);
        _timeLeft.Hide(player);
    }

    public void UpdateMapName()
    {
        CurrentMap currentMap = _mapInfoService.Read();
        _mapName.Text = currentMap.GetMapNameAsText();
    }

    public void UpdateTimeLeft(string text)
    {
        _timeLeft.Text = text;
    }

    private void Initialize()
    {
        _mapName = _worldService.CreateTextDraw(new Vector2(140.000000, 399.000000), string.Empty);
        _mapName.Text = "Map: ~w~RC Battlefield";
        _mapName.Font = TextDrawFont.Normal;
        _mapName.LetterSize = new Vector2(0.329166, 1.900000);
        _mapName.TextSize = new Vector2(400.000000, 17.000000);
        _mapName.Outline = 1;
        _mapName.Shadow = 0;
        _mapName.Alignment = TextDrawAlignment.Left;
        _mapName.ForeColor = new Color(-294256385);
        _mapName.BackColor = new Color(255);
        _mapName.BoxColor = new Color(50);
        _mapName.UseBox = false;
        _mapName.Proportional = true;
        _mapName.Selectable = false;

        _timer = _worldService.CreateTextDraw(new Vector2(566.000000, 395.000000), string.Empty);
        _timer.Text = "ld_grav:timer";
        _timer.Font = TextDrawFont.DrawSprite;
        _timer.LetterSize = new Vector2(0.600000, 2.000000);
        _timer.TextSize = new Vector2(17.000000, 17.000000);
        _timer.Outline = 1;
        _timer.Shadow = 0;
        _timer.Alignment = TextDrawAlignment.Left;
        _timer.ForeColor = new Color(-1);
        _timer.BackColor = new Color(255);
        _timer.BoxColor = new Color(50);
        _timer.UseBox = true;
        _timer.Proportional = true;
        _timer.Selectable = false;

        _timeLeft = _worldService.CreateTextDraw(new Vector2(586.000000, 397.000000), string.Empty);
        _timeLeft.Text = "00:00";
        _timeLeft.Font = TextDrawFont.Slim;
        _timeLeft.LetterSize = new Vector2(0.370833, 1.500000);
        _timeLeft.TextSize = new Vector2(400.000000, 17.000000);
        _timeLeft.Outline = 1;
        _timeLeft.Shadow = 0;
        _timeLeft.Alignment = TextDrawAlignment.Left;
        _timeLeft.ForeColor = new Color(-1);
        _timeLeft.BackColor = new Color(255);
        _timeLeft.BoxColor = new Color(0);
        _timeLeft.UseBox = true;
        _timeLeft.Proportional = true;
        _timeLeft.Selectable = false;
    }
}
