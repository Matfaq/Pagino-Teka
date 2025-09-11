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
            this.checkBox_UseGoogleApi = new System.Windows.Forms.CheckBox();
            this.label_Info = new System.Windows.Forms.Label();
            this.label_GoogleApiKey = new System.Windows.Forms.Label();
            this.textBox_GoogleApiKey = new System.Windows.Forms.TextBox();
            this.button_LinkConsole = new System.Windows.Forms.Button();
            this.button_LinkDocs = new System.Windows.Forms.Button();
            this.groupBox_Theme = new System.Windows.Forms.GroupBox();
            this.radioButton_Light = new System.Windows.Forms.RadioButton();
            this.radioButton_Dark = new System.Windows.Forms.RadioButton();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_Theme.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ustawienia Pagino-Teka";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            // 
            // checkBox_UseGoogleApi
            // 
            this.checkBox_UseGoogleApi.AutoSize = true;
            this.checkBox_UseGoogleApi.Location = new System.Drawing.Point(24, 24);
            this.checkBox_UseGoogleApi.Name = "checkBox_UseGoogleApi";
            this.checkBox_UseGoogleApi.Size = new System.Drawing.Size(197, 19);
            this.checkBox_UseGoogleApi.TabIndex = 0;
            this.checkBox_UseGoogleApi.Text = "Użyj Google Books API Key";
            this.checkBox_UseGoogleApi.UseVisualStyleBackColor = true;
            this.checkBox_UseGoogleApi.CheckedChanged += new System.EventHandler(this.checkBox_UseGoogleApi_CheckedChanged);
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(24, 52);
            this.label_Info.MaximumSize = new System.Drawing.Size(470, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(460, 30);
            this.label_Info.TabIndex = 1;
            this.label_Info.Text = "Możesz podać własny klucz Google Books API, aby uzupełnianie danych z sieci było dokładniejsze. Klucz jest opcjonalny i musisz go utworzyć samodzielnie.";
            // 
            // label_GoogleApiKey
            // 
            this.label_GoogleApiKey.AutoSize = true;
            this.label_GoogleApiKey.Location = new System.Drawing.Point(24, 92);
            this.label_GoogleApiKey.Name = "label_GoogleApiKey";
            this.label_GoogleApiKey.Size = new System.Drawing.Size(95, 15);
            this.label_GoogleApiKey.TabIndex = 2;
            this.label_GoogleApiKey.Text = "Google API Key:";
            // 
            // textBox_GoogleApiKey
            // 
            this.textBox_GoogleApiKey.Location = new System.Drawing.Point(24, 110);
            this.textBox_GoogleApiKey.Name = "textBox_GoogleApiKey";
            this.textBox_GoogleApiKey.Size = new System.Drawing.Size(470, 23);
            this.textBox_GoogleApiKey.TabIndex = 3;
            // 
            // button_LinkConsole
            // 
            this.button_LinkConsole.Location = new System.Drawing.Point(24, 142);
            this.button_LinkConsole.Name = "button_LinkConsole";
            this.button_LinkConsole.Size = new System.Drawing.Size(220, 30);
            this.button_LinkConsole.TabIndex = 4;
            this.button_LinkConsole.Text = "🔑 Jak uzyskać klucz (Cloud Console)";
            this.button_LinkConsole.UseVisualStyleBackColor = true;
            this.button_LinkConsole.Click += new System.EventHandler(this.button_LinkConsole_Click);
            // 
            // button_LinkDocs
            // 
            this.button_LinkDocs.Location = new System.Drawing.Point(254, 142);
            this.button_LinkDocs.Name = "button_LinkDocs";
            this.button_LinkDocs.Size = new System.Drawing.Size(240, 30);
            this.button_LinkDocs.TabIndex = 5;
            this.button_LinkDocs.Text = "📘 Dokumentacja Google Books API";
            this.button_LinkDocs.UseVisualStyleBackColor = true;
            this.button_LinkDocs.Click += new System.EventHandler(this.button_LinkDocs_Click);
            // 
            // groupBox_Theme
            // 
            this.groupBox_Theme.Controls.Add(this.radioButton_Light);
            this.groupBox_Theme.Controls.Add(this.radioButton_Dark);
            this.groupBox_Theme.Location = new System.Drawing.Point(24, 188);
            this.groupBox_Theme.Name = "groupBox_Theme";
            this.groupBox_Theme.Size = new System.Drawing.Size(200, 68);
            this.groupBox_Theme.TabIndex = 6;
            this.groupBox_Theme.TabStop = false;
            this.groupBox_Theme.Text = "Motyw aplikacji";
            // 
            // radioButton_Light
            // 
            this.radioButton_Light.AutoSize = true;
            this.radioButton_Light.Location = new System.Drawing.Point(16, 21);
            this.radioButton_Light.Name = "radioButton_Light";
            this.radioButton_Light.Size = new System.Drawing.Size(58, 19);
            this.radioButton_Light.TabIndex = 0;
            this.radioButton_Light.TabStop = true;
            this.radioButton_Light.Text = "Jasny";
            this.radioButton_Light.UseVisualStyleBackColor = true;
            // 
            // radioButton_Dark
            // 
            this.radioButton_Dark.AutoSize = true;
            this.radioButton_Dark.Location = new System.Drawing.Point(16, 42);
            this.radioButton_Dark.Name = "radioButton_Dark";
            this.radioButton_Dark.Size = new System.Drawing.Size(68, 19);
            this.radioButton_Dark.TabIndex = 1;
            this.radioButton_Dark.TabStop = true;
            this.radioButton_Dark.Text = "Ciemny";
            this.radioButton_Dark.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(314, 226);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(84, 30);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Zapisz";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(410, 226);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(84, 30);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Text = "Anuluj";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // add controls
            // 
            this.Controls.Add(this.checkBox_UseGoogleApi);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.label_GoogleApiKey);
            this.Controls.Add(this.textBox_GoogleApiKey);
            this.Controls.Add(this.button_LinkConsole);
            this.Controls.Add(this.button_LinkDocs);
            this.Controls.Add(this.groupBox_Theme);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Cancel);

            this.groupBox_Theme.ResumeLayout(false);
            this.groupBox_Theme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
