namespace Pagino_Teka
{
    partial class AddBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox text_BookNote;
        private System.Windows.Forms.CheckedListBox checkedListBox_Gatunki;
        private System.Windows.Forms.Button button_AddPublisher, button_ZapiszKsiążkę, button_ZapiszKolejna, button_PobierzISBN, button_WybierzZDysku, button_Anuluj;
        private System.Windows.Forms.PictureBox pictureBox_Okladka;
        private System.Windows.Forms.RadioButton radioButton_Książka, radioButton_Ebook, radioButton_Audiobook;
        private System.Windows.Forms.RadioButton radioButton_NaPodFil, radioButton_NaPodGry;
        private System.Windows.Forms.GroupBox groupBox_PublicationType, groupBox_AdaptationType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_Publisher;
        private System.Windows.Forms.Label label_Cover, label_Notes;Label label_Title, label_Authors, label_ISBN, label_Genres, label_Publisher;
        private System.Windows.Forms.TextBox textBox_Isbn, textBox_Autorzy, textBox_BookTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            textBox_Isbn = new TextBox();
            button_PobierzISBN = new Button();
            textBox_BookTitle = new TextBox();
            label_Authors = new Label();
            textBox_Autorzy = new TextBox();
            label_ISBN = new Label();
            groupBox_PublicationType = new GroupBox();
            radioButton_Książka = new RadioButton();
            radioButton_Ebook = new RadioButton();
            radioButton_Audiobook = new RadioButton();
            label_Tome = new Label();
            textBox_Tome = new TextBox();
            label_Genres = new Label();
            label_Publisher = new Label();
            checkedListBox_Gatunki = new CheckedListBox();
            label_Series = new Label();
            comboBox_BookSeries = new ComboBox();
            label_Title = new Label();
            label_Pages = new Label();
            textBox_Pages = new TextBox();
            textBox_ReadTime = new TextBox();
            label_ReadTime = new Label();
            groupBox_AdaptationType = new GroupBox();
            radioButton_NaPodFil = new RadioButton();
            radioButton_NaPodGry = new RadioButton();
            comboBox_Publisher = new ComboBox();
            button_AddPublisher = new Button();
            label_Notes = new Label();
            text_BookNote = new RichTextBox();
            label_Cover = new Label();
            pictureBox_Okladka = new PictureBox();
            button_WybierzZDysku = new Button();
            button_ZapiszKsiążkę = new Button();
            button_ZapiszKolejna = new Button();
            button_Anuluj = new Button();
            groupBox2 = new GroupBox();
            label_Okładka = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox_PublicationType.SuspendLayout();
            groupBox_AdaptationType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Okladka).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 18);
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox_BookTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(label_Authors, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox_Autorzy, 1, 1);
            tableLayoutPanel1.Controls.Add(label_ISBN, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox_PublicationType, 1, 17);
            tableLayoutPanel1.Controls.Add(label_Tome, 0, 13);
            tableLayoutPanel1.Controls.Add(textBox_Tome, 1, 13);
            tableLayoutPanel1.Controls.Add(label_Genres, 0, 7);
            tableLayoutPanel1.Controls.Add(label_Publisher, 0, 18);
            tableLayoutPanel1.Controls.Add(checkedListBox_Gatunki, 1, 7);
            tableLayoutPanel1.Controls.Add(label_Series, 0, 10);
            tableLayoutPanel1.Controls.Add(comboBox_BookSeries, 1, 10);
            tableLayoutPanel1.Controls.Add(label_Title, 0, 0);
            tableLayoutPanel1.Controls.Add(label_Pages, 0, 14);
            tableLayoutPanel1.Controls.Add(textBox_Pages, 1, 14);
            tableLayoutPanel1.Controls.Add(textBox_ReadTime, 1, 15);
            tableLayoutPanel1.Controls.Add(label_ReadTime, 0, 15);
            tableLayoutPanel1.Controls.Add(groupBox_AdaptationType, 1, 16);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 19;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(388, 521);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_Isbn);
            groupBox1.Controls.Add(button_PobierzISBN);
            groupBox1.Location = new Point(123, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 23);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // textBox_Isbn
            // 
            textBox_Isbn.Location = new Point(0, 0);
            textBox_Isbn.Name = "textBox_Isbn";
            textBox_Isbn.Size = new Size(155, 23);
            textBox_Isbn.TabIndex = 5;
            // 
            // button_PobierzISBN
            // 
            button_PobierzISBN.Location = new Point(161, 0);
            button_PobierzISBN.Name = "button_PobierzISBN";
            button_PobierzISBN.Size = new Size(98, 23);
            button_PobierzISBN.TabIndex = 6;
            button_PobierzISBN.Text = "Pobierz z sieci";
            // 
            // textBox_BookTitle
            // 
            textBox_BookTitle.Location = new Point(123, 3);
            textBox_BookTitle.Name = "textBox_BookTitle";
            textBox_BookTitle.Size = new Size(259, 23);
            textBox_BookTitle.TabIndex = 1;
            // 
            // label_Authors
            // 
            label_Authors.Anchor = AnchorStyles.Left;
            label_Authors.Location = new Point(3, 33);
            label_Authors.Name = "label_Authors";
            label_Authors.Size = new Size(100, 20);
            label_Authors.TabIndex = 2;
            label_Authors.Text = "Autorzy :";
            label_Authors.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Autorzy
            // 
            textBox_Autorzy.Location = new Point(123, 32);
            textBox_Autorzy.Name = "textBox_Autorzy";
            textBox_Autorzy.Size = new Size(259, 23);
            textBox_Autorzy.TabIndex = 3;
            // 
            // label_ISBN
            // 
            label_ISBN.Anchor = AnchorStyles.Left;
            label_ISBN.Location = new Point(3, 62);
            label_ISBN.Name = "label_ISBN";
            label_ISBN.Size = new Size(100, 20);
            label_ISBN.TabIndex = 4;
            label_ISBN.Text = "Numer ISBN:";
            label_ISBN.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox_PublicationType
            // 
            groupBox_PublicationType.Controls.Add(radioButton_Książka);
            groupBox_PublicationType.Controls.Add(radioButton_Ebook);
            groupBox_PublicationType.Controls.Add(radioButton_Audiobook);
            groupBox_PublicationType.Location = new Point(123, 384);
            groupBox_PublicationType.Name = "groupBox_PublicationType";
            groupBox_PublicationType.Size = new Size(200, 100);
            groupBox_PublicationType.TabIndex = 20;
            groupBox_PublicationType.TabStop = false;
            groupBox_PublicationType.Text = "Wybierz jedną z opcji:";
            // 
            // radioButton_Książka
            // 
            radioButton_Książka.Location = new Point(6, 70);
            radioButton_Książka.Name = "radioButton_Książka";
            radioButton_Książka.Size = new Size(133, 24);
            radioButton_Książka.TabIndex = 0;
            radioButton_Książka.Text = "Książka drukowana";
            // 
            // radioButton_Ebook
            // 
            radioButton_Ebook.Location = new Point(6, 44);
            radioButton_Ebook.Name = "radioButton_Ebook";
            radioButton_Ebook.Size = new Size(104, 24);
            radioButton_Ebook.TabIndex = 1;
            radioButton_Ebook.Text = "Ebook";
            // 
            // radioButton_Audiobook
            // 
            radioButton_Audiobook.Location = new Point(6, 22);
            radioButton_Audiobook.Name = "radioButton_Audiobook";
            radioButton_Audiobook.Size = new Size(104, 24);
            radioButton_Audiobook.TabIndex = 2;
            radioButton_Audiobook.Text = "Audiobook";
            // 
            // label_Tome
            // 
            label_Tome.Anchor = AnchorStyles.Left;
            label_Tome.Location = new Point(3, 219);
            label_Tome.Name = "label_Tome";
            label_Tome.Size = new Size(100, 23);
            label_Tome.TabIndex = 11;
            label_Tome.Text = "Numer w serii:";
            label_Tome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Tome
            // 
            textBox_Tome.Location = new Point(123, 219);
            textBox_Tome.Name = "textBox_Tome";
            textBox_Tome.Size = new Size(100, 23);
            textBox_Tome.TabIndex = 12;
            // 
            // label_Genres
            // 
            label_Genres.Anchor = AnchorStyles.Left;
            label_Genres.Location = new Point(3, 125);
            label_Genres.Name = "label_Genres";
            label_Genres.Size = new Size(100, 23);
            label_Genres.TabIndex = 13;
            label_Genres.Text = "Gatunek:";
            // 
            // label_Publisher
            // 
            label_Publisher.Anchor = AnchorStyles.Left;
            label_Publisher.Location = new Point(3, 494);
            label_Publisher.Name = "label_Publisher";
            label_Publisher.Size = new Size(100, 20);
            label_Publisher.TabIndex = 15;
            label_Publisher.Text = "Wydawca";
            label_Publisher.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkedListBox_Gatunki
            // 
            checkedListBox_Gatunki.Location = new Point(123, 90);
            checkedListBox_Gatunki.Name = "checkedListBox_Gatunki";
            checkedListBox_Gatunki.Size = new Size(259, 94);
            checkedListBox_Gatunki.TabIndex = 14;
            // 
            // label_Series
            // 
            label_Series.Anchor = AnchorStyles.Left;
            label_Series.Location = new Point(3, 190);
            label_Series.Name = "label_Series";
            label_Series.Size = new Size(100, 23);
            label_Series.TabIndex = 18;
            label_Series.Text = "Tytuł serii:";
            label_Series.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_BookSeries
            // 
            comboBox_BookSeries.Location = new Point(123, 190);
            comboBox_BookSeries.Name = "comboBox_BookSeries";
            comboBox_BookSeries.Size = new Size(259, 23);
            comboBox_BookSeries.TabIndex = 19;
            // 
            // label_Title
            // 
            label_Title.Anchor = AnchorStyles.Left;
            label_Title.BackColor = SystemColors.Control;
            label_Title.Font = new Font("Segoe UI", 9F);
            label_Title.Location = new Point(3, 4);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(62, 20);
            label_Title.TabIndex = 0;
            label_Title.Text = "Tytuł:";
            label_Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Pages
            // 
            label_Pages.Anchor = AnchorStyles.Left;
            label_Pages.Location = new Point(3, 248);
            label_Pages.Name = "label_Pages";
            label_Pages.Size = new Size(100, 23);
            label_Pages.TabIndex = 7;
            label_Pages.Text = "Ilość stron:";
            label_Pages.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Pages
            // 
            textBox_Pages.Location = new Point(123, 248);
            textBox_Pages.Name = "textBox_Pages";
            textBox_Pages.Size = new Size(100, 23);
            textBox_Pages.TabIndex = 8;
            // 
            // textBox_ReadTime
            // 
            textBox_ReadTime.Location = new Point(123, 277);
            textBox_ReadTime.Name = "textBox_ReadTime";
            textBox_ReadTime.Size = new Size(100, 23);
            textBox_ReadTime.TabIndex = 10;
            // 
            // label_ReadTime
            // 
            label_ReadTime.Anchor = AnchorStyles.Left;
            label_ReadTime.Location = new Point(3, 277);
            label_ReadTime.Name = "label_ReadTime";
            label_ReadTime.Size = new Size(100, 23);
            label_ReadTime.TabIndex = 9;
            label_ReadTime.Text = "Czas czytania:";
            label_ReadTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox_AdaptationType
            // 
            groupBox_AdaptationType.Controls.Add(radioButton_NaPodFil);
            groupBox_AdaptationType.Controls.Add(radioButton_NaPodGry);
            groupBox_AdaptationType.Location = new Point(123, 306);
            groupBox_AdaptationType.Name = "groupBox_AdaptationType";
            groupBox_AdaptationType.Size = new Size(200, 72);
            groupBox_AdaptationType.TabIndex = 21;
            groupBox_AdaptationType.TabStop = false;
            groupBox_AdaptationType.Text = "Wybierz jedną z opcji";
            // 
            // radioButton_NaPodFil
            // 
            radioButton_NaPodFil.Location = new Point(6, 43);
            radioButton_NaPodFil.Name = "radioButton_NaPodFil";
            radioButton_NaPodFil.Size = new Size(141, 24);
            radioButton_NaPodFil.TabIndex = 0;
            radioButton_NaPodFil.Text = "Na podstawie filmu";
            // 
            // radioButton_NaPodGry
            // 
            radioButton_NaPodGry.Location = new Point(6, 22);
            radioButton_NaPodGry.Name = "radioButton_NaPodGry";
            radioButton_NaPodGry.Size = new Size(133, 24);
            radioButton_NaPodGry.TabIndex = 1;
            radioButton_NaPodGry.Text = "Na podstawie gry";
            // 
            // comboBox_Publisher
            // 
            comboBox_Publisher.Anchor = AnchorStyles.Left;
            comboBox_Publisher.Location = new Point(0, 3);
            comboBox_Publisher.Name = "comboBox_Publisher";
            comboBox_Publisher.Size = new Size(155, 23);
            comboBox_Publisher.TabIndex = 16;
            // 
            // button_AddPublisher
            // 
            button_AddPublisher.Location = new Point(161, 3);
            button_AddPublisher.Name = "button_AddPublisher";
            button_AddPublisher.Size = new Size(98, 23);
            button_AddPublisher.TabIndex = 17;
            button_AddPublisher.Text = "Dodaj wydawcę";
            // 
            // label_Notes
            // 
            label_Notes.Location = new Point(419, 322);
            label_Notes.Name = "label_Notes";
            label_Notes.Size = new Size(100, 23);
            label_Notes.TabIndex = 22;
            label_Notes.Text = "Opis książki:";
            // 
            // text_BookNote
            // 
            text_BookNote.Location = new Point(419, 348);
            text_BookNote.Name = "text_BookNote";
            text_BookNote.Size = new Size(306, 156);
            text_BookNote.TabIndex = 23;
            text_BookNote.Text = "";
            // 
            // label_Cover
            // 
            label_Cover.Location = new Point(650, 0);
            label_Cover.Name = "label_Cover";
            label_Cover.Size = new Size(100, 23);
            label_Cover.TabIndex = 6;
            // 
            // pictureBox_Okladka
            // 
            pictureBox_Okladka.Location = new Point(472, 30);
            pictureBox_Okladka.Name = "pictureBox_Okladka";
            pictureBox_Okladka.Size = new Size(216, 271);
            pictureBox_Okladka.TabIndex = 1;
            pictureBox_Okladka.TabStop = false;
            // 
            // button_WybierzZDysku
            // 
            button_WybierzZDysku.Location = new Point(573, 307);
            button_WybierzZDysku.Name = "button_WybierzZDysku";
            button_WybierzZDysku.Size = new Size(115, 23);
            button_WybierzZDysku.TabIndex = 2;
            button_WybierzZDysku.Text = "Wybierz z dysku:";
            // 
            // button_ZapiszKsiążkę
            // 
            button_ZapiszKsiążkę.Location = new Point(419, 510);
            button_ZapiszKsiążkę.Name = "button_ZapiszKsiążkę";
            button_ZapiszKsiążkę.Size = new Size(75, 23);
            button_ZapiszKsiążkę.TabIndex = 3;
            // 
            // button_ZapiszKolejna
            // 
            button_ZapiszKolejna.Location = new Point(500, 510);
            button_ZapiszKolejna.Name = "button_ZapiszKolejna";
            button_ZapiszKolejna.Size = new Size(75, 23);
            button_ZapiszKolejna.TabIndex = 4;
            // 
            // button_Anuluj
            // 
            button_Anuluj.Location = new Point(650, 510);
            button_Anuluj.Name = "button_Anuluj";
            button_Anuluj.Size = new Size(75, 23);
            button_Anuluj.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox_Publisher);
            groupBox2.Controls.Add(button_AddPublisher);
            groupBox2.Location = new Point(123, 490);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 27);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            // 
            // label_Okładka
            // 
            label_Okładka.AutoSize = true;
            label_Okładka.Location = new Point(541, 15);
            label_Okładka.Name = "label_Okładka";
            label_Okładka.Size = new Size(90, 15);
            label_Okładka.TabIndex = 24;
            label_Okładka.Text = "Okładka książki:";
            // 
            // AddBookForm
            // 
            ClientSize = new Size(746, 553);
            Controls.Add(label_Okładka);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox_Okladka);
            Controls.Add(button_WybierzZDysku);
            Controls.Add(button_ZapiszKsiążkę);
            Controls.Add(button_ZapiszKolejna);
            Controls.Add(button_Anuluj);
            Controls.Add(label_Notes);
            Controls.Add(text_BookNote);
            Controls.Add(label_Cover);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj książkę";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_PublicationType.ResumeLayout(false);
            groupBox_AdaptationType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Okladka).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private GroupBox groupBox1;
        private Label label_Tome;
        private TextBox textBox_Tome;
        private Label label_Series;
        private ComboBox comboBox_BookSeries;
        private Label label_Pages;
        private TextBox textBox_Pages;
        private TextBox textBox_ReadTime;
        private Label label_ReadTime;
        private GroupBox groupBox2;
        private Label label_Okładka;
    }
}
