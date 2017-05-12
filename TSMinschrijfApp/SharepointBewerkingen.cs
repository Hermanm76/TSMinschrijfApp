using System;
using System.Security;
using Microsoft.SharePoint.Client;

namespace TSMinschrijfApp
{
    class SharepointBewerkingen
    {
        //foutafhandeling nog programmeren voor de verbinding met sharepoint
        string userName;
        string paswoord;
        ClientContext context;
        Web web;
        List announcementsList;
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
            context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM ICT/");
            context.Credentials = credentials;
            // Het sharepoint web binnenhalen.
            Web web = context.Web;
            // De bestaande lijst die we nodig hebben binnenhalen "Testlijst - Inschrijvingen eID". 
            List announcementsList = context.Web.Lists.GetByTitle("Testlijst - Inschrijvingen eID");
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
                if (teControlerenLeerling.nationaalnummer.Equals(listItem["_x0077_x97"]))
                {
                    //leerling bestaat reeds
                    return true;
                }
            }
            //leerling bestaat nog niet
            return false;
        }

        public void  LeerlingBewarenInSharepointList(Leerling teBewarenLeerling)
        {

            var securePassword = new SecureString();
            foreach (var c in paswoord)
            {
                securePassword.AppendChar(c);
            }
            credentials = new SharePointOnlineCredentials(userName, securePassword);
            context = new ClientContext("https://technischescholenmechel.sharepoint.com/TSM ICT/");
            context.Credentials = credentials;

            // Het sharepoint web binnenhalen.
            Web web = context.Web;
            // De bestaande lijst die we nodig hebben binnenhalen "Testlijst - Inschrijvingen eID". 
            List announcementsList = context.Web.Lists.GetByTitle("Testlijst - Inschrijvingen eID");
            // List item aanmaken op basis van de leerling die we willen aanmaken in sharepoint

            //standaard aanmaak info gegevens aanmaken. indien nodig kan je hier bepaalde gegevens specifieren
            ListItemCreationInformation itemAanmaakInfo = new ListItemCreationInformation();
            //list item aanmaken en linken met opgevraagde lijst
            ListItem nieuwItem = announcementsList.AddItem(itemAanmaakInfo);
            //NAAM
            nieuwItem["Title"] = teBewarenLeerling.naam;
            //VOORNAAM
            nieuwItem["rszx"] = teBewarenLeerling.voornaam;
            //NATIONAALNUMMER
            nieuwItem["_x0077_x97"] = teBewarenLeerling.nationaalnummer;
            //GEBOORTEPLAATS
            nieuwItem["km3h"] = teBewarenLeerling.geboorteplaats;
            //GEBOORTEDATUM
            nieuwItem["rmtr"] = teBewarenLeerling.geboorteDatumOmzetenDateTime();
            //STRAAT
            nieuwItem["e5ql"] = teBewarenLeerling.straatZonderNr;
            //NR
            nieuwItem["zl6m"] = teBewarenLeerling.huisNr;
            //BUS
            nieuwItem["llnv"] = teBewarenLeerling.bus;
            //POSTCODE
            nieuwItem["yfqh"] = teBewarenLeerling.postcode;
            //GEMEENTE
            nieuwItem["cd9i"] = teBewarenLeerling.gemeente;
            //LAND
            nieuwItem["drdn"] = teBewarenLeerling.land;

            //nieuwe gegevens updaten in item lijst
            nieuwItem.Update();
            //



            //de aanmaak query uitvoeren tegenover de sharepoint server.
            context.ExecuteQuery();

            //laten weten dat leerling aangemaakt is
            System.Windows.Forms.MessageBox.Show("Leerling is aangemaakt", "Melding");

        }
    }
}
