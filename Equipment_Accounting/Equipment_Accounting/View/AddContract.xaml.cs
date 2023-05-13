using DocumentFormat.OpenXml.Office2021.PowerPoint.Comment;
using Equipment_Accounting.Resource.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        public int getID()
        {
            if (db.Task.Where(x => x.TypeID == task.TypeID).Count() > 0) return db.Task.Where(x => x.TypeID == task.TypeID).Select(x => x.IDofType).Max() + 1;
            else return 1;
        }
        TypeTask typeTask;
        DatabaseEntities db;
        Classes.ConnectBD con = new Classes.ConnectBD();
        List<TaskTMC> TMCs = new List<TaskTMC>();
        List<TaskEquipment> Equipments = new List<TaskEquipment>();
        List<TaskTMC> TMCsDel = new List<TaskTMC>();
        List<TaskEquipment> EquipmentsDel = new List<TaskEquipment>();
        public Resource.Model.Task task;
        Logins creator;

        public AddContract(TypeTask typeT, Logins creator_, DatabaseEntities db_)
        {
            InitializeComponent();
            WareHouse.Visibility = Visibility.Hidden;
            EditB.IsEnabled = false;
            CloseB.IsEnabled = false;
            task = new Resource.Model.Task();
            db = db_;
            creator = creator_;
            task.TypeID = typeT.ID;
            typeTask = typeT;
            ClientT.ItemsSource = db.Client.ToList();
            MasterT.ItemsSource = db.Logins.ToList();
            task.IDofType = getID();
            task.DateStart = DateTime.Now;
            contractNum.Content = $"Заявка №{task.FullID} от {task.DateStart}";
        }
        public AddContract(Resource.Model.Task task_, Logins creator_, DatabaseEntities db_)
        {
            InitializeComponent();
            CreateB.IsEnabled = false;
            typeTask = task_.TypeTask;
            db = db_;
            ClientT.ItemsSource = db.Client.ToList();
            MasterT.ItemsSource = db.Logins.ToList();
            task = task_;
            TMCsDel = db.TaskTMC.Where(x => x.TaskID == task.ID).ToList();
            EquipmentsDel = db.TaskEquipment.Where(x => x.TaskID == task.ID).ToList();
            TMCs = TMCsDel.ToList();
            Equipments = EquipmentsDel.ToList();
            Elv.ItemsSource = Equipments.ToList();
            TMClv.ItemsSource = TMCs.ToList();
            ClientT.Text = task.ClientContracts.Client.FullName;
            ContractT.Text = task.ClientContracts.Contract;
            MasterT.Text = task.Logins.FullName;
            PortT.Text = $"{task.Equipment.Name}|{task.Equipment.IP}";
            PortT.Tag = task.PortID;
            ComentT.Text = task.Note;
            DateEndT.SelectedDate = task.DateEnt;
            AddresT.Text = task.Addres;
            contractNum.Content = $"Заявка №{task.FullID} от {task.DateStart}";
            if(task.StatusTaskID == 3)
            {
                CloseB.IsEnabled = false;
            }
            if (creator_.Permission == 0)
            {
                CloseB.IsEnabled = false;
                ClientT.IsEnabled = false;
                ContractT.IsEnabled = false;
                MasterT.IsEnabled = false;
                PortT.IsEnabled = false;
                DateEndT.IsEnabled = false;
                ComentT.IsEnabled = false;
                AddresT.IsEnabled = false;
                createClient.IsEnabled = false;
                createContract.IsEnabled = false;
                selectPort.IsEnabled = false;
            }
        }

        private void wordP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void excelB_Click(object sender, RoutedEventArgs e)
        {

        }
        public void setTask()
        {
            task.Contract = (int)ContractT.SelectedValue;
            task.ClientContracts = (ClientContracts)ContractT.SelectedItem;
            task.DateEnt = DateEndT.SelectedDate;
            task.Note = ComentT.Text;
            task.Addres = AddresT.Text;
            task.MasterID = (int)MasterT.SelectedValue;
            task.Logins = (Logins)MasterT.SelectedItem;
            task.PortID = (int)PortT.Tag;
            task.Equipment = db.Equipment.Where(x => x.ID == task.PortID).FirstOrDefault();  
        }
        private void CreateB_Click(object sender, RoutedEventArgs e)
        {
            if (ClientT.Text != "" && ContractT.Text != "" && AddresT.Text != "" && PortT.Text != "" && MasterT.Text != "" && DateEndT.Text != "" && ComentT.Text != "")
            {
                setTask();
                task.Creator = creator.FullName;
                task.IDofType = getID();
                task.StatusTaskID = 3;
                task.TypeTask = db.TypeTask.Where(x => x.ID == typeTask.ID).FirstOrDefault();
                task.StatusTask = db.StatusTask.Where(x => x.ID == 3).FirstOrDefault();
                db.Task.Add(task);
                db.SaveChanges();
                DialogResult = true;
            }
            else MessageBox.Show("Заполни все поля");
        }
        public bool CheckTMC()
        {
            bool res = true;
            foreach (TaskTMC t in TMCs.ToList())
            {
                if(!TMCsDel.Contains(t))
                    if (db.TMC.Where(x => x.ID == t.TMCID).Select(x => x.Size).FirstOrDefault() < t.Size) res = false;
            }
            return res;
        }
        public bool CheckEquip()
        {
            bool res = true;
            foreach (TaskEquipment t in Equipments.ToList())
            {
                if(!EquipmentsDel.Contains(t))
                    if (db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() == 0) res = false;
            }
            return res;
        }
        public void Clear()
        {
            foreach (TaskTMC t in TMCsDel.ToList())
            {
                if (!TMCs.Contains(t))
                {
                    TMC tmc = db.TMC.Where(x => x.ID == t.TMCID).FirstOrDefault();
                    tmc.Size += t.Size;
                    db.TaskTMC.Remove(t);
                }
            }
            EquipmentWarehouseS equipmentWarehouseS;
            foreach (TaskEquipment t in EquipmentsDel.ToList())
            {
                if (!Equipments.Contains(t))
                {
                    if (db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() > 0)
                        db.EquipmentWarehouseMaster.Remove(db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).FirstOrDefault());
                    if (db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() == 0)
                    {
                        equipmentWarehouseS = new EquipmentWarehouseS()
                        {
                            EquipmentWarehouseID = t.EquipmentWarehouse,
                            WarehouseID = 1,
                            Size = 1,
                            EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == t.EquipmentWarehouse).FirstOrDefault()
                        };
                        db.EquipmentWarehouseS.Add(equipmentWarehouseS);
                    }
                    else
                    {
                        equipmentWarehouseS = db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).FirstOrDefault();
                        equipmentWarehouseS.Size += 1;
                    }
                    db.TaskEquipment.Remove(t);
                }
            }
        }
        public void AddtoEdit()
        {
            foreach(TaskTMC t in TMCs.ToList())
            {
                if (!TMCsDel.Contains(t))
                {
                    TMC tmc = db.TMC.Where(x => x.ID == t.TMCID).FirstOrDefault();
                    tmc.Size -= t.Size;
                    db.TaskTMC.Add(t);
                }
            }
            EquipmentWarehouseMaster equipmentWarehouseMaster;
            EquipmentWarehouseS equipmentWarehouseS;
            foreach (TaskEquipment t in Equipments.ToList())
            {
                if (db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() > 0)
                {
                    equipmentWarehouseS = db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).FirstOrDefault();
                    if (equipmentWarehouseS.Size == 1)
                        db.EquipmentWarehouseS.Remove(db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).FirstOrDefault());
                    else equipmentWarehouseS.Size -= 1;
                }
                if (db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() == 0)
                {
                    equipmentWarehouseMaster = new EquipmentWarehouseMaster()
                    {
                        MasterID = task.MasterID,
                        Logins = db.Logins.Where(x => x.ID == task.MasterID).FirstOrDefault(),
                        Size = 1,
                        EquipmentWarehouseID = t.EquipmentWarehouse,
                        EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == t.EquipmentWarehouse).FirstOrDefault()
                    };
                    db.EquipmentWarehouseMaster.Add(equipmentWarehouseMaster);
                }
                if (!EquipmentsDel.Contains(t))
                {
                    db.TaskEquipment.Add(t);
                }
            }
            
        
        }
        public void AddtoClose()
        {
            foreach (TaskTMC t in TMCs.ToList())
            {
                if (!TMCsDel.Contains(t))
                {
                    TMC tmc = db.TMC.Where(x => x.ID == t.TMCID).FirstOrDefault();
                    tmc.Size -= t.Size;
                    db.TaskTMC.Add(t);
                }
            }
            EquipmentWarehouseClient equipmentWarehouseClient;
            foreach (TaskEquipment t in Equipments.ToList())
            {
                if (db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() > 0)
                    db.EquipmentWarehouseMaster.Remove(db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).FirstOrDefault());
                if (db.EquipmentWarehouseClient.Where(x => x.EquipmentWarehouseID == t.EquipmentWarehouse).Count() == 0)
                {
                    equipmentWarehouseClient = new EquipmentWarehouseClient()
                    {
                        ClientID = task.ClientContracts.ClientID,
                        Client = db.Client.Where(x => x.ID == task.ClientContracts.ClientID).FirstOrDefault(),
                        EquipmentWarehouseID = t.EquipmentWarehouse,
                        Size = 1,
                        EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == t.EquipmentWarehouse).FirstOrDefault()
                    };
                    db.EquipmentWarehouseClient.Add(equipmentWarehouseClient);
                }
                if (!EquipmentsDel.Contains(t))
                {
                    db.TaskEquipment.Add(t);
                }
            }
            

        }
        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            if (ClientT.Text != "" && ContractT.Text != "" && AddresT.Text != "" && PortT.Text != "" && MasterT.Text != "" && DateEndT.Text != "" && ComentT.Text != "")
            {
                if (CheckTMC())
                {
                    if (CheckEquip())
                    {
                        setTask();
                        task.StatusTaskID = 1;
                        task.StatusTask = db.StatusTask.Where(x => x.ID == 1).FirstOrDefault();
                        Clear();
                        AddtoEdit();
                        db.SaveChanges();
                        DialogResult = true;
                    }
                    else MessageBox.Show("Не всё оборудование есть на складе(оборудование очищено)");
                }
                else MessageBox.Show("Не всё указанное TMC есть на складе");
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            if (ClientT.Text != "" && ContractT.Text != "" && AddresT.Text != "" && PortT.Text != "" && MasterT.Text != "" && DateEndT.Text != "" && ComentT.Text != "")
            {
                if (CheckTMC())
                {
                    if (CheckEquip())
                    {
                        setTask();
                        task.StatusTaskID = 2;
                        task.StatusTask = db.StatusTask.Where(x => x.ID == 2).FirstOrDefault();
                        Clear();
                        AddtoClose();
                        db.SaveChanges();
                        DialogResult = true;
                    }
                    else MessageBox.Show("Не всё оборудование есть на складе");
                }
                else MessageBox.Show("Не всё указанное TMC есть на складе");
            }
        }

        private void createClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient ac = new AddClient();
            if (ac.ShowDialog() == true)
            {
                Client c = new Client()
                {
                    Surname = ac.SurnameT.Text,
                    Name = ac.NameT.Text,
                    LastName = ac.LastNameT.Text,
                    Phone = ac.PhoneT.Text
                };
                db.Client.Add(c);
                db.SaveChanges();
                ClientT.ItemsSource = db.Client.ToList();
                ClientT.Text = c.FullName;
            }
        }
        private void selectPort_Click(object sender, RoutedEventArgs e)
        {
            SelectPort sel = new SelectPort(db);
            if(sel.ShowDialog() == true)
            {
                TreeViewItem item = (TreeViewItem)sel.treeView.SelectedItem;
                int id = (int)item.Tag;
                Equipment equip = db.Equipment.Where(x => x.ID == id).FirstOrDefault();
                PortT.Text = $"{equip.Name}|{equip.IP}";
                PortT.Tag = id;
            }
        }

        private void addE_Click(object sender, RoutedEventArgs e)
        {
            SelectWarehouseEquip sel = new SelectWarehouseEquip();
            if(sel.ShowDialog() == true)
            {
                if (Equipments.Where(x => x.EquipmentWarehouse == ((EquipmentWarehouseS)sel.equipS.SelectedItem).EquipmentWarehouse.ID).Count() == 0)
                {
                    TaskEquipment tE = new TaskEquipment()
                    {
                        EquipmentWarehouse = ((EquipmentWarehouseS)sel.equipS.SelectedItem).EquipmentWarehouse.ID,
                        EquipmentWarehouse1 = db.EquipmentWarehouse.Where(x => x.ID == ((EquipmentWarehouseS)sel.equipS.SelectedItem).EquipmentWarehouse.ID).FirstOrDefault(),
                        TaskID = task.ID
                    };
                    Equipments.Add(tE);
                    Elv.ItemsSource = Equipments.ToList();
                }
                else MessageBox.Show("Этот объект уже есть в списке");
            }
        }

        private void addTMC_Click(object sender, RoutedEventArgs e)
        {
            SelectWarehouseTMC sel = new SelectWarehouseTMC();
            if (sel.ShowDialog() == true)
            {
                if (TMCs.Where(x => x.ID == ((TMC)sel.TMCdg.SelectedItem).ID).Count() == 0)
                {
                    AddSize aS = new AddSize();
                    if (aS.ShowDialog() == true)
                    {
                        if (Convert.ToInt32(aS.text.Text) <= ((TMC)sel.TMCdg.SelectedItem).Size)
                        {
                            TaskTMC t = new TaskTMC()
                            {
                                TMC = db.TMC.Where(x => x.ID == ((TMC)sel.TMCdg.SelectedItem).ID).FirstOrDefault(),
                                TMCID = ((TMC)sel.TMCdg.SelectedItem).ID,
                                Size = Convert.ToInt32(aS.text.Text),
                                TaskID = task.ID
                            };
                            TMCs.Add(t);
                            TMClv.ItemsSource = TMCs.ToList();
                        }
                        else MessageBox.Show("На складе нет такого количество материалов");
                    }
                } else MessageBox.Show("Этот объект уже есть в списке");
            }
        }

        private void EButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            Equipments.Remove(Equipments.Where(x => x.ID == id).FirstOrDefault());
            Elv.ItemsSource = Equipments.ToList();
        }
        private void TButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            TMCs.Remove(TMCs.Where(x => x.ID == id).FirstOrDefault());
            TMClv.ItemsSource = TMCs.ToList();
        }

        private void createContract_Click(object sender, RoutedEventArgs e)
        {
            NewContract nC = new NewContract();
            if(nC.ShowDialog() == true)
            {
                ClientContracts clientContracts = new ClientContracts()
                {
                    Client = (Client)ClientT.SelectedItem,
                    ClientID = (int)ClientT.SelectedValue,
                    Contract = nC.text.Text
                };
                db.ClientContracts.Add(clientContracts);
                db.SaveChanges();
                ContractT.ItemsSource = db.ClientContracts.Where(x => x.ClientID == (int)ClientT.SelectedValue).ToList();
                ContractT.Text = clientContracts.Contract;
            }
        }

        private void ClientT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContractT.IsEnabled = true;
            createContract.IsEnabled = true;
            ContractT.ItemsSource = db.ClientContracts.Where(x => x.ClientID == (int)ClientT.SelectedValue).ToList();
        }
    }
}
