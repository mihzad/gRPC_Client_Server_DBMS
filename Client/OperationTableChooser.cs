using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassHierarchy;

namespace Client
{
    public partial class OperationTableChooser : Form
    {
        internal DataTable? DRtable = new DataTable();
        internal DataTable FirstOperand = new DataTable();
        internal DataTable[] tables;
        internal OperationTableChooser(DataTable firstOperand)
        {
            FirstOperand = firstOperand;
            tables = DBmanager.getAllTables().Except(new[] { FirstOperand }).ToArray();
            InitializeComponent();
        }


        private void OperationTableChooser_Load(object sender, EventArgs e)
        {
            TableChooserList.Items.AddRange(tables.Select(t => $"{t.Name} (Parent: {t.Parent.Name})").ToArray());
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            DRtable = tables[TableChooserList.SelectedIndex];
        }
    }
}
