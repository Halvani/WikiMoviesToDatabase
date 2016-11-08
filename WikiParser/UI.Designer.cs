namespace WikiParser
{
    partial class UI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.reMain = new System.Windows.Forms.RichTextBox();
            this.comboCorpusPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrawlWebsites = new System.Windows.Forms.Button();
            this.btnExportDatabase = new System.Windows.Forms.Button();
            this.tabParent = new System.Windows.Forms.TabControl();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btnDebugAction = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabGenerateDatabase = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optMySQL = new System.Windows.Forms.RadioButton();
            this.optSQLite = new System.Windows.Forms.RadioButton();
            this.reLog = new System.Windows.Forms.RichTextBox();
            this.tabCrawling = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMovieFolder = new System.Windows.Forms.TextBox();
            this.btnMoviesPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabParent.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabGenerateDatabase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabCrawling.SuspendLayout();
            this.SuspendLayout();
            // 
            // reMain
            // 
            this.reMain.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reMain.Location = new System.Drawing.Point(8, 98);
            this.reMain.Name = "reMain";
            this.reMain.Size = new System.Drawing.Size(1088, 324);
            this.reMain.TabIndex = 1;
            this.reMain.Text = "";
            this.reMain.WordWrap = false;
            // 
            // comboCorpusPath
            // 
            this.comboCorpusPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCorpusPath.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCorpusPath.FormattingEnabled = true;
            this.comboCorpusPath.Location = new System.Drawing.Point(111, 12);
            this.comboCorpusPath.Name = "comboCorpusPath";
            this.comboCorpusPath.Size = new System.Drawing.Size(779, 24);
            this.comboCorpusPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filmtitel:";
            // 
            // btnCrawlWebsites
            // 
            this.btnCrawlWebsites.Location = new System.Drawing.Point(861, 14);
            this.btnCrawlWebsites.Name = "btnCrawlWebsites";
            this.btnCrawlWebsites.Size = new System.Drawing.Size(225, 39);
            this.btnCrawlWebsites.TabIndex = 4;
            this.btnCrawlWebsites.Text = "Crawl Film-URL\'s über MediaWiki...";
            this.btnCrawlWebsites.UseVisualStyleBackColor = true;
            this.btnCrawlWebsites.Click += new System.EventHandler(this.btnCrawlWebsites_Click);
            // 
            // btnExportDatabase
            // 
            this.btnExportDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDatabase.Location = new System.Drawing.Point(983, 16);
            this.btnExportDatabase.Name = "btnExportDatabase";
            this.btnExportDatabase.Size = new System.Drawing.Size(113, 81);
            this.btnExportDatabase.TabIndex = 5;
            this.btnExportDatabase.Text = "Exportiere Datenbank";
            this.btnExportDatabase.UseVisualStyleBackColor = true;
            this.btnExportDatabase.Click += new System.EventHandler(this.btnExportDatabase_Click);
            // 
            // tabParent
            // 
            this.tabParent.Controls.Add(this.tabDebug);
            this.tabParent.Controls.Add(this.tabGenerateDatabase);
            this.tabParent.Controls.Add(this.tabCrawling);
            this.tabParent.Location = new System.Drawing.Point(8, 7);
            this.tabParent.Name = "tabParent";
            this.tabParent.SelectedIndex = 0;
            this.tabParent.Size = new System.Drawing.Size(1112, 456);
            this.tabParent.TabIndex = 6;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.label4);
            this.tabDebug.Controls.Add(this.btnMoviesPath);
            this.tabDebug.Controls.Add(this.txtMovieFolder);
            this.tabDebug.Controls.Add(this.btnDebugAction);
            this.tabDebug.Controls.Add(this.label2);
            this.tabDebug.Controls.Add(this.reMain);
            this.tabDebug.Controls.Add(this.comboCorpusPath);
            this.tabDebug.Controls.Add(this.label1);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(1104, 430);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "Debug-Modus";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // btnDebugAction
            // 
            this.btnDebugAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugAction.Location = new System.Drawing.Point(897, 11);
            this.btnDebugAction.Name = "btnDebugAction";
            this.btnDebugAction.Size = new System.Drawing.Size(199, 53);
            this.btnDebugAction.TabIndex = 7;
            this.btnDebugAction.Text = "Film-Webseiten parsen";
            this.btnDebugAction.UseVisualStyleBackColor = true;
            this.btnDebugAction.Click += new System.EventHandler(this.btnDebugAction_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ausgabe:";
            // 
            // tabGenerateDatabase
            // 
            this.tabGenerateDatabase.Controls.Add(this.label3);
            this.tabGenerateDatabase.Controls.Add(this.groupBox1);
            this.tabGenerateDatabase.Controls.Add(this.reLog);
            this.tabGenerateDatabase.Controls.Add(this.btnExportDatabase);
            this.tabGenerateDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabGenerateDatabase.Name = "tabGenerateDatabase";
            this.tabGenerateDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerateDatabase.Size = new System.Drawing.Size(1104, 430);
            this.tabGenerateDatabase.TabIndex = 0;
            this.tabGenerateDatabase.Text = "Datenbank-Generierung";
            this.tabGenerateDatabase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optMySQL);
            this.groupBox1.Controls.Add(this.optSQLite);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(808, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datenbanktyp festlegen";
            // 
            // optMySQL
            // 
            this.optMySQL.AutoSize = true;
            this.optMySQL.Checked = true;
            this.optMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMySQL.Location = new System.Drawing.Point(10, 28);
            this.optMySQL.Name = "optMySQL";
            this.optMySQL.Size = new System.Drawing.Size(70, 20);
            this.optMySQL.TabIndex = 9;
            this.optMySQL.TabStop = true;
            this.optMySQL.Text = "MySQL";
            this.optMySQL.UseVisualStyleBackColor = true;
            // 
            // optSQLite
            // 
            this.optSQLite.AutoSize = true;
            this.optSQLite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optSQLite.Location = new System.Drawing.Point(10, 54);
            this.optSQLite.Name = "optSQLite";
            this.optSQLite.Size = new System.Drawing.Size(66, 20);
            this.optSQLite.TabIndex = 8;
            this.optSQLite.Text = "SQLite";
            this.optSQLite.UseVisualStyleBackColor = true;
            // 
            // reLog
            // 
            this.reLog.Location = new System.Drawing.Point(6, 103);
            this.reLog.Name = "reLog";
            this.reLog.Size = new System.Drawing.Size(1090, 260);
            this.reLog.TabIndex = 7;
            this.reLog.Text = "";
            // 
            // tabCrawling
            // 
            this.tabCrawling.Controls.Add(this.btnCrawlWebsites);
            this.tabCrawling.Location = new System.Drawing.Point(4, 22);
            this.tabCrawling.Name = "tabCrawling";
            this.tabCrawling.Padding = new System.Windows.Forms.Padding(3);
            this.tabCrawling.Size = new System.Drawing.Size(1104, 430);
            this.tabCrawling.TabIndex = 1;
            this.tabCrawling.Text = "Crawling";
            this.tabCrawling.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(796, 84);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hier werden sämtliche runtergeladene Wikipedia-Film-Webseiten geparst, aufbereite" +
    "t und anschließend in eine zuvor ausgewählte Datenbank geschrieben...";
            // 
            // txtMovieFolder
            // 
            this.txtMovieFolder.Location = new System.Drawing.Point(111, 44);
            this.txtMovieFolder.Name = "txtMovieFolder";
            this.txtMovieFolder.Size = new System.Drawing.Size(704, 20);
            this.txtMovieFolder.TabIndex = 8;
            // 
            // btnMoviesPath
            // 
            this.btnMoviesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoviesPath.Location = new System.Drawing.Point(822, 43);
            this.btnMoviesPath.Name = "btnMoviesPath";
            this.btnMoviesPath.Size = new System.Drawing.Size(68, 22);
            this.btnMoviesPath.TabIndex = 9;
            this.btnMoviesPath.Text = "...";
            this.btnMoviesPath.UseVisualStyleBackColor = true;
            this.btnMoviesPath.Click += new System.EventHandler(this.btnMoviesPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filmverzeichnis:";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 467);
            this.Controls.Add(this.tabParent);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wikipedia Film-Metadaten Crawler, Parser, Datenbank Generator";
            this.tabParent.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabGenerateDatabase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCrawling.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox reMain;
        private System.Windows.Forms.ComboBox comboCorpusPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrawlWebsites;
        private System.Windows.Forms.Button btnExportDatabase;
        private System.Windows.Forms.TabControl tabParent;
        private System.Windows.Forms.TabPage tabGenerateDatabase;
        private System.Windows.Forms.TabPage tabCrawling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnDebugAction;
        private System.Windows.Forms.RichTextBox reLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optMySQL;
        private System.Windows.Forms.RadioButton optSQLite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMoviesPath;
        private System.Windows.Forms.TextBox txtMovieFolder;
    }
}

