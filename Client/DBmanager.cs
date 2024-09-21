using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Client.ClassHierarchy;
using static Server.DBmanagement;
using Server;
using System.Data;

namespace Client
{
    internal static class DBmanager
    {
        private static int clientID = -1;
        internal static void loadDataBases(DBmanagementClient client)
        {
            try {
                clientID = Int32.Parse(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "clientId.json")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                var model = client.GetID(new ClientIdRequest());

                DirectoryInfo d = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));
                if (!d.Exists) d.Create();

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "clientId.json"),
                                    model.ClientId.ToString() );
                clientID = model.ClientId;
            }


            var requestedData = client.GetData(new ClientDataLookupModel { ClientId = clientID });

            foreach(var dbToAdd in requestedData.Bases)
            {
                var db = new DataBase(dbToAdd);
                db.WasChanged = false;
                Bases.Add(db);
            }

        }

        internal static void saveDataBases(DBmanagementClient client)
        {
            var model = new ClientDataModel() { ClientId = clientID };
            foreach(var db in Bases)
            {
                if(db.WasChanged)
                {
                    model.Bases.Add(createSOfromDB(db));
                }
            }

            if (model.Bases.Count == 0) return;

            var responce = client.SaveData(model);

            if(responce.Success == false)
                MessageBox.Show(responce.Message);
            
        }

        internal static DataBaseSO createSOfromDB(DataBase db)
        {
            var so = new DataBaseSO()
            {
                Id = db.Id,
                Name = db.Name
            };
            foreach (var t in db.Tables)
                so.Tables.Add(createSOfromDT(t));
            return so;
        }

        internal static DataTableSO createSOfromDT(ClassHierarchy.DataTable dt)
        {
            var so = new DataTableSO()
            {
                Id = dt.Id,
                Name = dt.Name
            };
            foreach (var c in dt.Columns)
                so.Columns.Add(createSOfromColumn(c));
            foreach (var r in dt.Rows)
                so.Rows.Add(createSOfromRow(r));
            return so;

        }

        internal static DataColumnSO createSOfromColumn(ClassHierarchy.DataColumn c)
        {
            var so = new DataColumnSO()
            {
                Name = c.Name,
                SupportedType = c.SupportedDataType
            };
            return so;
        }

        internal static DataRowSO createSOfromRow(ClassHierarchy.DataRow r)
        {
            var so = new DataRowSO();

            foreach (var cell in r.Data)
                so.Data.Add(cell.stringOutput());
            return so;
        }

        internal static List<ClassHierarchy.DataTable> getAllTables()
        {
            List<ClassHierarchy.DataTable> tables = new List<ClassHierarchy.DataTable>();
            foreach(var db in Bases)
                foreach(var dt in db.Tables)
                    tables.Add(dt);
            return tables;
        }

        internal static void addDB(string name)
        {
            Bases.Add(new DataBase(name));
        }
        internal static void addDB(DataBase db)
        {
            Bases.Add(db);
        }

        internal static void removeDB(DataBase db)
        {
            Bases.Remove(db);
        }

        internal static List<DataBase> Bases = new List<DataBase>();
    }
}
