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
    /// Логика взаимодействия для AddContractToClient.xaml
    /// </summary>
    public partial class AddContractToClient : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        bool checkP = true;
        string txt = "";
        public AddContractToClient()
        {
            InitializeComponent();
            db = con.getDB();
        }
        public AddContractToClient(string t)
        {
            InitializeComponent();
            db = con.getDB();
            text.Text = t;
            checkP = false;
            txt = t;
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            if(text.Text != "")
            {
                if (checkP)
                {
                    if (db.ClientContracts.Where(x => x.Contract == text.Text).Count() == 0)
                    {
                        DialogResult = true;
                    }
                    else MessageBox.Show("Такой договор уже есть");
                }
                else
                {
                    if(db.ClientContracts.Where(x => x.Contract == text.Text && x.Contract != txt).Count() == 0)
                    {
                        DialogResult = true;
                    }
                    else MessageBox.Show("Такой договор уже есть");
                }
            }
        }
    }
}
