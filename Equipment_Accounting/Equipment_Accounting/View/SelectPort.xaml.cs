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
    /// Логика взаимодействия для SelectWarehouse.xaml
    /// </summary>
    public partial class SelectPort : Window
    {
        Classes.ConnectBD con = new Classes.ConnectBD();
        DatabaseEntities database;
        void addItems(TreeViewItem selectT, Equipment equipSelect)
        {
            if (database.Equipment.Where(x => x.ID_in_item == equipSelect.ID).Count() > 0)
            {
                try
                {
                    TreeViewItem treeViewItem;
                    List<Equipment> equipments = database.Equipment.Where(x => x.ID_in_item == equipSelect.ID).ToList();
                    foreach (Equipment equip in equipments)
                    {
                        treeViewItem = new TreeViewItem();
                        treeViewItem.Tag = equip.ID;
                        treeViewItem.Header = equip.FullName;
                        selectT.Items.Add(treeViewItem);
                        addItems(treeViewItem, equip);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        void updateTree()
        {
            if (database.Equipment.Where(x => x.ID_in_item == 0).Count() > 0)
            {
                try
                {
                    TreeViewItem treeViewItem;
                    List<Equipment> equipments = database.Equipment.Where(x => x.ID_in_item == 0).ToList();
                    foreach (Equipment equip in equipments)
                    {
                        treeViewItem = new TreeViewItem();
                        treeViewItem.Tag = equip.ID;
                        treeViewItem.Header = equip.Name;
                        addItems(treeViewItem, equip);
                        treeView.Items.Add(treeViewItem);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public SelectPort(DatabaseEntities db)
        {
            InitializeComponent();
            database = con.getDB();
            updateTree();
        }
        void serchItem(string text, TreeViewItem serch)
        {
            try
            {
                foreach (TreeViewItem item in serch.Items)
                {
                    if (item.Header.ToString().Contains(searchText.Text))
                    {
                        item.IsSelected = true;
                        TreeViewItem i = (TreeViewItem)item.Parent;
                        string head = "";
                        int countHead = 51;
                        while (countHead > 50)
                        {
                            i.IsExpanded = true;
                            i = (TreeViewItem)i.Parent;
                            head = i.Header.ToString();
                            countHead = head.Length;
                        }
                    }
                    serchItem(text, item);
                }

            }
            catch
            {
            }
        }
        void serchItem2(string text)
        {
            try
            {
                foreach (TreeViewItem item in treeView.Items)
                {
                    if (item.Header.ToString().Contains(searchText.Text))
                    {
                        item.IsSelected = true;
                        foreach (TreeViewItem i in item.Items)
                        {
                            i.IsExpanded = true;
                        }
                    }
                    else
                    {
                        serchItem(text, item);
                    }
                }
            }
            catch
            {
            }
        }
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                serchItem2(searchText.Text);
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            serchItem2(searchText.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null) DialogResult = true;
        }
    }
}
