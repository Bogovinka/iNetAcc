using DocumentFormat.OpenXml.Office2010.Excel;
using Equipment_Accounting.Resource.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Equipment_Accounting
{
    /// <summary>
    /// Логика взаимодействия для AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        WorkBD workBD = new WorkBD();
        Resource.Model.DatabaseEntities db = new Resource.Model.DatabaseEntities();
        public AddNote()
        {
            InitializeComponent();
            StateT.ItemsSource = db.Conditions.ToList();
            MarkT.ItemsSource = db.Brand.ToList();
            ModelT.ItemsSource = db.Model.ToList();
            TypeT.ItemsSource = db.Type_Device.ToList();
        }

        private void createB_Click(object sender, RoutedEventArgs e)
        {
            if (MarkT.Text != "" && ModelT.Text != "" && StateT.Text != "" && TypeT.Text != "" && nameT.Text.Length > 0 && IPT.Text.Length > 0 && MACT.Text.Length > 0 && db.Equipment.Where(x => x.IP == IPT.Text).Count() == 0 && db.Equipment.Where(x => x.Serial_num == SerT.Text).Count() == 0 && db.Equipment.Where(x => x.MAC == MACT.Text).Count() == 0 && db.Equipment.Where(x => x.Name == nameT.Text).Count() == 0)
            {
                DialogResult = true;
            }
            else
            {
                string error = "Заполни все поля\n";
                if (db.Equipment.Where(x => x.IP == IPT.Text).Count() > 0) error += "Такой IP-адрес уже есть в базе данных\n";
                if (db.Equipment.Where(x => x.Serial_num == SerT.Text).Count() > 0) error += "Такой серийный номер уже есть в базе данных\n";
                if (db.Equipment.Where(x => x.MAC == MACT.Text).Count() > 0) error += "Такой MAC-адрес уже есть в базе данных\n";
                if (db.Equipment.Where(x => x.Name == nameT.Text).Count() > 0) error += "Такое наименование уже есть в базе данных\n";
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void IPT_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!IPT.Text.Contains(".") && IPT.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
