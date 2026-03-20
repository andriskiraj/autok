using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace autok
{
    /// <summary>
    /// Interaction logic for UjAuto.xaml
    /// </summary>
    public partial class UjAuto : Window
    {
        public UjAuto()
        {
            InitializeComponent();
        }

        private void hozzaad_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ujrendszam.Text) ||
                string.IsNullOrWhiteSpace(ujuzemanyag.Text) ||
                string.IsNullOrWhiteSpace(ujkilometer.Text) ||
                string.IsNullOrWhiteSpace(ujszin.Text) ||
                string.IsNullOrWhiteSpace(ujtipus.Text))
            {
                MessageBox.Show("Az összes megzőt ki kell tölteni!");
                return;
            }
            string ujSor =
        ujrendszam.Text + ";" +
        ujuzemanyag.Text + ";" +
        ujkilometer.Text + ";" +
        ujszin.Text + ";" +
        ujtipus.Text;

            File.AppendAllText("autok.txt", ujSor + "\n");

            MessageBox.Show("Sikeresen hozzáadtad!");

            MainWindow fo = new MainWindow();
            fo.Show();
            this.Close();

        }
    }
}
