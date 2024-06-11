﻿using Equipment_Accounting.Resource.Model;
using Equipment_Accounting.View.WarehouseView;
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
        public void SearchList(string searchT, string searchStatus, string searchType)
        {
           contractsDG.ItemsSource = db.Task.Where(x => (x.ClientContracts.Client.Surname.ToString().Contains(searchT) || x.Addres.Contains(searchT)) && x.StatusTask.Name.Contains(searchStatus) && x.TypeTask.Name.Contains(searchType)).ToList();

        }
        public Menu(Logins login)
        {
            InitializeComponent();
            log = login;
            loginName.Content = "логин: " + log.Login;
            db = con.getDB();
            SearchList("", "", "");
            StatusCB.ItemsSource = db.StatusTask.ToList();
            TypeCB.ItemsSource = db.TypeTask.ToList();
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


        private void warehouse_Click(object sender, RoutedEventArgs e)
        {
            WarehouseM w = new WarehouseM(log, db);
            w.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchList(SearchTB.Text, StatusCB.Text, TypeCB.Text);
        }



        private void StatusCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(StatusCB.SelectedItem != null)
                SearchList(SearchTB.Text, ((StatusTask)StatusCB.SelectedItem).Name, TypeCB.Text);
        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TypeCB.SelectedItem != null)
            SearchList(SearchTB.Text, StatusCB.Text, ((TypeTask)TypeCB.SelectedItem).Name);
        }

        private void resetSort_Click(object sender, RoutedEventArgs e)
        {
            StatusCB.SelectedItem = null;
            TypeCB.SelectedItem = null;
            SearchList(SearchTB.Text, StatusCB.Text, TypeCB.Text);
        }
    }
}
