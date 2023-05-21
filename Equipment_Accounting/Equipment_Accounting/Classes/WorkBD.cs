using Equipment_Accounting.Resource.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Equipment_Accounting
{
    
    class WorkBD
    {
        Resource.Model.DatabaseEntities databaseEntities = new Resource.Model.DatabaseEntities();     

        public void insertDB(string name, string ip, string mac, object typeID, object stateID, string adres, string note, string login, string pass, string SNMP, string vlan, string ser, object brandID, object modelID, int id_in_item)
        {
            Equipment equip = new Equipment()
            {
                Name = name,
                IP = ip,
                MAC = mac,
                Address = adres,
                Note = note,
                Login = login,
                Password = pass,
                SNMP = SNMP,
                Num_vlan = vlan,
                Serial_num = ser,
                ID_in_item = id_in_item
            };
            if(typeID != null)
                equip.Type_Device_id = (int)typeID;
            if(stateID != null)
                equip.Conditions_id = (int)stateID;
            if(modelID!= null) 
                equip.Model_id = (int)modelID;
            if(brandID != null) 
                equip.Brand_id = (int)brandID;
            databaseEntities.Equipment.Add(equip);
            databaseEntities.SaveChanges();
        }
        public void updateDB(string name, string ip, string mac, object typeID, object stateID, string adres, string note, string login, string pass, string SNMP, string vlan, string ser, object markID, object modelID, Equipment equip, DatabaseEntities db, TreeViewItem t)
        {
            try
            {
                equip.Name = name;
                equip.IP = ip;
                equip.MAC = mac;
                equip.Address = adres;
                equip.Note = note; 
                equip.Login = login;
                equip.Password= pass;
                equip.SNMP = SNMP; 
                equip.Num_vlan = vlan;
                equip.Serial_num = ser;
                if (typeID != null)
                {
                    equip.Type_Device_id = (int)typeID;
                    equip.Type_Device = db.Type_Device.Where(x => x.ID == equip.Type_Device_id).FirstOrDefault();
                }
                else
                {
                    equip.Type_Device_id = null;
                    equip.Type_Device = null;
                }
                if (stateID != null)
                {
                    equip.Conditions_id = (int)stateID;
                    equip.Conditions = db.Conditions.Where(x => x.ID == equip.Conditions_id).FirstOrDefault();
                }
                else
                {
                    equip.Conditions_id = null;
                    equip.Conditions = null;
                }
                if (modelID != null)
                {
                    equip.Model_id = (int)modelID;
                    equip.Model = db.Model.Where(x => x.ID == equip.Model_id).FirstOrDefault();
                }
                else
                {
                    equip.Model_id = null;
                    equip.Model = null;
                }
                if (markID != null)
                {
                    equip.Brand_id = (int)markID;
                    equip.Brand = db.Brand.Where(x => x.ID == equip.Brand_id).FirstOrDefault();
                }
                else
                {
                    equip.Brand_id = null;
                    equip.Brand = null;
                }
                db.Equipment.AddOrUpdate(equip);
                db.SaveChanges();
                t.Header = equip.FullName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       


        public void delete(TreeViewItem t)
        {
            try
            {
                int ID = Convert.ToInt32(t.Tag);
                Equipment equip = databaseEntities.Equipment.Where(x => x.ID == ID).FirstOrDefault();
                databaseEntities.Equipment.Remove(equip);
                databaseEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
