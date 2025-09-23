using System;
using System.Windows.Forms;

namespace Pagino_Teka.Forms
{
    public class StatusForm : Form
    {
        private TextBox textBox;
        private Button copyButton;

        public StatusForm(string statusText)
        {
            this.Text = "Status bazy";
            this.Width = 700;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterParent;

            textBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Text = statusText,
                WordWrap = false
            };

            copyButton = new Button
            {
                Text = "Kopiuj do schowka",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            copyButton.Click += (s, e) =>
            {
                Clipboard.SetText(textBox.Text);
                MessageBox.Show("Skopiowano do schowka.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            this.Controls.Add(textBox);
            this.Controls.Add(copyButton);
        }
    }
}