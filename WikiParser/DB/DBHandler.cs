using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace WikiParser
{
    public class DBConnector
    {
        public string DatabaseName { get; set; }

        
        private string EscapeSqlString(string command)
        {
            string clean = Regex.Replace(command, @"[ˈ'′]+", "''");
            clean = Regex.Replace(clean, @"[;]+", ".");

            return clean;
        }


        public void Export2SQLiteDatabase(IEnumerable<string> movieItemPaths)
        {
            #region Define and connect to the local database.
            /******************************************************/
            DatabaseName = "MovieDatabase.sqlite";
            SQLiteConnection.CreateFile(DatabaseName);

            SQLiteConnection sqlConnection = new SQLiteConnection("Data Source=" + DatabaseName + ";Version=3;");
            sqlConnection.Open();
            /******************************************************/
            #endregion

            #region Define necessary tables.
            /******************************************************/
            string sql_TABLE_ProductionCountries = "CREATE TABLE ProductionCountries (ID VARCHAR(50), ProductionCountry VARCHAR(50))";
            string sql_TABLE_Languages = "CREATE TABLE Languages (ID VARCHAR(50), Language VARCHAR(50))";
            string sql_TABLE_Actors = "CREATE TABLE Actors (ID VARCHAR(50), Name VARCHAR(50))";
            string sql_TABLE_MovieItems = "CREATE TABLE MovieItems (ID VARCHAR(50), DT VARCHAR(50), OT VARCHAR(50), LEN INT, PJ INT, FSK INT, REG VARCHAR(50), INF VARCHAR(50))";

            SQLiteCommand cmd_TABLE_ProductionCountries = new SQLiteCommand(sql_TABLE_ProductionCountries, sqlConnection);
            SQLiteCommand cmd_TABLE_Languages = new SQLiteCommand(sql_TABLE_Languages, sqlConnection);
            SQLiteCommand cmd_TABLE_Actors = new SQLiteCommand(sql_TABLE_Actors, sqlConnection);
            SQLiteCommand cmd_TABLE_MovieItems = new SQLiteCommand(sql_TABLE_MovieItems, sqlConnection);

            cmd_TABLE_ProductionCountries.ExecuteNonQuery();
            cmd_TABLE_Languages.ExecuteNonQuery();
            cmd_TABLE_Actors.ExecuteNonQuery();
            cmd_TABLE_MovieItems.ExecuteNonQuery();
            /******************************************************/
            #endregion

            #region Fill the tables.
            /******************************************************/            
            MovieItem[] movieItems = MovieItemFactory.MovieFactory.ConstructMovieItems(movieItemPaths);

            foreach (MovieItem movieItem in movieItems)
            {
                string[] productionCountries = movieItem.ProduktionsLaender;
                foreach (var productionCountry in productionCountries)
                {
                    string cmd_INSERT_ProductionCountries = "insert into ProductionCountries (ID, ProductionCountry) values('" + movieItem.ID + "', '" + EscapeSqlString(productionCountry) + "')";
                    SQLiteCommand command_INSERT_ProductionCountries = new SQLiteCommand(cmd_INSERT_ProductionCountries, sqlConnection);
                    command_INSERT_ProductionCountries.ExecuteNonQuery();
                }


                string[] languages = movieItem.OriginalSprachen;
                foreach (var language in languages)
                {
                    string sql_INSERT_Languages = "insert into Languages (ID, Language) values('" + movieItem.ID + "', '" + EscapeSqlString(language) + "')";
                    SQLiteCommand command_INSERT_Languages = new SQLiteCommand(sql_INSERT_Languages, sqlConnection);
                    command_INSERT_Languages.ExecuteNonQuery();
                }


                string[] actors = movieItem.Darsteller;
                foreach (var actor in actors)
                {
                    string sql_INSERT_Actors = "insert into Actors (ID, Name) values('" + movieItem.ID + "', '" + EscapeSqlString(actor) + "')";
                    SQLiteCommand command_INSERT_Actors = new SQLiteCommand(sql_INSERT_Actors, sqlConnection);
                    command_INSERT_Actors.ExecuteNonQuery();
                }

                string sql_INSERT_MovieItem = string.Concat(
                    "insert into MovieItems (ID, DT, OT, LEN, PJ, FSK, REG, INF) values ('",
                    movieItem.ID, "', '",
                    EscapeSqlString(movieItem.DeutscherTitel), "', '",
                    EscapeSqlString(movieItem.OriginalTitel), "', '",
                    movieItem.Laenge, "', '",
                    movieItem.ProduktionsJahr, "', '",
                    movieItem.FreiwilligeSelbstKontrolle, "', '",
                    movieItem.Regisseur, "', '",
                    EscapeSqlString(movieItem.Filmkurzbeschreibung), "')");

                SQLiteCommand command_INSERT_MovieItem = new SQLiteCommand(sql_INSERT_MovieItem, sqlConnection);
                command_INSERT_MovieItem.ExecuteNonQuery();
            }

            sqlConnection.Close();            
            /******************************************************/
            #endregion
        }





        public void Export2MySQLDatabase(IEnumerable<string> movieItemPaths)
        {
            string connstring = string.Format("Server=localhost; database={0}; UID=jonas; password=", "wba");
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();

            if (connection != null)
            {
                string sql_TABLE_ProductionCountries = "CREATE TABLE ProductionCountries (ID VARCHAR(50), ProductionCountry VARCHAR(50))";
                string sql_TABLE_Languages = "CREATE TABLE Languages (ID VARCHAR(50), Language VARCHAR(50))";
                string sql_TABLE_Actors = "CREATE TABLE Actors (ID VARCHAR(50), Name VARCHAR(50))";
                string sql_TABLE_MovieItems =
                    "CREATE TABLE MovieItems (ID VARCHAR(50), DT VARCHAR(100), OT VARCHAR(100), LEN INT, PJ INT, FSK INT, REG VARCHAR(100), WID VARCHAR(200), DSC VARCHAR(2000))";

                MySqlCommand cmd_TABLE_ProductionCountries = new MySqlCommand(sql_TABLE_ProductionCountries, connection);
                MySqlCommand cmd_TABLE_Languages = new MySqlCommand(sql_TABLE_Languages, connection);
                MySqlCommand cmd_TABLE_Actors = new MySqlCommand(sql_TABLE_Actors, connection);
                MySqlCommand cmd_TABLE_MovieItems = new MySqlCommand(sql_TABLE_MovieItems, connection);

                cmd_TABLE_ProductionCountries.ExecuteNonQuery();
                cmd_TABLE_Languages.ExecuteNonQuery();
                cmd_TABLE_Actors.ExecuteNonQuery();
                cmd_TABLE_MovieItems.ExecuteNonQuery();


                #region Fill the tables.
                /******************************************************/
                MovieItem[] movieItems = MovieItemFactory.MovieFactory.ConstructMovieItems(movieItemPaths);

                foreach (MovieItem movieItem in movieItems)
                {
                    string[] productionCountries = movieItem.ProduktionsLaender;
                    foreach (var productionCountry in productionCountries)
                    {
                        string cmd_INSERT_ProductionCountries = "insert into ProductionCountries (ID, ProductionCountry) values('" + movieItem.ID + "', '" + EscapeSqlString(productionCountry) + "')";
                        MySqlCommand command_INSERT_ProductionCountries = new MySqlCommand(cmd_INSERT_ProductionCountries, connection);
                        command_INSERT_ProductionCountries.ExecuteNonQuery();
                    }


                    string[] languages = movieItem.OriginalSprachen;
                    foreach (var language in languages)
                    {
                        string sql_INSERT_Languages = "insert into Languages (ID, Language) values('" + movieItem.ID + "', '" + EscapeSqlString(language) + "')";
                        MySqlCommand command_INSERT_Languages = new MySqlCommand(sql_INSERT_Languages, connection);
                        command_INSERT_Languages.ExecuteNonQuery();
                    }


                    string[] actors = movieItem.Darsteller;
                    foreach (var actor in actors)
                    {
                        string sql_INSERT_Actors = "insert into Actors (ID, Name) values('" + movieItem.ID + "', '" + EscapeSqlString(actor) + "')";
                        MySqlCommand command_INSERT_Actors = new MySqlCommand(sql_INSERT_Actors, connection);
                        command_INSERT_Actors.ExecuteNonQuery();
                    }

                    string sql_INSERT_MovieItem = string.Concat(
                        "insert into MovieItems (ID, DT, OT, LEN, PJ, FSK, REG, WID, DSC) values ('",
                        movieItem.ID, "', '",
                        EscapeSqlString(movieItem.DeutscherTitel), "', '",
                        EscapeSqlString(movieItem.OriginalTitel), "', '",
                        movieItem.Laenge, "', '",
                        movieItem.ProduktionsJahr, "', '",
                        movieItem.FreiwilligeSelbstKontrolle, "', '",
                        EscapeSqlString(movieItem.Regisseur), "', '",
                        EscapeSqlString(movieItem.WikipediaLink), "', '",
                        EscapeSqlString(movieItem.Filmkurzbeschreibung) , "')");

                    MySqlCommand command_INSERT_MovieItem = new MySqlCommand(sql_INSERT_MovieItem, connection);
                    command_INSERT_MovieItem.ExecuteNonQuery();
                }
                /******************************************************/
                #endregion
            }

            connection.Close();
        }
    }
}