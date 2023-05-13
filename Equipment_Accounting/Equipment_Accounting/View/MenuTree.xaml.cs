using DocumentFormat.OpenXml.Wordprocessing;
using Equipment_Accounting.Resource.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static NPOI.POIFS.Crypt.CryptoFunctions;

namespace Equipment_Accounting
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class MenuTree : Window
    {
        Resource.Model.DatabaseEntities databaseEntities = new DatabaseEntities();
        Logins log;
        TreeViewItem copyItem = null;
        WorkBD workBD = new WorkBD();
        DatabaseEntities database = new DatabaseEntities();
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

        public MenuTree(Logins login)
        {
            InitializeComponent();   
            log = login;
            loginName.Content = $"Логин: {log.Login}";
            if (log.Permission == 1)
            {
                create.Visibility = Visibility.Visible;
                add.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Visible;
                add2.Visibility = Visibility.Visible;
                edit2.Visibility = Visibility.Visible;
                delete.Visibility = Visibility.Visible;

            }
            updateTree();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Create c = new Create();
            if (c.ShowDialog() == true)
            {
                TreeViewItem newT = new TreeViewItem();
                string name = c.createText.Text;
                newT.Header = name;
                Equipment equip = new Equipment()
                {
                    Name = name,
                    ID_in_item = 0,
                };
                databaseEntities.Equipment.Add(equip);
                databaseEntities.SaveChanges();
                newT.Tag = equip.ID;
                treeView.Items.Add(newT);
                
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                AddNote add = new AddNote();
                if (add.ShowDialog() == true)
                {
                    try
                    {
                        TreeViewItem newT = new TreeViewItem();
                        TreeViewItem t = (TreeViewItem)treeView.SelectedItem;
                        int IDin = (int)t.Tag;
                        workBD.insertDB(add.nameT.Text, add.IPT.Text, add.MACT.Text, add.TypeT.SelectedValue, add.StateT.SelectedValue,
                        add.AdresT.Text, add.NoteT.Text, add.LoginT.Text, add.PasswordT.Text, add.SNMPT.Text, add.VLANT.Text, add.SerT.Text, add.MarkT.SelectedValue,
                        add.ModelT.SelectedValue, IDin);
                        Equipment newEquip = database.Equipment.Where(x => x.IP == add.IPT.Text).FirstOrDefault();
                        newT.Header = newEquip.FullName;
                        newT.Tag = newEquip.ID;
                        t.Items.Add(newT);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem t = (TreeViewItem)treeView.SelectedItem;
                Equipment equip = database.Equipment.Where(x => x.ID == (int)t.Tag).FirstOrDefault();
                if (equip.ID != 0)
                {
                    Update c = new Update(equip);
                    if (c.ShowDialog() == true)
                    {
                        try
                        {
                            workBD.updateDB(c.nameT.Text, c.IPT.Text, c.MACT.Text, (int)c.TypeT.SelectedValue, (int)c.StateT.SelectedValue,
                            c.AdresT.Text, c.NoteT.Text, c.LoginT.Text, c.PasswordT.Text, c.SNMPT.Text, c.VLANT.Text, c.SerT.Text, (int)c.MarkT.SelectedValue,
                            (int)c.ModelT.SelectedValue, equip, databaseEntities, t);
                            t.Header = equip.FullName;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void table_Click(object sender, RoutedEventArgs e)
        {
            Table w = new Table();
            w.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem t = (TreeViewItem)treeView.SelectedItem;
                if (t.HasItems) MessageBox.Show("Этот элемент не пустой", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    workBD.delete(t);
                    t.Background = Brushes.IndianRed;
                    t.Header += "  (удален)";
                }
            }
        }

        void serchItem(string text, TreeViewItem serch)
        {
            try {
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
        private void search_Click(object sender, RoutedEventArgs e)
        {
            serchItem2(searchText.Text);
        }

        private void ping_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                if (selectEquip.ID != 0)
                {
                    Process.Start("cmd.exe", "/C" + $" ping -t {selectEquip.IP}");
                }
            }
        }

        private void tracert_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                new Thread(() =>
                {
                    Tracert(selectT, selectEquip.IP, selectEquip.ID);
                }).Start();
            }

        }
        public void Tracert(TreeViewItem selectT, string IP, int ID)
        {
            if (ID != 0)
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "CMD.EXE";
                psi.Arguments = $"/K tracert {IP}";
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit();
            }
        }

        private void winBox_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                if (selectEquip.ID != 0)
                {
                    if (File.Exists(@"C:\winbox.exe"))
                    {
                        Process.Start(@"C:\winbox.exe");
                        Clipboard.SetText($"{selectEquip.IP}");
                    }
                    else MessageBox.Show("На диске C: нет winbox", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }  
        }

        private void web_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                if (selectEquip.ID != 0)
                {
                    Process.Start($"http://{selectEquip.IP}");
                }
            }
        }

        private void putty_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                if (selectEquip.ID != 0)
                {
                    if (File.Exists(@"C:\putty.exe"))
                    {
                        Process.Start(@"C:\putty.exe");
                        Clipboard.SetText($"{selectEquip.ID}");
                    }
                    else MessageBox.Show("На диске C: нет putty", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void treeView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }
        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                serchItem2(searchText.Text);
            }
        }

        private void maps_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                Equipment selectEquip = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                if (selectEquip.ID != 0)
                {
                    Process.Start($"https://yandex.ru/maps/?text={selectEquip.Address}");
                }
            }

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Reg r = new Reg();
            r.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            View.Menu m = new View.Menu(log);
            m.Show();
            this.Close();
        }



        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                copyItem = selectT;
            }
        }
        public bool checkIdElements(TreeViewItem iCopy, TreeViewItem iPaste)
        {
            bool res = true;
            Equipment copy = database.Equipment.Where(x => x.ID == (int)iCopy.Tag).FirstOrDefault();
            Equipment paste = database.Equipment.Where(x => x.ID == (int)iPaste.Tag).FirstOrDefault();
            int id = (int)paste.ID_in_item;
            if (copy.ID_in_item != 0)
            {
                while (id != 0)
                {
                    if (id == Convert.ToInt32(copy.ID))
                    {
                        res = false;
                        break;
                    }
                    paste = database.Equipment.Where(x => x.ID == id).FirstOrDefault();
                    id = (int)paste.ID_in_item;
                }
                return res;
            }
            else return false;
        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                if (copyItem != null)
                {
                    TreeViewItem selectT = (TreeViewItem)treeView.SelectedItem;
                    if (checkIdElements(copyItem, selectT))
                    {
                        Equipment copy = database.Equipment.Where(x => x.ID == (int)copyItem.Tag).FirstOrDefault();
                        Equipment paste = database.Equipment.Where(x => x.ID == (int)selectT.Tag).FirstOrDefault();
                        copy.ID_in_item = paste.ID;
                        database.SaveChanges();
                        copyItem = null;
                        treeView.Items.Clear();
                        updateTree();
                    }
                    else MessageBox.Show("НИХУЯ, так не работает, переделавай", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Не вырезан элемент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }
    }
}

