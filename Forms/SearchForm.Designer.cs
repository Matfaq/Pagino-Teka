namespace Pagino_Teka.Forms
{
    partial class SearchForm
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
            label_Search = new Label();
            textBox_Search = new TextBox();
            button_Search = new Button();
            SuspendLayout();
            // 
            // label_Search
            // 
            label_Search.AutoSize = true;
            label_Search.Location = new Point(12, 9);
            label_Search.Name = "label_Search";
            label_Search.Size = new Size(141, 15);
            label_Search.TabIndex = 0;
            label_Search.Text = "Wpisz wyszukiwaną frazę:";
            // 
            // textBox_Search
            // 
            textBox_Search.Location = new Point(12, 28);
            textBox_Search.Name = "textBox_Search";
            textBox_Search.Size = new Size(272, 23);
            textBox_Search.TabIndex = 1;
            // 
            // button_Search
            // 
            button_Search.Location = new Point(302, 28);
            button_Search.Name = "button_Search";
            button_Search.Size = new Size(146, 23);
            button_Search.TabIndex = 2;
            button_Search.Text = "Wyszukaj";
            button_Search.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 64);
            Controls.Add(button_Search);
            Controls.Add(textBox_Search);
            Controls.Add(label_Search);
            Name = "SearchForm";
            Text = "Wyszukiwanie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Search;
        private TextBox textBox_Search;
        private Button button_Search;
    }
}