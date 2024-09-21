using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ClassHierarchy;
using static Server.OperationsManagement;
using Server;

namespace Client
{
    internal static class OperationsManager
    {
        internal static DataTable performFullMultiplication(DataTable table1, DataTable table2, OperationsManagementClient omanager)
        {
            var resultTable = omanager.PerformFullMultiplication(new MultiplicationParameters
            {
                First = DBmanager.createSOfromDT(table1),
                Second = DBmanager.createSOfromDT(table2)
            });

            if(resultTable == null)
                return new DataTable();

            return new DataTable(resultTable, new DataBase());
        }
    }
}
