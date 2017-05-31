using System;
using System.Security;
using Microsoft.SharePoint.Client;
using System.Windows.Forms;
using System.Diagnostics;

namespace TSMinschrijfApp
{
    class SharepointBewerkingen
    {
        //foutafhandeling nog programmeren voor de verbinding met sharepoint
        string userName;
        string paswoord;
        ClientContext context;
        //Web web;
        //List announcementsList;
        SharePointOnlineCredentials credentials; 
        public SharepointBewerkingen(string username,string password)
        {
            this.userName = username;
            this.paswoord = password;
        }
        //methode die gaat controleren of leerling niet al bestaat in de sharepointlist
        public Boolean ControleerOfLeerlingAlBestaat(Leerling teControlerenLeerling)
        {
            var securePassword = new SecureString();
            foreach (var c in paswoord)
            {
                securePassword.AppendChar(c);
            }
            credentials = new SharePointOnlineCredentials(userName, securePassword);
            //context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM ICT/");
            context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM Globaal/");
            context.Credentials = credentials;
            // Het sharepoint web binnenhalen.
            Web web = context.Web;
            // De bestaande lijst die we nodig hebben binnenhalen "Testlijst - Inschrijvingen eID". 
            // List announcementsList = context.Web.Lists.GetByTitle("Testlijst - Inschrijvingen eID");
            List announcementsList = context.Web.Lists.GetByTitle("MS Inschrijvingen - TEST");
            // This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll" 
            // so that it grabs all list items, regardless of the folder they are in. 
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            ListItemCollection items = announcementsList.GetItems(query);
            // Retrieve all items in the ListItemCollection from List.GetItems(Query). 
            context.Load(items);
            context.ExecuteQuery();
            foreach (ListItem listItem in items)
            {
                // teControlerenLeerling.naam == listItem["Title"]|teControlerenLeerling.voornaam == listItem["rszx"]|
                
                // We have all the list item data. For example, Title. 
                if (teControlerenLeerling.nationaalnummer.Equals(listItem["mofc"]))
                {
                    //leerling bestaat reeds
                    return true;
                }
            }
            //leerling bestaat nog niet
            return false;
        }
        public String VraagContentId(Leerling teControlerenLeerling)
        {
            var securePassword = new SecureString();
            foreach (var c in paswoord)
            {
                securePassword.AppendChar(c);
            }
            credentials = new SharePointOnlineCredentials(userName, securePassword);
            //context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM ICT/");
            context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM Globaal/");
            context.Credentials = credentials;
            // Het sharepoint web binnenhalen.
            Web web = context.Web;
            // De bestaande lijst die we nodig hebben binnenhalen "Testlijst - Inschrijvingen eID". 
            // List announcementsList = context.Web.Lists.GetByTitle("Testlijst - Inschrijvingen eID");
            List announcementsList = context.Web.Lists.GetByTitle("MS Inschrijvingen - TEST");
            // This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll" 
            // so that it grabs all list items, regardless of the folder they are in. 
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            ListItemCollection items = announcementsList.GetItems(query);
            // Retrieve all items in the ListItemCollection from List.GetItems(Query). 
            context.Load(items);
            context.ExecuteQuery();
            MessageBox.Show("Tot hier geraak ik");
            foreach (ListItem listItem in items)
            {
                
                // juiste leerling opzoeken op bass van nationaalnummer. 
                if (teControlerenLeerling.nationaalnummer.Equals(listItem["mofc"]))
                {
                    //leerling ID terug sturen voor opbouw URL
                    return listItem["ID"].ToString();
                }
            }
            //Moest leerling toch niet gevonden worden volgende terug sturen.
            return "Leerling niet gevonden";
        }
        public void  LeerlingBewarenInSharepointList(Leerling teBewarenLeerling,String schooljaar)
        {
            
            var securePassword = new SecureString();
            foreach (var c in paswoord)
            {
                securePassword.AppendChar(c);
            }
            credentials = new SharePointOnlineCredentials(userName, securePassword);
            //context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM ICT/");
            context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM Globaal/");
            context.Credentials = credentials;

            // Het sharepoint web binnenhalen.
            Web web = context.Web;
            // De bestaande lijst die we nodig hebben binnenhalen "Testlijst - Inschrijvingen eID". 
            //List announcementsList = context.Web.Lists.GetByTitle("Testlijst - Inschrijvingen eID");
            List announcementsList = context.Web.Lists.GetByTitle("MS Inschrijvingen - TEST");
            // List item aanmaken op basis van de leerling die we willen aanmaken in sharepoint

            //standaard aanmaak info gegevens aanmaken. indien nodig kan je hier bepaalde gegevens specifieren
            ListItemCreationInformation itemAanmaakInfo = new ListItemCreationInformation();
            //list item aanmaken en linken met opgevraagde lijst
            ListItem nieuwItem = announcementsList.AddItem(itemAanmaakInfo);
            //NAAM
            nieuwItem["Title"] = teBewarenLeerling.naam;
            //VOORNAAM
            nieuwItem["_x006c_a76"] = teBewarenLeerling.voornaam;
            //NATIONAALNUMMER
            nieuwItem["mofc"] = teBewarenLeerling.nationaalnummer;
            //GEBOORTEPLAATS
            nieuwItem["_x0071_py8"] = teBewarenLeerling.geboorteplaats;
            //GEBOORTEDATUM
            nieuwItem["lpcu"] = teBewarenLeerling.geboorteDatumOmzetenDateTime();
            //STRAAT
            nieuwItem["leerling_adres_straat"] = teBewarenLeerling.straatZonderNr;
            //NR
            nieuwItem["leerling_adres_nummer"] = teBewarenLeerling.huisNr;
            //BUS
            nieuwItem["leerling_adres_bus"] = teBewarenLeerling.bus;
            //POSTCODE
            nieuwItem["leerling_adres_postcode"] = teBewarenLeerling.postcode;
            //GEMEENTE
            nieuwItem["leerling_adres_gemeente"] = teBewarenLeerling.gemeente;
            //LAND
            nieuwItem["leerling_adres_land"] = teBewarenLeerling.land;
            //NATIONALITEIT
            nieuwItem["eo9y"] = teBewarenLeerling.nationaliteit;
            //SCHOOLJAAR
            nieuwItem["ins_schooljaar"] = schooljaar;
            //GESLACHT
            if (teBewarenLeerling.geslacht == "M")
            {
                nieuwItem["leerling_geslacht"] = "Man";
            } else
            {
                nieuwItem["leerling_geslacht"] = "Vrouw";
            }     
            //nieuwe gegevens updaten in item lijst
            nieuwItem.Update();
            //



            //de aanmaak query uitvoeren tegenover de sharepoint server.
            context.ExecuteQuery();

            //laten weten dat leerling aangemaakt is
            DialogResult dResult = MessageBox.Show("Leerling is aangemaakt. Verder gaan op inschrijvingssite ?", "Inschrijving resultaat", MessageBoxButtons.OKCancel);
            if (dResult == DialogResult.OK)
            {
                if (VraagContentId(teBewarenLeerling) == "Leerling niet gevonden")
                {
                    String url = "https://technischescholenmechel.sharepoint.com/TSM%20Globaal/Lists/MS%20Inschrijvingen%20%20TEST/Item/editifs.aspx?List=fac6218d%2D5da6%2D4dd4%2D9f27%2Dd51e2306b156&ID=" + VraagContentId(teBewarenLeerling) + "&Source=https%3A%2F%2Ftechnischescholenmechel%2Esharepoint%2Ecom%2FTSM%2520Globaal%2FLists%2FMS%2520Inschrijvingen%2520%2520TEST%2FOverzicht%2Easpx&ContentTypeId=0x0100F6FB02CA6D57EC41B63B32BBDE8F5824";
                    Process.Start(url);
                } else
                {
                    MessageBox.Show("Leerling niet gevonden om Sharepoint te openen.","Melding");
                }
            }
        }
    }
}
