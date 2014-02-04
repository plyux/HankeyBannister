using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hankey
{
    /// <summary>
    /// Логика взаимодействия для Currency.xaml
    /// </summary>
    public partial class Currency : Page
    {
        public Currency()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
              Color strt, end;
            double x = 0, y = 0;
            int r, g, b;
            Random rand = new Random();
            r = rand.Next();
            g = rand.Next();
            b = rand.Next();
            strt = Color.FromRgb((byte)r, (byte)g, (byte)b);
            r = rand.Next();
            g = rand.Next();
            b = rand.Next();
            end = Color.FromRgb((byte)r, (byte)g, (byte)b);
            RadialGradientBrush grb1=new RadialGradientBrush(strt,end);
            grb1.MappingMode=BrushMappingMode.RelativeToBoundingBox;
            x = rand.NextDouble();
            y = rand.NextDouble();
            grb1.GradientOrigin = new Point(x,y);
            this.Background = grb1;
                string patternUSD = "<td class=\"cell_c\">(.*)</td>";
                   HttpWebRequest myHttpWebRequest =
                       (HttpWebRequest)
                       HttpWebRequest.Create("http://www.bank.gov.ua/control/uk/curmetal/detail/currency?period=daily");
                   HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();
                   StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());
                   string html = myStreamReader.ReadToEnd();
                   Match match;
                   int l = 0;
            for (int i = 0; i < 100; i++)
            {
                l++;
                match = Regex.Match(html, patternUSD);
                label1.Content += match.Groups[1].ToString();
                if (l%4 != 0) label1.Content += "     -     ";
                int n = html.IndexOf("<td class=\"cell_c\">");
                html = html.Remove(n, 18);
                if (l%4 == 0) label1.Content += "\r\n";
            }
        }
        }
    }
}
