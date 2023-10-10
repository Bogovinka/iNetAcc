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

namespace Equipment_Accounting.View.Tree
{
    /// <summary>
    /// Логика взаимодействия для ModelsWin.xaml
    /// </summary>
    public partial class ModelsWin : Window
    {
        ConnectBD con = new ConnectBD();
        DatabaseEntities db;
        public ModelsWin()
        {
            InitializeComponent();
            db = con.getDB();
            lV.ItemsSource = db.Model.ToList();
        }
        AddTypeName aTN;
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            aTN = new AddTypeName();
            if (aTN.ShowDialog() == true)
            {
                Model b = new Model();
                b.Name = aTN.text.Text;
                db.Model.Add(b);
                db.SaveChanges();
                lV.ItemsSource = db.Model.ToList();
            }
        }

        private void EditNew_Click(object sender, RoutedEventArgs e)
        {
            if (lV.SelectedItem != null)
            {
                Model b = lV.SelectedItem as Model;
                aTN = new AddTypeName(b.Name);
                if (aTN.ShowDialog() == true)
                {
                    b.Name = aTN.text.Text;
                    db.SaveChanges();
                    lV.ItemsSource = db.Model.ToList();
                }
            }
        }
    }
}

