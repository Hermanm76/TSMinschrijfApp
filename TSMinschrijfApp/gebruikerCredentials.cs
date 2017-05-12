namespace TSMinschrijfApp
{
    public class gebruikerCredentials
    {
        public string gebruikerEmail;
        public string gebruikerPaswoord;

        public gebruikerCredentials()
        {
            gebruikerEmail = "";
            gebruikerPaswoord = "";
        }

        public gebruikerCredentials(gebruikerCredentials gebruiker)
        {
            this.gebruikerPaswoord = gebruiker.gebruikerPaswoord;
            this.gebruikerEmail = gebruiker.gebruikerEmail;
        }
    }
}
