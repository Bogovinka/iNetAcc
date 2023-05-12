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
    /// Логика взаимодействия для SelectContract.xaml
    /// </summary>
    public partial class SelectContract : Window
    {
        Classes.ConnectBD con = new Classes.ConnectBD();
        public SelectContract()
        {
            InitializeComponent();
            Resource.Model.DatabaseEntities db = con.getDB();
            typeC.ItemsSource = db.TypeTask.ToList();
            typeC.SelectedIndex = 0;
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
