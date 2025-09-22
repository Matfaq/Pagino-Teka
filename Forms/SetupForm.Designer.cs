namespace Pagino_Teka.Forms
{
    partial class SetupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox checkBox_UseGoogleApi;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Label label_GoogleApiKey;
        private System.Windows.Forms.TextBox textBox_GoogleApiKey;
        private System.Windows.Forms.Button button_LinkConsole;
        private System.Windows.Forms.Button button_LinkDocs;
        private System.Windows.Forms.GroupBox groupBox_Theme;
        private System.Windows.Forms.RadioButton radioButton_Light;
        private System.Windows.Forms.RadioButton radioButton_Dark;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            checkBox_UseGoogleApi = new CheckBox();
            label_Info = new Label();
            label_GoogleApiKey = new Label();
            textBox_GoogleApiKey = new TextBox();
            button_LinkConsole = new Button();
            button_LinkDocs = new Button();
            groupBox_Theme = new GroupBox();
            radioButton_Light = new RadioButton();
            radioButton_Dark = new RadioButton();
            button_Save = new Button();
            button_Cancel = new Button();
            checkBox_UseOmdbApiKey = new CheckBox();
            label_InfoOmdb = new Label();
            label_OmdbKey = new Label();
            textBox_OmdbApiKey = new TextBox();
            button_OmdbKeyLink = new Button();
            button_DocsOmdbKey = new Button();
            groupBox_Theme.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox_UseGoogleApi
            // 
            checkBox_UseGoogleApi.AutoSize = true;
            checkBox_UseGoogleApi.Location = new Point(24, 24);
            checkBox_UseGoogleApi.Name = "checkBox_UseGoogleApi";
            checkBox_UseGoogleApi.Size = new Size(167, 19);
            checkBox_UseGoogleApi.TabIndex = 0;
            checkBox_UseGoogleApi.Text = "Użyj Google Books API Key";
            checkBox_UseGoogleApi.UseVisualStyleBackColor = true;
            checkBox_UseGoogleApi.CheckedChanged += checkBox_UseGoogleApi_CheckedChanged;
            // 
            // label_Info
            // 
            label_Info.AutoSize = true;
            label_Info.Location = new Point(24, 52);
            label_Info.MaximumSize = new Size(470, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(448, 30);
            label_Info.TabIndex = 1;
            label_Info.Text = "Możesz podać własny klucz Google Books API, aby uzupełnianie danych z sieci było dokładniejsze. Klucz jest opcjonalny i musisz go utworzyć samodzielnie.";
            // 
            // label_GoogleApiKey
            // 
            label_GoogleApiKey.AutoSize = true;
            label_GoogleApiKey.Location = new Point(24, 92);
            label_GoogleApiKey.Name = "label_GoogleApiKey";
            label_GoogleApiKey.Size = new Size(91, 15);
            label_GoogleApiKey.TabIndex = 2;
            label_GoogleApiKey.Text = "Google API Key:";
            // 
            // textBox_GoogleApiKey
            // 
            textBox_GoogleApiKey.Location = new Point(24, 110);
            textBox_GoogleApiKey.Name = "textBox_GoogleApiKey";
            textBox_GoogleApiKey.Size = new Size(470, 23);
            textBox_GoogleApiKey.TabIndex = 3;
            // 
            // button_LinkConsole
            // 
            button_LinkConsole.Location = new Point(24, 142);
            button_LinkConsole.Name = "button_LinkConsole";
            button_LinkConsole.Size = new Size(220, 30);
            button_LinkConsole.TabIndex = 4;
            button_LinkConsole.Text = "🔑 Jak uzyskać klucz (Cloud Console)";
            button_LinkConsole.UseVisualStyleBackColor = true;
            button_LinkConsole.Click += button_LinkConsole_Click;
            // 
            // button_LinkDocs
            // 
            button_LinkDocs.Location = new Point(254, 142);
            button_LinkDocs.Name = "button_LinkDocs";
            button_LinkDocs.Size = new Size(240, 30);
            button_LinkDocs.TabIndex = 5;
            button_LinkDocs.Text = "📘 Dokumentacja Google Books API";
            button_LinkDocs.UseVisualStyleBackColor = true;
            button_LinkDocs.Click += button_LinkDocs_Click;
            // 
            // groupBox_Theme
            // 
            groupBox_Theme.Controls.Add(radioButton_Light);
            groupBox_Theme.Controls.Add(radioButton_Dark);
            groupBox_Theme.Location = new Point(24, 382);
            groupBox_Theme.Name = "groupBox_Theme";
            groupBox_Theme.Size = new Size(200, 68);
            groupBox_Theme.TabIndex = 6;
            groupBox_Theme.TabStop = false;
            groupBox_Theme.Text = "Motyw aplikacji";
            // 
            // radioButton_Light
            // 
            radioButton_Light.AutoSize = true;
            radioButton_Light.Location = new Point(16, 21);
            radioButton_Light.Name = "radioButton_Light";
            radioButton_Light.Size = new Size(53, 19);
            radioButton_Light.TabIndex = 0;
            radioButton_Light.TabStop = true;
            radioButton_Light.Text = "Jasny";
            radioButton_Light.UseVisualStyleBackColor = true;
            // 
            // radioButton_Dark
            // 
            radioButton_Dark.AutoSize = true;
            radioButton_Dark.Location = new Point(16, 42);
            radioButton_Dark.Name = "radioButton_Dark";
            radioButton_Dark.Size = new Size(66, 19);
            radioButton_Dark.TabIndex = 1;
            radioButton_Dark.TabStop = true;
            radioButton_Dark.Text = "Ciemny";
            radioButton_Dark.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            button_Save.Location = new Point(314, 420);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(84, 30);
            button_Save.TabIndex = 7;
            button_Save.Text = "Zapisz";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(410, 420);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(84, 30);
            button_Cancel.TabIndex = 8;
            button_Cancel.Text = "Anuluj";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button_Cancel_Click;
            // 
            // checkBox_UseOmdbApiKey
            // 
            checkBox_UseOmdbApiKey.AutoSize = true;
            checkBox_UseOmdbApiKey.Location = new Point(24, 197);
            checkBox_UseOmdbApiKey.Name = "checkBox_UseOmdbApiKey";
            checkBox_UseOmdbApiKey.Size = new Size(189, 19);
            checkBox_UseOmdbApiKey.TabIndex = 9;
            checkBox_UseOmdbApiKey.Text = "Użyj The Open Movie Database";
            checkBox_UseOmdbApiKey.UseVisualStyleBackColor = true;
            checkBox_UseOmdbApiKey.CheckedChanged += checkBox_UseOmdbApi_CheckedChanged;
            // 
            // label_InfoOmdb
            // 
            label_InfoOmdb.AutoSize = true;
            label_InfoOmdb.Location = new Point(24, 225);
            label_InfoOmdb.MaximumSize = new Size(470, 0);
            label_InfoOmdb.Name = "label_InfoOmdb";
            label_InfoOmdb.Size = new Size(451, 30);
            label_InfoOmdb.TabIndex = 10;
            label_InfoOmdb.Text = "Możesz podać własny klucz The Open Movie Database API, aby uzupełniać danych z sieci . Klucz jest opcjonalny i musisz go utworzyć samodzielnie.";
            // 
            // label_OmdbKey
            // 
            label_OmdbKey.AutoSize = true;
            label_OmdbKey.Location = new Point(24, 265);
            label_OmdbKey.Name = "label_OmdbKey";
            label_OmdbKey.Size = new Size(194, 15);
            label_OmdbKey.TabIndex = 11;
            label_OmdbKey.Text = "The Open Movie Database Api Key :";
            // 
            // textBox_OmdbApiKey
            // 
            textBox_OmdbApiKey.Location = new Point(24, 283);
            textBox_OmdbApiKey.Name = "textBox_OmdbApiKey";
            textBox_OmdbApiKey.Size = new Size(470, 23);
            textBox_OmdbApiKey.TabIndex = 12;
            // 
            // button_OmdbKeyLink
            // 
            button_OmdbKeyLink.Location = new Point(24, 315);
            button_OmdbKeyLink.Name = "button_OmdbKeyLink";
            button_OmdbKeyLink.Size = new Size(220, 30);
            button_OmdbKeyLink.TabIndex = 13;
            button_OmdbKeyLink.Text = "🔑 Jak uzyskać klucz (Omdb)";
            button_OmdbKeyLink.UseVisualStyleBackColor = true;
            button_OmdbKeyLink.Click += button_OmdbKeyLink_Click;
            // 
            // button_DocsOmdbKey
            // 
            button_DocsOmdbKey.Location = new Point(254, 315);
            button_DocsOmdbKey.Name = "button_DocsOmdbKey";
            button_DocsOmdbKey.Size = new Size(240, 30);
            button_DocsOmdbKey.TabIndex = 14;
            button_DocsOmdbKey.Text = "📘 Dokumentacja Omdb API";
            button_DocsOmdbKey.UseVisualStyleBackColor = true;
            button_DocsOmdbKey.Click += button_DocsOmdbKey_Click;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 474);
            Controls.Add(checkBox_UseOmdbApiKey);
            Controls.Add(label_InfoOmdb);
            Controls.Add(label_OmdbKey);
            Controls.Add(textBox_OmdbApiKey);
            Controls.Add(button_OmdbKeyLink);
            Controls.Add(button_DocsOmdbKey);
            Controls.Add(checkBox_UseGoogleApi);
            Controls.Add(label_Info);
            Controls.Add(label_GoogleApiKey);
            Controls.Add(textBox_GoogleApiKey);
            Controls.Add(button_LinkConsole);
            Controls.Add(button_LinkDocs);
            Controls.Add(groupBox_Theme);
            Controls.Add(button_Save);
            Controls.Add(button_Cancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ustawienia Pagino-Teka";
            Load += SetupForm_Load;
            groupBox_Theme.ResumeLayout(false);
            groupBox_Theme.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private CheckBox checkBox_UseOmdbApiKey;
        private Label label_InfoOmdb;
        private Label label_OmdbKey;
        private TextBox textBox_OmdbApiKey;
        private Button button_OmdbKeyLink;
        private Button button_DocsOmdbKey;
    }
}
