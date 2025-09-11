namespace Pagino_Teka
{
    partial class AddBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox_BookTitle;
        private System.Windows.Forms.TextBox textBox_Autorzy;
        private System.Windows.Forms.TextBox textBox_Isbn;
        private System.Windows.Forms.TextBox textBox_Pages;
        private System.Windows.Forms.TextBox textBox_ReadTime;
        private System.Windows.Forms.TextBox textBox_Tome;
        private System.Windows.Forms.RichTextBox text_BookNote;
        private System.Windows.Forms.CheckedListBox checkedListBox_Gatunki;
        private System.Windows.Forms.ComboBox comboBox_Publisher;
        private System.Windows.Forms.ComboBox comboBox_BookSeries;
        private System.Windows.Forms.Button button_AddPublisher;
        private System.Windows.Forms.Button button_ZapiszKsiążkę;
        private System.Windows.Forms.Button button_ZapiszKolejna;
        private System.Windows.Forms.Button button_PobierzISBN;
        private System.Windows.Forms.Button button_WybierzZDysku;
        private System.Windows.Forms.Button button_Anuluj;
        private System.Windows.Forms.PictureBox pictureBox_Okladka;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButton_Książka;
        private System.Windows.Forms.RadioButton radioButton_Ebook;
        private System.Windows.Forms.RadioButton radioButton_Audiobook;
        private System.Windows.Forms.RadioButton radioButton_NaPodFil;
        private System.Windows.Forms.RadioButton radioButton_NaPodGry;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Authors;
        private System.Windows.Forms.Label label_ISBN;
        private System.Windows.Forms.Label label_Pages;
        private System.Windows.Forms.Label label_ReadTime;
        private System.Windows.Forms.Label label_Tome;
        private System.Windows.Forms.Label label_Publisher;
        private System.Windows.Forms.Label label_Series;
        private System.Windows.Forms.Label label_Genres;
        private System.Windows.Forms.Label label_Cover;
        private System.Windows.Forms.Label label_Notes;
        private System.Windows.Forms.GroupBox groupBox_PublicationType;
        private System.Windows.Forms.GroupBox groupBox_AdaptationType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // TextBoxes
            this.textBox_BookTitle = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 20), Size = new System.Drawing.Size(400, 22), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            this.textBox_Autorzy = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 60), Size = new System.Drawing.Size(400, 22), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            this.textBox_Isbn = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 100), Size = new System.Drawing.Size(250, 22), Anchor = AnchorStyles.Top | AnchorStyles.Left };
            this.textBox_Pages = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 140), Size = new System.Drawing.Size(100, 22) };
            this.textBox_ReadTime = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(320, 140), Size = new System.Drawing.Size(100, 22) };
            this.textBox_Tome = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 180), Size = new System.Drawing.Size(100, 22) };

            // RichTextBox for Notes
            this.text_BookNote = new System.Windows.Forms.RichTextBox() { Location = new System.Drawing.Point(120, 400), Size = new System.Drawing.Size(400, 120), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            // CheckedListBox for Genres
            this.checkedListBox_Gatunki = new System.Windows.Forms.CheckedListBox() { Location = new System.Drawing.Point(120, 220), Size = new System.Drawing.Size(400, 150), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            // ComboBoxes
            this.comboBox_Publisher = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(120, 330), Size = new System.Drawing.Size(250, 22) };
            this.comboBox_BookSeries = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(120, 360), Size = new System.Drawing.Size(250, 22) };

            // Buttons
            this.button_AddPublisher = new System.Windows.Forms.Button() { Text = "Dodaj wydawcę", Location = new System.Drawing.Point(380, 330), Size = new System.Drawing.Size(140, 25) };
            this.button_PobierzISBN = new System.Windows.Forms.Button() { Text = "Pobierz po ISBN", Location = new System.Drawing.Point(380, 100), Size = new System.Drawing.Size(140, 25) };
            this.button_WybierzZDysku = new System.Windows.Forms.Button() { Text = "Wybierz z dysku", Location = new System.Drawing.Point(650, 330), Size = new System.Drawing.Size(140, 25) };
            this.button_ZapiszKsiążkę = new System.Windows.Forms.Button() { Text = "Zapisz", Location = new System.Drawing.Point(600, 540), Size = new System.Drawing.Size(100, 30), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
            this.button_ZapiszKolejna = new System.Windows.Forms.Button() { Text = "Zapisz i dodaj kolejną", Location = new System.Drawing.Point(710, 540), Size = new System.Drawing.Size(150, 30), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
            this.button_Anuluj = new System.Windows.Forms.Button() { Text = "Anuluj", Location = new System.Drawing.Point(870, 540), Size = new System.Drawing.Size(100, 30), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };

            // PictureBox
            this.pictureBox_Okladka = new System.Windows.Forms.PictureBox() { Location = new System.Drawing.Point(650, 20), Size = new System.Drawing.Size(320, 300), SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom, BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            // RadioButtons
            this.radioButton_Książka = new System.Windows.Forms.RadioButton() { Text = "Książka", Location = new System.Drawing.Point(10, 20) };
            this.radioButton_Ebook = new System.Windows.Forms.RadioButton() { Text = "E-book", Location = new System.Drawing.Point(100, 20) };
            this.radioButton_Audiobook = new System.Windows.Forms.RadioButton() { Text = "Audiobook", Location = new System.Drawing.Point(200, 20) };

            this.radioButton_NaPodFil = new System.Windows.Forms.RadioButton() { Text = "Na podstawie filmu", Location = new System.Drawing.Point(10, 20) };
            this.radioButton_NaPodGry = new System.Windows.Forms.RadioButton() { Text = "Na podstawie gry", Location = new System.Drawing.Point(160, 20) };

            // GroupBoxes
            this.groupBox_PublicationType = new System.Windows.Forms.GroupBox() { Text = "Rodzaj wydania", Location = new System.Drawing.Point(120, 220), Size = new System.Drawing.Size(320, 50) };
            this.groupBox_PublicationType.Controls.Add(this.radioButton_Książka);
            this.groupBox_PublicationType.Controls.Add(this.radioButton_Ebook);
            this.groupBox_PublicationType.Controls.Add(this.radioButton_Audiobook);

            this.groupBox_AdaptationType = new System.Windows.Forms.GroupBox() { Text = "Adaptacja", Location = new System.Drawing.Point(120, 280), Size = new System.Drawing.Size(320, 50) };
            this.groupBox_AdaptationType.Controls.Add(this.radioButton_NaPodFil);
            this.groupBox_AdaptationType.Controls.Add(this.radioButton_NaPodGry);

            // Labels
            this.label_Title = new System.Windows.Forms.Label() { Text = "Tytuł:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.label_Authors = new System.Windows.Forms.Label() { Text = "Autorzy:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.label_ISBN = new System.Windows.Forms.Label() { Text = "ISBN:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            this.label_Pages = new System.Windows.Forms.Label() { Text = "Liczba stron:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            this.label_ReadTime = new System.Windows.Forms.Label() { Text = "Czas czytania:", Location = new System.Drawing.Point(240, 140), AutoSize = true };
            this.label_Tome = new System.Windows.Forms.Label() { Text = "Tom:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            this.label_Publisher = new System.Windows.Forms.Label() { Text = "Wydawca:", Location = new System.Drawing.Point(20, 330), AutoSize = true };
            this.label_Series = new System.Windows.Forms.Label() { Text = "Seria:", Location = new System.Drawing.Point(20, 360), AutoSize = true };
            this.label_Genres = new System.Windows.Forms.Label() { Text = "Gatunki:", Location = new System.Drawing.Point(20, 220), AutoSize = true };
            this.label_Cover = new System.Windows.Forms.Label() { Text = "Okładka:", Location = new System.Drawing.Point(650, 0), AutoSize = true };
            this.label_Notes = new System.Windows.Forms.Label() { Text = "Notatki:", Location = new System.Drawing.Point(20, 400), AutoSize = true };

            // Form properties
            this.Text = "Dodaj książkę";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.AutoScroll = true;

            // Add controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                textBox_BookTitle, textBox_Autorzy, textBox_Isbn, textBox_Pages, textBox_ReadTime, textBox_Tome,
                text_BookNote, checkedListBox_Gatunki, comboBox_Publisher, comboBox_BookSeries, button_AddPublisher,
                button_PobierzISBN, button_WybierzZDysku, button_ZapiszKsiążkę, button_ZapiszKolejna, button_Anuluj,
                pictureBox_Okladka, groupBox_PublicationType, groupBox_AdaptationType,
                label_Title, label_Authors, label_ISBN, label_Pages, label_ReadTime, label_Tome,
                label_Publisher, label_Series, label_Genres, label_Cover, label_Notes
            });
        }
    }
}
