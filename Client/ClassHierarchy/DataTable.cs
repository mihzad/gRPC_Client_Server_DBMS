using Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Client.ClassHierarchy
{
    internal class DataTable
    {

        private static readonly Random IdIdentifier = new Random();

        public DataTable()
        {
            Name = "default";
            Id = -1;
            columns = new List<DataColumn>();
            rows = new List<DataRow>();
            Parent = new DataBase();
        }

        public DataTable(DataTableSO dt, DataBase p)
        {
            Name = dt.Name;
            Id = dt.Id;
            Parent = p;

            columns = new List<DataColumn>();
            foreach (var c in dt.Columns)
                Columns.Add(new DataColumn(c));

            rows = new List<DataRow>();
            foreach (var r in dt.Rows)
            {
                var data = new List<SupportedType>();
                for(int i = 0; i < r.Data.Count; i++)
                {
                    var val = SupportMethods.createSupportedTypeInstance(
                        Columns[i].SupportedDataType, r.Data[i]);

                    if (val == null || val.isInvalid())
                        throw new Exception($"Error. Values got from server are invalid. Table: {dt.Name}");

                    data.Add(val);
                }
                rows.Add(new DataRow(data));
            }
        }
        internal DataTable(string name, List<DataColumn> c, DataBase p)
        {
            Name = name;
            Id = IdIdentifier.Next();
            columns = c;
            rows = new List<DataRow>();
            Parent = p;
        }

        public bool AddRow(List<SupportedType> data)
        {
            if (data == null || data.Count != Columns.Count) return false;

            for (int i = 0; i < Columns.Count; i++)
            {
                if (data[i].Type != Columns[i].SupportedDataType)
                    return false;
            }
            Rows.Add(new DataRow(data));
            return true;
        }

        public bool EditRow(int index, List<SupportedType> newData)
        {
            if (newData == null || newData.Count != Columns.Count ||
                index >= Rows.Count || index <= 0) return false;

            for (int i = 0; i < Columns.Count; i++)
            {
                if (newData[i].Type != Columns[i].SupportedDataType)
                    return false;
            }
            Rows[index] = new DataRow(newData);
            return true;
        }
        public bool RemoveRow(int index)
        {
            if (index >= Columns.Count || index <= 0) return false;

            Rows.RemoveAt(index);
            return true;
        }

        public bool RemoveRow(DataRow row)
        {
            Rows.Remove(row);
            return true;
        }

        public string Name { get; set; }
        public int Id { get; set; }

        private List<DataColumn> columns;
        public List<DataColumn> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private List<DataRow> rows;
        public List<DataRow> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        internal DataBase Parent { get; set; }
    }
}
