namespace Pagino_Teka
{
    partial class AboutForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "O programie Pagino-Teka";

            // Przycisk Zamknij
            var buttonClose = new System.Windows.Forms.Button
            {
                Text = "Zamknij",
                Anchor = System.Windows.Forms.AnchorStyles.Bottom,
                Width = 100,
                Height = 30,
                Top = this.ClientSize.Height - 50,
                Left = (this.ClientSize.Width - 100) / 2,
            };
            buttonClose.Click += new System.EventHandler(this.button1_Click);

            this.Controls.Add(buttonClose);
        }

        #endregion
    }
}
