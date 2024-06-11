using DocumentFormat.OpenXml.Office2021.DocumentTasks;
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
        DatabaseEntities db;
        public AddClient(DatabaseEntities db_)
        {
            InitializeComponent();
            db = db_;
        }
        public AddClient(Client c, DatabaseEntities db_)
        {
            InitializeComponent();
            db = db_;
            SurnameT.Text = c.Surname;
            NameT.Text = c.Name;
            LastNameT.Text = c.LastName;
            PhoneT.Text = c.Phone;
            if (c.EquipmentID != null)
            {
                PortT.Text = $"{c.Equipment.Name}|{c.Equipment.IP}";
                PortT.Tag = c.EquipmentID;
            }
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

        private void selectPort_Click(object sender, RoutedEventArgs e)
        {
            SelectPort sel = new SelectPort(db);
            if (sel.ShowDialog() == true)
            {
                TreeViewItem item = (TreeViewItem)sel.treeView.SelectedItem;
                int id = (int)item.Tag;
                Equipment equip = db.Equipment.Where(x => x.ID == id).FirstOrDefault();
                PortT.Text = $"{equip.Name}|{equip.IP}";
                PortT.Tag = id;
            }
        }
    }
}
