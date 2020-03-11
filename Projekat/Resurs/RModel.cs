using Projekat.Etiketa;
using Projekat.Tip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projekat.Resurs
{
    [Serializable]
    public class RModel : INotifyPropertyChanged
    {
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string oznaka { get; set; }
        private string ime;
        private string opis;

        private string frekvencija;
        private bool obnovljiv;
        private bool strateska;
        private bool eksploatisanje;
        private string mera;
        private int cena;
        private string datum;

        private TModel tip;

        private List<EModel> etikete;

        private string ikonica;

        private double x = -1;
        private double y = -1;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value != x)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public List<EModel> Etikete
        {
            get
            {
                return etikete;
            }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public TModel Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public string Ikonica
        {
            get
            {
                return ikonica;
            }
            set
            {
                if (value != ikonica)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public int Cena
        {
            get
            {
                return cena;
            }
            set
            {
                if (value != cena)
                {
                    cena = value;
                    OnPropertyChanged("Cena");
                }
            }
        }

        public string Datum
        {
            get
            {
                return datum;
            }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public string Mera
        {
            get
            {
                return mera;
            }
            set
            {
                if (value != mera)
                {
                    mera = value;
                    OnPropertyChanged("Mera");
                }
            }
        }

        public bool Eksploatisanje
        {
            get
            {
                return eksploatisanje;
            }
            set
            {
                if (value != eksploatisanje)
                {
                    eksploatisanje = value;
                    OnPropertyChanged("Eksploatisanje");
                }
            }
        }

        public bool Strateska
        {
            get
            {
                return strateska;
            }
            set
            {
                if (value != strateska)
                {
                    strateska = value;
                    OnPropertyChanged("Strateska");
                }
            }
        }

        public bool Obnovljiv
        {
            get
            {
                return obnovljiv;
            }
            set
            {
                if (value != obnovljiv)
                {
                    obnovljiv = value;
                    OnPropertyChanged("Obnovljiv");
                }
            }
        }

        public string Frekvencija
        {
            get
            {
                return frekvencija;
            }
            set
            {
                if (value != frekvencija)
                {
                    frekvencija = value;
                    OnPropertyChanged("Frekvencija");
                }
            }
        }

        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
    }
}
