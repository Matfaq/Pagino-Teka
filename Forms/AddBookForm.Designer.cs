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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            this.label_Title = new Label();
            this.textBox_BookTitle = new TextBox();
            this.label_Authors = new Label();
            this.textBox_Autorzy = new TextBox();
            this.label_ISBN = new Label();
            this.textBox_Isbn = new TextBox();
            button_PobierzISBN = new Button();
            this.label_Genres = new Label();
            checkedListBox_Gatunki = new CheckedListBox();
            this.label_Publisher = new Label();
            this.comboBox_Publisher = new ComboBox();
            button_AddPublisher = new Button();
            groupBox_PublicationType = new GroupBox();
            radioButton_Książka = new RadioButton();
            radioButton_Ebook = new RadioButton();
            radioButton_Audiobook = new RadioButton();
            groupBox_AdaptationType = new GroupBox();
            radioButton_NaPodFil = new RadioButton();
            radioButton_NaPodGry = new RadioButton();
            this.label_Notes = new Label();
            text_BookNote = new RichTextBox();
            this.label_Cover = new Label();
            pictureBox_Okladka = new PictureBox();
            button_WybierzZDysku = new Button();
            button_ZapiszKsiążkę = new Button();
            button_ZapiszKolejna = new Button();
            button_Anuluj = new Button();
            groupBox1 = new GroupBox();
            comboBox_BookSeries = new ComboBox();
            label_Series = new Label();
            textBox_Tome = new TextBox();
            label_Tome = new Label();
            textBox_Pages = new TextBox();
            label_Pages = new Label();
            textBox_ReadTime = new TextBox();
            label_ReadTime = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox_PublicationType.SuspendLayout();
            groupBox_AdaptationType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Okladka).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 2);
            tableLayoutPanel1.Controls.Add(this.textBox_BookTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(this.label_Authors, 0, 1);
            tableLayoutPanel1.Controls.Add(this.textBox_Autorzy, 1, 1);
            tableLayoutPanel1.Controls.Add(this.label_ISBN, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox_PublicationType, 1, 17);
            tableLayoutPanel1.Controls.Add(label_Tome, 0, 13);
            tableLayoutPanel1.Controls.Add(textBox_Tome, 1, 13);
            tableLayoutPanel1.Controls.Add(this.label_Genres, 0, 7);
            tableLayoutPanel1.Controls.Add(this.comboBox_Publisher, 1, 18);
            tableLayoutPanel1.Controls.Add(this.label_Publisher, 0, 18);
            tableLayoutPanel1.Controls.Add(checkedListBox_Gatunki, 1, 7);
            tableLayoutPanel1.Controls.Add(label_Series, 0, 10);
            tableLayoutPanel1.Controls.Add(comboBox_BookSeries, 1, 10);
            tableLayoutPanel1.Controls.Add(this.label_Title, 0, 0);
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
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(388, 521);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label_Title
            // 
            this.label_Title.Anchor = AnchorStyles.Left;
            this.label_Title.BackColor = SystemColors.Control;
            this.label_Title.Font = new Font("Segoe UI", 9F);
            this.label_Title.Location = new Point(3, 4);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new Size(62, 20);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Tytuł:";
            this.label_Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_BookTitle
            // 
            this.textBox_BookTitle.Location = new Point(123, 3);
            this.textBox_BookTitle.Name = "textBox_BookTitle";
            this.textBox_BookTitle.Size = new Size(259, 23);
            this.textBox_BookTitle.TabIndex = 1;
            // 
            // label_Authors
            // 
            this.label_Authors.Anchor = AnchorStyles.Left;
            this.label_Authors.Location = new Point(3, 33);
            this.label_Authors.Name = "label_Authors";
            this.label_Authors.Size = new Size(100, 20);
            this.label_Authors.TabIndex = 2;
            this.label_Authors.Text = "Autorzy :";
            this.label_Authors.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Autorzy
            // 
            this.textBox_Autorzy.Location = new Point(123, 32);
            this.textBox_Autorzy.Name = "textBox_Autorzy";
            this.textBox_Autorzy.Size = new Size(259, 23);
            this.textBox_Autorzy.TabIndex = 3;
            // 
            // label_ISBN
            // 
            this.label_ISBN.Anchor = AnchorStyles.Left;
            this.label_ISBN.Location = new Point(3, 62);
            this.label_ISBN.Name = "label_ISBN";
            this.label_ISBN.Size = new Size(100, 20);
            this.label_ISBN.TabIndex = 4;
            this.label_ISBN.Text = "Numer ISBN:";
            this.label_ISBN.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Isbn
            // 
            this.textBox_Isbn.Location = new Point(0, 0);
            this.textBox_Isbn.Name = "textBox_Isbn";
            this.textBox_Isbn.Size = new Size(155, 23);
            this.textBox_Isbn.TabIndex = 5;
            // 
            // button_PobierzISBN
            // 
            button_PobierzISBN.Location = new Point(161, 0);
            button_PobierzISBN.Name = "button_PobierzISBN";
            button_PobierzISBN.Size = new Size(98, 23);
            button_PobierzISBN.TabIndex = 6;
            button_PobierzISBN.Text = "Pobierz z sieci";
            // 
            // label_Genres
            // 
            this.label_Genres.Anchor = AnchorStyles.Left;
            this.label_Genres.Location = new Point(3, 126);
            this.label_Genres.Name = "label_Genres";
            this.label_Genres.Size = new Size(100, 23);
            this.label_Genres.TabIndex = 13;
            this.label_Genres.Text = "Gatunek:";
            // 
            // checkedListBox_Gatunki
            // 
            checkedListBox_Gatunki.Location = new Point(123, 90);
            checkedListBox_Gatunki.Name = "checkedListBox_Gatunki";
            checkedListBox_Gatunki.Size = new Size(259, 94);
            checkedListBox_Gatunki.TabIndex = 14;
            // 
            // label_Publisher
            // 
            this.label_Publisher.Anchor = AnchorStyles.Left;
            this.label_Publisher.Location = new Point(3, 495);
            this.label_Publisher.Name = "label_Publisher";
            this.label_Publisher.Size = new Size(100, 20);
            this.label_Publisher.TabIndex = 15;
            this.label_Publisher.Text = "Wydawca";
            this.label_Publisher.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_Publisher
            // 
            this.comboBox_Publisher.Location = new Point(123, 492);
            this.comboBox_Publisher.Name = "comboBox_Publisher";
            this.comboBox_Publisher.Size = new Size(259, 23);
            this.comboBox_Publisher.TabIndex = 16;
            // 
            // button_AddPublisher
            // 
            button_AddPublisher.Location = new Point(571, 240);
            button_AddPublisher.Name = "button_AddPublisher";
            button_AddPublisher.Size = new Size(75, 23);
            button_AddPublisher.TabIndex = 17;
            // 
            // groupBox_PublicationType
            // 
            groupBox_PublicationType.Controls.Add(radioButton_Książka);
            groupBox_PublicationType.Controls.Add(radioButton_Ebook);
            groupBox_PublicationType.Controls.Add(radioButton_Audiobook);
            groupBox_PublicationType.Location = new Point(123, 386);
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
            // groupBox_AdaptationType
            // 
            groupBox_AdaptationType.Controls.Add(radioButton_NaPodFil);
            groupBox_AdaptationType.Controls.Add(radioButton_NaPodGry);
            groupBox_AdaptationType.Location = new Point(123, 308);
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
            // label_Notes
            // 
            this.label_Notes.Location = new Point(746, 656);
            this.label_Notes.Name = "label_Notes";
            this.label_Notes.Size = new Size(100, 23);
            this.label_Notes.TabIndex = 22;
            this.label_Notes.Text = "Opis książki:";
            // 
            // text_BookNote
            // 
            text_BookNote.Location = new Point(814, 616);
            text_BookNote.Name = "text_BookNote";
            text_BookNote.Size = new Size(100, 96);
            text_BookNote.TabIndex = 23;
            text_BookNote.Text = "";
            // 
            // label_Cover
            // 
            this.label_Cover.Location = new Point(650, 0);
            this.label_Cover.Name = "label_Cover";
            this.label_Cover.Size = new Size(100, 23);
            this.label_Cover.TabIndex = 6;
            // 
            // pictureBox_Okladka
            // 
            pictureBox_Okladka.Location = new Point(746, 17);
            pictureBox_Okladka.Name = "pictureBox_Okladka";
            pictureBox_Okladka.Size = new Size(100, 50);
            pictureBox_Okladka.TabIndex = 1;
            pictureBox_Okladka.TabStop = false;
            // 
            // button_WybierzZDysku
            // 
            button_WybierzZDysku.Location = new Point(650, 330);
            button_WybierzZDysku.Name = "button_WybierzZDysku";
            button_WybierzZDysku.Size = new Size(75, 23);
            button_WybierzZDysku.TabIndex = 2;
            // 
            // button_ZapiszKsiążkę
            // 
            button_ZapiszKsiążkę.Location = new Point(650, 540);
            button_ZapiszKsiążkę.Name = "button_ZapiszKsiążkę";
            button_ZapiszKsiążkę.Size = new Size(75, 23);
            button_ZapiszKsiążkę.TabIndex = 3;
            // 
            // button_ZapiszKolejna
            // 
            button_ZapiszKolejna.Location = new Point(760, 540);
            button_ZapiszKolejna.Name = "button_ZapiszKolejna";
            button_ZapiszKolejna.Size = new Size(75, 23);
            button_ZapiszKolejna.TabIndex = 4;
            // 
            // button_Anuluj
            // 
            button_Anuluj.Location = new Point(920, 540);
            button_Anuluj.Name = "button_Anuluj";
            button_Anuluj.Size = new Size(75, 23);
            button_Anuluj.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.textBox_Isbn);
            groupBox1.Controls.Add(button_PobierzISBN);
            groupBox1.Location = new Point(123, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 23);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // comboBox_BookSeries
            // 
            comboBox_BookSeries.Location = new Point(123, 192);
            comboBox_BookSeries.Name = "comboBox_BookSeries";
            comboBox_BookSeries.Size = new Size(259, 23);
            comboBox_BookSeries.TabIndex = 19;
            // 
            // label_Series
            // 
            label_Series.Anchor = AnchorStyles.Left;
            label_Series.Location = new Point(3, 192);
            label_Series.Name = "label_Series";
            label_Series.Size = new Size(100, 23);
            label_Series.TabIndex = 18;
            label_Series.Text = "Tytuł serii:";
            label_Series.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Tome
            // 
            textBox_Tome.Location = new Point(123, 221);
            textBox_Tome.Name = "textBox_Tome";
            textBox_Tome.Size = new Size(100, 23);
            textBox_Tome.TabIndex = 12;
            // 
            // label_Tome
            // 
            label_Tome.Anchor = AnchorStyles.Left;
            label_Tome.Location = new Point(3, 221);
            label_Tome.Name = "label_Tome";
            label_Tome.Size = new Size(100, 23);
            label_Tome.TabIndex = 11;
            label_Tome.Text = "Numer w serii:";
            label_Tome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Pages
            // 
            textBox_Pages.Location = new Point(123, 250);
            textBox_Pages.Name = "textBox_Pages";
            textBox_Pages.Size = new Size(100, 23);
            textBox_Pages.TabIndex = 8;
            // 
            // label_Pages
            // 
            label_Pages.Anchor = AnchorStyles.Left;
            label_Pages.Location = new Point(3, 250);
            label_Pages.Name = "label_Pages";
            label_Pages.Size = new Size(100, 23);
            label_Pages.TabIndex = 7;
            label_Pages.Text = "Ilość stron:";
            label_Pages.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_ReadTime
            // 
            textBox_ReadTime.Location = new Point(123, 279);
            textBox_ReadTime.Name = "textBox_ReadTime";
            textBox_ReadTime.Size = new Size(100, 23);
            textBox_ReadTime.TabIndex = 10;
            // 
            // label_ReadTime
            // 
            label_ReadTime.Anchor = AnchorStyles.Left;
            label_ReadTime.Location = new Point(3, 279);
            label_ReadTime.Name = "label_ReadTime";
            label_ReadTime.Size = new Size(100, 23);
            label_ReadTime.TabIndex = 9;
            label_ReadTime.Text = "Czas czytania:";
            label_ReadTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddBookForm
            // 
            ClientSize = new Size(1023, 737);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox_Okladka);
            Controls.Add(button_WybierzZDysku);
            Controls.Add(button_ZapiszKsiążkę);
            Controls.Add(button_ZapiszKolejna);
            Controls.Add(button_Anuluj);
            Controls.Add(this.label_Notes);
            Controls.Add(text_BookNote);
            Controls.Add(this.label_Cover);
            Controls.Add(button_AddPublisher);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj książkę";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox_PublicationType.ResumeLayout(false);
            groupBox_AdaptationType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Okladka).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
