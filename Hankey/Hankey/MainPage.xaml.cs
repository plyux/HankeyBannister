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
using System.Net.Mail;
using System.Net;

namespace Hankey
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
        string mail;
        string pass;
        string prov;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("1.txt");
            mail = sr.ReadLine();
            pass = sr.ReadLine();
            prov = sr.ReadLine();
            sr.Close();
            label5.Content = mail;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns;
            ns = NavigationService.GetNavigationService(this);
            Currency nextPage = new Currency();
            ns.Navigate(nextPage);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string prov1="";
            int prov2=0;
            if (prov == "0")
            {
                prov1 = "smtp.gmail.com";
                prov2 = 587;
            };
            if (prov == "1")
            {
                prov1 = "smtp.ukr.net";
                prov2 = 2525;
            };
            if (prov == "2")
            {
                prov1 = "smtp.mail.ru";
                prov2 = 587;
            };
            if (prov == "3")
            {
                prov1 = "smtp.yandex.ua";
                prov2 = 587;
            };
            try
            {
                SmtpClient Smtp = new SmtpClient(prov1, prov2);
                Smtp.Credentials = new NetworkCredential(mail, pass);
                Smtp.EnableSsl = true;
                   //Формирование письма
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress(mail);
                Message.To.Add(new MailAddress(textBox1.Text));
                Message.Subject = textBox2.Text;
                string richText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                Message.Body = richText;
                Smtp.Send(Message);//отправка
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
