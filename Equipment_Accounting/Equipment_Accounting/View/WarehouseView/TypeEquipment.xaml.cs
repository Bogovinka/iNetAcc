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

namespace Equipment_Accounting.View.Warehouse
{
    /// <summary>
    /// Логика взаимодействия для TypeEquipment.xaml
    /// </summary>
    public partial class TypeEquipment : Window
    {
        ConnectBD con = new ConnectBD();
        DatabaseEntities db;
        public TypeEquipment()
        {
            InitializeComponent();
            db = con.getDB();
            lV.ItemsSource = db.EquipmentWarehouseType.ToList();
        }
        AddTypeName aTN;
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            aTN = new AddTypeName();
            if (aTN.ShowDialog() == true)
            {
                EquipmentWarehouseType b = new EquipmentWarehouseType();
                b.Name = aTN.text.Text;
                db.EquipmentWarehouseType.Add(b);
                db.SaveChanges();
                lV.ItemsSource = db.EquipmentWarehouseType.ToList();
            }
        }

        private void EditNew_Click(object sender, RoutedEventArgs e)
        {
            if (lV.SelectedItem != null)
            {
                EquipmentWarehouseType b = lV.SelectedItem as EquipmentWarehouseType;
                aTN = new AddTypeName(b.Name);
                if (aTN.ShowDialog() == true)
                {
                    b.Name = aTN.text.Text;
                    db.SaveChanges();
                    lV.ItemsSource = db.EquipmentWarehouseType.ToList();
                }
            }
        }
    }
}