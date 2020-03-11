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
    /// Interaction logic for RPregled.xaml
    /// </summary>
    public partial class RPregled : Window, INotifyPropertyChanged
    {
        private string filterbind;
        private string pretragabind;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FilterBind
        {
            get { return filterbind; }
            set
            {
                if (value != filterbind)
                {
                    filterbind = value;
                    OnPropertyChanged("FilterBind");
                }
            }
        }

        public string PretragaBind
        {
            get { return pretragabind; }
            set
            {
                if (value != pretragabind)
                {
                    pretragabind = value;
                    OnPropertyChanged("PretragaBind");
                }
            }
        }

        public ObservableCollection<RModel> resursi { get; set; } = new ObservableCollection<RModel>();

        public RPregled()
        {
            InitializeComponent();
            this.DataContext = this;
            PregledG.ItemsSource = MainWindow.Resursi;
            resursi = MainWindow.Resursi;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((RModel)PregledG.SelectedItem == null)
                    return;
                RWindow rWindow = new RWindow((RModel)PregledG.SelectedItem);
                rWindow.ShowDialog();
                
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
                if ((RModel)PregledG.SelectedItem == null)
                    return;
                MainWindow.Resursi.Remove((RModel)PregledG.SelectedItem);
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
            RWindow d = new RWindow();
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

        private void doFiltering(string text)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => 
                    resurs.Tip.Oznaka.ToUpper().Contains(word.ToUpper()) || 
                    resurs.Ime.ToUpper().Contains(word.ToUpper()) || 
                    resurs.Oznaka.ToUpper().Contains(word.ToUpper()) ||
                    resurs.Cena.ToString().ToUpper().Contains(word.ToUpper()) ||
                    resurs.Datum.ToUpper().Contains(word.ToUpper()) ||
                    resurs.Mera.ToUpper().Contains(word.ToUpper()) ||
                    resurs.Opis.ToUpper().Contains(word.ToUpper()) ||
                    resurs.Frekvencija.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void TBPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as System.Windows.Controls.TextBox;
            doFiltering(textField.Text);
        }

        private void doFilteringI(string text) // cena
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Cena.ToString().ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringH(string text) // mera
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Mera.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringG(string text) // frekvencija
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Frekvencija.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringF(string text) // opis
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Opis.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringE(string text) // datum
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Datum.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringD(string text) // tip.ime
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Tip.Ime.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringC(string text) // tip.oznaka
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Tip.Oznaka.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringB(string text) // ime
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Ime.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void doFilteringA(string text) // oznaka
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            if (string.IsNullOrEmpty(text))
                return;
            else
            {
                cv.Filter = o =>
                {
                    RModel resurs = o as RModel;
                    string[] words = text.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => resurs.Oznaka.ToUpper().Contains(word.ToUpper()));
                };

                PregledG.ItemsSource = resursi;
            }
        }

        private void Pretraga_Checked(object sender, RoutedEventArgs e)
        {

        }

        private int pretragaCheck()
        {
            if (CBOznaka.IsChecked.Value)
                return 0;
            else if (CBIme.IsChecked.Value)
                return 1;
            else if (CBTipO.IsChecked.Value)
                return 2;
            else if (CBTipI.IsChecked.Value)
                return 3;
            else if (CBDatum.IsChecked.Value)
                return 4;
            else if (CBOpis.IsChecked.Value)
                return 5;

            return -1;
        }

        private void TBFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as System.Windows.Controls.TextBox;

            var a = pretragaCheck();

            switch (a)
            {
                case 0: doFilteringA(textField.Text); break;

                case 1: doFilteringB(textField.Text); break;

                case 2: doFilteringC(textField.Text); break;

                case 3: doFilteringD(textField.Text); break;

                case 4: doFilteringE(textField.Text); break;

                case 5: doFilteringF(textField.Text); break;

                default: doFilteringA(textField.Text); break;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help(3);
            d.Show();
        }

        private void SearchB_Click(object sender, RoutedEventArgs e)
        {
            doFilteringA(OznakaTBA.Text);
            doFilteringB(ImeTBA.Text);
            doFilteringC(TipA.Text);
            doFilteringF(OpisTBA.Text);
            doFilteringG(FrekvencijaA.Text);
            doFilteringH(MeraA.Text);
            doFilteringI(CenaTBA.Text);
            doFilteringE(DatumPA.Text);

            ICollectionView cv = CollectionViewSource.GetDefaultView(resursi);
            cv.Filter = new Predicate<object>(PretraziBool);
            PregledG.ItemsSource = cv;

        }

        private bool PretraziBool(object obj)
        {
            RModel res = (RModel)obj;

            if (resursi == null)
                return false;

            if (EksploatisanjeDA.IsChecked.Value || EksploatisanjeNA.IsChecked.Value)
            {
                if (EksploatisanjeIsChecked())
                    if (!res.Eksploatisanje)
                        return false;
                if (!EksploatisanjeIsChecked())
                    if (res.Eksploatisanje)
                        return false;
            }

            if (ObnovljivDA.IsChecked.Value || ObnovljivNA.IsChecked.Value)
            {
                if (ObnovljivIsChecked())
                    if (!res.Obnovljiv)
                        return false;
                if (!ObnovljivIsChecked())
                    if (res.Obnovljiv)
                        return false;
            }

            if (StrateskaDA.IsChecked.Value || StrateskaNA.IsChecked.Value)
            {
                if (StrateskaIsChecked())
                    if (!res.Strateska)
                        return false;
                if (!StrateskaIsChecked())
                    if (res.Strateska)
                        return false;
            }

            return true;
        }

        private bool EksploatisanjeIsChecked()
        {
            if (EksploatisanjeDA.IsChecked.Value)
                return true;
            return false;
        }

        private bool ObnovljivIsChecked()
        {
            if (ObnovljivDA.IsChecked.Value)
                return true;
            return false;
        }

        private bool StrateskaIsChecked()
        {
            if (StrateskaDA.IsChecked.Value)
                return true;
            return false;
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

        private void ResetB_Click(object sender, RoutedEventArgs e)
        {
            doFiltering(null);

            OznakaTBA.Text = null;
            ImeTBA.Text = null;
            OpisTBA.Text = null;
            FrekvencijaA.SelectedItem = null;
            TipA.Text = null;
            MeraA.SelectedItem = null;
            CenaTBA.Text = null;
            DatumPA.SelectedDate = null;

            ObnovljivDA.IsChecked = false;
            ObnovljivNA.IsChecked = false;
            StrateskaDA.IsChecked = false;
            StrateskaNA.IsChecked = false;
            EksploatisanjeDA.IsChecked = false;
            EksploatisanjeNA.IsChecked = false;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            doFiltering(null);
        }
    }
}
