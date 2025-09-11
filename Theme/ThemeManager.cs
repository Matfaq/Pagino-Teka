using System.Windows.Forms;

namespace Pagino_Teka.Theme
{
    public static class ThemeManager
    {
        public static Theme Current { get; private set; } = Themes.Dark;

        public static void SetTheme(Theme theme)
        {
            Current = theme;
        }

        public static void ApplyTheme(Form form)
        {
            form.BackColor = Current.Background;
            form.ForeColor = Current.Foreground;

            foreach (Control ctrl in form.Controls)
            {
                ApplyThemeToControl(ctrl);
            }
        }

        private static void ApplyThemeToControl(Control ctrl)
        {
            ctrl.BackColor = Current.Background;
            ctrl.ForeColor = Current.Foreground;

            if (ctrl is Button btn)
            {
                btn.BackColor = Current.ButtonBackground;
                btn.ForeColor = Current.ButtonForeground;
            }
            else if (ctrl is TextBox || ctrl is RichTextBox)
            {
                ctrl.BackColor = Current.TextBoxBackground;
                ctrl.ForeColor = Current.TextBoxForeground;
            }
            else if (ctrl is ListBox || ctrl is CheckedListBox)
            {
                ctrl.BackColor = Current.ListBackground;
                ctrl.ForeColor = Current.ListForeground;
            }
            else if (ctrl is ComboBox combo)
            {
                combo.BackColor = Current.TextBoxBackground;
                combo.ForeColor = Current.TextBoxForeground;
            }
            else if (ctrl is DataGridView grid)
            {
                grid.BackgroundColor = Current.Background;
                grid.DefaultCellStyle.BackColor = Current.ListBackground;
                grid.DefaultCellStyle.ForeColor = Current.ListForeground;
                grid.ColumnHeadersDefaultCellStyle.BackColor = Current.GridHeaderBackground;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Current.GridHeaderForeground;
            }
            else if (ctrl is MenuStrip menu)
            {
                menu.BackColor = Current.MenuBackground;
                menu.ForeColor = Current.MenuForeground;

                // dodatkowo ustawienia dla elementów menu
                foreach (ToolStripMenuItem item in menu.Items)
                {
                    ApplyThemeToMenuItem(item);
                }
            }

            // Rekurencyjnie dla wszystkich dzieci
            foreach (Control child in ctrl.Controls)
            {
                ApplyThemeToControl(child);
            }
        }

        private static void ApplyThemeToMenuItem(ToolStripMenuItem item)
        {
            item.BackColor = Current.MenuBackground;
            item.ForeColor = Current.MenuForeground;

            // rekurencja dla podmenu
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    ApplyThemeToMenuItem(subMenuItem);
                }
                else
                {
                    subItem.BackColor = Current.MenuBackground;
                    subItem.ForeColor = Current.MenuForeground;
                }
            }
        }
    }
}
