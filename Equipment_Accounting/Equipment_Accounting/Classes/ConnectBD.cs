using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Accounting.Classes
{
    class ConnectBD
    {
        public Resource.Model.DatabaseEntities getDB()
        {
            Resource.Model.DatabaseEntities db = new Resource.Model.DatabaseEntities();
            db.Database.Connection.ConnectionString = File.ReadLines("connect.txt").First();
            return db;
        }
    }
}
