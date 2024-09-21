using System.Windows.Forms;
using Client.ClassHierarchy;

namespace Client
{
    public partial class EnterColumnDataWindow : Form
    {
        int columnNum = -1;
        public string DRcolumnName = string.Empty;
        public string DRChosenType = string.Empty;
        public EnterColumnDataWindow(int i)
        {
            columnNum = i;
            InitializeComponent();
            CDddl.Items.Clear();
            CDddl.Items.Add(Int.TypeValue);
            CDddl.Items.Add(ClassHierarchy.Char.TypeValue);
            CDddl.Items.Add(ClassHierarchy.String.TypeValue);
            CDddl.Items.Add(Real.TypeValue);
            CDddl.Items.Add(CharInvl.TypeValue);
            CDddl.Items.Add(StringInvl.TypeValue);
        }

        private void EnterColumnDataWindow_Load(object sender, EventArgs e)
        {
            this.Text = $"Колонка #{columnNum + 1}: введення даних";
        }

        private void CDokButton_Click(object sender, EventArgs e)
        {
            DRChosenType = CDddl.GetItemText(CDddl.SelectedItem);
            DRcolumnName = CDtextBox.Text;
        }

        private void CDtextBox_DoubleClick(object sender, EventArgs e)
        {
            CDtextBox.Text = "";
        }
    }
}
