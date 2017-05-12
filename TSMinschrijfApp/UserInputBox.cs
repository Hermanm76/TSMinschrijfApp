using System;
using System.Windows.Forms;

namespace TSMinschrijfApp
{
    public partial class UserInputBox : Form
    {
        private gebruikerCredentials gebruikerCr;
        private Main_form main_form;
        public UserInputBox()
        {
            InitializeComponent();
        }
        public UserInputBox(gebruikerCredentials gebruikerCr, Main_form main)
        {
            InitializeComponent();
            this.gebruikerCr = gebruikerCr;
            this.main_form = main;
        }
        //form afsluiten zonder gegevens in te vullen. programma beeindigen vanuit form1
        private void btn_Annuleer_Click(object sender, EventArgs e)
        {
            this.main_form.Close();
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if(txtbox_Email != null)
            {
                gebruikerCr.gebruikerEmail = txtbox_Email.Text;
                if (txtbox_Paswoord != null)
                {
                    gebruikerCr.gebruikerPaswoord = txtbox_Paswoord.Text;
                    this.Close();
                }
            } else
            {
                this.main_form.Close();
            }            
        }
    }
}
