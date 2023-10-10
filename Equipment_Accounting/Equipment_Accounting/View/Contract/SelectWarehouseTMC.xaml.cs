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
    /// Логика взаимодействия для SelectWarehouse.xaml
    /// </summary>
    public partial class SelectWarehouseTMC : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public SelectWarehouseTMC()
        {
            InitializeComponent();
            db = con.getDB();
            TMCdg.ItemsSource = db.TMC.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TMCdg.SelectedItem != null) DialogResult = true;
        }
    }
}
