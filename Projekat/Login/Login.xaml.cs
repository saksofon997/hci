using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        static ObservableCollection<Korisnik> korisnici
        {
            get;
            set;
        } = new ObservableCollection<Korisnik>();

        public Login()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.DataContext = this;

            loadUsers();
        }

        public static void AddUser(Korisnik k)
        {
            korisnici.Add(k);
        }


        private void loadUsers()
        {
            try
            {
                string userspath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.bin");

                using (Stream stream = File.Open(userspath, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ObservableCollection<Korisnik> temp = new ObservableCollection<Korisnik>();
                    temp = (ObservableCollection<Korisnik>)bformatter.Deserialize(stream);

                    foreach (var value in temp)
                        korisnici.Add(value);
                }  

                MessageBox.Show("Učitana lista korisnika");

            }
            catch (Exception)
            {
                MessageBox.Show("Neuspešno učitavanje liste korisnika");
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                doLogin();
            }
        }

        private void doLogin()
        {
            try
            {
                foreach (var kor in korisnici)
                {
                    if (kor.getIme().Equals(TBUser.Text) && kor.getSifra().Equals(TBPass.Password))
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
            catch
            { }
        }

        private void BTLogin_Click(object sender, RoutedEventArgs e)
        {
            doLogin();
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            var reg = new Registracija().ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string userpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.bin");

                //serialize
                using (Stream stream = File.Open(userpath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, korisnici);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Neuspešno čuvanje liste korisnika");
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help();
            d.Show();
        }
    }
}
