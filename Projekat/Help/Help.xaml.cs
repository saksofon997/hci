using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Xps.Packaging; //Required namespace
using System.Xml;

namespace Projekat.Help
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.xps");

            XpsDocument doc = new XpsDocument(fileName, System.IO.FileAccess.Read);

            documentViewer1.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(OnRequestNavigate));

            documentViewer1.Document = doc.GetFixedDocumentSequence();
        }

        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // URI contains the page number (e.Uri = "...#PG_7_LNK_2")
            int pageNumber;
            if (int.TryParse(Regex.Match(e.Uri.ToString(), @"(?<=PG_)[0-9]+").Value, out pageNumber))
            {
                documentViewer1.GoToPage(pageNumber);
            }
        }

            public Help(int a)
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.xps");

            XpsDocument doc = new XpsDocument(fileName, System.IO.FileAccess.Read);

            documentViewer1.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(OnRequestNavigate));

            documentViewer1.Document = doc.GetFixedDocumentSequence();

            switch (a)
            {
                case 2:

                    documentViewer1.GoToPage(2);

                    break;

                case 3:

                    documentViewer1.GoToPage(3);

                    break;
                case 4:

                    documentViewer1.GoToPage(4);

                    break;
                case 5:

                    documentViewer1.GoToPage(5);

                    break;
                case 6:

                    documentViewer1.GoToPage(6);

                    break;
                case 7:

                    documentViewer1.GoToPage(7);

                    break;
                case 8:

                    documentViewer1.GoToPage(8);

                    break;
                default:
                    documentViewer1.GoToPage(1);

                    break;
            }
        }
    }
}
