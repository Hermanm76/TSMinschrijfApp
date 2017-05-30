using System;
using System.Linq;
using Net.Sf.Pkcs11;
using Net.Sf.Pkcs11.Objects;
using Net.Sf.Pkcs11.Wrapper;
using System.Windows.Forms;

namespace TSMinschrijfApp
{
    public class EIDinleesCode : IDisposable
    {

        //variables
        public String naam { get; set; }
        public String voornaam { get; set; }
        public String geboorteplaats { get
           ; set; }
        public String geboortedatum {
            get;
            set; }

        public String nationaliteit { get; set; }
        public String land { get; set; }
        public String geslacht { get; set; }
        public String nationaalnummer { get; set; }
        public String straat { get; set; }
        public String postcode { get; set; }
        public String gemeente { get; set; }
        public Byte[] pasfoto { get; set; }

        
        
        //static van gemaakt om zeker te zijn dat deze geen instance fout geeft bij het aanmaken van de variable slotlist
        static Module m = null;
        
        private String mFileName;
        public Boolean IDingelezen { get; set; } = false;

        //constructor van de klasse
        public EIDinleesCode()
        {
            
            mFileName = "beidpkcs11.dll";
            getData();
        }

        private void getData()
        {
            if (m == null) {
                m = Module.GetInstance(mFileName);
            }

            try
            {


                Slot[] slotlist = m.GetSlotList(true);

                if (slotlist.Length > 0)
                {

                    Slot slot = slotlist[0];
                    Session session = slot.Token.OpenSession(true);
                    ByteArrayAttribute classAttribute = new ByteArrayAttribute(CKA.CLASS);
                    
                    classAttribute.Value = BitConverter.GetBytes(Convert.ToUInt32(CKO.DATA));

                    session.FindObjectsInit(new P11Attribute[] { classAttribute });

                    P11Object[] foundObjects = session.FindObjects(100);

                    //FOR LOOP om alle gegevens uit te lezen

                    for (int i = 0; i < foundObjects.Count() - 1; i++)
                    {
                        Net.Sf.Pkcs11.Objects.Data data = (Net.Sf.Pkcs11.Objects.Data)foundObjects[i];

                        String label = data.Label.ToString();

                        switch (label.ToLower())
                        {
                            case "[chararrayattribute value=surname]":
                                naam = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=firstnames]":
                                voornaam = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=date_of_birth]":
                                geboortedatum = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=location_of_birth]":
                                geboorteplaats = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=gender]":
                                geslacht = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=national_number]":
                                nationaalnummer = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=address_street_and_number]":
                                straat = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=address_country]":
                                land = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=address_zip]":
                                postcode = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=address_municipality]":
                                gemeente = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=nationality]":
                                nationaliteit = System.Text.Encoding.UTF8.GetString(data.Value.Value);
                                break;
                            case "[chararrayattribute value=photo_file]":
                                pasfoto = data.Value.Value;
                                break;
                        }
                        

                    }
                    session.FindObjectsFinal();
                    IDingelezen = true;
                    m.P11Module.Finalize_();
                }
                else {
                    throw new Exception("Controleer de kaartlezer, werd de identiteitskaart correct geplaatst");
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Controleer de kaartlezer, werd de identiteitskaart correct geplaatst", "Melding");
                //throw new Exception("Controleer de kaartlezer, werd de identiteitskaart correct geplaatst");
                
                
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EIDinleesCode() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
