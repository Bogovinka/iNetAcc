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
    /// Логика взаимодействия для SelectWarehouseEquipC.xaml
    /// </summary>
    public partial class SelectWarehouseEquipC : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public SelectWarehouseEquipC(int cID)
        {
            InitializeComponent();
            db = con.getDB();
            equipS.ItemsSource = db.EquipmentWarehouseClient.Where(x=>x.ClientID == cID).ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (equipS.SelectedItem != null) DialogResult = true;
        }
    }
}
