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
        public TextDraw TdCTF { get; set; }         = new TextDraw();
        public TextDraw TdScoreAlpha { get; set; }  = new TextDraw();
        public TextDraw TdScoreBeta { get; set; }   = new TextDraw();
        public TextDraw TdFlagRed { get; set; }     = new TextDraw();
        public TextDraw TdFlagBlue { get; set; }    = new TextDraw();

        public TextDrawGlobal()
        {
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

            TdFlagRed.Position = new Vector2(-7.000000, 264.000000);
            TdFlagRed.Text = "Preview_Model";
            TdFlagRed.Font = TextDrawFont.PreviewModel;
            TdFlagRed.Outline = 0;
            TdFlagRed.Shadow = 0;
            TdFlagRed.LetterSize = new Vector2(0.600000, 2.000000);
            TdFlagRed.ForeColor = Color.Red;
            TdFlagRed.PreviewModel = 19306;
            TdFlagRed.PreviewRotation = new Vector3(-10.000000, 0.000000, -20.000000);
            TdFlagRed.PreviewZoom = 1.000000f;
            TdFlagRed.BackColor = 0;
            TdFlagRed.BoxColor = 255;
            TdFlagRed.Proportional = true;
            TdFlagRed.Height = 50.000000f;
            TdFlagRed.Width = 59.500000f;

            TdFlagBlue.Position = new Vector2(-6.000000, 302.000000);
            TdFlagBlue.Text = "Preview_Model";
            TdFlagBlue.Font = TextDrawFont.PreviewModel;
            TdFlagBlue.Outline = 0;
            TdFlagBlue.Shadow = 0;
            TdFlagBlue.LetterSize = new Vector2(0.600000, 2.000000);
            TdFlagBlue.ForeColor = Color.Blue;
            TdFlagBlue.PreviewModel = 19307;
            TdFlagBlue.PreviewRotation = new Vector3(-10.000000, 0.000000, -20.000000);
            TdFlagBlue.PreviewZoom = 1.000000f;
            TdFlagBlue.BackColor =  0;
            TdFlagBlue.BoxColor = 255;
            TdFlagBlue.Proportional = true;
            TdFlagBlue.Height = 50.000000f;
            TdFlagBlue.Width = 59.500000f;

            TdScoreAlpha.Position = new Vector2(46.000000, 279.000000);
            TdScoreAlpha.Text = "~r~Alpha: 0";
            TdScoreAlpha.Font = TextDrawFont.Slim;
            TdScoreAlpha.LetterSize = new Vector2(0.262497, 1.299998);
            TdScoreAlpha.BackColor = 255;
            TdScoreAlpha.ForeColor = Color.Red;
            TdScoreAlpha.Outline = 1;

            TdScoreBeta.Position = new Vector2(46.000000, 316.000000);
            TdScoreBeta.Text = "~b~Beta: 0";
            TdScoreBeta.Font = TextDrawFont.Slim;
            TdScoreBeta.LetterSize = new Vector2(0.262497, 1.299998);
            TdScoreBeta.BackColor = 255;
            TdScoreBeta.ForeColor = Color.Blue;
            TdScoreBeta.Outline = 1;
        }

        public void Show(Player player)
        {
            TdCTF.Show(player);
            TdScoreAlpha.Show(player);
            TdScoreBeta.Show(player);
            TdFlagRed.Show(player);
            TdFlagBlue.Show(player);
        }

        public void Hide(Player player)
        {
            TdCTF.Hide(player);
            TdScoreAlpha.Hide(player);
            TdScoreBeta.Hide(player);
            TdFlagRed.Hide(player);
            TdFlagBlue.Hide(player);
        }
    }
}
