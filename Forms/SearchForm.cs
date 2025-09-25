using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagino_Teka.Forms
{
    public partial class SearchForm : Form
    {
        // Usunięto niepotrzebną deklarację textBoxSearch
        // Poprawka: zainicjalizowano SearchText na pusty string, aby uniknąć CS8618
        public string SearchText { get; private set; } = string.Empty;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            // Poprawka: użycie textBox_Search z designer-a
            SearchText = textBox_Search.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
