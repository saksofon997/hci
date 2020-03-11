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

namespace Projekat.Login
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.DataContext = this;
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TBUserNew.Text.Equals("") || TBPassNew.Password.Equals(""))
            {
                MessageBox.Show("Unesite podatke");
                return;
            }

            Korisnik temp = new Korisnik(TBUserNew.Text, TBPassNew.Password);

            Login.AddUser(temp);

            MessageBox.Show("Dodat novi korisnik");

            this.Close();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help();
            d.Show();
        }
    }
}
