using System;
using System.Text.RegularExpressions;

namespace TSMinschrijfApp
{
    public class Leerling
    {
        //variables
        public String naam { get; set; }
        public String voornaam { get; set; }
        public String geboorteplaats { get; set; }
        public String geboortedatum { get; set;  }
        public String nationaliteit { get; set; }
        public String geslacht { get; set; }
        public String nationaalnummer { get; set; }
        public String straat { get; set; }
        public string straatZonderNr { get; set; }
        public string huisNr { get; set; }
        public string bus { get; set; }
        public String postcode { get; set; }
        public String gemeente { get; set; }
        public String land { get; set; }
        public Byte[] pasfoto { get; set; }

        public Leerling()
    {
            //waarden initialiseren met null waarden
            leegMaken();
            land = "Belgie";

    }  
        public void inLezen(EIDinleesCode ingelezenKaart)
        {
            //waarden instellen vanuit ingelezen EIDkaart
            voornaam = ingelezenKaart.voornaam;
            naam = ingelezenKaart.naam;
            geboorteplaats = ingelezenKaart.geboorteplaats;
            geboortedatum = ingelezenKaart.geboortedatum;
            nationaliteit = ingelezenKaart.nationaliteit;
            geslacht = ingelezenKaart.geslacht;
            nationaalnummer = ingelezenKaart.nationaalnummer;
            straat = ingelezenKaart.straat;
            postcode = ingelezenKaart.postcode;
            gemeente = ingelezenKaart.gemeente;
            land = ingelezenKaart.land;
            pasfoto = ingelezenKaart.pasfoto;

        }
        public void leegMaken()
        {
            //leerling waarden leegmaken
            voornaam = "";
            naam = "";
            geboorteplaats = "";
            geboortedatum = "";
            nationaliteit = "";
            geslacht = "";
            nationaalnummer = "";
            straat = "";
            straatZonderNr = "";
            huisNr = "";
            bus = "";
            postcode = "";
            gemeente = "";
            land = "";
            pasfoto = null;
        }

        //straat terug geven na splitsen straat string
        public void straatControleren(Leerling leerling)
        {
             string[] s = straat.Split(Convert.ToChar(" "));
            //voor straatnaam uit 1 stuk zonder bus of andere extraas
            if (s.Length == 2)
            {
                leerling.straatZonderNr = s[0];
                leerling.huisNr = s[1];
            } else
            {
                if (s.Length == 3 | Regex.IsMatch(s[s.Length - 1], @"^\d"))
                {
                    straatZonderNr = s[0] + s[1];
                    huisNr = s[s.Length - 1];
                } else
                {
                    //scherm aanmaken om gebruiker manueel het adres te laten controleren
                    StraatControleScherm controleScherm = new StraatControleScherm(leerling);
                
                }
            }
             
                    
                     
        }
        public DateTime geboorteDatumOmzetenDateTime()
        {
            //geboortedatum string gaan splitsen en omzetten naar DateTime
            //gebruik hiervoor een methode om standaard deze als string te laten voor het bewaren op schijf
            
            string[] d = geboortedatum.Split(Convert.ToChar(" "));
            

            switch (d[1].ToLower().Substring(0, 3))
            {
                case "jan":
                    return new System.DateTime(Convert.ToInt32(d[3]), 1, Convert.ToInt32(d[0]));
                case "feb":
                    return new System.DateTime(Convert.ToInt32(d[3]), 2, Convert.ToInt32(d[0]));
                case "maa":
                    return new System.DateTime(Convert.ToInt32(d[3]), 3, Convert.ToInt32(d[0]));
                case "apr":
                    return new System.DateTime(Convert.ToInt32(d[3]), 4, Convert.ToInt32(d[0]));
                case "mei":
                    return new System.DateTime(Convert.ToInt32(d[3]), 5, Convert.ToInt32(d[0]));
                case "jun":
                    return new System.DateTime(Convert.ToInt32(d[3]), 6, Convert.ToInt32(d[0]));
                case "jul":
                    return new System.DateTime(Convert.ToInt32(d[3]), 7, Convert.ToInt32(d[0]));
                case "aug":
                    return new System.DateTime(Convert.ToInt32(d[3]), 8, Convert.ToInt32(d[0]));
                case "sep":
                    return new System.DateTime(Convert.ToInt32(d[3]), 9, Convert.ToInt32(d[0]));
                case "okt":
                    return new System.DateTime(Convert.ToInt32(d[3]), 10, Convert.ToInt32(d[0]));
                case "nov":
                    return new System.DateTime(Convert.ToInt32(d[3]), 11, Convert.ToInt32(d[0]));
                case "dec":
                    return new System.DateTime(Convert.ToInt32(d[3]), 12, Convert.ToInt32(d[0]));
                default:
                    return new System.DateTime(1900, 1, 1);
            }
           
        }
    }
}
