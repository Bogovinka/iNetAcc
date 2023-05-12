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
    /// Логика взаимодействия для AddTMC.xaml
    /// </summary>
    public partial class AddTMC : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public AddTMC()
        {
            InitializeComponent();
            db = con.getDB();
            UnitT.ItemsSource = db.Unit.ToList();
        }
        public AddTMC(TMC tmc)
        {
            InitializeComponent();
            db = con.getDB();
            UnitT.ItemsSource = db.Unit.ToList();
            UnitT.Text = tmc.Unit.Name;
            NameT.Text = tmc.Name;
            SizeT.Text = tmc.Size.ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
