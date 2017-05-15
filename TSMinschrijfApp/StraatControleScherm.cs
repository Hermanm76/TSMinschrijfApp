using System;
using System.Windows.Forms;

namespace TSMinschrijfApp
{
    public partial class StraatControleScherm : Form
    {
        //variabel Leerling aanmaken
        private Leerling leerling;
        //constructor voor het form
        public StraatControleScherm(Leerling leerling)
        {
            InitializeComponent();
            this.leerling = leerling;
            txtbox_VolledigeStraat.Text = leerling.straat;
        }
        //straat, nr en bus gegevens wegschrijven in leerling
        private void button1_Click(object sender, EventArgs e)
        {
            //controle of gebruiker geen straat en nr ingeeft anders het scherm niet sluiten
            if ((txtbox_StraatZonderHuisNr.Text == "") || (txtbox_HuisNr.Text == ""))
            {
                MessageBox.Show("Je hebt geen straat en huisnr ingegeven! Gelieve dit aan te passen");
            } else { 
            leerling.huisNr = txtbox_HuisNr.Text;
            leerling.straatZonderNr = txtbox_StraatZonderHuisNr.Text;
            leerling.bus = txtbox_Bus.Text;
            this.Close();
            }
        }
    }
}
