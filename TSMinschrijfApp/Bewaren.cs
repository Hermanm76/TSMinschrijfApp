using System.IO;
namespace TSMinschrijfApp
{
    class Bewaren
    {
        public Leerling TeBewarenLeerling { get; set; }
        private BinaryWriter writer;
        private BinaryReader reader;
        public Bewaren()
        {
            //constructor
            //TeBewarenLeerling = leerling1;
            TeBewarenLeerling = new Leerling();
        }
        //methode om een leerling te gaan bewaren
        public void BewaarLeerling()
        {
            try
            {
                //writer aanmaken om de leerling lokaal te bewaren met als bestandsnaam naam en voornaam van de leerling.
                writer = new BinaryWriter(new FileStream(TeBewarenLeerling.naam+TeBewarenLeerling.voornaam, FileMode.Create));
            }
            catch (IOException e)
            {
                //message box dat er door een fout geen bestand lokaal kan aangemaakt worden
                System.Windows.Forms.MessageBox.Show("Kan leerling niet lokaal bewaren.","Melding");
                return;
            }
            try
            {
                //de gegeven leerling weg schrijven naar het geopende bestand
                writer.Write(TeBewarenLeerling.naam);
                writer.Write(TeBewarenLeerling.voornaam);
                writer.Write(TeBewarenLeerling.geboorteplaats);
                writer.Write(TeBewarenLeerling.geboortedatum);
                writer.Write(TeBewarenLeerling.nationaliteit);
                writer.Write(TeBewarenLeerling.geslacht);
                writer.Write(TeBewarenLeerling.nationaalnummer);
                writer.Write(TeBewarenLeerling.straat);
                writer.Write(TeBewarenLeerling.postcode);
                writer.Write(TeBewarenLeerling.gemeente);
                writer.Write(TeBewarenLeerling.land);
                writer.Write(TeBewarenLeerling.pasfoto.Length);
                writer.Write(TeBewarenLeerling.pasfoto);                
            }
            catch (IOException e)
            {
                //message box geven dat er niet naar het bestand kan geschreven worden
                System.Windows.Forms.MessageBox.Show("\n Kan niet naar bestand schrijven.");                
            }
            //writer afsluiten
            writer.Close();
            //bevestiging laten zien dat leerling correct is weggeschreven
            System.Windows.Forms.MessageBox.Show("Leerling lokaal opgeslagen.");
        }
        //methode om een leerling van een gekozen bestand te gaan inlezen en laten zien in het formulier.
        public Leerling LaadLeerling()
        {
            //selectie venster geven om bestand met leerling gegevens te kiezen
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.ShowDialog();
            //checken of een filenaam gekozen is om dan onderstaande uit te voeren. Anders is het niet nodig.
            if (!(ofd.FileName == ""))
            {
                //reading from the file
                try
            {               
                    reader = new BinaryReader(new FileStream(ofd.FileName, FileMode.Open));                
            }
            catch (IOException e)
            {
                    //Message box laten zien als het bestand niet kan geopend worden.
                    System.Windows.Forms.MessageBox.Show("\n Kan bestand niet openen.","Melding");                
            }
            try
            {
             //gegevens inladen in de aangemaakte leerling om terug te kunnen geven en laten zien in het formulier
                TeBewarenLeerling.naam = reader.ReadString();
                TeBewarenLeerling.voornaam = reader.ReadString();
                TeBewarenLeerling.geboorteplaats = reader.ReadString();
                TeBewarenLeerling.geboortedatum = reader.ReadString();
                TeBewarenLeerling.nationaliteit = reader.ReadString();
                TeBewarenLeerling.geslacht = reader.ReadString();
                TeBewarenLeerling.nationaalnummer = reader.ReadString();
                TeBewarenLeerling.straat = reader.ReadString();
                TeBewarenLeerling.postcode = reader.ReadString();
                TeBewarenLeerling.gemeente = reader.ReadString();
                TeBewarenLeerling.land = reader.ReadString();
                int pasfotolengte = reader.ReadInt32();
                TeBewarenLeerling.pasfoto = reader.ReadBytes(pasfotolengte);
            }
            catch (IOException e)
            {
                    //messagebox laten zien als het gekozen bestand niet kan gelezen worden. bv. fout bestand
                    System.Windows.Forms.MessageBox.Show("\n Kan niet lezen van bestand.","Melding");               
            }
                //reader afsluiten
                reader.Close();            
            }
            //lleerling terug geven. Dit kan ook een lege zijn als er geen bestand gekozen is
            return TeBewarenLeerling;
        }            
     }
}

    

