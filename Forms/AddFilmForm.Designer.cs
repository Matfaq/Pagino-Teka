namespace Pagino_Teka
{
    partial class AddFilmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_FilmTitle = new TextBox();
            label_Tytuł = new Label();
            label_Reżyser = new Label();
            textBox_FilmDirector = new TextBox();
            label_Scenariusz = new Label();
            textBox_FilmScreenwriter = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox_FilmTitle = new GroupBox();
            button_PobierzDaneOmdb = new Button();
            label_Opis = new Label();
            label_NaPodstawie = new Label();
            textBox_Language = new TextBox();
            label_Język = new Label();
            label_Gatunek = new Label();
            textBox_RunTime = new TextBox();
            label_CzasTrwania = new Label();
            label_RokProdukcji = new Label();
            textBox_FilmYear = new TextBox();
            groupBox_NaPodstawie = new GroupBox();
            radioButton_NP3 = new RadioButton();
            radioButton_NP2 = new RadioButton();
            radioButton_NP1 = new RadioButton();
            textBox_description = new TextBox();
            checkedListBox_FGatunki = new CheckedListBox();
            button_Anuluj = new Button();
            pictureBox_Plakat = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            label_Plakat = new Label();
            button_WybierzPlakat = new Button();
            button_ZapiszFilm = new Button();
            tableLayoutPanel1.SuspendLayout();
            groupBox_FilmTitle.SuspendLayout();
            groupBox_NaPodstawie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Plakat).BeginInit();
            SuspendLayout();
            // 
            // textBox_FilmTitle
            // 
            textBox_FilmTitle.Location = new Point(7, 2);
            textBox_FilmTitle.MaxLength = 200;
            textBox_FilmTitle.Name = "textBox_FilmTitle";
            textBox_FilmTitle.Size = new Size(283, 23);
            textBox_FilmTitle.TabIndex = 0;
            // 
            // label_Tytuł
            // 
            label_Tytuł.Anchor = AnchorStyles.Left;
            label_Tytuł.AutoSize = true;
            label_Tytuł.Location = new Point(3, 25);
            label_Tytuł.Name = "label_Tytuł";
            label_Tytuł.Size = new Size(69, 15);
            label_Tytuł.TabIndex = 1;
            label_Tytuł.Text = "Tytuł filmu :";
            // 
            // label_Reżyser
            // 
            label_Reżyser.Anchor = AnchorStyles.Left;
            label_Reżyser.AutoSize = true;
            label_Reżyser.Location = new Point(3, 73);
            label_Reżyser.Name = "label_Reżyser";
            label_Reżyser.Size = new Size(61, 15);
            label_Reżyser.TabIndex = 2;
            label_Reżyser.Text = "Reżyseria :";
            // 
            // textBox_FilmDirector
            // 
            textBox_FilmDirector.Location = new Point(120, 69);
            textBox_FilmDirector.MaxLength = 300;
            textBox_FilmDirector.Name = "textBox_FilmDirector";
            textBox_FilmDirector.Size = new Size(289, 23);
            textBox_FilmDirector.TabIndex = 3;
            // 
            // label_Scenariusz
            // 
            label_Scenariusz.Anchor = AnchorStyles.Left;
            label_Scenariusz.AutoSize = true;
            label_Scenariusz.Location = new Point(3, 102);
            label_Scenariusz.Name = "label_Scenariusz";
            label_Scenariusz.Size = new Size(68, 15);
            label_Scenariusz.TabIndex = 4;
            label_Scenariusz.Text = "Scenariusz :";
            // 
            // textBox_FilmScreenwriter
            // 
            textBox_FilmScreenwriter.Location = new Point(120, 98);
            textBox_FilmScreenwriter.MaxLength = 300;
            textBox_FilmScreenwriter.Name = "textBox_FilmScreenwriter";
            textBox_FilmScreenwriter.Size = new Size(289, 23);
            textBox_FilmScreenwriter.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.Controls.Add(groupBox_FilmTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(label_Opis, 0, 8);
            tableLayoutPanel1.Controls.Add(label_NaPodstawie, 0, 7);
            tableLayoutPanel1.Controls.Add(textBox_Language, 1, 6);
            tableLayoutPanel1.Controls.Add(label_Język, 0, 6);
            tableLayoutPanel1.Controls.Add(label_Gatunek, 0, 5);
            tableLayoutPanel1.Controls.Add(textBox_RunTime, 1, 4);
            tableLayoutPanel1.Controls.Add(label_CzasTrwania, 0, 4);
            tableLayoutPanel1.Controls.Add(label_Scenariusz, 0, 2);
            tableLayoutPanel1.Controls.Add(label_Reżyser, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox_FilmDirector, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox_FilmScreenwriter, 1, 2);
            tableLayoutPanel1.Controls.Add(label_RokProdukcji, 0, 3);
            tableLayoutPanel1.Controls.Add(textBox_FilmYear, 1, 3);
            tableLayoutPanel1.Controls.Add(groupBox_NaPodstawie, 1, 7);
            tableLayoutPanel1.Controls.Add(textBox_description, 1, 8);
            tableLayoutPanel1.Controls.Add(label_Tytuł, 0, 0);
            tableLayoutPanel1.Controls.Add(checkedListBox_FGatunki, 1, 5);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(419, 540);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // groupBox_FilmTitle
            // 
            groupBox_FilmTitle.Controls.Add(textBox_FilmTitle);
            groupBox_FilmTitle.Controls.Add(button_PobierzDaneOmdb);
            groupBox_FilmTitle.Location = new Point(120, 3);
            groupBox_FilmTitle.Name = "groupBox_FilmTitle";
            groupBox_FilmTitle.Size = new Size(296, 60);
            groupBox_FilmTitle.TabIndex = 18;
            groupBox_FilmTitle.TabStop = false;
            // 
            // button_PobierzDaneOmdb
            // 
            button_PobierzDaneOmdb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_PobierzDaneOmdb.Location = new Point(6, 31);
            button_PobierzDaneOmdb.Name = "button_PobierzDaneOmdb";
            button_PobierzDaneOmdb.Size = new Size(283, 23);
            button_PobierzDaneOmdb.TabIndex = 16;
            button_PobierzDaneOmdb.Text = "Pobierz dane z bazy Omdb";
            button_PobierzDaneOmdb.UseVisualStyleBackColor = true;
            button_PobierzDaneOmdb.Click += button_PobierzDaneOmdb_Click;
            // 
            // label_Opis
            // 
            label_Opis.Anchor = AnchorStyles.Left;
            label_Opis.AutoSize = true;
            label_Opis.Location = new Point(3, 491);
            label_Opis.Name = "label_Opis";
            label_Opis.Size = new Size(68, 15);
            label_Opis.TabIndex = 18;
            label_Opis.Text = "Opis filmu :";
            // 
            // label_NaPodstawie
            // 
            label_NaPodstawie.Anchor = AnchorStyles.Left;
            label_NaPodstawie.AutoSize = true;
            label_NaPodstawie.Location = new Point(3, 395);
            label_NaPodstawie.Name = "label_NaPodstawie";
            label_NaPodstawie.Size = new Size(85, 15);
            label_NaPodstawie.TabIndex = 17;
            label_NaPodstawie.Text = "Na podstawie :";
            // 
            // textBox_Language
            // 
            textBox_Language.Location = new Point(120, 321);
            textBox_Language.Name = "textBox_Language";
            textBox_Language.Size = new Size(193, 23);
            textBox_Language.TabIndex = 14;
            // 
            // label_Język
            // 
            label_Język.Anchor = AnchorStyles.Left;
            label_Język.AutoSize = true;
            label_Język.Location = new Point(3, 325);
            label_Język.Name = "label_Język";
            label_Język.Size = new Size(40, 15);
            label_Język.TabIndex = 13;
            label_Język.Text = "Język :";
            // 
            // label_Gatunek
            // 
            label_Gatunek.Anchor = AnchorStyles.Left;
            label_Gatunek.AutoSize = true;
            label_Gatunek.Location = new Point(3, 242);
            label_Gatunek.Name = "label_Gatunek";
            label_Gatunek.Size = new Size(57, 15);
            label_Gatunek.TabIndex = 10;
            label_Gatunek.Text = "Gatunek :";
            // 
            // textBox_RunTime
            // 
            textBox_RunTime.Location = new Point(120, 156);
            textBox_RunTime.MaxLength = 4;
            textBox_RunTime.Name = "textBox_RunTime";
            textBox_RunTime.Size = new Size(193, 23);
            textBox_RunTime.TabIndex = 9;
            // 
            // label_CzasTrwania
            // 
            label_CzasTrwania.Anchor = AnchorStyles.Left;
            label_CzasTrwania.AutoSize = true;
            label_CzasTrwania.Location = new Point(3, 160);
            label_CzasTrwania.Name = "label_CzasTrwania";
            label_CzasTrwania.Size = new Size(79, 15);
            label_CzasTrwania.TabIndex = 8;
            label_CzasTrwania.Text = "Czas trwania :";
            // 
            // label_RokProdukcji
            // 
            label_RokProdukcji.Anchor = AnchorStyles.Left;
            label_RokProdukcji.AutoSize = true;
            label_RokProdukcji.Location = new Point(3, 131);
            label_RokProdukcji.Name = "label_RokProdukcji";
            label_RokProdukcji.Size = new Size(86, 15);
            label_RokProdukcji.TabIndex = 6;
            label_RokProdukcji.Text = "Rok produkcji :";
            // 
            // textBox_FilmYear
            // 
            textBox_FilmYear.Location = new Point(120, 127);
            textBox_FilmYear.MaxLength = 4;
            textBox_FilmYear.Name = "textBox_FilmYear";
            textBox_FilmYear.Size = new Size(193, 23);
            textBox_FilmYear.TabIndex = 7;
            // 
            // groupBox_NaPodstawie
            // 
            groupBox_NaPodstawie.Controls.Add(radioButton_NP3);
            groupBox_NaPodstawie.Controls.Add(radioButton_NP2);
            groupBox_NaPodstawie.Controls.Add(radioButton_NP1);
            groupBox_NaPodstawie.Location = new Point(120, 350);
            groupBox_NaPodstawie.Name = "groupBox_NaPodstawie";
            groupBox_NaPodstawie.Size = new Size(193, 105);
            groupBox_NaPodstawie.TabIndex = 16;
            groupBox_NaPodstawie.TabStop = false;
            groupBox_NaPodstawie.Text = "Wybierz jedną z opcji";
            // 
            // radioButton_NP3
            // 
            radioButton_NP3.AutoSize = true;
            radioButton_NP3.Location = new Point(6, 72);
            radioButton_NP3.Name = "radioButton_NP3";
            radioButton_NP3.Size = new Size(140, 19);
            radioButton_NP3.TabIndex = 17;
            radioButton_NP3.TabStop = true;
            radioButton_NP3.Text = "Oryginalny scenariusz";
            radioButton_NP3.UseVisualStyleBackColor = true;
            // 
            // radioButton_NP2
            // 
            radioButton_NP2.AutoSize = true;
            radioButton_NP2.Location = new Point(6, 47);
            radioButton_NP2.Name = "radioButton_NP2";
            radioButton_NP2.Size = new Size(43, 19);
            radioButton_NP2.TabIndex = 16;
            radioButton_NP2.TabStop = true;
            radioButton_NP2.Text = "Gra";
            radioButton_NP2.UseVisualStyleBackColor = true;
            // 
            // radioButton_NP1
            // 
            radioButton_NP1.AutoSize = true;
            radioButton_NP1.Location = new Point(6, 22);
            radioButton_NP1.Name = "radioButton_NP1";
            radioButton_NP1.Size = new Size(63, 19);
            radioButton_NP1.TabIndex = 15;
            radioButton_NP1.TabStop = true;
            radioButton_NP1.Text = "Książka";
            radioButton_NP1.UseVisualStyleBackColor = true;
            // 
            // textBox_description
            // 
            textBox_description.Location = new Point(120, 461);
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.Size = new Size(289, 76);
            textBox_description.TabIndex = 19;
            // 
            // checkedListBox_FGatunki
            // 
            checkedListBox_FGatunki.FormattingEnabled = true;
            checkedListBox_FGatunki.Location = new Point(120, 185);
            checkedListBox_FGatunki.Name = "checkedListBox_FGatunki";
            checkedListBox_FGatunki.Size = new Size(289, 130);
            checkedListBox_FGatunki.TabIndex = 20;
            // 
            // button_Anuluj
            // 
            button_Anuluj.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Anuluj.Location = new Point(698, 529);
            button_Anuluj.Name = "button_Anuluj";
            button_Anuluj.Size = new Size(75, 23);
            button_Anuluj.TabIndex = 12;
            button_Anuluj.Text = "Anuluj";
            button_Anuluj.UseVisualStyleBackColor = true;
            button_Anuluj.Click += button_Anuluj_Click;
            // 
            // pictureBox_Plakat
            // 
            pictureBox_Plakat.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_Plakat.Location = new Point(504, 41);
            pictureBox_Plakat.Name = "pictureBox_Plakat";
            pictureBox_Plakat.Size = new Size(221, 318);
            pictureBox_Plakat.TabIndex = 13;
            pictureBox_Plakat.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_Plakat
            // 
            label_Plakat.AutoSize = true;
            label_Plakat.Location = new Point(573, 15);
            label_Plakat.Name = "label_Plakat";
            label_Plakat.Size = new Size(76, 15);
            label_Plakat.TabIndex = 14;
            label_Plakat.Text = "Plakat filmu :";
            // 
            // button_WybierzPlakat
            // 
            button_WybierzPlakat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_WybierzPlakat.Location = new Point(504, 368);
            button_WybierzPlakat.Name = "button_WybierzPlakat";
            button_WybierzPlakat.Size = new Size(221, 23);
            button_WybierzPlakat.TabIndex = 15;
            button_WybierzPlakat.Text = "Wybierz plakat z dysku";
            button_WybierzPlakat.UseVisualStyleBackColor = true;
            button_WybierzPlakat.Click += button_WybierzPlakat_Click;
            // 
            // button_ZapiszFilm
            // 
            button_ZapiszFilm.Location = new Point(617, 529);
            button_ZapiszFilm.Name = "button_ZapiszFilm";
            button_ZapiszFilm.Size = new Size(75, 23);
            button_ZapiszFilm.TabIndex = 17;
            button_ZapiszFilm.Text = "Zapisz film";
            button_ZapiszFilm.UseVisualStyleBackColor = true;
            button_ZapiszFilm.Click += button_ZapiszFilm_Click;
            // 
            // AddFilmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 564);
            Controls.Add(button_ZapiszFilm);
            Controls.Add(button_WybierzPlakat);
            Controls.Add(label_Plakat);
            Controls.Add(pictureBox_Plakat);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button_Anuluj);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AddFilmForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj film do kolekcji";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox_FilmTitle.ResumeLayout(false);
            groupBox_FilmTitle.PerformLayout();
            groupBox_NaPodstawie.ResumeLayout(false);
            groupBox_NaPodstawie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Plakat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Tytuł;
        private TextBox textBox_FilmTitle;
        private Label label_Reżyser;
        private TextBox textBox_FilmDirector;
        private Label label_Scenariusz;
        private TextBox textBox_FilmScreenwriter;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label_RokProdukcji;
        private TextBox textBox_FilmYear;
        private TextBox textBox_RunTime;
        private Label label_CzasTrwania;
        private Label label_Gatunek;
        private Button button_Anuluj;
        private Label label_Język;
        private TextBox textBox_Language;
        private RadioButton radioButton_NP1;
        private GroupBox groupBox_NaPodstawie;
        private RadioButton radioButton_NP2;
        private Label label_NaPodstawie;
        private RadioButton radioButton_NP3;
        private PictureBox pictureBox_Plakat;
        private OpenFileDialog openFileDialog1;
        private Label label_Opis;
        private TextBox textBox_description;
        private Label label_Plakat;
        private Button button_WybierzPlakat;
        private Button button_PobierzDaneOmdb;
        private Button button_ZapiszFilm;
        private CheckedListBox checkedListBox_FGatunki;
        private GroupBox groupBox_FilmTitle;
    }
}