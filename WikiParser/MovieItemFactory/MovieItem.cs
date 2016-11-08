using System;
using System.Collections.Generic;

namespace WikiParser
{
    public class MovieItem
    {
        public string ID { get; set; }

        //DT      = The Day After Tomorrow 
        public string DeutscherTitel { get; set; }

        // OT      = The Day After Tomorrow 
        public string OriginalTitel { get; set; }

        //PL      = Vereinigte Staaten 
        public string[] ProduktionsLaender { get; set; }

        //PJ      = 2004 
        public int ProduktionsJahr { get; set; }

        //FSK     = 12{{FSK 0405 97957K}} 
        public int FreiwilligeSelbstKontrolle { get; set; }
        
        //LEN     = 118 
        public int Laenge { get; set; }

        //OS      = Englisch 
        public string[] OriginalSprachen { get; set; }

        //REG     = Roland Emmerich 
        public string Regisseur { get; set; }

        //DRB     = Roland Emmerich  / Jeffrey Nachmanoff 
        public List<string> Drehbuch { get; set; }

        //PRO     = Roland Emmerich  / Mark Gordon 
        public List<string> Produzenten { get; set; }

        //DS      = * Dennis Quaid: Jack Hall * Jake Gyllenhaal: Sam Hall * Emmy Rossum: Laura Chapman * Ian Holm: Terry Rapson * Kenneth Welsh: Vizepräsident Becker * Sela Ward: Dr. Lucy Hall * Dash Mihok: Jason Evans * Austin Nichols: J.D. * Perry King: US-Präsident Blake * Arjay Smith: Brian Parks * Tamlyn Tomita: Janet Tokada * Sasha Roiz: Parker * Glenn Plummer: Luther * Nestor Serrano: Gomez * Jay O. Sanders: Frank Harris 
        public string[] Darsteller { get; set; }

        //'''Filmtitel''' 
        public string Filmkurzbeschreibung { get; set; }
        
        public string WikipediaLink { get; set; }
       

        public string[] GetItems()
        {
            return new string[] 
            {
                string.Concat("DT =\t",  DeutscherTitel),
                string.Concat("OT =\t",  OriginalTitel),
                string.Concat("PL =\t",  string.Join(", ", ProduktionsLaender)),
                string.Concat("PJ =\t",  ProduktionsJahr),
                string.Concat("FSK =\t",  FreiwilligeSelbstKontrolle),
                string.Concat("LEN =\t",  Laenge),
                string.Concat("OS =\t",  string.Join(", ", OriginalSprachen)), 
                string.Concat("REG =\t",  Regisseur),
                string.Concat("DS =\t",  string.Join(", ", Darsteller)),
                string.Concat("WID =\t",  WikipediaLink),
                string.Concat("INF =\t",  Filmkurzbeschreibung)
            };
        }

        public override string ToString()
        {
            return string.Join("\n", GetItems());
        }
    }
}
