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
    /// Interaction logic for EWindow.xaml
    /// </summary>
    public partial class EWindow : Window
    {
        public EModel novi
        {
            get;
            set;
        }

        public EWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = new EModel();
        }

        public EWindow(EModel model)
        {
            InitializeComponent();
            this.DataContext = this;

            Button1.IsEnabled = false;

            novi = model;

            OznakaTB.Text = novi.Oznaka;
            OpisTB.Text = model.Opis;
            ColorPickerbg.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(model.Boja);

            MainWindow.Etikete.Remove(model);
        }

        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Etikete.Add(new EModel { Oznaka = OznakaTB.Text, Boja = ColorPickerbg.SelectedColorText, Opis = OpisTB.Text });
            this.Close();
            MessageBox.Show("Etiketa dodata");
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
            var d = new Help.Help(8);
            d.Show();
        }
    }
}
