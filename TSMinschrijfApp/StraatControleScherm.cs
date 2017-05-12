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
            leerling.huisNr = txtbox_HuisNr.Text;
            leerling.straatZonderNr = txtbox_StraatZonderHuisNr.Text;
            leerling.bus = txtbox_Bus.Text;
            this.Close();
        }

        private void StraatControleScherm_Load(object sender, EventArgs e)
        {

        }
    }
}
