using CaptureTheFlag.Events;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using System.Reflection;

namespace CaptureTheFlag.Textdraw
{
    public static class ExtensionTextdraw
    {
        public static void ShowAll(this TextDraw td)
        {
            foreach (Player player in Player.GetAll())
                td.Show(player);
        }
    }

    public static class TextDrawGlobal
    {
        public static TextDraw TdCTF { get; set; }         
        public static TextDraw TdScoreAlpha { get; set; }  
        public static TextDraw TdScoreBeta { get; set; }   
        public static TextDraw TdFlagRed { get; set; }    
        public static TextDraw TdFlagBlue { get; set; }    
        public static TextDraw TdClock { get; set; }       
        public static TextDraw TdTimeLeft { get; set; }    
        public static TextDraw TdCountUsers { get; set; }  
        public static TextDraw TdBox1 { get; set; }        
        public static TextDraw TdBox2 { get; set; }       
        public static TextDraw TdRank { get; set; }        
        public static TextDraw TdStar1 { get; set; }       
        public static TextDraw TdStar2 { get; set; }       

        public static void Create()
        {
            TdCTF           = new TextDraw();
            TdScoreAlpha    = new TextDraw();
            TdScoreBeta     = new TextDraw();
            TdFlagRed       = new TextDraw();
            TdFlagBlue      = new TextDraw();
            TdClock         = new TextDraw();
            TdTimeLeft      = new TextDraw();
            TdCountUsers    = new TextDraw();
            TdBox1          = new TextDraw();
            TdBox2          = new TextDraw();
            TdRank          = new TextDraw();
            TdStar1         = new TextDraw();
            TdStar2         = new TextDraw();

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

            TdClock.Position = new Vector2(513.000000, 100.000000);
            TdClock.Text = "ld_grav:timer";
            TdClock.Font = TextDrawFont.DrawSprite;
            TdClock.LetterSize = new Vector2(0.600000, 2.000000);
            TdClock.Height = 17.000000f;
            TdClock.Width = 17.000000f;
            TdClock.Outline = 1;
            TdClock.Shadow = 0;
            TdClock.BackColor = 255;
            TdClock.BoxColor = 50;
            TdClock.Proportional = true;

            TdTimeLeft.Position = new Vector2(533.000000, 102.000000);
            TdTimeLeft.Text = "24:59";
            TdTimeLeft.Font = TextDrawFont.Slim;
            TdTimeLeft.LetterSize = new Vector2(0.370833, 1.500000);
            TdTimeLeft.Outline = 1;
            TdTimeLeft.Shadow = 0;
            TdTimeLeft.ForeColor = -1;
            TdTimeLeft.BackColor = 255;
            TdTimeLeft.Proportional = true;

            TdCountUsers.Position = new Vector2(3.000000, 431.000000);
            TdCountUsers.Text = "users: ~r~0~w~/~b~0";
            TdCountUsers.Font = TextDrawFont.Pricedown;
            TdCountUsers.LetterSize = new Vector2(0.495833, 1.649999);
            TdCountUsers.Outline = 1;
            TdCountUsers.ForeColor = -1;
            TdCountUsers.BackColor = 255;
            TdCountUsers.Proportional = true;

            TdBox1.Position = new Vector2(565.000000, 386.000000);
            TdBox1.Text = "_";
            TdBox1.Font = TextDrawFont.Normal;
            TdBox1.LetterSize = new Vector2(0.600000, 3.599993);
            TdBox1.Alignment = TextDrawAlignment.Center;
            TdBox1.ForeColor = -1;
            TdBox1.BackColor = 255;
            TdBox1.BoxColor = 135;
            TdBox1.UseBox = true;
            TdBox1.Proportional = true;
            TdBox1.Width = 302.500000f;
            TdBox1.Height = 101.000000f; 

            TdBox2.Position = new Vector2(499.000000, 386.000000);
            TdBox2.Text = "_";
            TdBox2.Font = TextDrawFont.Normal;
            TdBox2.LetterSize = new Vector2(0.600000, 3.599993);
            TdBox2.Alignment = TextDrawAlignment.Center;
            TdBox2.ForeColor = -1;
            TdBox2.BackColor = 255;
            TdBox2.BoxColor = 135;
            TdBox2.UseBox = true;
            TdBox2.Proportional = true;
            TdBox2.Width = 302.500000f;
            TdBox2.Height = 16.000000f;

            TdRank.Position = new Vector2(599.000000, 389.000000);
            TdRank.Text = "Your rank is:";
            TdRank.Font = TextDrawFont.Normal;
            TdRank.LetterSize = new Vector2(0.337500, 1.249999);
            TdRank.Outline = 1;
            TdRank.Alignment = TextDrawAlignment.Right;
            TdRank.ForeColor = 16711935;
            TdRank.BackColor = 255; 
            TdRank.Proportional = true;

            TdStar1.Position = new Vector2(475.000000, 388.000000);
            TdStar1.Text = "[]";
            TdStar1.Font = TextDrawFont.Slim;
            TdStar1.LetterSize = new Vector2(0.520833, 1.400000);
            TdStar1.ForeColor = 16711935;
            TdStar1.BackColor = 255;
            TdStar1.BoxColor = 135;
            TdStar1.Proportional = true;

            TdStar2.Position = new Vector2(475.000000, 404.000000);
            TdStar2.Text = "[]";
            TdStar2.Font = TextDrawFont.Slim;
            TdStar2.LetterSize = new Vector2(0.520833, 1.400000);
            TdStar2.ForeColor = 16711935;
            TdStar2.BackColor = 255;
            TdStar2.BoxColor = 135;
            TdStar2.Proportional = true;
        }

        public static void Show(Player player)
        {
            TdCTF.Show(player);
            TdScoreAlpha.Show(player);
            TdScoreBeta.Show(player);
            TdFlagRed.Show(player);
            TdFlagBlue.Show(player);
            TdClock.Show(player);
            TdTimeLeft.Show(player);
            TdCountUsers.Show(player);
            TdBox1.Show(player);
            TdBox2.Show(player);
            TdRank.Show(player);
            TdStar1.Show(player);
            TdStar2.Show(player);
        }

        public static void Hide(Player player)
        {
            TdCTF.Hide(player);
            TdScoreAlpha.Hide(player);
            TdScoreBeta.Hide(player);
            TdFlagRed.Hide(player);
            TdFlagBlue.Hide(player);
            TdClock.Hide(player);
            TdTimeLeft.Hide(player);
            TdCountUsers.Hide(player);
            TdBox1.Hide(player);
            TdBox2.Hide(player);
            TdRank.Hide(player);
            TdStar1.Hide(player);
            TdStar2.Hide(player);
        }

        public static void Destroy()
        {
            TdCTF.Dispose();
            TdScoreAlpha.Dispose();
            TdScoreBeta.Dispose();
            TdFlagRed.Dispose();
            TdFlagBlue.Dispose();
            TdClock.Dispose();
            TdTimeLeft.Dispose();
            TdCountUsers.Dispose();
            TdBox1.Dispose();
            TdBox2.Dispose();
            TdRank.Dispose();
            TdStar1.Dispose();
            TdStar2.Dispose();
        }

        public static void UpdateCountUsers()
        {
            TdCountUsers.Text = $"users: ~r~{GameMode.TeamAlpha.Members}~w~/~b~{GameMode.TeamBeta.Members}";
            TdCountUsers.ShowAll();
        }
    }
}
