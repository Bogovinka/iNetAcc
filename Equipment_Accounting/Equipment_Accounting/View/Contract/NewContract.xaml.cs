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
    /// Логика взаимодействия для NewContract.xaml
    /// </summary>
    public partial class NewContract : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public NewContract()
        {
            InitializeComponent();
            db = con.getDB();
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            if (text.Text != "") {

                if (db.ClientContracts.Where(x => x.Contract == text.Text).Count() == 0)
                {
                    DialogResult = true;
                }
                else MessageBox.Show("Такой договор уже есть");
            }
        }
    }
}
