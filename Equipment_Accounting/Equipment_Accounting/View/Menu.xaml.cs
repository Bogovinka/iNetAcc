using Equipment_Accounting.Resource.Model;
using Microsoft.Office.Interop.Excel;
using MySqlX.XDevAPI;
using NPOI.HSSF.Record.Chart;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : System.Windows.Window
    {
        Logins log;
        DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public Menu(Logins login)
        {
            InitializeComponent();
            log = login;
            loginName.Content = "логин: " + log.Login;
            db = con.getDB();
            contractsDG.ItemsSource = db.Task.ToList();
            if (log.Permission == 0)
            {
                delContract.IsEnabled = false;
                addContract.IsEnabled = false;
                users.Visibility = Visibility.Hidden;
            }
        }

        private void tree_Click(object sender, RoutedEventArgs e)
        {
            MenuTree mT = new MenuTree(log, db);
            mT.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void warehouse_Click(object sender, RoutedEventArgs e)
        {
            Warehouse w = new Warehouse(log, db);
            w.Show();
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow cw = new ClientsWindow(log, db);
            cw.Show();
        }

        private void addContract_Click(object sender, RoutedEventArgs e)
        {
            SelectContract selectContract = new SelectContract();
            if (selectContract.ShowDialog() == true)
            {
                AddContract addContract = new AddContract((TypeTask)selectContract.typeC.SelectedItem, log, db);
                if (addContract.ShowDialog() == true)
                {
                    contractsDG.ItemsSource = db.Task.ToList();
                }
            }
        }
        public void EditClick()
        {
            if (contractsDG.SelectedItem != null)
            {
                AddContract addContract = new AddContract((Resource.Model.Task)contractsDG.SelectedItem, log, db);
                if (addContract.ShowDialog() == true)
                {
                    contractsDG.ItemsSource = db.Task.ToList();
                }
            }
        }
        private void editContract_Click(object sender, RoutedEventArgs e)
        {
            EditClick();
        }

        private void delContract_Click(object sender, RoutedEventArgs e)
        {
            if (contractsDG.SelectedItem != null)
            {
                Resource.Model.Task taskCheck = (Resource.Model.Task)contractsDG.SelectedItem;
                if (taskCheck.StatusTaskID == 2)
                {
                    DialogWindow dw = new DialogWindow();
                    if (dw.ShowDialog() == true)
                    {
                        foreach (TaskEquipment t in db.TaskEquipment.Where(x => x.TaskID == taskCheck.ID).ToList())
                            db.TaskEquipment.Remove(t);
                        foreach (TaskTMC t in db.TaskTMC.Where(x => x.TaskID == taskCheck.ID).ToList())
                            db.TaskTMC.Remove(t);
                        foreach (TaskEquipmentC t in db.TaskEquipmentC.Where(x => x.TaskID == taskCheck.ID).ToList())
                            db.TaskEquipmentC.Remove(t);
                        db.Task.Remove(taskCheck);
                        db.SaveChanges();
                        contractsDG.ItemsSource = db.Task.ToList();
                    }
                }
                else MessageBox.Show("Можно удалить только завершенную заявку");
            }
        }

        private void contractsDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditClick();
        }

        private void users_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
    }
}
