using System.Drawing;

namespace Pagino_Teka.Theme
{
    public class Theme
    {
        public Color Background { get; set; }
        public Color Foreground { get; set; }
        public Color MenuBackground { get; set; }
        public Color MenuForeground { get; set; }
        public Color ButtonBackground { get; set; }
        public Color ButtonForeground { get; set; }
        public Color TextBoxBackground { get; set; }
        public Color TextBoxForeground { get; set; }
        public Color ListBackground { get; set; }
        public Color ListForeground { get; set; }
        public Color GridHeaderBackground { get; set; }
        public Color GridHeaderForeground { get; set; }
    }

    public static class Themes
    {
        public static Theme Dark = new Theme
        {
            Background = Color.FromArgb(77, 77, 77),          // g³ówne t³o – ciemny grafit
            Foreground = Color.Gainsboro,                     // jasny, ale nie czysto bia³y
            MenuBackground = Color.FromArgb(60, 60, 60),      // typowe dla menu Win dark
            MenuForeground = Color.WhiteSmoke,
            ButtonBackground = Color.FromArgb(63, 63, 70),    // lekko jaœniejsze przyciski
            ButtonForeground = Color.WhiteSmoke,
            TextBoxBackground = Color.FromArgb(77, 77, 77),   // ciemne pola tekstowe
            TextBoxForeground = Color.WhiteSmoke,
            ListBackground = Color.FromArgb(77, 77, 77),      // listy z tym samym kolorem co textbox
            ListForeground = Color.Gainsboro,
            GridHeaderBackground = Color.FromArgb(63, 63, 70),// nag³ówki tabel jak w Visual Studio
            GridHeaderForeground = Color.WhiteSmoke
        };


        public static Theme Light = new Theme
        {
            Background = Color.FromArgb(245, 245, 250),        // z³amana biel (lekko szarawa)
            Foreground = Color.FromArgb(45, 45, 60),           // ciemny grafit z nut¹ fioletu

            MenuBackground = Color.FromArgb(230, 225, 245),    // jasny pastelowy fiolet
            MenuForeground = Color.FromArgb(60, 45, 80),       // g³êbszy fiolet dla kontrastu

            ButtonBackground = Color.FromArgb(210, 200, 235),  // delikatny liliowy
            ButtonForeground = Color.FromArgb(50, 35, 70),     // ciemny fioletowy tekst

            TextBoxBackground = Color.WhiteSmoke,              // lekko szare t³o textboxów
            TextBoxForeground = Color.FromArgb(40, 30, 60),    // grafitowo-fioletowy

            ListBackground = Color.FromArgb(240, 238, 250),    // bardzo jasny lawendowy
            ListForeground = Color.FromArgb(60, 45, 80),       // ciemny fiolet

            GridHeaderBackground = Color.FromArgb(200, 190, 225), // lawendowy nag³ówek
            GridHeaderForeground = Color.FromArgb(30, 20, 50)     // g³êboki fiolet
        };

    }
}