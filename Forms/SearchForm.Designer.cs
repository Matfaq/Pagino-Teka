namespace Pagino_Teka.Forms
{
    partial class SearchForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">true, jeśli zarządzane zasoby powinny zostać zlikwidowane; w przeciwnym razie false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(12, 12);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(200, 23);
            this.textBox_Search.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(220, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 27);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Szukaj";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 50);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBox_Search);
            this.Name = "SearchForm";
            this.Text = "Wyszukaj książkę";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button buttonSearch;
    }
}