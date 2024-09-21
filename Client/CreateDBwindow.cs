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
    public partial class CreateDBwindow : Form
    {
        public CreateDBwindow()
        {
            InitializeComponent();
        }

        private void CreateDBbutton_Click(object sender, EventArgs e)
        {
            DBmanager.addDB(CreateDBtextBox.Text);
            this.Close();
        }

        private void CreateDBtextBox_DoubleClick(object sender, EventArgs e)
        {
            CreateDBtextBox.Text = "";
        }
    }
}
