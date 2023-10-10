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
    public partial class Table : Window
    {
        Resource.Model.DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        public void relDT(string selectText)
        {
            dataGrid.ItemsSource = db.Equipment.Where(x => x.ID_in_item != 0 && (x.Name.Contains(selectText) || x.IP.Contains(selectText) || x.MAC.Contains(selectText) || x.Address.Contains(selectText) || x.Login.Contains(selectText))).ToList();
        }
        public Table()
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

        private void save_Click(object sender, RoutedEventArgs e)
        {
            
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");

            //Заголовки у столбцов
            worksheet.Cell("A" + 1).Value = "Наименование";
            worksheet.Cell("B" + 1).Value = "IP";
            worksheet.Cell("C" + 1).Value = "MAC";
            worksheet.Cell("D" + 1).Value = "Тип устройства";
            worksheet.Cell("E" + 1).Value = "Адрес";
            worksheet.Cell("F" + 1).Value = "Примечание";
            int row = 2;
            List<Equipment> equipments = db.Equipment.Where(x => x.ID_in_item != 0 && (x.Name.Contains(searchText.Text) || x.IP.Contains(searchText.Text) || x.MAC.Contains(searchText.Text) || x.Address.Contains(searchText.Text) || x.Login.Contains(searchText.Text))).ToList();
            foreach (Equipment eqip in equipments)
            {
                worksheet.Cell("A" + row).Value = eqip.Name;
                worksheet.Cell("B" + row).Value = eqip.IP;
                worksheet.Cell("C" + row).Value = eqip.MAC;
                if(eqip.Type_Device != null)
                    worksheet.Cell("D" + row).Value = eqip.Type_Device.Name;
                worksheet.Cell("E" + row).Value = eqip.Address;
                worksheet.Cell("F" + row).Value = eqip.Note;
                row++;
            }
            worksheet.Columns().AdjustToContents(); //ширина столбца по содержимому
            relDT(searchText.Text.ToString());
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                workbook.SaveAs(sfd.FileName + ".xlsx");
            }
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                relDT(searchText.Text.ToString());
            }
        }
    }
}
