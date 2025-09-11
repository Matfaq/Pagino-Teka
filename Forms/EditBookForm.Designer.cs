namespace Pagino_Teka
{
    partial class EditBookForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.ComboBox comboBox_Publisher;
        private System.Windows.Forms.ComboBox comboBox_BookSeries;
        private System.Windows.Forms.NumericUpDown numericUpDown_SeriesNumber;
        private System.Windows.Forms.CheckedListBox checkedListBox_Gatunki;
        private System.Windows.Forms.RadioButton radioButton_Hardcover;
        private System.Windows.Forms.RadioButton radioButton_Paperback;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Publisher;
        private System.Windows.Forms.Label label_Series;
        private System.Windows.Forms.Label label_SeriesNumber;
        private System.Windows.Forms.Label label_Gatunki;
        private System.Windows.Forms.Label label_EditionType;
        private System.Windows.Forms.Label label_Notes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.comboBox_Publisher = new System.Windows.Forms.ComboBox();
            this.comboBox_BookSeries = new System.Windows.Forms.ComboBox();
            this.numericUpDown_SeriesNumber = new System.Windows.Forms.NumericUpDown();
            this.checkedListBox_Gatunki = new System.Windows.Forms.CheckedListBox();
            this.radioButton_Hardcover = new System.Windows.Forms.RadioButton();
            this.radioButton_Paperback = new System.Windows.Forms.RadioButton();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Publisher = new System.Windows.Forms.Label();
            this.label_Series = new System.Windows.Forms.Label();
            this.label_SeriesNumber = new System.Windows.Forms.Label();
            this.label_Gatunki = new System.Windows.Forms.Label();
            this.label_EditionType = new System.Windows.Forms.Label();
            this.label_Notes = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SeriesNumber)).BeginInit();
            this.SuspendLayout();

            // 
            // Labels i kontrolki
            // 
            this.label_Title.Text = "Tytuł:";
            this.label_Title.Top = 10; this.label_Title.Left = 10;

            this.textBox_Title.Top = 30; this.textBox_Title.Left = 10; this.textBox_Title.Width = 300;

            this.label_Publisher.Text = "Wydawca:";
            this.label_Publisher.Top = 60; this.label_Publisher.Left = 10;

            this.comboBox_Publisher.Top = 80; this.comboBox_Publisher.Left = 10; this.comboBox_Publisher.Width = 200;

            this.label_Series.Text = "Seria:";
            this.label_Series.Top = 110; this.label_Series.Left = 10;

            this.comboBox_BookSeries.Top = 130; this.comboBox_BookSeries.Left = 10; this.comboBox_BookSeries.Width = 200;

            this.label_SeriesNumber.Text = "Numer w serii:";
            this.label_SeriesNumber.Top = 160; this.label_SeriesNumber.Left = 10;

            this.numericUpDown_SeriesNumber.Top = 180; this.numericUpDown_SeriesNumber.Left = 10; this.numericUpDown_SeriesNumber.Width = 60;

            this.label_Gatunki.Text = "Gatunki:";
            this.label_Gatunki.Top = 210; this.label_Gatunki.Left = 10;

            this.checkedListBox_Gatunki.Top = 230; this.checkedListBox_Gatunki.Left = 10; this.checkedListBox_Gatunki.Width = 200; this.checkedListBox_Gatunki.Height = 100;

            this.label_EditionType.Text = "Rodzaj wydania:";
            this.label_EditionType.Top = 340; this.label_EditionType.Left = 10;

            this.radioButton_Hardcover.Text = "Twarda okładka";
            this.radioButton_Hardcover.Top = 360; this.radioButton_Hardcover.Left = 10;

            this.radioButton_Paperback.Text = "Miękka okładka";
            this.radioButton_Paperback.Top = 360; this.radioButton_Paperback.Left = 150;

            this.label_Notes.Text = "Notatki:";
            this.label_Notes.Top = 390; this.label_Notes.Left = 10;

            this.textBox_Notes.Top = 410; this.textBox_Notes.Left = 10; this.textBox_Notes.Width = 300; this.textBox_Notes.Height = 60; this.textBox_Notes.Multiline = true;

            // Buttons
            this.button_Save.Text = "Zapisz"; this.button_Save.Top = 480; this.button_Save.Left = 10; this.button_Save.Click += button_Save_Click;
            this.button_Delete.Text = "Usuń"; this.button_Delete.Top = 480; this.button_Delete.Left = 100; this.button_Delete.Click += button_Delete_Click;
            this.button_Cancel.Text = "Anuluj"; this.button_Cancel.Top = 480; this.button_Cancel.Left = 190; this.button_Cancel.Click += button_Cancel_Click;

            // 
            // EditBookForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.label_Publisher);
            this.Controls.Add(this.comboBox_Publisher);
            this.Controls.Add(this.label_Series);
            this.Controls.Add(this.comboBox_BookSeries);
            this.Controls.Add(this.label_SeriesNumber);
            this.Controls.Add(this.numericUpDown_SeriesNumber);
            this.Controls.Add(this.label_Gatunki);
            this.Controls.Add(this.checkedListBox_Gatunki);
            this.Controls.Add(this.label_EditionType);
            this.Controls.Add(this.radioButton_Hardcover);
            this.Controls.Add(this.radioButton_Paperback);
            this.Controls.Add(this.label_Notes);
            this.Controls.Add(this.textBox_Notes);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Cancel);

            this.Text = "Edycja książki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EditBookForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SeriesNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
