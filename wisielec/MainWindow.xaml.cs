using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace wisielec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public char[] haslo = new char[32];
        public char[] wypis = new char[32];
        public int[] uzyte = new int[32];
        public int dlugoscHasa;
        
        private void WprowadzSłowo_OnClick(object sender, RoutedEventArgs e)
        {
            gra.Visibility = Visibility.Visible;
            wprowadzenie.Visibility = Visibility.Hidden;
            string str = wprowadzenieHasła.Text;
            dlugoscHasa = str.Length;
            for (int i = 0; i < dlugoscHasa; i++) {
                haslo[i] = str[i];
            }

            var litera = '>';
            sprawdzenieHasła(litera);
        }

        void sprawdzenieHasła(char litera)
        {
            for (var i = 0; i < dlugoscHasa; i++)
            {
                if (uzyte[i] != 1)
                {
                    if (haslo[i] == litera)
                    {
                        wypis[i] = litera;
                        uzyte[i] = 1;
                    }
                    else
                    {
                        wypis[i] = '_';
                    }
                }
            }

            hasło.Text = null;
            for (var i = 0; i < dlugoscHasa; i++)
            {
                hasło.Text += wypis[i];
                hasło.Text += " ";
            }
        }
        
        private void WprowadzLitere_OnClick(object sender, RoutedEventArgs e)
        {
            if (litera.Text != null)
            {
                char znak = Convert.ToChar(litera.Text);
                sprawdzenieHasła(znak);
            }
        }
    }
}