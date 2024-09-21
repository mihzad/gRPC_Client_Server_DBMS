using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateDTwindow : Form
    {
        public int DRcolumnsCount;
        public string DRtableName;
        public CreateDTwindow()
        {
            DRcolumnsCount = -1;
            DRtableName = string.Empty;
            InitializeComponent();
        }

        private void DTokButton_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(DTcolumnsCountTextBox.Text, out DRcolumnsCount) || DRcolumnsCount < 1)
            {
                DRcolumnsCount = -1;
            }
            DRtableName = DTnameTextBox.Text;
        }

        private void DTnameTextBox_DoubleClick(object sender, EventArgs e)
        {
            DTnameTextBox.Text = "";
        }

        private void DTcolumnsCountTextBox_DoubleClick(object sender, EventArgs e)
        {
            DTcolumnsCountTextBox.Text = "";
        }
    }
}
