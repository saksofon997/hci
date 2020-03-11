using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for TWindow.xaml
    /// </summary>
    public partial class TWindow : Window
    {
        public TModel novi
        {
            get;
            set;
        }

        private string slika = "";

        public TWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = new TModel();
        }

        public TWindow(TModel model)
        {
            InitializeComponent();
            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = model;

            OznakaTB.Text = model.Oznaka;
            ImeTB.Text = model.Ime;
            OpisTB.Text = model.Opis;

            if (!model.Ikonica.Equals(""))
            {
                Slika.Source = new BitmapImage(new Uri(model.Ikonica));
                slika = model.Ikonica;
            }

            MainWindow.Tipovi.Remove(model);

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

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            TModel novi = new TModel { Oznaka = OznakaTB.Text, Ime = ImeTB.Text, Opis = OpisTB.Text };

            novi.Ikonica = slika;

            MainWindow.Tipovi.Add(novi);

            MessageBox.Show("Tip dodat");
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
            var d = new Help.Help(6);
            d.Show();
        }
    }
}
