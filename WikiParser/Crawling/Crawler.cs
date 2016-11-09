using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace WikiParser.Crawling
{
    public class Crawler
    {        

        public static string[] ParseMovieTitlesFromCategoryWiki(string wikipediaCategoryURL)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load(wikipediaCategoryURL);
            var divBlock = doc.DocumentNode.SelectSingleNode(".//div[contains(@class,'mw-category')]");            

            // Remember: "//" searches from the beginning of the document. In contrast: ".//" searches anything the current node.
            List<string> tempMovieURLs = new List<string>();
            foreach (HtmlNode link in divBlock.SelectNodes(".//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];

                foreach (var wuff in att.Value.Split(' '))
                {
                    string cleanedMovieTitle = Regex.Replace(wuff, @"/wiki/", "");
                    tempMovieURLs.Add(cleanedMovieTitle);
                }
            }

            string[] parsedMovieTitles = tempMovieURLs.ToArray();
            return parsedMovieTitles;
        }
        


        public static string[] ConstructMediaWikiURLs(string wikipediaCategoryURL)
        {
            var parsedMovieTitles = ParseMovieTitlesFromCategoryWiki(wikipediaCategoryURL);

            #region Request MediaWiki.
            /*************************************************************/
            // https://de.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xmlfm&titles=Stephen_Kings_Es&rvsection=0 

            string mediaWikiBaseURL = @"https://de.wikipedia.org/w/api.php?action=query&prop=revisions&rvprop=content&format=xmlfm&titles=";
            string mediaWikiEnd = "&rvsection=0";
            /*************************************************************/
            #endregion

            string[] mediaWikiMovieUrls = parsedMovieTitles;

            for (int i = 0; i < mediaWikiMovieUrls.Length; i++)
            {
                string movieTitle = mediaWikiMovieUrls[i];
                string movieTitleURL = string.Concat(mediaWikiBaseURL, movieTitle, mediaWikiEnd);

                mediaWikiMovieUrls[i] = movieTitleURL;
            }

            return mediaWikiMovieUrls;
        }


        public static void PersistMovieWebsite(string mediaWikiMovieUrl, string folderPath)
        {
            string temp = "&titles=";
            string movieTitle = mediaWikiMovieUrl.Substring(mediaWikiMovieUrl.IndexOf(temp) + temp.Length);

            int pos = mediaWikiMovieUrl.IndexOf(temp) + temp.Length;
            movieTitle = mediaWikiMovieUrl.Substring(pos);
            movieTitle = movieTitle.Replace("&rvsection=0", "");
            movieTitle = Regex.Replace(movieTitle, @"[\/?:*""><|]+", string.Empty, RegexOptions.Compiled);

            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //string fileName = string.Concat(appPath, @"\Filme\", movieTitle, ".htm");
            string fileName = string.Concat(folderPath, @"\", movieTitle, ".htm");

            WebClient webClient = new WebClient();
            webClient.DownloadFile(mediaWikiMovieUrl, fileName);
            webClient.Dispose();
        }
    }
}
