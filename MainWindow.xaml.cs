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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Web;
using System.Windows.Threading;

namespace havadurumutugba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Goster
        {
            //   public string yerismi { get; set; }
            public string sicaklik { get; set; }
            public string hava { get; set; }
            public string nem { get; set; }

            public string ulke { get; set; }
        }
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            this.Title = ("Tuğba Arzu Yılmaz");
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += timersay;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            XmlDocument veri = new XmlDocument();
            Goster goster = new Goster();
            double sicaklik;
            veri.Load("http://api.openweathermap.org/data/2.5/weather?q=" + txt1.Text + "&mode=xml&units=imperial&APPID=67edae640bff6488e47a53857533dbda");
            //   goster.yerismi = veri.GetElementsByTagName("current")[0].ChildNodes[0].Attributes.GetNamedItem("name").Value.ToString();

            sicaklik = Convert.ToDouble(veri.GetElementsByTagName("current")[0].ChildNodes[1].Attributes.GetNamedItem("value").Value.ToString());
            sicaklik = (sicaklik-320)/18;
            goster.sicaklik = sicaklik.ToString();
            goster.hava = veri.GetElementsByTagName("current")[0].ChildNodes[8].Attributes.GetNamedItem("value").Value.ToString();
            goster.nem = veri.GetElementsByTagName("current")[0].ChildNodes[2].Attributes.GetNamedItem("value").Value.ToString();

            goster.ulke = veri.GetElementsByTagName("country")[0].InnerText;



            grd1.DataContext = null;
            grd1.DataContext = goster;
        }
        private void timersay(object sender, EventArgs e)
        {
            DateTime simdi = DateTime.Now;
            tblcsaat.Text = simdi.ToLongTimeString();
        }

    }

}
