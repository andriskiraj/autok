using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] sorok;
        public MainWindow()
        {

            InitializeComponent();
            sorok = File.ReadAllLines("autok.txt");

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                listbox.Items.Add(adatok[0]);
            }
        }

        private void uj_Click_1(object sender, RoutedEventArgs e)
        {
            UjAuto ujAuto = new UjAuto();
            ujAuto.Show();
            this.Close();
        }

        private void modositas_Click_1(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem == null) return;

            string rendszam = listbox.SelectedItem.ToString();

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                if (adatok[0] == rendszam)
                {
                    AutoModositas ablak = new AutoModositas(adatok);
                    ablak.Show();
                    this.Close();
                }
            }
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {

            if (listbox.SelectedItem == null) return;

            string rendszam = listbox.SelectedItem.ToString();

            string[] sorok = File.ReadAllLines("autok.txt");
            List<string> ujsorok = new List<string>();

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                if (adatok[0] != rendszam)
                {
                    ujsorok.Add(sor);
                }
            }

            File.WriteAllLines("autok.txt", ujsorok);

            MessageBox.Show("Sikeres törlés!");

            // Lista frissítése
            listbox.Items.Clear();

            foreach (string sor in ujsorok)
            {
                string[] adatok = sor.Split(';');
                listbox.Items.Add(adatok[0]);

            }
        }

        private void bezar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedItem == null) return;

            string rendszam = listbox.SelectedItem.ToString();

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                if (adatok[0] == rendszam)
                {
                    uzemanyag.Content = adatok[1];
                    km.Content = adatok[2];
                    szin.Content = adatok[3];
                    tipus.Content = adatok[4];
                }
                string tipus2 = adatok[4];

                if (tipus2 == "Suzuki Swift")
                {
                    kep.Source = new BitmapImage(new Uri("suzukiswift.png", UriKind.Relative));
                }
                else if (tipus2 == "Toyota Corolla")
                {
                    kep.Source = new BitmapImage(new Uri("toyotacorolla.jpg", UriKind.Relative));
                }
                else if (tipus2 == "Volkswagen Golf")
                {
                    kep.Source = new BitmapImage(new Uri("volkswagengolf.jpg", UriKind.Relative));
                }
                else 
                {
                    kep.Source = null;
                }
            }
            
            {

            }
        }

    }

}
            