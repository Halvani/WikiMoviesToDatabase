﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WikiParser.Crawling;
using WikiParser.MovieItemFactory;

namespace WikiParser
{
    public partial class UI : Form
    {
        // BASIC INFO: https://de.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xmlfm&titles=Independence_Day_%281996%29&rvsection=0
        // MUCH MORE INFO: https://de.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xmlfm&titles=Terminator_%28Film%29
        // SLite Mini-Tutorial: http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/
        // https://de.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xmlfm&titles=König_der_Freibeuter&rvsection=0 


        public string ApplicationPath { get; set; } // The folder of the executable (.exe)
        public string PathOfMovieSites { get; set; } // The folder where we want to save the MediaWiki pages (.htm files).
        public string[] MoviesFilePaths { get; set; } // WTF is this one ???


        #region UI initialization.
        /**************************************************************/
        public UI()
        {
            InitializeComponent();

            ApplicationPath = AppDomain.CurrentDomain.BaseDirectory;
            PathOfMovieSites = string.Concat(ApplicationPath, "Filme_test");
            txtMovieFolder.Text = PathOfMovieSites;
            PopulateComboMovies();

            tabOptions.SelectedTab = tabCrawling;
            comboTopCategory.SelectedIndex = 0;
            comboCategoryMoviesByState.SelectedIndex = 0;          
        }

        private void PopulateComboMovies()
        {
            if (Directory.Exists(PathOfMovieSites))
            {
                MoviesFilePaths = Directory.GetFiles(PathOfMovieSites, "*.htm", SearchOption.TopDirectoryOnly).OrderBy(x => x).ToArray();

                if (MoviesFilePaths.Length > 0)
                {
                    comboCorpusPath.Items.Clear();
                    comboCorpusPath.Items.AddRange(MoviesFilePaths); //.Select(movieFilePath => Path.GetFileNameWithoutExtension(movieFilePath).Replace("_", " ")).ToArray());
                    comboCorpusPath.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(string.Concat("Es existieren keine Film-Webseiten im Ordner:\n", ApplicationPath, "\nCrawlen Sie hierfür zunächst einige Film-Kategorien aus Wikipedia."), "Keine Film-Webseiten vorgefunden !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnMoviesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = PathOfMovieSites;
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            string chosenMoviePath = folderBrowserDialog.SelectedPath;

            if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                PathOfMovieSites = folderBrowserDialog.SelectedPath;
                txtMovieFolder.Text = PathOfMovieSites;
                PopulateComboMovies();
            }
        }
        /**************************************************************/
        #endregion



        private void btnCrawlWebsites_Click(object sender, EventArgs e)
        {
            //string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string wikipediaCategoryURLPath = string.Concat(appPath, @"\Movie URL's\US-Filme.txt");

            //// https://de.wikipedia.org/w/index.php?title=Kategorie:US-amerikanischer_Film&pagefrom=Bi";
            //string[] wikipediaCategoryURLs = File.ReadAllLines(wikipediaCategoryURLPath);

            //foreach (var wikipediaCategoryURL in wikipediaCategoryURLs)
            //{
            //    var mediaWikiMovieUrls = Crawler.ConstructMediaWikiURLs(wikipediaCategoryURL);
            //    foreach (var mediaWikiMovieUrl in mediaWikiMovieUrls)
            //    {
            //        Crawler.PersistMovieWebsite(mediaWikiMovieUrl, PathOfMovieSites);
            //    }
            //}



            // https://de.wikipedia.org/wiki/Kategorie:Israelischer_Film

            var mediaWikiMovieUrls = Crawler.ConstructMediaWikiURLs(comboCategoryMoviesByState.Text);
            foreach (var mediaWikiMovieUrl in mediaWikiMovieUrls)
            {
                Crawler.PersistMovieWebsite(mediaWikiMovieUrl, PathOfMovieSites);
            }
        }


        private void btnExportDatabase_Click(object sender, EventArgs e)
        {
            var movieItemPaths = comboCorpusPath.Items.Cast<string>();
            DBConnector dbConnector = new DBConnector();

            if (optMySQL.Checked)
            {
                dbConnector.Export2MySQLDatabase(movieItemPaths);
            }
            else if (optSQLite.Checked)
            {
                dbConnector.Export2SQLiteDatabase(movieItemPaths);
            }

            MessageBox.Show("Datenbank erstellt & befüllt", "Job finished...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnDebugAction_Click(object sender, EventArgs e)
        {
            MovieItem[] movieItems = MovieFactory.ConstructMovieItems(MoviesFilePaths);

            StringBuilder sb = new StringBuilder();
            foreach (MovieItem movieItem in movieItems)
            {
                sb.AppendLine(movieItem.ToString());
                sb.AppendLine("-----------------------------------------------------------------------");
            }

            reMain.Text = sb.ToString();
        }




        private void PopulateCategoryMoviesByCountry()
        {
            string wikiBaseCategory = @"https://de.wikipedia.org/wiki/";
            string movieTitleByCountry = wikiBaseCategory + "Kategorie:Filmtitel_nach_Staat";

            string[] countries = Crawler.ParseMovieTitlesFromCategoryWiki(movieTitleByCountry);
            foreach (var country in countries)
            {
                // https://de.wikipedia.org/wiki/Kategorie:Jordanischer_Film
                comboCategoryMoviesByState.Items.Add(string.Concat(wikiBaseCategory, country));
            }

            comboCategoryMoviesByState.SelectedIndex = 0;

            File.WriteAllLines(@"C:\data.txt", countries);
        }


        

        private void btnPopulateCategoryMoviesByState_Click(object sender, EventArgs e)
        {
            PopulateCategoryMoviesByCountry();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateComboMovies();
        }
    }
}
