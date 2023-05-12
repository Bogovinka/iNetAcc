﻿using Equipment_Accounting.Resource.Model;
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

        public void insertDB(string name, string ip, string mac, int typeID, int stateID, string adres, string note, string login, string pass, string SNMP, string vlan, string ser, int brandID, int modelID, int id_in_item)
        {
            Equipment equip = new Equipment()
            {
                Name = name,
                IP = ip,
                MAC = mac,
                Type_Device_id = typeID,
                Conditions_id = stateID,
                Address = adres,
                Note = note,
                Login = login,
                Password = pass,
                SNMP = SNMP,
                Num_vlan = vlan,
                Serial_num = ser,
                Model_id = modelID,
                Brand_id = brandID,
                ID_in_item = id_in_item
            };
            databaseEntities.Equipment.Add(equip);
            databaseEntities.SaveChanges();
        }
        public void updateDB(string name, string ip, string mac, int typeID, int stateID, string adres, string note, string login, string pass, string SNMP, string vlan, string ser, int markID, int modelID, Equipment equip, DatabaseEntities db, TreeViewItem t)
        {
            try
            {
                equip.Name = name;
                equip.IP = ip;
                equip.MAC = mac;
                equip.Type_Device_id = typeID;
                equip.Conditions_id = stateID;
                equip.Address = adres;
                equip.Note = note; 
                equip.Login = login;
                equip.Password= pass;
                equip.SNMP = SNMP; 
                equip.Num_vlan = vlan;
                equip.Serial_num = ser;
                equip.Model_id = modelID;
                equip.Brand_id = markID;
                Brand b = db.Brand.Where(x => x.ID == equip.Brand_id).FirstOrDefault();
                equip.Brand = b;
                Conditions c = db.Conditions.Where(x => x.ID == equip.Conditions_id).FirstOrDefault();
                equip.Conditions = c;
                Model m = db.Model.Where(x => x.ID == equip.Model_id).FirstOrDefault();
                equip.Model = m;
                Type_Device type_d = db.Type_Device.Where(x => x.ID == equip.Type_Device_id).FirstOrDefault();
                equip.Type_Device = type_d;
                db.Equipment.AddOrUpdate(equip);
                db.SaveChanges();
                
                t.Header = $"{equip.Name}|{equip.IP}|{equip.MAC}|{equip.Serial_num}|{equip.Model.Name}|{equip.Type_Device.Name}|{equip.Address}";
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
