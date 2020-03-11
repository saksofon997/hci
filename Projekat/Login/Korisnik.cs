using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Login
{
    [Serializable]
    public class Korisnik
    {
        private string ime;

        public string getIme()
        {
            return ime;
        }


        private string sifra;

        public string getSifra()
        {
            return sifra;
        }



        public Korisnik(string ime, string sifra)
        {
            this.ime = ime;
            this.sifra = sifra;
        }
    }
}
