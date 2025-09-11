namespace Pagino_Teka.Forms
{
    partial class EditBookForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;

        private System.Windows.Forms.Label labelAuthors;
        private System.Windows.Forms.TextBox textBoxAuthors;

        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.TextBox textBoxPublisher;

        private System.Windows.Forms.Label labelSeries;
        private System.Windows.Forms.TextBox textBoxSeries;

        private System.Windows.Forms.Label labelSeriesNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownSeriesNumber;

        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.TextBox textBoxIsbn;

        private System.Windows.Forms.Label labelPages;
        private System.Windows.Forms.NumericUpDown numericUpDownPages;

        private System.Windows.Forms.Label labelReadTime;
        private System.Windows.Forms.NumericUpDown numericUpDownReadTime;

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();

            this.labelAuthors = new System.Windows.Forms.Label();
            this.textBoxAuthors = new System.Windows.Forms.TextBox();

            this.labelPublisher = new System.Windows.Forms.Label();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();

            this.labelSeries = new System.Windows.Forms.Label();
            this.textBoxSeries = new System.Windows.Forms.TextBox();

            this.labelSeriesNumber = new System.Windows.Forms.Label();
            this.numericUpDownSeriesNumber = new System.Windows.Forms.NumericUpDown();

            this.labelIsbn = new System.Windows.Forms.Label();
            this.textBoxIsbn = new System.Windows.Forms.TextBox();

            this.labelPages = new System.Windows.Forms.Label();
            this.numericUpDownPages = new System.Windows.Forms.NumericUpDown();

            this.labelReadTime = new System.Windows.Forms.Label();
            this.numericUpDownReadTime = new System.Windows.Forms.NumericUpDown();

            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();

            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeriesNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTime)).BeginInit();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(35, 13);
            this.labelTitle.Text = "Tytuł:";

            // textBoxTitle
            this.textBoxTitle.Location = new System.Drawing.Point(120, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(300, 20);

            // labelAuthors
            this.labelAuthors.AutoSize = true;
            this.labelAuthors.Location = new System.Drawing.Point(12, 45);
            this.labelAuthors.Name = "labelAuthors";
            this.labelAuthors.Size = new System.Drawing.Size(38, 13);
            this.labelAuthors.Text = "Autorzy:";

            // textBoxAuthors
            this.textBoxAuthors.Location = new System.Drawing.Point(120, 42);
            this.textBoxAuthors.Name = "textBoxAuthors";
            this.textBoxAuthors.Size = new System.Drawing.Size(300, 20);

            // labelPublisher
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(12, 75);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(59, 13);
            this.labelPublisher.Text = "Wydawca:";

            // textBoxPublisher
            this.textBoxPublisher.Location = new System.Drawing.Point(120, 72);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(300, 20);

            // labelSeries
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(12, 105);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(33, 13);
            this.labelSeries.Text = "Seria:";

            // textBoxSeries
            this.textBoxSeries.Location = new System.Drawing.Point(120, 102);
            this.textBoxSeries.Name = "textBoxSeries";
            this.textBoxSeries.Size = new System.Drawing.Size(200, 20);

            // labelSeriesNumber
            this.labelSeriesNumber.AutoSize = true;
            this.labelSeriesNumber.Location = new System.Drawing.Point(330, 105);
            this.labelSeriesNumber.Name = "labelSeriesNumber";
            this.labelSeriesNumber.Size = new System.Drawing.Size(41, 13);
            this.labelSeriesNumber.Text = "Numer:";

            // numericUpDownSeriesNumber
            this.numericUpDownSeriesNumber.Location = new System.Drawing.Point(380, 102);
            this.numericUpDownSeriesNumber.Name = "numericUpDownSeriesNumber";
            this.numericUpDownSeriesNumber.Size = new System.Drawing.Size(40, 20);

            // labelIsbn
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Location = new System.Drawing.Point(12, 135);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(32, 13);
            this.labelIsbn.Text = "ISBN:";

            // textBoxIsbn
            this.textBoxIsbn.Location = new System.Drawing.Point(120, 132);
            this.textBoxIsbn.Name = "textBoxIsbn";
            this.textBoxIsbn.Size = new System.Drawing.Size(200, 20);

            // labelPages
            this.labelPages.AutoSize = true;
            this.labelPages.Location = new System.Drawing.Point(12, 165);
            this.labelPages.Name = "labelPages";
            this.labelPages.Size = new System.Drawing.Size(43, 13);
            this.labelPages.Text = "Strony:";

            // numericUpDownPages
            this.numericUpDownPages.Location = new System.Drawing.Point(120, 162);
            this.numericUpDownPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numericUpDownPages.Name = "numericUpDownPages";
            this.numericUpDownPages.Size = new System.Drawing.Size(80, 20);

            // labelReadTime
            this.labelReadTime.AutoSize = true;
            this.labelReadTime.Location = new System.Drawing.Point(220, 165);
            this.labelReadTime.Name = "labelReadTime";
            this.labelReadTime.Size = new System.Drawing.Size(72, 13);
            this.labelReadTime.Text = "Czas czytania:";

            // numericUpDownReadTime
            this.numericUpDownReadTime.Location = new System.Drawing.Point(300, 162);
            this.numericUpDownReadTime.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numericUpDownReadTime.Name = "numericUpDownReadTime";
            this.numericUpDownReadTime.Size = new System.Drawing.Size(80, 20);

            // labelDescription
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 195);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(56, 13);
            this.labelDescription.Text = "Opis / Notatki:";

            // textBoxDescription
            this.textBoxDescription.Location = new System.Drawing.Point(120, 192);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(300, 80);

            // buttonSave
            this.buttonSave.Location = new System.Drawing.Point(120, 290);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(240, 290);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 30);
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // EditBookForm
            this.ClientSize = new System.Drawing.Size(450, 340);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);

            this.Controls.Add(this.labelAuthors);
            this.Controls.Add(this.textBoxAuthors);

            this.Controls.Add(this.labelPublisher);
            this.Controls.Add(this.textBoxPublisher);

            this.Controls.Add(this.labelSeries);
            this.Controls.Add(this.textBoxSeries);

            this.Controls.Add(this.labelSeriesNumber);
            this.Controls.Add(this.numericUpDownSeriesNumber);

            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.textBoxIsbn);

            this.Controls.Add(this.labelPages);
            this.Controls.Add(this.numericUpDownPages);

            this.Controls.Add(this.labelReadTime);
            this.Controls.Add(this.numericUpDownReadTime);

            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxDescription);

            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "EditBookForm";
            this.Text = "Edytuj książkę";

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeriesNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
