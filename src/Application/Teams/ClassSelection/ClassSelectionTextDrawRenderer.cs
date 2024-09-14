namespace CTF.Application.Teams.ClassSelection;

public class ClassSelectionTextDrawRenderer
{
    private readonly IWorldService _worldService;
    private TextDraw _gameModeTitle;
    private TextDraw _gameModeDescription;
    private TextDraw _commandList;
    private TextDraw _blueCommandListBox;

    public ClassSelectionTextDrawRenderer(IWorldService worldService)
    {
        _worldService = worldService;
        Initialize();
    }

    public void Show(Player player)
    {
        _gameModeDescription.Show(player);
        _commandList.Show(player);
        _blueCommandListBox.Show(player);
        _gameModeTitle.Show(player);
    }

    public void Hide(Player player)
    {
        _gameModeDescription.Hide(player);
        _commandList.Hide(player);
        _blueCommandListBox.Hide(player);
    }

    private void Initialize()
    {
        _gameModeTitle = _worldService.CreateTextDraw(new Vector2(483.000000, 4.000000), string.Empty);
        _gameModeTitle.Text = "Capture The Flag";
        _gameModeTitle.Font = TextDrawFont.Diploma;
        _gameModeTitle.LetterSize = new Vector2(0.680000, 1.799998);
        _gameModeTitle.BackColor = 255;
        _gameModeTitle.ForeColor = Color.Yellow;
        _gameModeTitle.Outline = 1;
        _gameModeTitle.Proportional = true;

        _gameModeDescription = _worldService.CreateTextDraw(new Vector2(18.000000, 225.000000), string.Empty);
        _gameModeDescription.Text = Messages.GameModeDescription;
        _gameModeDescription.Font = TextDrawFont.Normal;
        _gameModeDescription.LetterSize = new Vector2(0.320833, 1.300000);
        _gameModeDescription.TextSize = new Vector2(227.000000, 42.000000);
        _gameModeDescription.Outline = 1;
        _gameModeDescription.Shadow = 0;
        _gameModeDescription.Alignment = TextDrawAlignment.Left;
        _gameModeDescription.ForeColor = new Color(-1);
        _gameModeDescription.BackColor = new Color(255);
        _gameModeDescription.BoxColor = new Color(65368);
        _gameModeDescription.UseBox = true;
        _gameModeDescription.Proportional = true;
        _gameModeDescription.Selectable = false;

        _commandList = _worldService.CreateTextDraw(new Vector2(616.000000, 431.000000), string.Empty);
        _commandList.Text = "~r~/cmds ~y~/help ~p~~h~/weapons ~g~/pack ~r~/combos ~y~/stats ~p~~h~/tstats ~g~/team ~w~/admins";
        _commandList.Font = TextDrawFont.Pricedown;
        _commandList.LetterSize = new Vector2(0.479166, 1.500000);
        _commandList.TextSize = new Vector2(400.000000, 17.000000);
        _commandList.Outline = 1;
        _commandList.Shadow = 0;
        _commandList.Alignment = TextDrawAlignment.Right;
        _commandList.ForeColor = new Color(-1);
        _commandList.BackColor = new Color(255);
        _commandList.BoxColor = new Color(50);
        _commandList.UseBox = true;
        _commandList.Proportional = true;
        _commandList.Selectable = false;

        _blueCommandListBox = _worldService.CreateTextDraw(new Vector2(319.000000, 430.000000), "_");
        _blueCommandListBox.Font = TextDrawFont.Normal;
        _blueCommandListBox.LetterSize = new Vector2(0.612500, 1.649996);
        _blueCommandListBox.TextSize = new Vector2(303.000000, 633.000000);
        _blueCommandListBox.Outline = 1;
        _blueCommandListBox.Shadow = 0;
        _blueCommandListBox.Alignment = TextDrawAlignment.Center;
        _blueCommandListBox.ForeColor = new Color(65535);
        _blueCommandListBox.BackColor = new Color(255);
        _blueCommandListBox.BoxColor = new Color(65368);
        _blueCommandListBox.UseBox = true;
        _blueCommandListBox.Proportional = true;
        _blueCommandListBox.Selectable = false;
    }
}
