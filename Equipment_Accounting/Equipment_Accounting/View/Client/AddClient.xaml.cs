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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }
        public AddClient(Client c)
        {
            InitializeComponent();
            SurnameT.Text = c.Surname;
            NameT.Text = c.Name;
            LastNameT.Text = c.LastName;
            PhoneT.Text = c.Phone;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneT.IsMaskFull)
            {
                DialogResult = true;
            }
            else MessageBox.Show("Заполни полностью номер телефона");
        }
    }
}
