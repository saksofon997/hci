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
    /// Interaction logic for TPregled.xaml
    /// </summary>
    public partial class TPregled : Window
    {
        public TPregled()
        {
            InitializeComponent();
            this.DataContext = this;
            PregledG.ItemsSource = MainWindow.Tipovi;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((TModel)PregledG.SelectedItem == null)
                    return;
                TWindow tw = new TWindow((TModel)PregledG.SelectedItem);
                tw.ShowDialog();
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
                if ((TModel)PregledG.SelectedItem == null)
                    return;
                MainWindow.Tipovi.Remove((TModel)PregledG.SelectedItem);
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
            var d = new Tip.TWindow();
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
            var d = new Help.Help(5);
            d.Show();
        }
    }
}
