
using Equipment_Accounting.Resource.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD ConnectBD = new Classes.ConnectBD();
        public int IDW = 0;
        public string name_i = "";
        Equipment equipment;
        public Update(Equipment equip)
        {
            InitializeComponent();
            db = ConnectBD.getDB();
            StateT.ItemsSource = db.Conditions.ToList();
            MarkT.ItemsSource = db.Brand.ToList();
            ModelT.ItemsSource = db.Model.ToList();
            TypeT.ItemsSource = db.Type_Device.ToList();
            nameT.Text = equip.Name;
            IPT.Text = equip.IP;
            MACT.Text = equip.MAC;
            TypeT.SelectedValue = equip.Type_Device_id;
            StateT.SelectedValue = equip.Conditions_id;
            AdresT.Text = equip.Address;
            NoteT.Text = equip.Note;
            LoginT.Text = equip.Login;
            PasswordT.Text = equip.Password;
            SNMPT.Text = equip.SNMP;
            IDW = (int)equip.ID_in_item;
            SerT.Text = equip.Serial_num;
            VLANT.Text = equip.Num_vlan;
            MarkT.SelectedValue = equip.Brand_id;
            ModelT.SelectedValue = equip.Model_id;
            equipment = equip;
        }
        private void createB_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
            List<Equipment> equipList = new List<Equipment>();
            equipList.Remove(equipment);
            if (nameT.Text.Length > 0 && equipList.Where(x => x.IP == IPT.Text && x.IP != "").Count() == 0 && equipList.Where(x => x.Serial_num == SerT.Text && x.Serial_num != "").Count() == 0 && equipList.Where(x => x.MAC == MACT.Text && x.MAC != "").Count() == 0 && equipList.Where(x => x.Name == nameT.Text && x.Name != "").Count() == 0)
            {
                if (Regex.IsMatch(IPT.Text, pattern) && (MACT.IsMaskFull | MACT.Text == "__:__:__:__:__:__"))
                    DialogResult = true;
                else MessageBox.Show("Заполни IP и MAC до конца или оставь пустыми, проверь правильность заполнения");
            }
            else
            {
                string error = "Ошибка:\n";
                if (nameT.Text == "") error += "Заполни название оборудования\n";
                if (equipList.Where(x => x.IP == IPT.Text).Count() > 0) error += "Такой IP-адрес уже есть в базе данных\n";
                if (equipList.Where(x => x.MAC == MACT.Text).Count() > 0) error += "Такой MAC-адрес уже есть в базе данных\n";
                if (equipList.Where(x => x.Name == nameT.Text).Count() > 0) error += "Такой наименование уже есть в базе данных\n";
                if (equipList.Where(x => x.Serial_num == SerT.Text && x.Serial_num != "").Count() > 0) error += "Такой серийный номер уже есть в базе данных\n";
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
