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

        public int zycia = 5;
        public char[] haslo = new char[32];
        public char[] wypis = new char[32];
        public int[] uzyte = new int[32];
        public int dlugoscHasa;
        public int wygrana = 0;
        
        private void WprowadzSłowo_OnClick(object sender, RoutedEventArgs e)
        {
            gra.Visibility = Visibility.Visible;
            wprowadzenie.Visibility = Visibility.Hidden;
            string str = wprowadzenieHasła.Text.ToLower();
            dlugoscHasa = str.Length;
            for (int i = 0; i < dlugoscHasa; i++) {
                haslo[i] = str[i];
            }

            var litera = ' ';
            sprawdzenieHasła(litera);
        }

        void sprawdzenieHasła(char litera)
        {
            var licz = 0;
            var licz2 = 0;
            for (var i = 0; i < dlugoscHasa; i++)
            {
                if (uzyte[i] != 1)
                {
                    if (haslo[i] == litera)
                    {
                        wypis[i] = litera;
                        uzyte[i] = 1;
                        licz++;
                        wygrana++;
                    }
                    else
                    {
                        wypis[i] = '_';
                    }
                }
            }
            
            if (licz == licz2)
            {
                zycia -= 1;
                literki.Text += litera;
                literki.Text += " ";
            }
            else
            {
                licz2 = licz;
            }
            
            zycie.Text = Convert.ToString(zycia);

            if (wygrana == dlugoscHasa)
            {
                MessageBox.Show("Gratulujuę zgadłeś słowo.", "Zamknij");
                wprowadzenie.Visibility = Visibility.Visible;
                gra.Visibility = Visibility.Hidden;
                zycia = 5;
            }
            
            if (zycia == -1)
            {
                MessageBox.Show("Straciłeś wszystkie życia, przegrałeś..", "Zamknij");
                wprowadzenie.Visibility = Visibility.Visible;
                gra.Visibility = Visibility.Hidden;
                zycia = 5;
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
                char znak = Convert.ToChar(litera.Text.ToLower());
                sprawdzenieHasła(znak);
            }
        }
    }
}