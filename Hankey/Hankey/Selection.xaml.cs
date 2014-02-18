using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Hankey
{
    /// <summary>
    /// Логика взаимодействия для Selection.xaml
    /// </summary>
    public partial class Selection : Page
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string p1 = passwordBox1.Password;
            string p2 = passwordBox2.Password;
            if (p1 != p2)
                MessageBox.Show("Неспівпадіння паролів", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                StreamWriter sw = new StreamWriter("1.txt");
                sw.WriteLine(textBox1.Text);
              
                sw.WriteLine(passwordBox1.Password.ToString());
                sw.WriteLine(comboBox1.SelectedIndex);
                sw.Close();
                NavigationService ns;
                ns = NavigationService.GetNavigationService(this);
                MainPage nextPage = new MainPage();
                ns.Navigate(nextPage);
               }
            }
    }
}
