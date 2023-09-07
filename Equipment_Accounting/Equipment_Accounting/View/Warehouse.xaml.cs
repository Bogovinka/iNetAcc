using Equipment_Accounting.Resource.Model;
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
    /// Логика взаимодействия для Warehouse.xaml
    /// </summary>
    public partial class Warehouse : Window
    {
        Resource.Model.DatabaseEntities db;
        Logins log;
        public void relDT(string selectText)
        {
            if (equipTabC.IsSelected)
            {
                equipC.ItemsSource = db.EquipmentWarehouseClient.Where(x => x.EquipmentWarehouse.SerialNum.Contains(selectText) || x.EquipmentWarehouse.Name.Contains(selectText)).ToList();
            }
            else if (equipTabM.IsSelected)
            {
                equipM.ItemsSource = db.EquipmentWarehouseMaster.Where(x => x.EquipmentWarehouse.SerialNum.Contains(selectText) || x.EquipmentWarehouse.Name.Contains(selectText)).ToList();
            }
            else if (equipTabS.IsSelected)
            {
                equipS.ItemsSource = db.EquipmentWarehouseS.Where(x => x.EquipmentWarehouse.SerialNum.Contains(selectText) || x.EquipmentWarehouse.Name.Contains(selectText)).ToList();
            }

        }
        public Warehouse(Logins log_, DatabaseEntities db_)
        {
            InitializeComponent();
            log = log_;
            db = db_;
            equipC.ItemsSource = db.EquipmentWarehouseClient.ToList();
            equipM.ItemsSource = db.EquipmentWarehouseMaster.ToList();
            equipS.ItemsSource = db.EquipmentWarehouseS.ToList();
            TMCdg.ItemsSource = db.TMC.ToList();
            sizeE.Content = "Всего: " + db.EquipmentWarehouseS.Count();
        }

        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            AddEWarehouse addE = new AddEWarehouse();
            if(addE.ShowDialog() == true)
            {
                try
                {
                    EquipmentWarehouse equipment = new EquipmentWarehouse()
                    {
                        Name = addE.nameT.Text,
                        EquipmentWarehouseTypeID = (int)addE.TypeT.SelectedValue,
                        StatusID = (int)addE.StatusT.SelectedValue,
                        ConditionsID = (int)addE.CondT.SelectedValue,
                        Model = addE.ModelT.Text,
                        SerialNum = addE.SerT.Text,
                        EquipmentWarehouseStatus = db.EquipmentWarehouseStatus.Where(x => x.ID == (int)addE.StatusT.SelectedValue).FirstOrDefault(),
                        Conditions = db.Conditions.Where(x => x.ID == (int)addE.CondT.SelectedValue).FirstOrDefault(),
                        EquipmentWarehouseType = db.EquipmentWarehouseType.Where(x => x.ID == (int)addE.TypeT.SelectedValue).FirstOrDefault()
                    };
                    db.EquipmentWarehouse.Add(equipment);
                    switch (addE.AffiliationT.SelectedIndex)
                    {
                        case 1:
                            EquipmentWarehouseMaster equipmentWarehouseMaster = new EquipmentWarehouseMaster()
                            {
                                EquipmentWarehouseID = equipment.ID,
                                EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equipment.ID).FirstOrDefault(),
                                MasterID = (int)addE.AffiliationPersonT.SelectedValue,
                                Logins = db.Logins.Where(x => x.ID == (int)addE.AffiliationPersonT.SelectedValue).FirstOrDefault()
                            };
                            db.EquipmentWarehouseMaster.Add(equipmentWarehouseMaster);
                            db.SaveChanges();
                            equipM.ItemsSource = db.EquipmentWarehouseMaster.ToList();
                            break;
                        case 2:
                            EquipmentWarehouseClient equipmentWarehouseClient = new EquipmentWarehouseClient()
                            {
                                EquipmentWarehouseID = equipment.ID,
                                EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equipment.ID).FirstOrDefault(),
                                ClientID = (int)addE.AffiliationPersonT.SelectedValue,
                                Client = db.Client.Where(x => x.ID == (int)addE.AffiliationPersonT.SelectedValue).FirstOrDefault()
                            };
                            db.EquipmentWarehouseClient.Add(equipmentWarehouseClient);
                            db.SaveChanges();
                            equipC.ItemsSource = db.EquipmentWarehouseClient.ToList();
                            break;
                        default:
                            EquipmentWarehouseS equipmentWarehouseS = new EquipmentWarehouseS()
                            {
                                EquipmentWarehouseID = equipment.ID,
                                EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equipment.ID).FirstOrDefault(),
                                WarehouseID = 1,
                                Size = Convert.ToInt32(addE.SizeT.Text)
                            };
                            db.EquipmentWarehouseS.Add(equipmentWarehouseS);
                            db.SaveChanges();
                            equipS.ItemsSource = db.EquipmentWarehouseS.ToList();
                            break;
                    }
                    sizeE.Content = "Всего: " + db.EquipmentWarehouseS.Count();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddTMC_Click(object sender, RoutedEventArgs e)
        {
            AddTMC aT = new AddTMC();
            if(aT.ShowDialog() == true)
            {
                try
                {
                    TMC tmc = new TMC()
                    {
                        Name = aT.NameT.Text,
                        Size = Convert.ToInt32(aT.SizeT.Text),
                        UnitID = (int)aT.UnitT.SelectedValue,
                        Unit = db.Unit.Where(x => x.ID == (int)aT.UnitT.SelectedValue).FirstOrDefault(),
                        WarehouseID = 1
                    };
                    db.TMC.Add(tmc);
                    db.SaveChanges();
                    TMCdg.ItemsSource = db.TMC.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool EditE(AddEWarehouse addE, EquipmentWarehouse equip)
        {
            bool res = false;
            if(addE.ShowDialog() == true)
            {
                res = true;
                equip.Name = addE.nameT.Text;
                equip.EquipmentWarehouseTypeID = (int)addE.TypeT.SelectedValue;
                equip.StatusID = (int)addE.StatusT.SelectedValue;
                equip.ConditionsID = (int)addE.CondT.SelectedValue;
                equip.Model = addE.ModelT.Text;
                equip.SerialNum = addE.SerT.Text;
                equip.EquipmentWarehouseStatus = db.EquipmentWarehouseStatus.Where(x => x.ID == (int)addE.StatusT.SelectedValue).FirstOrDefault();
                equip.Conditions = db.Conditions.Where(x => x.ID == (int)addE.CondT.SelectedValue).FirstOrDefault();
                equip.EquipmentWarehouseType = db.EquipmentWarehouseType.Where(x => x.ID == (int)addE.TypeT.SelectedValue).FirstOrDefault();
                int addInd;
                if (Convert.ToInt32(addE.SizeT.Text) > 1) addInd = 0;
                else addInd = addE.AffiliationT.SelectedIndex;
                switch (addE.AffiliationT.SelectedIndex)
                {
                    case 1:
                        EquipmentWarehouseMaster equipmentWarehouseMaster = new EquipmentWarehouseMaster()
                        {
                            EquipmentWarehouseID = equip.ID,
                            EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equip.ID).FirstOrDefault(),
                            MasterID = (int)addE.AffiliationPersonT.SelectedValue,
                            Logins = db.Logins.Where(x => x.ID == (int)addE.AffiliationPersonT.SelectedValue).FirstOrDefault()
                        };
                        db.EquipmentWarehouseMaster.Add(equipmentWarehouseMaster);
                        db.SaveChanges();
                        equipM.ItemsSource = db.EquipmentWarehouseMaster.ToList();
                        break;
                    case 2:
                        EquipmentWarehouseClient equipmentWarehouseClient = new EquipmentWarehouseClient()
                        {
                            EquipmentWarehouseID = equip.ID,
                            EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equip.ID).FirstOrDefault(),
                            ClientID = (int)addE.AffiliationPersonT.SelectedValue,
                            Client = db.Client.Where(x => x.ID == (int)addE.AffiliationPersonT.SelectedValue).FirstOrDefault()
                        };
                        db.EquipmentWarehouseClient.Add(equipmentWarehouseClient);
                        db.SaveChanges();
                        equipC.ItemsSource = db.EquipmentWarehouseClient.ToList();
                        break;
                    default:
                        EquipmentWarehouseS equipmentWarehouseS = new EquipmentWarehouseS()
                        {
                            EquipmentWarehouseID = equip.ID,
                            EquipmentWarehouse = db.EquipmentWarehouse.Where(x => x.ID == equip.ID).FirstOrDefault(),
                            WarehouseID = 1,
                            Size = Convert.ToInt32(addE.SizeT.Text)
                        };
                        db.EquipmentWarehouseS.Add(equipmentWarehouseS);
                        db.SaveChanges();
                        equipS.ItemsSource = db.EquipmentWarehouseS.ToList();
                        break;
                }
            }
            return res;
        }
        private void EditEquipment_Click(object sender, RoutedEventArgs e)
        {
            AddEWarehouse addE;
            object item;
            if (equipTabC.IsSelected)
            {
                if (equipC.SelectedItem != null)
                {
                    item = equipC.SelectedItem;
                    EquipmentWarehouse equip = ((EquipmentWarehouseClient)item).EquipmentWarehouse;
                    addE = new AddEWarehouse((EquipmentWarehouseClient)item);
                    if (EditE(addE, equip))
                    {
                        db.EquipmentWarehouseClient.Remove((EquipmentWarehouseClient)item);
                        db.SaveChanges();
                        equipC.ItemsSource = db.EquipmentWarehouseClient.ToList();
                    }
                }
            }
            else if(equipTabM.IsSelected)
            {
                if (equipM.SelectedItem != null)
                {
                    item = equipM.SelectedItem;
                    EquipmentWarehouse equip = ((EquipmentWarehouseMaster)item).EquipmentWarehouse;
                    addE = new AddEWarehouse((EquipmentWarehouseMaster)item);
                    if (EditE(addE, equip))
                    {
                        db.EquipmentWarehouseMaster.Remove((EquipmentWarehouseMaster)item);
                        db.SaveChanges();
                        equipM.ItemsSource = db.EquipmentWarehouseMaster.ToList();
                    }
                }
            }
            else if (equipTabS.IsSelected)
            {
                if (equipS.SelectedItem != null)
                {
                    item = equipS.SelectedItem;
                    EquipmentWarehouse equip = ((EquipmentWarehouseS)item).EquipmentWarehouse;
                    addE = new AddEWarehouse((EquipmentWarehouseS)item);
                    if (EditE(addE, equip))
                    {
                        db.EquipmentWarehouseS.Remove((EquipmentWarehouseS)item);
                        db.SaveChanges();
                        equipS.ItemsSource = db.EquipmentWarehouseS.ToList();
                    }
                }
            }
            sizeE.Content = "Всего: " + db.EquipmentWarehouseS.Count();
        }

        /*private void DelEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (equipTabC.IsSelected)
            {
                if (equipC.SelectedItem != null)
                {
                    EquipmentWarehouseClient equip = (EquipmentWarehouseClient)equipC.SelectedItem;
                    EquipmentWarehouse equipment = db.EquipmentWarehouse.Where(x => x.ID == equip.EquipmentWarehouseID).FirstOrDefault();
                    db.EquipmentWarehouseClient.Remove(equip);
                    if (db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipment.Remove(db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    if (db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipmentC.Remove(db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    db.EquipmentWarehouse.Remove(equipment);
                    db.SaveChanges();
                    equipC.ItemsSource = db.EquipmentWarehouseClient.ToList();
                }
            }
            else if (equipTabM.IsSelected)
            {
                if (equipM.SelectedItem != null)
                {
                    EquipmentWarehouseMaster equip = (EquipmentWarehouseMaster)equipM.SelectedItem;
                    db.EquipmentWarehouseMaster.Remove(equip);
                    EquipmentWarehouse equipment = db.EquipmentWarehouse.Where(x => x.ID == equip.EquipmentWarehouseID).FirstOrDefault();
                    if(db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipment.Remove(db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    if (db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipmentC.Remove(db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    db.EquipmentWarehouse.Remove(equipment);
                    db.SaveChanges();
                    equipM.ItemsSource = db.EquipmentWarehouseMaster.ToList();
                }
            }
            else if (equipTabS.IsSelected)
            {
                if (equipS.SelectedItem != null)
                {
                    EquipmentWarehouseS equip = (EquipmentWarehouseS)equipS.SelectedItem;
                    db.EquipmentWarehouseS.Remove(equip);
                    EquipmentWarehouse equipment = db.EquipmentWarehouse.Where(x => x.ID == equip.EquipmentWarehouseID).FirstOrDefault();
                    if (db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipment.Remove(db.TaskEquipment.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    if (db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).Count() > 0)
                        db.TaskEquipmentC.Remove(db.TaskEquipmentC.Where(x => x.EquipmentWarehouse == equipment.ID).FirstOrDefault());
                    db.EquipmentWarehouse.Remove(equipment);
                    db.SaveChanges();
                    equipS.ItemsSource = db.EquipmentWarehouseS.ToList();
                }
            }
        }*/

        private void EditTMC_Click(object sender, RoutedEventArgs e)
        {
            if(TMCdg.SelectedItem != null)
            {
                TMC tmc = (TMC)TMCdg.SelectedItem;
                AddTMC aT = new AddTMC(tmc);
                if (aT.ShowDialog() == true)
                {
                    tmc.Name = aT.NameT.Text;
                    tmc.Size = Convert.ToInt32(aT.SizeT.Text);
                    tmc.UnitID = (int)aT.UnitT.SelectedValue;
                    tmc.Unit = db.Unit.Where(x => x.ID == (int)aT.UnitT.SelectedValue).FirstOrDefault();
                    db.SaveChanges();
                    TMCdg.ItemsSource = db.TMC.ToList();
                }
            }
        }

        private void DelTMC_Click(object sender, RoutedEventArgs e)
        {
            if (TMCdg.SelectedItem != null)
            {
                TMC tmc = (TMC)TMCdg.SelectedItem;
                if (db.TaskTMC.Where(x => x.TMCID == tmc.ID).Count() > 0)
                    db.TaskTMC.Remove(db.TaskTMC.Where(x => x.TMCID == tmc.ID).FirstOrDefault());
                db.TMC.Remove(tmc);
                db.SaveChanges();
                TMCdg.ItemsSource = db.TMC.ToList();
                
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            relDT(searchText.Text);
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                relDT(searchText.Text);
            }
        }
    }
}
