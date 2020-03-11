using Projekat.Resurs;
using Projekat.Tip;
using Projekat.Etiketa;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private RModel izabraniResurs;
        private Point startPoint;

        public RModel IzabraniResurs
        {
            get { return izabraniResurs; }
            set
            {
                if (value != izabraniResurs)
                {
                    izabraniResurs = value;
                    OnPropertyChanged("SelectedMonument");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Resurs.RModel> Resursi
        {
            set;
            get;
        }

        public static ObservableCollection<Tip.TModel> Tipovi
        {
            set;
            get;
        }

        public static ObservableCollection<Etiketa.EModel> Etikete
        {
            set;
            get;
        }

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.DataContext = this;

            Resursi = new ObservableCollection<RModel>();
            Tipovi = new ObservableCollection<TModel>();
            Etikete = new ObservableCollection<EModel>();

            loadFromFile();

            fixReferences();

            loadMap();

        }

        private void loadFromFile()
        {
            try
            {
                string resursipath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.bin");
                string tipovipath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.bin");
                string etiketepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.bin");


                using (Stream stream = File.Open(tipovipath, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ObservableCollection<TModel> temp = new ObservableCollection<TModel>();
                    temp = (ObservableCollection<TModel>)bformatter.Deserialize(stream);

                    foreach (var value in temp)
                        Tipovi.Add(value);
                }

                using (Stream stream = File.Open(etiketepath, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ObservableCollection<EModel> temp = new ObservableCollection<EModel>();
                    temp = (ObservableCollection<EModel>)bformatter.Deserialize(stream);

                    foreach (var value in temp)
                        Etikete.Add(value);
                }

                using (Stream stream = File.Open(resursipath, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ObservableCollection<RModel> temp = new ObservableCollection<RModel>();
                    temp = (ObservableCollection<RModel>)bformatter.Deserialize(stream);

                    foreach (var value in temp)
                        Resursi.Add(value);
                }

                MessageBox.Show("Učitani podaci");

            }
            catch (Exception)
            {
                MessageBox.Show("Neuspešno učitavanje");
            }
        }

        private void loadMap()
        {
            foreach (var resurs in Resursi)
            {
                bool result = mapImageView.Children.Cast<Image>()
                    .Any(x => x.Tag != null && x.Tag.ToString() == resurs.Oznaka);
                if (result || resurs.X == -1 || resurs.Y == -1)
                {
                    continue;
                }

                putOnMap(resurs, false);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IzabraniResurs = listView.SelectedItem as RModel;

            ObservableCollection<RModel> temp = new ObservableCollection<RModel>();

            temp.Add(IzabraniResurs);

            PregledR.ItemsSource = temp;
        }

        private void MapImageView_OnDragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("resurs") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MapImageView_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("resurs"))
            {
                return;
            }

            RModel resurs = e.Data.GetData("resurs") as RModel;

            if (resurs == null)
            {
                return;
            }

            bool result = mapImageView.Children.Cast<Image>()
                .Any(x => x.Tag != null && x.Tag.ToString() == resurs.Oznaka);

            System.Windows.Point d0 = e.GetPosition(mapImageView);

            foreach (var mon in Resursi)
            {
                if (mon.Oznaka != resurs.Oznaka && mon.X != -1 && mon.Y != -1 && Math.Abs(mon.X - d0.X) <= 30 &&
                    Math.Abs(mon.Y - d0.Y) <= 30)
                {
                    System.Windows.MessageBox.Show("Nemoguće postaviti preko postojećeg resursa", "");
                    return;
                }

            }

            if (result)
            {
                System.Windows.MessageBox.Show("Ovaj resurs se već nalazi na mapi.", "");
                return;
            }

            var positionX = e.GetPosition(mapImageView).X;
            var positionY = e.GetPosition(mapImageView).Y;
            resurs.X = positionX;
            resurs.Y = positionY;

            putOnMap(resurs, true);
        }

        private void putOnMap(RModel monument, bool shouldEdit)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(monument.Ikonica));
            img.Width = 40;
            img.Height = 40;
            img.Tag = monument.Oznaka;
            img.ToolTip = monument.Ime;
            img.MouseMove += ExistingImageMove;
            img.MouseRightButtonDown += DeleteImage;

            Binding myBinding = new Binding();
            myBinding.Source = findResourceById(monument.Oznaka);
            myBinding.Path = new PropertyPath("Ikonica");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(img, Image.SourceProperty, myBinding);

            mapImageView.Children.Add(img);
            Canvas.SetLeft(img, monument.X - 20);
            Canvas.SetTop(img, monument.Y - 20);
        }

        private void DeleteImage(object sender, MouseEventArgs e)
        {
            System.Windows.Point d0 = e.GetPosition(mapImageView);

            foreach (var mon in Resursi)
            {
                if (Math.Abs(mon.X - d0.X) <= 30 &&
                    Math.Abs(mon.Y - d0.Y) <= 30)
                {
                    Image img = sender as Image;
                    mapImageView.Children.Remove(img);
                    mon.X = -1;
                    mon.Y = -1;

                    MessageBox.Show("Resurs uklonjen sa mape");
                }

            }
        }

        private void ExistingImageMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image img = sender as Image;
                var uid = img.Tag as string;
                var res = findResourceById(uid);
                mapImageView.Children.Remove(img);
                DataObject dragData = new DataObject("resurs", res);
                DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);
            }
        }

        private void Icon_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Icon_OnMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                try
                {
                    if (izabraniResurs != null)
                    {
                        ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
                        DataObject dragData = new DataObject("resurs", izabraniResurs);
                        DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void fixReferences()
        {
            foreach (var resurs in Resursi)
            {
                for (var i = resurs.Etikete.Count - 1; i >= 0; i--)
                {
                    var tag = findTagById(resurs.Etikete[i].Oznaka);
                    if (tag != null)
                    {
                        resurs.Etikete[i] = tag;
                    }
                }

                TModel type = findTypeById(resurs.Tip.Oznaka);
                if (type != null)
                {
                    resurs.Tip = type;
                }
            }
        }

        private EModel findTagById(string oznaka)
        {
            foreach (var etiketa in Etikete)
            {
                if (etiketa.Oznaka == oznaka)
                {
                    return etiketa;
                }
            }

            return null;
        }

        public TModel findTypeById(string oznaka)
        {
            foreach (var tip in Tipovi)
            {
                if (tip.Oznaka == oznaka)
                {
                    return tip;
                }
            }

            return null;
        }

        public RModel findResourceById(string oznaka)
        {
            foreach (var resurs in Resursi)
            {
                if (resurs.Oznaka == oznaka)
                {
                    return resurs;
                }
            }

            return null;
        }

        private void EventSetter_OnHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //editMonument();
                return;
            }

            if (e.Key == Key.Delete)
            {
                //deleteMonument();
                return;
            }
        }

        private void rClick1(object sender, RoutedEventArgs e)
        {
            var d = new Resurs.RPregled();
            d.ShowDialog();
            PregledR.ItemsSource = null;
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            var d = new Tip.TPregled();
            d.ShowDialog();
        }

        private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            var d = new Etiketa.EPregled();
            d.ShowDialog();
        }

        private void Main_Closing(object sender, CancelEventArgs e)
        {
            try
            {

                string resursipath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.bin");
                string tipovipath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.bin");
                string etiketepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.bin");

                //serialize
                using (Stream stream = File.Open(resursipath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, Resursi);
                }

                //serialize
                using (Stream stream = File.Open(tipovipath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, Tipovi);
                }

                //serialize
                using (Stream stream = File.Open(etiketepath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, Etikete);
                }

                MessageBox.Show("Sačuvano, program se zatvara");
            }
            catch(Exception)
            {
                MessageBox.Show("Neuspešno čuvanje podataka");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var d = new Help.Help();
            d.Show();
        }

        private void MapImageView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point d0 = e.GetPosition(mapImageView);

            ObservableCollection<RModel> temp = new ObservableCollection<RModel>();

            foreach (var mon in Resursi)
            {
                if (mon.X != -1 && mon.Y != -1 && Math.Abs(mon.X - d0.X) <= 30 &&
                    Math.Abs(mon.Y - d0.Y) <= 30)
                {
                    temp.Add(mon);
                    PregledR.ItemsSource = temp;
                }

            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var d = new Help.Help(2);
            d.Show();
        }
    }
}
