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
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabCrawling = new System.Windows.Forms.TabPage();
            this.comboCategoryMoviesByState = new System.Windows.Forms.ComboBox();
            this.btnPopulateCategoryMoviesByState = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboTopCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMoviesPath = new System.Windows.Forms.Button();
            this.txtMovieFolder = new System.Windows.Forms.TextBox();
            this.btnDebugAction = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabGenerateDatabase = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optMySQL = new System.Windows.Forms.RadioButton();
            this.optSQLite = new System.Windows.Forms.RadioButton();
            this.reLog = new System.Windows.Forms.RichTextBox();
            this.tabOptions.SuspendLayout();
            this.tabCrawling.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabGenerateDatabase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reMain
            // 
            this.reMain.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reMain.Location = new System.Drawing.Point(8, 98);
            this.reMain.Name = "reMain";
            this.reMain.Size = new System.Drawing.Size(1119, 425);
            this.reMain.TabIndex = 1;
            this.reMain.Text = "";
            this.reMain.WordWrap = false;
            // 
            // comboCorpusPath
            // 
            this.comboCorpusPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCorpusPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCrawlWebsites.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrawlWebsites.Location = new System.Drawing.Point(819, 398);
            this.btnCrawlWebsites.Name = "btnCrawlWebsites";
            this.btnCrawlWebsites.Size = new System.Drawing.Size(308, 121);
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
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabCrawling);
            this.tabOptions.Controls.Add(this.tabDebug);
            this.tabOptions.Controls.Add(this.tabGenerateDatabase);
            this.tabOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOptions.Location = new System.Drawing.Point(8, 7);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(1141, 554);
            this.tabOptions.TabIndex = 6;
            // 
            // tabCrawling
            // 
            this.tabCrawling.Controls.Add(this.comboCategoryMoviesByState);
            this.tabCrawling.Controls.Add(this.btnPopulateCategoryMoviesByState);
            this.tabCrawling.Controls.Add(this.label6);
            this.tabCrawling.Controls.Add(this.comboTopCategory);
            this.tabCrawling.Controls.Add(this.label5);
            this.tabCrawling.Controls.Add(this.btnCrawlWebsites);
            this.tabCrawling.Location = new System.Drawing.Point(4, 25);
            this.tabCrawling.Name = "tabCrawling";
            this.tabCrawling.Padding = new System.Windows.Forms.Padding(3);
            this.tabCrawling.Size = new System.Drawing.Size(1133, 525);
            this.tabCrawling.TabIndex = 1;
            this.tabCrawling.Text = "Crawling";
            this.tabCrawling.UseVisualStyleBackColor = true;
            // 
            // comboCategoryMoviesByState
            // 
            this.comboCategoryMoviesByState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategoryMoviesByState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategoryMoviesByState.FormattingEnabled = true;
            this.comboCategoryMoviesByState.Items.AddRange(new object[] {
            "https://de.wikipedia.org/wiki/Kategorie:Afghanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:%C3%84gyptischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Algerischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Angolanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Argentinischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Armenischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Aserbaidschanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:%C3%84thiopischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Australischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Bahamaischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Belgischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Bosnisch-herzegowinischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Brasilianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Britischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Bulgarischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Burkinischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Chilenischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Chinesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:D%C3%A4nischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:DDR-Film",
            "https://de.wikipedia.org/wiki/Kategorie:Deutscher_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Dominikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Ecuadorianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Estnischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Finnischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Franz%C3%B6sischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Georgischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Griechischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Haitianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Indischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Indonesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Irakischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Iranischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Irischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Isl%C3%A4ndischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Israelischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Italienischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Jamaikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Japanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Jordanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Jugoslawischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kambodschanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kanadischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kapverdischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kasachischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Katarischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kenianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kolumbianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kroatischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Kubanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Laotischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Lettischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Libanesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Liechtensteinischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Litauischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Luxemburgischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Malischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Maltesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Marokkanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Mauretanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Mazedonischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Mexikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Moldawischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Mongolischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Mosambikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Neuseel%C3%A4ndischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Niederl%C3%A4ndischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Nigerianischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Nordkoreanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Norwegischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:%C3%96sterreichischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Osttimoresischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Pakistanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Panamaischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Paraguayischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Peruanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Philippinischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Polnischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Portugiesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Rum%C3%A4nischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Russischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Saudi-arabischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Schwedischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Schweizer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Senegalesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Serbischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Singapurischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Slowakischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Slowenischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Sowjetischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Spanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Sri-lankischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:S%C3%BCdafrikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:S%C3%BCdkoreanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Syrischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Taiwanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Thail%C3%A4ndischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Tschechischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Tschechoslowakischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Tunesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:T%C3%BCrkischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Ugandischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Ukrainischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Ungarischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Uruguayischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:US-amerikanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Usbekischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Venezolanischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Vietnamesischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Wei%C3%9Frussischer_Film",
            "https://de.wikipedia.org/wiki/Kategorie:Zyprischer_Film"});
            this.comboCategoryMoviesByState.Location = new System.Drawing.Point(262, 54);
            this.comboCategoryMoviesByState.Name = "comboCategoryMoviesByState";
            this.comboCategoryMoviesByState.Size = new System.Drawing.Size(676, 24);
            this.comboCategoryMoviesByState.TabIndex = 10;
            // 
            // btnPopulateCategoryMoviesByState
            // 
            this.btnPopulateCategoryMoviesByState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopulateCategoryMoviesByState.Location = new System.Drawing.Point(944, 24);
            this.btnPopulateCategoryMoviesByState.Name = "btnPopulateCategoryMoviesByState";
            this.btnPopulateCategoryMoviesByState.Size = new System.Drawing.Size(183, 54);
            this.btnPopulateCategoryMoviesByState.TabIndex = 9;
            this.btnPopulateCategoryMoviesByState.Text = "Kategorien einlesen";
            this.btnPopulateCategoryMoviesByState.UseVisualStyleBackColor = true;
            this.btnPopulateCategoryMoviesByState.Click += new System.EventHandler(this.btnPopulateCategoryMoviesByState_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Film-Link-Seite:";
            // 
            // comboTopCategory
            // 
            this.comboTopCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTopCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTopCategory.FormattingEnabled = true;
            this.comboTopCategory.Items.AddRange(new object[] {
            "Filmtitel nach Staat"});
            this.comboTopCategory.Location = new System.Drawing.Point(262, 24);
            this.comboTopCategory.Name = "comboTopCategory";
            this.comboTopCategory.Size = new System.Drawing.Size(676, 24);
            this.comboTopCategory.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Wikipedia Einstiegspunkt --> Kategorie:  ";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.button1);
            this.tabDebug.Controls.Add(this.label4);
            this.tabDebug.Controls.Add(this.btnMoviesPath);
            this.tabDebug.Controls.Add(this.txtMovieFolder);
            this.tabDebug.Controls.Add(this.btnDebugAction);
            this.tabDebug.Controls.Add(this.label2);
            this.tabDebug.Controls.Add(this.reMain);
            this.tabDebug.Controls.Add(this.comboCorpusPath);
            this.tabDebug.Controls.Add(this.label1);
            this.tabDebug.Location = new System.Drawing.Point(4, 25);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(1133, 525);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "Debug-Modus";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(896, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "Refresh !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // txtMovieFolder
            // 
            this.txtMovieFolder.Location = new System.Drawing.Point(111, 44);
            this.txtMovieFolder.Name = "txtMovieFolder";
            this.txtMovieFolder.Size = new System.Drawing.Size(704, 22);
            this.txtMovieFolder.TabIndex = 8;
            // 
            // btnDebugAction
            // 
            this.btnDebugAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugAction.Location = new System.Drawing.Point(1008, 11);
            this.btnDebugAction.Name = "btnDebugAction";
            this.btnDebugAction.Size = new System.Drawing.Size(119, 81);
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
            this.label2.Size = new System.Drawing.Size(236, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Textausgabe (zu Debugging-Zwecke):";
            // 
            // tabGenerateDatabase
            // 
            this.tabGenerateDatabase.Controls.Add(this.label3);
            this.tabGenerateDatabase.Controls.Add(this.groupBox1);
            this.tabGenerateDatabase.Controls.Add(this.reLog);
            this.tabGenerateDatabase.Controls.Add(this.btnExportDatabase);
            this.tabGenerateDatabase.Location = new System.Drawing.Point(4, 25);
            this.tabGenerateDatabase.Name = "tabGenerateDatabase";
            this.tabGenerateDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerateDatabase.Size = new System.Drawing.Size(1133, 525);
            this.tabGenerateDatabase.TabIndex = 0;
            this.tabGenerateDatabase.Text = "Datenbank-Generierung";
            this.tabGenerateDatabase.UseVisualStyleBackColor = true;
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
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 564);
            this.Controls.Add(this.tabOptions);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wikipedia Film-Metadaten Crawler, Parser, Datenbank Generator";
            this.tabOptions.ResumeLayout(false);
            this.tabCrawling.ResumeLayout(false);
            this.tabCrawling.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabGenerateDatabase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox reMain;
        private System.Windows.Forms.ComboBox comboCorpusPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrawlWebsites;
        private System.Windows.Forms.Button btnExportDatabase;
        private System.Windows.Forms.TabControl tabOptions;
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
        private System.Windows.Forms.ComboBox comboTopCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCategoryMoviesByState;
        private System.Windows.Forms.Button btnPopulateCategoryMoviesByState;
        private System.Windows.Forms.Button button1;
    }
}

