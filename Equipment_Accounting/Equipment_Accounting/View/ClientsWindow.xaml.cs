using Equipment_Accounting.Classes;
using Equipment_Accounting.Resource.Model;
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
using System.Windows.Shapes;

namespace Equipment_Accounting.View
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        DatabaseEntities db;
        ConnectBD c = new ConnectBD();
        public ClientsWindow(Logins log)
        {
            InitializeComponent();
            db = c.getDB();
            Clientsdg.ItemsSource = db.Client.ToList();
            if(log.Permission == 0)
            {
                AddC.IsEnabled = false;
                DelC.IsEnabled = false;
                EditC.IsEnabled = false;
            }
        }

        private void AddC_Click(object sender, RoutedEventArgs e)
        {
            AddClient ac = new AddClient();
            if(ac.ShowDialog() == true)
            {
                Client c = new Client()
                {
                    Surname = ac.SurnameT.Text,
                    Name = ac.NameT.Text,
                    LastName = ac.LastNameT.Text,
                    Phone = ac.PhoneT.Text
                };
                db.Client.Add(c);
                db.SaveChanges();
                Clientsdg.ItemsSource = db.Client.ToList();
            }
        }

        private void EditC_Click(object sender, RoutedEventArgs e)
        {
            if (Clientsdg.SelectedItem != null)
            {
                Client client = Clientsdg.SelectedItem as Client;
                AddClient ac = new AddClient(client);
                if (ac.ShowDialog() == true)
                {
                    client.Surname = ac.SurnameT.Text;
                    client.Name = ac.NameT.Text;
                    client.LastName = ac.LastNameT.Text;
                    client.Phone = ac.PhoneT.Text;
                    db.SaveChanges();
                    Clientsdg.ItemsSource = db.Client.ToList();
                }
            }
        }

        private void DelC_Click(object sender, RoutedEventArgs e)
        {
            if (Clientsdg.SelectedItem != null)
            {
                Client client = Clientsdg.SelectedItem as Client;
                db.Client.Remove(client);
                db.SaveChanges();
                Clientsdg.ItemsSource = db.Client.ToList();
                
            }
        }
    }
}
