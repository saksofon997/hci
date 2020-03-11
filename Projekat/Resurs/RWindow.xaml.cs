using Microsoft.Win32;
using Projekat.Etiketa;
using Projekat.Tip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Resurs
{
    /// <summary>
    /// Interaction logic for rWindow.xaml
    /// </summary>
    public partial class RWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public RModel novi
        {
            get;
            set;
        }

        private string slika = "";

        public RWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = null;

            Tip.ItemsSource = MainWindow.Tipovi;
            Etiketa.ItemsSource = MainWindow.Etikete;

        }

        public RWindow(RModel model)
        {
            InitializeComponent();
            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = new RModel();
            novi = model;

            Tip.ItemsSource = MainWindow.Tipovi;
            Etiketa.ItemsSource = MainWindow.Etikete;

            OznakaTB.Text = model.Oznaka;
            ImeTB.Text = model.Ime;
            OpisTB.Text = model.Opis;
            Frekvencija.Text = model.Frekvencija;

            if (!model.Tip.Equals(null))
            {
                Tip.SelectedIndex = Tip.Items.IndexOf(model.Tip);
            }

            if (!model.Etikete.Equals(null))
            {

                foreach (var value in model.Etikete)
                    Etiketa.SelectedIndex = Etiketa.Items.IndexOf(value);
            }

            if (model.Obnovljiv)
                ObnovljivD.IsChecked = true;
            else
                ONe.IsChecked = true;

            if (model.Strateska)
                StrateskaD.IsChecked = true;
            else
                SNe.IsChecked = true;

            if (model.Eksploatisanje)
                EksploatisanjeD.IsChecked = true;
            else
                ENe.IsChecked = true;

            Mera.Text = model.Mera;
            CenaTB.Text = model.Cena.ToString();
            DatumP.Text = model.Datum;

            if (!model.Ikonica.Equals(""))
            {
                Slika.Source = new BitmapImage(new Uri(model.Ikonica));
                slika = model.Ikonica;
            } 

        }

        private void IkonicaB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                Slika.Source = new BitmapImage(new Uri(op.FileName));
                slika = op.FileName;
            }
        }

        private void Obnovljivot_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Strateska_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Eksploatisanje_Checked(object sender, RoutedEventArgs e)
        {
        }

        private bool EksploatisanjeIsChecked()
        {
            if (EksploatisanjeD.IsChecked.Value)
                return true;
            return false;
        }

        private bool ObnovljivIsChecked()
        {
            if (ObnovljivD.IsChecked.Value)
                return true;
            return false;
        }

        private bool StrateskaIsChecked()
        {
            if (StrateskaD.IsChecked.Value)
                return true;
            return false;
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            if (this.novi != null)
                MainWindow.Resursi.Remove(this.novi);

            OznakaTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (OznakaTB.GetBindingExpression(TextBox.TextProperty).HasError)
            {
                MessageBox.Show("Proverite oznaku", "Greška");
                return;
            }     

            RModel novi = new RModel
            {
                Oznaka = OznakaTB.Text,
                Ime = ImeTB.Text,
                Opis = OpisTB.Text,
                Cena = int.Parse(CenaTB.Text),
                Datum = DatumP.Text,
                Frekvencija = Frekvencija.Text,
                Mera = Mera.Text,
                Eksploatisanje = EksploatisanjeIsChecked(),
                Obnovljiv = ObnovljivIsChecked(),
                Strateska = StrateskaIsChecked(),
                Tip = (TModel)Tip.SelectedItem,
            };

            TModel val = (TModel)Tip.SelectedItem;

            if (slika == "")
                novi.Ikonica = val.Ikonica;
            else
                novi.Ikonica = slika;

            novi.Etikete = new List<EModel>();

            if(Etiketa.SelectedItems != null)
            {
                foreach (var value in Etiketa.SelectedItems)
                    novi.Etikete.Add((EModel)value);
            }

            Projekat.MainWindow.Resursi.Add(novi);

            MessageBox.Show("Resurs dodat");
            this.Close();

        }

        private void OznakaTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OznakaTB.Text == "")
            {
                Button1.IsEnabled = false;

            }
            else
            {
                Button1.IsEnabled = true;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help(4);
            d.Show();
        }
    }
}
