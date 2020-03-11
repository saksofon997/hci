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

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for EPregled.xaml
    /// </summary>
    public partial class EPregled : Window
    {
        public EPregled()
        {
            InitializeComponent();
            this.DataContext = this;
            PregledG.ItemsSource = MainWindow.Etikete;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((EModel)PregledG.SelectedItem == null)
                    return;
                EWindow ew = new EWindow((EModel)this.PregledG.SelectedItem);
                ew.ShowDialog();
            }

            catch (Exception)
            {

                throw;
            }
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((EModel)PregledG.SelectedItem == null)
                    return;
                MainWindow.Etikete.Remove((EModel)PregledG.SelectedItem);
                MessageBox.Show("Stavka obrisana");
                this.PregledG.Items.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var d = new Etiketa.EWindow();
            d.ShowDialog();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            //this.PregledG.Items.Refresh();
        }

        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //this.PregledG.Items.Refresh();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help(7);
            d.Show();
        }
    }
}
