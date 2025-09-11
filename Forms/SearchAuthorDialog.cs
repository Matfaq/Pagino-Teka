using System;
using System.Windows.Forms;

namespace Pagino_Teka.Forms.Dialogs
{
    public partial class SearchAuthorDialog : Form
    {
        public string AuthorName => textBoxAuthor.Text.Trim();

        public SearchAuthorDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AuthorName))
            {
                MessageBox.Show("Podaj nazwisko autora.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
