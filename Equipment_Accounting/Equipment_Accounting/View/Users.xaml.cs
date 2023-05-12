using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Equipment_Accounting.Resource.Model;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Users : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public void relDT(string selectText)
        {
            dataGrid.ItemsSource = db.Logins.Where(x => x.Login.Contains(selectText) || x.Password.Contains(selectText)).ToList();
        }
        public Users()
        {
            InitializeComponent();
            db = con.getDB();
            relDT("");
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            relDT(searchText.Text.ToString());
        }

        private void sizeT_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            relDT(searchText.Text.ToString());
        }

        private void dataGrid_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

       
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                relDT(searchText.Text.ToString());
            }
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (db.Logins.Where(x => x.Login == searchText.Text).Count() > 0)
            {
                DialogWindow d = new DialogWindow();
                d.txt.Content = $"Удалить пользователя {searchText.Text}?";
                if (d.ShowDialog() == true)
                {
                    Logins l = db.Logins.Where(x => x.Login == searchText.Text).FirstOrDefault();
                    db.Logins.Remove(l);
                    db.SaveChanges();
                    relDT("");
                }
            }
            else MessageBox.Show("Такого логина нету");
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
            relDT(searchText.Text);
        }
    }
}