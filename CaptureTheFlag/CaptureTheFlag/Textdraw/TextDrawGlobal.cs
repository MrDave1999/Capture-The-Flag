using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Textdraw
{
    public class TextDrawGlobal
    {
        public TextDraw TdCTF { get; set; }
        public TextDraw TdScoreAlpha { get; set; }
        public TextDraw TdScoreBeta { get; set; }

        public TextDrawGlobal()
        {
            TdCTF = new TextDraw();
            TdScoreAlpha = new TextDraw();
            TdScoreBeta = new TextDraw();
            Create();
        }

        public void Create()
        {
            TdCTF.Position = new Vector2(483.000000, 4.000000);
            TdCTF.Text = "Capture The Flag";
            TdCTF.Font = TextDrawFont.Diploma;
            TdCTF.LetterSize = new Vector2(0.680000, 1.799998);
            TdCTF.BackColor = 255;
            TdCTF.ForeColor = Color.Yellow;
            TdCTF.Outline = 1;
            TdCTF.Proportional = true;

            TdScoreAlpha.Position = new Vector2(36.000000, 305.000000);
            TdScoreAlpha.Text = $"~r~Alpha: 0";
            TdScoreAlpha.Font = TextDrawFont.Slim;
            TdScoreAlpha.LetterSize = new Vector2(0.330000, 1.100000);
            TdScoreAlpha.BackColor = 255;
            TdScoreAlpha.ForeColor = Color.Red;
            TdScoreAlpha.Outline = 1;
            TdScoreAlpha.Proportional = true;

            TdScoreBeta.Position = new Vector2(37.000000, 317.000000);
            TdScoreBeta.Text = "~b~Beta: 0";
            TdScoreBeta.Font = TextDrawFont.Slim;
            TdScoreBeta.LetterSize = new Vector2(0.330000, 1.100000);
            TdScoreBeta.BackColor = 255;
            TdScoreBeta.ForeColor = Color.Blue;
            TdScoreBeta.Outline = 1;
            TdScoreBeta.Proportional = true;
        }

        public void Show(Player player)
        {
            TdCTF.Show(player);
            TdScoreAlpha.Show(player);
            TdScoreBeta.Show(player);
        }

        public void Hide(Player player)
        {
            TdCTF.Hide(player);
            TdScoreAlpha.Hide(player);
            TdScoreBeta.Hide(player);
        }
    }
}
