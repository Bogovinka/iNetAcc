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
    /// Логика взаимодействия для MarksWin.xaml
    /// </summary>
    public partial class MarksWin : Window
    {
        ConnectBD con = new ConnectBD();
        DatabaseEntities db;
        public MarksWin()
        {
            InitializeComponent();
            db = con.getDB();
            lV.ItemsSource = db.Brand.ToList();
        }
        AddTypeName aTN;
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            aTN = new AddTypeName();
            if (aTN.ShowDialog() == true)
            {
                Brand b = new Brand();
                b.Name = aTN.text.Text;
                db.Brand.Add(b);
                db.SaveChanges();
                lV.ItemsSource = db.Brand.ToList();
            }
        }

        private void EditNew_Click(object sender, RoutedEventArgs e)
        {
            if(lV.SelectedItem != null)
            {
                Brand b = lV.SelectedItem as Brand;
                aTN = new AddTypeName(b.Name);
                if (aTN.ShowDialog() == true)
                {
                    b.Name = aTN.text.Text;
                    db.SaveChanges();
                    lV.ItemsSource = db.Brand.ToList();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lV.SelectedItem != null)
            {
                Brand b = lV.SelectedItem as Brand;
                if (db.Equipment.Where(x => x.Brand_id == b.ID).Count() == 0)
                {
                    db.Brand.Remove(b);
                    db.SaveChanges();
                    lV.ItemsSource = db.Brand.ToList();
                }
                else MessageBox.Show("Сначала удалите ВСЁ оборудование с этой маркой");
            }
        }
    }
}
