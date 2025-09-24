namespace Pagino_Teka
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            DodajKsiążkęToolStripMenuItem = new ToolStripMenuItem();
            edytujPozycjęToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            dodajFilmToolStripMenuItem = new ToolStripMenuItem();
            edytujPozycjęToolStripMenuItem1 = new ToolStripMenuItem();
            ustawieniaToolStripMenuItem = new ToolStripMenuItem();
            motywToolStripMenuItem = new ToolStripMenuItem();
            jasnyToolStripMenuItem = new ToolStripMenuItem();
            ciemnyToolStripMenuItem = new ToolStripMenuItem();
            konfiguracjaToolStripMenuItem = new ToolStripMenuItem();
            tworzenieKopiiBazyDanychToolStripMenuItem = new ToolStripMenuItem();
            przywracanieKopiiDanychToolStripMenuItem = new ToolStripMenuItem();
            pomocToolStripMenuItem = new ToolStripMenuItem();
            oProgramieToolStripMenuItem = new ToolStripMenuItem();
            wyjścieToolStripMenuItem = new ToolStripMenuItem();
            statustoolStripMenuItem3 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelBooks = new ToolStripStatusLabel();
            toolStripStatusLabelPages = new ToolStripStatusLabel();
            toolStripStatusLabelReadTime = new ToolStripStatusLabel();
            toolStripStatusLabelFilms = new ToolStripStatusLabel();
            toolStripStatusLabelFilmLength = new ToolStripStatusLabel();
            wyszukajKsiążkęToolStripMenuItem = new ToolStripMenuItem();
            poTytuleToolStripMenuItem = new ToolStripMenuItem();
            poAutorzeToolStripMenuItem = new ToolStripMenuItem();
            poSeriiToolStripMenuItem = new ToolStripMenuItem();
            poWydawcyToolStripMenuItem = new ToolStripMenuItem();
            poGatunkuToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, ustawieniaToolStripMenuItem, pomocToolStripMenuItem, wyjścieToolStripMenuItem, statustoolStripMenuItem3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1008, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { DodajKsiążkęToolStripMenuItem, edytujPozycjęToolStripMenuItem, wyszukajKsiążkęToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(119, 20);
            toolStripMenuItem1.Text = "Przeczytane Książki";
            // 
            // DodajKsiążkęToolStripMenuItem
            // 
            DodajKsiążkęToolStripMenuItem.Name = "DodajKsiążkęToolStripMenuItem";
            DodajKsiążkęToolStripMenuItem.Size = new Size(180, 22);
            DodajKsiążkęToolStripMenuItem.Text = "Dodaj Książkę";
            DodajKsiążkęToolStripMenuItem.Click += DodajKsiążkęToolStripMenuItem_Click;
            // 
            // edytujPozycjęToolStripMenuItem
            // 
            edytujPozycjęToolStripMenuItem.Name = "edytujPozycjęToolStripMenuItem";
            edytujPozycjęToolStripMenuItem.Size = new Size(180, 22);
            edytujPozycjęToolStripMenuItem.Text = "Edytuj pozycję";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { dodajFilmToolStripMenuItem, edytujPozycjęToolStripMenuItem1 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(109, 20);
            toolStripMenuItem2.Text = "Oglądnięte Filmy";
            // 
            // dodajFilmToolStripMenuItem
            // 
            dodajFilmToolStripMenuItem.Name = "dodajFilmToolStripMenuItem";
            dodajFilmToolStripMenuItem.Size = new Size(150, 22);
            dodajFilmToolStripMenuItem.Text = "Dodaj Film";
            dodajFilmToolStripMenuItem.Click += dodajFilmToolStripMenuItem_Click;
            // 
            // edytujPozycjęToolStripMenuItem1
            // 
            edytujPozycjęToolStripMenuItem1.Name = "edytujPozycjęToolStripMenuItem1";
            edytujPozycjęToolStripMenuItem1.Size = new Size(150, 22);
            edytujPozycjęToolStripMenuItem1.Text = "Edytuj pozycję";
            // 
            // ustawieniaToolStripMenuItem
            // 
            ustawieniaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { motywToolStripMenuItem, konfiguracjaToolStripMenuItem, tworzenieKopiiBazyDanychToolStripMenuItem, przywracanieKopiiDanychToolStripMenuItem });
            ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            ustawieniaToolStripMenuItem.Size = new Size(76, 20);
            ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // motywToolStripMenuItem
            // 
            motywToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jasnyToolStripMenuItem, ciemnyToolStripMenuItem });
            motywToolStripMenuItem.Name = "motywToolStripMenuItem";
            motywToolStripMenuItem.Size = new Size(224, 22);
            motywToolStripMenuItem.Text = "Motyw";
            // 
            // jasnyToolStripMenuItem
            // 
            jasnyToolStripMenuItem.Name = "jasnyToolStripMenuItem";
            jasnyToolStripMenuItem.Size = new Size(115, 22);
            jasnyToolStripMenuItem.Text = "Jasny";
            jasnyToolStripMenuItem.Click += jasnyToolStripMenuItem_Click;
            // 
            // ciemnyToolStripMenuItem
            // 
            ciemnyToolStripMenuItem.Name = "ciemnyToolStripMenuItem";
            ciemnyToolStripMenuItem.Size = new Size(115, 22);
            ciemnyToolStripMenuItem.Text = "Ciemny";
            ciemnyToolStripMenuItem.Click += ciemnyToolStripMenuItem_Click;
            // 
            // konfiguracjaToolStripMenuItem
            // 
            konfiguracjaToolStripMenuItem.Name = "konfiguracjaToolStripMenuItem";
            konfiguracjaToolStripMenuItem.Size = new Size(224, 22);
            konfiguracjaToolStripMenuItem.Text = "Konfiguracja";
            konfiguracjaToolStripMenuItem.Click += konfiguracjaToolStripMenuItem_Click;
            // 
            // tworzenieKopiiBazyDanychToolStripMenuItem
            // 
            tworzenieKopiiBazyDanychToolStripMenuItem.Name = "tworzenieKopiiBazyDanychToolStripMenuItem";
            tworzenieKopiiBazyDanychToolStripMenuItem.Size = new Size(224, 22);
            tworzenieKopiiBazyDanychToolStripMenuItem.Text = "Tworzenie kopii bazy danych";
            tworzenieKopiiBazyDanychToolStripMenuItem.Click += tworzenieKopiiBazyDanychToolStripMenuItem_Click;
            // 
            // przywracanieKopiiDanychToolStripMenuItem
            // 
            przywracanieKopiiDanychToolStripMenuItem.Name = "przywracanieKopiiDanychToolStripMenuItem";
            przywracanieKopiiDanychToolStripMenuItem.Size = new Size(224, 22);
            przywracanieKopiiDanychToolStripMenuItem.Text = "Przywracanie kopii danych";
            przywracanieKopiiDanychToolStripMenuItem.Click += przywracanieKopiiDanychToolStripMenuItem_Click;
            // 
            // pomocToolStripMenuItem
            // 
            pomocToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { oProgramieToolStripMenuItem });
            pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            pomocToolStripMenuItem.Size = new Size(57, 20);
            pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgramieToolStripMenuItem
            // 
            oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            oProgramieToolStripMenuItem.Size = new Size(141, 22);
            oProgramieToolStripMenuItem.Text = "O programie";
            oProgramieToolStripMenuItem.Click += oProgramieToolStripMenuItem_Click;
            // 
            // wyjścieToolStripMenuItem
            // 
            wyjścieToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            wyjścieToolStripMenuItem.Size = new Size(59, 20);
            wyjścieToolStripMenuItem.Text = "Wyjście";
            wyjścieToolStripMenuItem.Click += wyjścieToolStripMenuItem_Click;
            // 
            // statustoolStripMenuItem3
            // 
            statustoolStripMenuItem3.Name = "statustoolStripMenuItem3";
            statustoolStripMenuItem3.Size = new Size(51, 20);
            statustoolStripMenuItem3.Text = "Status";
            statustoolStripMenuItem3.Click += statustoolStripMenuItem3_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelBooks, toolStripStatusLabelPages, toolStripStatusLabelReadTime, toolStripStatusLabelFilms, toolStripStatusLabelFilmLength });
            statusStrip1.Location = new Point(0, 707);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1008, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelBooks
            // 
            toolStripStatusLabelBooks.Name = "toolStripStatusLabelBooks";
            toolStripStatusLabelBooks.Size = new Size(118, 17);
            toolStripStatusLabelBooks.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelPages
            // 
            toolStripStatusLabelPages.Name = "toolStripStatusLabelPages";
            toolStripStatusLabelPages.Size = new Size(118, 17);
            toolStripStatusLabelPages.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelReadTime
            // 
            toolStripStatusLabelReadTime.Name = "toolStripStatusLabelReadTime";
            toolStripStatusLabelReadTime.Size = new Size(118, 17);
            toolStripStatusLabelReadTime.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabelFilms
            // 
            toolStripStatusLabelFilms.Name = "toolStripStatusLabelFilms";
            toolStripStatusLabelFilms.Size = new Size(118, 17);
            toolStripStatusLabelFilms.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabelFilmLength
            // 
            toolStripStatusLabelFilmLength.Name = "toolStripStatusLabelFilmLength";
            toolStripStatusLabelFilmLength.Size = new Size(118, 17);
            toolStripStatusLabelFilmLength.Text = "toolStripStatusLabel3";
            // 
            // wyszukajKsiążkęToolStripMenuItem
            // 
            wyszukajKsiążkęToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { poTytuleToolStripMenuItem, poAutorzeToolStripMenuItem, poSeriiToolStripMenuItem, poWydawcyToolStripMenuItem, poGatunkuToolStripMenuItem });
            wyszukajKsiążkęToolStripMenuItem.Name = "wyszukajKsiążkęToolStripMenuItem";
            wyszukajKsiążkęToolStripMenuItem.Size = new Size(180, 22);
            wyszukajKsiążkęToolStripMenuItem.Text = "Wyszukaj Książkę";
            // 
            // poTytuleToolStripMenuItem
            // 
            poTytuleToolStripMenuItem.Name = "poTytuleToolStripMenuItem";
            poTytuleToolStripMenuItem.Size = new Size(180, 22);
            poTytuleToolStripMenuItem.Text = "Po tytule";
            poTytuleToolStripMenuItem.Click += poTytuleToolStripMenuItem_Click;
            // 
            // poAutorzeToolStripMenuItem
            // 
            poAutorzeToolStripMenuItem.Name = "poAutorzeToolStripMenuItem";
            poAutorzeToolStripMenuItem.Size = new Size(180, 22);
            poAutorzeToolStripMenuItem.Text = "Po autorze";
            // 
            // poSeriiToolStripMenuItem
            // 
            poSeriiToolStripMenuItem.Name = "poSeriiToolStripMenuItem";
            poSeriiToolStripMenuItem.Size = new Size(180, 22);
            poSeriiToolStripMenuItem.Text = "Po serii";
            // 
            // poWydawcyToolStripMenuItem
            // 
            poWydawcyToolStripMenuItem.Name = "poWydawcyToolStripMenuItem";
            poWydawcyToolStripMenuItem.Size = new Size(180, 22);
            poWydawcyToolStripMenuItem.Text = "Po wydawcy";
            // 
            // poGatunkuToolStripMenuItem
            // 
            poGatunkuToolStripMenuItem.Name = "poGatunkuToolStripMenuItem";
            poGatunkuToolStripMenuItem.Size = new Size(180, 22);
            poGatunkuToolStripMenuItem.Text = "Po gatunku";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1024, 768);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagino-Teka";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem pomocToolStripMenuItem;
        private ToolStripMenuItem wyjścieToolStripMenuItem;
        private ToolStripMenuItem DodajKsiążkęToolStripMenuItem;
        private ToolStripMenuItem dodajFilmToolStripMenuItem;
        private ToolStripMenuItem edytujPozycjęToolStripMenuItem;
        private ToolStripMenuItem edytujPozycjęToolStripMenuItem1;
        private ToolStripMenuItem oProgramieToolStripMenuItem;
        private ToolStripMenuItem ustawieniaToolStripMenuItem;
        private ToolStripMenuItem motywToolStripMenuItem;
        private ToolStripMenuItem jasnyToolStripMenuItem;
        private ToolStripMenuItem ciemnyToolStripMenuItem;
        private ToolStripMenuItem statustoolStripMenuItem3;
        private ToolStripMenuItem konfiguracjaToolStripMenuItem;
        private ToolStripMenuItem przywracanieKopiiDanychToolStripMenuItem;
        private ToolStripMenuItem tworzenieKopiiBazyDanychToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelBooks;
        private ToolStripStatusLabel toolStripStatusLabelFilms;
        private ToolStripStatusLabel toolStripStatusLabelPages;
        private ToolStripStatusLabel toolStripStatusLabelReadTime;
        private ToolStripStatusLabel toolStripStatusLabelFilmLength;
        private ToolStripMenuItem wyszukajKsiążkęToolStripMenuItem;
        private ToolStripMenuItem poTytuleToolStripMenuItem;
        private ToolStripMenuItem poAutorzeToolStripMenuItem;
        private ToolStripMenuItem poSeriiToolStripMenuItem;
        private ToolStripMenuItem poWydawcyToolStripMenuItem;
        private ToolStripMenuItem poGatunkuToolStripMenuItem;
    }
}
