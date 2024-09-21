using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    internal class DataBase : IEquatable<DataBase>
    {
        private static readonly Random IdIdentifier = new Random();
        private static string DefaultName = "default;";
        public DataBase()
        {
            Name = DefaultName;
            Id = -1;
            tables = new List<DataTable>();
        }

        public DataBase (DataBaseSO db)
        {
            Name = db.Name;
            Id = db.Id;
            tables = new List<DataTable>();
            foreach (var t in db.Tables)
                Tables.Add(new DataTable(t, this));
        }
        internal DataBase(string name)
        {
            Name = name;
            Id = IdIdentifier.Next();
            tables = new List<DataTable>();
        }

        public bool Equals(DataBase? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }

        internal void addTable(string name, List<DataColumn> columns)
        {
            Tables.Add(new DataTable(name, columns, this));
            WasChanged = true;
        }

        internal void removeTable(DataTable t)
        {
            Tables.Remove(t);
            WasChanged = true;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public bool WasChanged { get; set; } = true;//it is created = changed

        private List<DataTable> tables;
        public List<DataTable> Tables
        {
            get { return tables; }
            set { tables = value; }
        }

    }
}
