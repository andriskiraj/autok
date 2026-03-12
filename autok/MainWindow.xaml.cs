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
                textbox.AppendText(adatok[0] + "\n");
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
            AutoModositas modositas = new AutoModositas();
            modositas.Show();
            this.Close();
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bezar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void rendszamm(object sender, RoutedEventArgs e)
        {
            string rendszam = textbox.SelectedText.Trim();

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

            }
            if( rendszam =)
            {

            }
            
        }
    }
}