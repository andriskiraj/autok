using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace autok
{
    /// <summary>
    /// Interaction logic for AutoModositas.xaml
    /// </summary>
    public partial class AutoModositas : Window
    {

        string[] adatok;
        string eredetirendszam;

        public AutoModositas(string[] kapottAdatok)
        {
            InitializeComponent();
            adatok = kapottAdatok;
            eredetirendszam = adatok[0];
            rendszaam.Text = adatok[0];
            uzemanyag.Text = adatok[1];
            km.Text = adatok[2];
            szin.Text = adatok[3];
            tipus.Text = adatok[4];
        }

        private void valtoztat_Click(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("autok.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(';');

                if (adatok[0] == eredetirendszam)
                {
                    sorok[i] =
                        rendszaam.Text + ";" +
                        uzemanyag.Text + ";" +
                        km.Text + ";" +
                        szin.Text + ";" +
                        tipus.Text;
                }
            }

            File.WriteAllLines("autok.txt", sorok);

            MessageBox.Show("Sikeresen módosítottad!");

            MainWindow foablak = new MainWindow();
            foablak.Show();
            this.Close();
        }

    }
}
