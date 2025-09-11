using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pagino_Teka
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Text = "O programie Pagino-Teka";

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                ColumnCount = 1,
                RowCount = 3,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Opis aplikacji
            var lblDescription = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(500, 0),
                Font = new Font("Segoe UI", 10),
                Text =
@"📚 Pagino-Teka
Twoja osobista biblioteka książek i filmów!

Aplikacja pozwala w prosty sposób zapisywać przeczytane książki 📖 i obejrzane filmy 🎬, przypisywać im gatunki oraz porządkować swoją kolekcję."
            };

            // Lista funkcjonalności
            var lblFeatures = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(500, 0),
                Font = new Font("Segoe UI", 9),
                Text =
@"🛠 Funkcjonalności Pagino-Teka:
- Dodawanie i edytowanie książek oraz filmów
- Wyszukiwanie książek po ISBN i automatyczne uzupełnianie danych z Open Library i Google Books
- Przypisywanie gatunków do książek i filmów
- Obsługa serii książek i numerów w cyklu
- Możliwość dodawania nowych autorów, wydawców i serii
- Zapis okładek i plików multimedialnych lokalnie
- Zmiana motywów: jasny 🌞 i ciemny 🌙
- Podgląd statystyk i liczby zapisanych elementów
- Przechowywanie danych w lokalnej, lekkiej bazie SQLite"
            };

            // Informacja o wersji
            string versionFull = Application.ProductVersion; // np. "1.0.0+abcdef" lub "1.0.0.5+abc"
            string versionClean = string.Join(".", versionFull.Split(new char[] { '.', '+' }, StringSplitOptions.RemoveEmptyEntries).Take(3));

            var lblVersion = new Label
            {
                AutoSize = true,
                Dock = DockStyle.Bottom,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Text = $"🔖 Wersja aplikacji: {versionClean}"
            };

            layout.Controls.Add(lblDescription, 0, 0);
            layout.Controls.Add(lblFeatures, 0, 1);
            layout.Controls.Add(lblVersion, 0, 2);

            Controls.Add(layout);

            // Zastosowanie motywu
            Theme.ThemeManager.ApplyTheme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
