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
    /// Логика взаимодействия для AddEWarehouse.xaml
    /// </summary>
    public partial class AddEWarehouse : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public void startForm()
        {
            db = con.getDB();
            TypeT.ItemsSource = db.EquipmentWarehouseType.ToList();
            StatusT.ItemsSource = db.EquipmentWarehouseStatus.ToList();
            CondT.ItemsSource = db.Conditions.ToList();
        }
        public void editForm(EquipmentWarehouse equip)
        {
            nameT.Text = equip.Name;
            SerT.Text = equip.SerialNum;
            TypeT.Text = equip.EquipmentWarehouseType.Name;
            ModelT.Text = equip.Model;
            StatusT.Text = equip.EquipmentWarehouseStatus.Name;
            CondT.Text = equip.Conditions.Name;
        }
        public AddEWarehouse()
        {
            InitializeComponent();
            startForm();
            AffiliationT.SelectedIndex = 0;
        }
        public AddEWarehouse(EquipmentWarehouseS s)
        {
            InitializeComponent();
            startForm();
            editForm(s.EquipmentWarehouse);
            SizeT.Text = s.Size.ToString();
            AffiliationT.SelectedIndex = 0;
            if(s.Size > 1)
            {
                AffiliationT.Visibility = Visibility.Hidden;
            }
        }
        public AddEWarehouse(EquipmentWarehouseClient s)
        {
            InitializeComponent();
            startForm();
            editForm(s.EquipmentWarehouse);
            SizeT.Text = s.Size.ToString();
            AffiliationT.SelectedIndex = 2;
            AffiliationPersonT.Text = s.Client.FullName;
        }
        public AddEWarehouse(EquipmentWarehouseMaster s)
        {
            InitializeComponent();
            startForm();
            editForm(s.EquipmentWarehouse);
            SizeT.Text = s.Size.ToString();
            AffiliationT.SelectedIndex = 1;
            AffiliationPersonT.Text = s.Logins.FullName;
        }

        private void AffiliationT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (AffiliationT.SelectedIndex)
            {
                case 0:
                    AffiliationPersonT.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    AffiliationPersonT.Visibility = Visibility.Visible;
                    AffiliationPersonT.ItemsSource = db.Logins.ToList();
                    break;
                case 2:
                    AffiliationPersonT.Visibility = Visibility.Visible;
                    AffiliationPersonT.ItemsSource = db.Client.ToList();
                    break;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            int checkI;
            if (StatusT.Text != "" && CondT.Text != "" && TypeT.Text != "" && int.TryParse(SizeT.Text, out checkI))
            {
                if (Convert.ToInt32(SizeT.Text) > 0)
                {
                    if (AffiliationT.SelectedIndex != 0 && AffiliationPersonT.Text == "") MessageBox.Show("Заполните персону");
                    else DialogResult = true;
                }
                else MessageBox.Show("Количество должно быть > 0");
            }
        }

        private void SizeT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SizeT.Text != "1")
            {
                AffiliationT.Visibility = Visibility.Hidden;
                AffiliationT.SelectedIndex = 0;
                AffiliationPersonT.Visibility = Visibility.Hidden;
                AffL.Visibility = Visibility.Hidden;
            }
            else
            {
                AffL.Visibility = Visibility.Visible;
                AffiliationT.Visibility = Visibility.Visible;
                if (AffiliationT.SelectedIndex != 0) AffiliationPersonT.Visibility = Visibility.Visible;
            }
        }
    }
}
