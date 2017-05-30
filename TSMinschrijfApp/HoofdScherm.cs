using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSMinschrijfApp
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }
        //De nodige variabelen aanmaken bij opstart 
        private gebruikerCredentials gebruikerCr = new gebruikerCredentials();
        private UserInputBox invoerBox; 
        //invulScherm.StartPosition = FormStartPosition.CenterParent;
        private Leerling leerling = new Leerling();
        private Bewaren bewaren = new Bewaren();
        private StraatControleScherm straatControle;
        private int Jaar = DateTime.Now.Year;
        
        private void btn_Afsluiten_Click(object sender, EventArgs e)
        {
            //applicatie afsluiten
            Application.Exit();
        }
        private void btn_IdInlezen_Click(object sender, EventArgs e)
        {
            //using gebruiken om ervoor te zorgen dat het na gebruik niet in het geheugen blijft hangen
            using (EIDinleesCode idinlezen = new EIDinleesCode())
            {
                //opgevangen dat deze code niet loopt als er fout is bij het inlezen van de kaart
                if (idinlezen.IDingelezen)
                {
                    leerling.inLezen(idinlezen);
                    //land vastzetten op belgie aangezien het over een belgische EID gaat
                    leerling.land = "Belgie";
                    formUpdaten(leerling);
                }
            }      
        }
        private void formUpdaten(Leerling leerling)
        {
            //methode om formulier te updaten
            txtbox_Naam.Text = leerling.naam;
            txtbox_Voornaam.Text = leerling.voornaam;
            txtbox_GeboortePlaats.Text = leerling.geboorteplaats;
            txtbox_GeboorteDatum.Text = leerling.geboortedatum;
            txtbox_Geslacht.Text = leerling.geslacht;
            txtbox_NationaalNummer.Text = leerling.nationaalnummer;
            txtbox_Nationaliteit.Text = leerling.nationaliteit;
            txtbox_Straat.Text = leerling.straat;
            txtbox_Postcode.Text = leerling.postcode;
            txtbox_Gemeente.Text = leerling.gemeente;
            txtBox_land.Text = leerling.land;
            if (!(leerling.pasfoto == null))
            {
                picBox_pasfoto.Image = (Bitmap)((new ImageConverter()).ConvertFrom(leerling.pasfoto));
            } else
            {
                picBox_pasfoto.Image = null;
            }
        }
        //methode die formulier leegmaakt om nieuwe leerling in te lezen
        private void btn_Leegmaken_Click(object sender, EventArgs e)
        {
            leerling.leegMaken();
            formUpdaten(leerling);
        }
        //leerling lokaal bewaren op de hardeschijf. bv. bij probleem met internet verbinding
        private void btn_LeerlingLokaalBewaren_Click(object sender, EventArgs e)
        {
            bewaren.TeBewarenLeerling = leerling;
            bewaren.BewaarLeerling();
    }
        //lokaal opgeslagen leerling terug inladen
        private void btn_LeerlingLokaalInladen_Click(object sender, EventArgs e)
        {
            leerling = bewaren.LaadLeerling();
            formUpdaten(leerling);
        }
        //leerling met ingelezen gegevens aanmaken in sharepoint
        private void btn_LeerlingAanmaken_Click(object sender, EventArgs e)
        {

            SharepointBewerkingen aanmaken = new SharepointBewerkingen(gebruikerCr.gebruikerEmail, gebruikerCr.gebruikerPaswoord);
            try
            {
                if (!(aanmaken.ControleerOfLeerlingAlBestaat(leerling)))
                {
                    if (straatControleren(leerling))
                    {
                        aanmaken.LeerlingBewarenInSharepointList(leerling,cmbbox_Schooljaar.SelectedItem.ToString());
                        leerling.leegMaken();
                        formUpdaten(leerling);
                    } else
                    {
                        MessageBox.Show("adres niet correct!");
                    }
                }
                else
                {
                    MessageBox.Show("Leerling bestaat al!", "Melding");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Probleem met Sharepoint verbinding. Controleer gebruikersnaam en wachtwoord", "Melding");
                UserInputBox invoerBox = new UserInputBox(gebruikerCr, this);
                invoerBox.Show();
            }      
        }
        //nog grondig nakijken en testen
        private Boolean straatControleren(Leerling leerling)
        {

            string[] str = leerling.straat.Split(' ');
            //voor een adres bestaande uit straat (in 1 woord) + nr
            if (str.Length == 2)
            {
                leerling.straatZonderNr = str[0];
                leerling.huisNr = str[1];
                return true;
            }
            if (str.Length == 3 && (System.Text.RegularExpressions.Regex.IsMatch(str[2], @"^\d+$")))
            {
                leerling.straatZonderNr = str[0] + " " + str[1];
                leerling.huisNr = str[2];
                return true;
            }

            straatControle = new StraatControleScherm(leerling);
            var testAdres = straatControle.ShowDialog();
            if(testAdres == DialogResult.OK)
            {
                return true;
            } else {
                return false;
            }
            
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            //opvullen combobox voor het schooljaar en selectie instellen
            this.cmbbox_Schooljaar.Items.AddRange(new object[] {
            Jaar-1+"-"+Jaar,
            Jaar+"-"+(Jaar+1)});
            this.cmbbox_Schooljaar.SelectedIndex = 1;
            //gebruikersnaam en paswoord vragen
            invoerBox = new UserInputBox(gebruikerCr,this);
            invoerBox.Focus();
            invoerBox.Show();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            HelpScherm help = new HelpScherm();
            help.Visible = true;
        }
    }
}
