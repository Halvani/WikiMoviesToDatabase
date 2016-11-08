using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace WikiParser.MovieItemFactory
{
    public class MovieFactory
    {
        public string MovieFilePath { get; set; }
        public string[] RawMovieEntries { get; set; }
        public Dictionary<string, string> CleanMovieEntries { get; set; }
        public string MovieDescription { get; set; }
        public string[] Actors { get; set; }
        public string WikipediaMovieID { get; set; }

        public MovieFactory(string movieFilePath)
        {
            MovieFilePath = movieFilePath;
            RawMovieEntries = GetRawMovieEntries();
            CleanMovieEntries = GetCleanMovieEntries();
            MovieDescription = GetMovieDescription();
            Actors = GetActors();
        }


        /// <summary>
        /// Gibt einen MD5 Hash als String zurück
        /// </summary>
        /// <param name="TextToHash">string der Gehasht werden soll.</param>
        /// <returns>Hash als string.</returns>
        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result);
        }


        /// <summary>
        /// Elliminates irrelevant HTML-tags and removes decoding-noise.
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string StripHtmlTags(string html)
        {
            if (String.IsNullOrEmpty(html)) return string.Empty;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return WebUtility.HtmlDecode(doc.DocumentNode.InnerText);
        }



        private string ExtractRevisionBlock()
        {
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(File.ReadAllText(MovieFilePath));

            string preBlock = html.DocumentNode.SelectSingleNode(".//div[contains(@class,'mw-highlight')]").InnerHtml;
            string apiBlock = StripHtmlTags(preBlock);

            HtmlAgilityPack.HtmlDocument infoBoxNode = new HtmlAgilityPack.HtmlDocument();
            infoBoxNode.LoadHtml(apiBlock);
            string revisionBlock = infoBoxNode.DocumentNode.SelectSingleNode(".//rev").InnerText;
            
            var normalizedBlockNode = infoBoxNode.DocumentNode.SelectSingleNode(".//normalized//n[@to]");
            if(normalizedBlockNode != null)
            {
                var movieID = normalizedBlockNode.Attributes["from"].Value;
                WikipediaMovieID = string.IsNullOrEmpty(movieID) ? "Undefined_Wikipedia_Movie_ID" : movieID;
            }

            return revisionBlock;
        }


        /// <summary>
        /// Chooses the last option within an optional block, e.g. [[Nuklearer Holocaust|nuklearem Holocaust]] ---> "nuklearem Holocaust"
        /// </summary>
        /// <param name="dirtyString"></param>
        /// <returns></returns>
        private string ReplaceOptionalWikitextByLastItem(string dirtyString)
        {
            string openBrackets = @"\[\[";
            string closeBrackets = @"\]\]";
            
            
            int start = dirtyString.IndexOf("[[");
            int end = dirtyString.IndexOf("]]");
            if (start == -1 && end == -1) return dirtyString;


            // Elliminate double brackets from single items, e.g. [[Horror]] --> Horror.
            if (Regex.Matches(dirtyString, @"\|").Count == 0)
            {
                string withoutBrackets =  dirtyString.Replace("[[", string.Empty);
                withoutBrackets = withoutBrackets.Replace("]]", string.Empty);

                return withoutBrackets;
            }

            // [[Science-Fiction]]-[[Horrorliteratur|Horror]]
            
            

            string innerItem = @"([ .,„“’0-9A-ZÄÖÜa-zäöüß\(\)#-–]+)"; // Gruppe ! Maureen O’Sullivan (Schauspielerin)|Maureen O’Sullivan
            string pattern = string.Concat(openBrackets, innerItem, @"\|", innerItem, closeBrackets);
            string replacement = string.Concat("[[", "$2", "]]"); // $1 referenziert die erste Gruppe (...), $2 die zweite, usw.

            string result = Regex.Replace(dirtyString, pattern, replacement);
            return Regex.Replace(result, @"[\[\]]+", "");
        }



        private string[] GetRawMovieEntries()
        {
            string revisionBlock = ExtractRevisionBlock();
            string[] lines = revisionBlock.Split('\n');
            string[] infoBoxItem = lines.Skip(1).TakeWhile(line => line.Trim() != "}}").ToArray();

            return infoBoxItem;
        }



        private string[] GetActors()
        {
            List<string> actors = new List<string>(RawMovieEntries.Length);

            string[] dsLines = RawMovieEntries.SkipWhile(line => !line.Contains(@"")).ToArray();
            if (dsLines.Length > 0)
            {
                for (int i = 0; i < dsLines.Length; i++)
                {
                    string line = dsLines[i];

                    if (line.StartsWith(@"*") && line.Contains(":"))
                    {
                        string[] actorMapping = line.Split(':');
                        string actorTrueName = ReplaceOptionalWikitextByLastItem(actorMapping[0]);
                        actorTrueName = actorTrueName.Replace("*", "").Trim();

                        actors.Add(actorTrueName);
                    }
                }
            }
            return actors.ToArray();
        }


        /// <summary>
        /// Extracts a short description about the movie.         
        /// </summary>
        /// <returns></returns>
        private string GetMovieDescription()
        {
            string revisionBlock = ExtractRevisionBlock();
            string[] movieDescriptionLines = revisionBlock.Split('\n').SkipWhile(line => line.Trim() != "}}").ToArray();

            string cleanMovieDescription = string.Join(" ", movieDescriptionLines);
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, @"^\}\}\s+", string.Empty);
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, @"'''", string.Empty);


            // Handle ugly IPA-cases: [{{IPA|dʒʊˈɹæsɪk ˈpɑːɹk}}]
            int posIPAStart = cleanMovieDescription.IndexOf("[{{IPA|");
            int posIPAEnd = cleanMovieDescription.IndexOf("}}]");
            if (posIPAStart != -1)
            {
                string temp = cleanMovieDescription.Substring(posIPAStart, posIPAEnd - posIPAStart + 3);
                cleanMovieDescription = cleanMovieDescription.Replace(temp, string.Empty);
            }
                        

            cleanMovieDescription = ReplaceOptionalWikitextByLastItem(cleanMovieDescription);


            cleanMovieDescription = Regex.Replace(cleanMovieDescription, "&lt;/.*&gt;", string.Empty);
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, "&lt;ref name=&quot;.*&quot;&gt;", " ");
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, "&amp;nbsp;", " ");
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, @"\s{2,}", " ");
            cleanMovieDescription = Regex.Replace(cleanMovieDescription, @"'+", "'");
            

            return cleanMovieDescription;
        }

        


        private bool HasValidSchema()
        {
            string[] movieItemTags = CleanMovieEntries.Keys.ToArray();
            string[] temp = movieItemTags.Select(item => Regex.Replace(item, @"\s+.+", "")).ToArray();
            HashSet<string> currentMovieTags = new HashSet<string>(temp);
            HashSet<string> validMovieTags = new HashSet<string>() { "DT", "OT", "PL", "LEN", "PJ", "OS", "FSK", "REG", "DS" };

            bool isSubset = validMovieTags.IsSubsetOf(currentMovieTags);

            return isSubset;
        }


        public Dictionary<string, string> GetCleanMovieEntries()
        {
            Dictionary<string, string> cleanInfoBoxItems = new Dictionary<string, string>(RawMovieEntries.Length);


            string beginningPipe = @"^\|\s*";

            // Choose last revision entry (most upper right item in [[...|xxx]] bracket-block.)
            for (int i = 0; i < RawMovieEntries.Length; i++)
            {
                string line = RawMovieEntries[i];
                line = ReplaceOptionalWikitextByLastItem(line);

                // Replace non-breakable space.
                line = Regex.Replace(line, @"&amp;nbsp;", " ");  

                // Remove begining pipe-symbol.
                //line = Regex.Replace(line, @"^\|\s*", string.Empty);

                // Replace multiple item-seperator
                line = Regex.Replace(line, @"&lt;br /&gt;", "/");

                // Remove HTML-comments.
                line = Regex.Replace(line, @"&lt;!--.+--&gt;", string.Empty);

                // Remove footnotes.
                line = Regex.Replace(line, @"&amp;lt;(/)?ref&amp;gt;", " ");

                line = Regex.Replace(line, @"&lt;ref.*/ref&gt;", " ");
                // PL =	Vereinigte Staaten,/ Deutschland&lt;ref name=&quot;LdIF&quot;&gt;{{LdiF|527308}}&lt;/ref&gt;

                // Replace html(&)
                line = line.Replace(@"&amp;", "&");

                string contentSection = line.Substring(line.IndexOf("=") + 1).Trim();
                string itemContent = (string.IsNullOrEmpty(contentSection)) ? "<empty>" : contentSection;


                // Replace muliple spaces by only one space.
                line = Regex.Replace(line, @"\s{2,}", " ");

                #region Map movieTags that might have different keys to a unique key, e.g. (PJ|EJ|Produktionsjahr|Erscheinungsjahr) --> PJ
                /******************************************************/
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(DT|Deutscher Name)")))
                {
                    cleanInfoBoxItems.Add("DT", itemContent); 
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(OT|Originaltitel)")))
                {
                    cleanInfoBoxItems.Add("OT", itemContent);
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(PL|Produktionsland)")))
                {
                    cleanInfoBoxItems.Add("PL", itemContent); 
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(PJ|EJ|Produktionsjahr|Produktionsjahre|Erscheinungsjahr)")))
                {
                    if(!cleanInfoBoxItems.ContainsKey("PJ"))
                    {
                        cleanInfoBoxItems.Add("PJ", itemContent); // There are info-boxes of movies with entries for both: Produktionsjahre AND Erscheinungsjahr  
                    }
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(FSK)")))
                {
                    cleanInfoBoxItems.Add("FSK", itemContent);
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, @"(REG|Regie\s*=)")))
                {
                    cleanInfoBoxItems.Add("REG", itemContent);
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(LEN|Länge)")))
                {
                    if (!cleanInfoBoxItems.ContainsKey("LEN"))
                    {
                        cleanInfoBoxItems.Add("LEN", itemContent);   
                    }                    
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(OS|Originalsprache)")))
                {
                    cleanInfoBoxItems.Add("OS", itemContent);
                }
                if (Regex.IsMatch(line, string.Concat(beginningPipe, "(DS|Darsteller)")))
                {
                    cleanInfoBoxItems.Add("DS", itemContent);
                }
                /******************************************************/
                #endregion
            }

            return cleanInfoBoxItems;
        }



        public MovieItem ConstructMovieItem()
        {
            // Vereinigten Staaten‎ --> USA 
            if (!HasValidSchema()) return null;

            #region Initialize movieItem properties.
            /***************************************************/
            string DT = string.Empty;
            string OT = string.Empty;
            string[] PL = new string[] { };
            int PJ = -1;
            int FSK = -1;
            int LEN = -1;
            string[] OS = new string[] { };
            string REG = string.Empty;
            string[] DS = new string[] { };
            /***************************************************/
            #endregion

            #region Apply cleaning operations on each movieItem.
            /*********************************************************/
            string seperator = ", ";

            foreach (var infoBoxItem in CleanMovieEntries.Keys)
            {
                switch(infoBoxItem)
                {
                    case "DT": DT = CleanMovieEntries[infoBoxItem]; break;
                    case "OT": OT = CleanMovieEntries[infoBoxItem]; break;

                    case "PL":
                        {
                            string tempPL = CleanMovieEntries[infoBoxItem];
                            tempPL = tempPL.Replace("Vereinigte Staaten", "USA");

                            if (tempPL.IndexOf(seperator) == -1)
                            {
                                PL = new string[] { tempPL };
                            }
                            else
                            {
                                PL = tempPL.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            int JJ = tempPL.Length;
                            break;
                        }

                    case "PJ":
                        {
                            string tempPJ = CleanMovieEntries[infoBoxItem];
                            bool containsOnlyDigits = tempPJ.All(c => Char.IsDigit(c));                            

                            if (containsOnlyDigits)
                            {
                                PJ = int.Parse(tempPJ);
                            }
                            else if (tempPJ == "<empty>") 
                            {
                                PJ = -1; 
                            }
                            else
                            {
                                Regex regexObj = new Regex(@"[^\d]");
                                string cleanPJ = regexObj.Replace(tempPJ, "");
                                PJ = int.Parse(cleanPJ);
                            }                           

                            break;
                        }

                    case "FSK":
                        {
                            StringBuilder sb = new StringBuilder(CleanMovieEntries[infoBoxItem].ToLower());
                            sb.Replace("&thinsp;", " ");
                            sb.Replace("\"", string.Empty);
                            sb.Replace("'", string.Empty);
                            sb.Replace("ab ", string.Empty);
                            sb.Replace("fsk", string.Empty);
                            sb.Replace("kino:", string.Empty);
                            sb.Replace("kinofassung:", string.Empty);
                            sb.Replace("freigegeben", string.Empty);
                            string tempFSK = sb.ToString().Trim();
                            tempFSK = Regex.Replace(tempFSK, @"^[:|]\s*", string.Empty);


                            // Handle evil cases like: "/1977: 16/1978: 12"
                            if (Regex.IsMatch(tempFSK, @".+[0-9]{4}:\s*[0-9]+$"))
                            {
                                tempFSK = tempFSK.Substring(tempFSK.LastIndexOf(":") + 1).Trim();
                            }

                            // Handle the case, where there are new/old FSK settings.
                            if (Regex.IsMatch(tempFSK, @"^alt\s+[0-9]+/neu\s+[0-9]+$"))
                            {
                                tempFSK = tempFSK.Split('/')[1];

                                Regex regexObj = new Regex(@"[^\d]");
                                tempFSK = regexObj.Replace(tempFSK, string.Empty);
                            }

                       
                            bool containsOnlyDigits = tempFSK.All(c => Char.IsDigit(c));
                            
                            if (Regex.IsMatch(tempFSK, @"(nicht|un)\s*(getestet|geprüft|bekannt)") || Regex.IsMatch(tempFSK, @"^(<empty>|\?|n.a.)$") || tempFSK.StartsWith("früher") || tempFSK.StartsWith("usa:")) // Keep in mind that this is ambigue, as no FSK-setting can describe a movie that is for 0-ages.
                            {
                                FSK = -1; // Note: There is no option the "null" an int data type !
                            }
                            else if ( Regex.IsMatch(tempFSK, "[-–]") || tempFSK == "ohne" || tempFSK == "keine" || tempFSK.StartsWith("o.a.") || Regex.IsMatch(tempFSK, @"(o.\s*a.*|o.\s*al.|ohne al.|ohne altersfreigabe)") || Regex.IsMatch(tempFSK, @"(k.\s*a.|keine angabe)") || Regex.IsMatch(tempFSK, @"\(*(keine|ohne)\s+(altersbe|ein|be)schränkung\)*"))
                            {
                                FSK = 0; 
                            }
                            else if (Regex.IsMatch(tempFSK, @"spio\s*/\s*jk") || tempFSK.StartsWith("ungeprüft") || tempFSK.IndexOf("strafrechtlich unbedenklich") != -1 || tempFSK.IndexOf("beschlagnahmt") != -1  || tempFSK.IndexOf("indiziert") != -1 ||  tempFSK.StartsWith("adult content")  || tempFSK.StartsWith("ohne freigabe") || tempFSK.StartsWith("kj") || tempFSK.IndexOf("keine jugendfreigabe") != -1)
                            {
                                FSK = 18; 
                            }
                            else if (containsOnlyDigits)
                            {
                                FSK = int.Parse(tempFSK);
                            }
                            else 
                            {
                                Regex temp = new Regex(@"\{\{.*\}\}");  // Cases like: "12{{fsk|0611|106485vdvdumd}}", "16 jahren{{|0807|114556vdvdumd}}"
                                string cleanTemp = temp.Replace(tempFSK, string.Empty);

                                char[] digits = cleanTemp.TakeWhile(c => char.IsDigit(c)).ToArray();
                                cleanTemp = new string(digits);

                                FSK = int.Parse(cleanTemp);
                            }
                            break;
                        }

                    case "LEN": 
                        {
                            string tempLEN = CleanMovieEntries[infoBoxItem];
                            bool containsOnlyDigits = tempLEN.All(c => Char.IsDigit(c));


                            if(tempLEN == "<empty>")
                            {
                                LEN = -1;
                            }
                            else if (containsOnlyDigits)
                            {
                                LEN = int.Parse(tempLEN);
                            }
                            else
                            {
                                // Wenn die Längenangabe mit irgendwas AUSSER Zahlen anfängt dann weg damit !
                                tempLEN = Regex.Replace(tempLEN, "^[^0-9]+", string.Empty);

                                char[] digits = tempLEN.TakeWhile(c => Char.IsDigit(c)).ToArray();
                                tempLEN = new string(digits);

                                LEN = int.Parse(tempLEN);
                            }
                            break;
                        }
                        
                    case "OS":
                        {
                            string tempOS = CleanMovieEntries[infoBoxItem];
                            if (tempOS.IndexOf(seperator) == -1)
                            {
                                OS = new string[]{ tempOS };
                            }
                            else
                            {
                                OS = tempOS.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
                            }                            
                            break;
                        }

                    case "REG":
                        {
                            REG = CleanMovieEntries[infoBoxItem];
                            break;
                        }

                    case "DS":
                        {
                            if(Actors.Length == 0)
                            {
                                DS = new string[] { "<empty>" };
                            }
                            else
                            {
                                DS = Actors;
                            }
                            
                            break;
                        }
                    default: break;
                }
            }
            /*********************************************************/
            #endregion

            #region Construct the movieItem object.
            /*************************************************/
            if (DT == "<empty>")
            {
                DT = OT;
            }

            MovieItem movieItem = new MovieItem()
            {
                DeutscherTitel = DT,
                OriginalTitel = OT,
                ProduktionsLaender = PL,
                ProduktionsJahr = PJ,
                FreiwilligeSelbstKontrolle = FSK,
                Laenge = LEN,
                OriginalSprachen = OS,
                Regisseur = REG,
                Darsteller = DS,
                WikipediaLink = string.Concat("https://de.wikipedia.org/wiki/", WikipediaMovieID),
                Filmkurzbeschreibung = GetMovieDescription()                
            };

            // Define the primaryKey based on a hash of all relevant items.
            movieItem.ID = GetMD5Hash(movieItem.ToString());
            /*************************************************/
            #endregion


            return movieItem;
        }

        
        public static MovieItem[] ConstructMovieItems(IEnumerable<string> movieItemPaths)
        {
            List<MovieItem> movieItems = new List<MovieItem>(movieItemPaths.Count());

            foreach (var movieItemPath in movieItemPaths)
            {
                if (string.IsNullOrEmpty(movieItemPath)) continue;

                MovieFactory movieItemBuilder = new MovieFactory(movieItemPath);
                MovieItem movieItem = movieItemBuilder.ConstructMovieItem();

                if (movieItem != null)
                {
                    movieItems.Add(movieItem);
                }
            }
            return movieItems.ToArray();
        }
    }
}
