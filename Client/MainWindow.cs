using System.Text.Json;
using Client.ClassHierarchy;
using Grpc.Core;
using Grpc.Net.Client;
using static Server.DBmanagement;
using static Server.OperationsManagement;

namespace Client
{
    public partial class MainWindow : Form
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:7018/", new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        private static DBmanagementClient dbManager = new DBmanagementClient(channel);
        private static OperationsManagementClient omanager = new OperationsManagementClient(channel);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            

            Cursor.Current = Cursors.WaitCursor;

            TableDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            DBmanager.loadDataBases(dbManager);
            PopulateTreeView();

            Cursor.Current = Cursors.Default;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBmanager.saveDataBases(dbManager);
        }
        private void PopulateTreeView()
        {
            DBtreeView.BeginUpdate();

            DBtreeView.Nodes.Clear();
            foreach (var db in DBmanager.Bases)
            {
                var dbtn = new TreeNode(db.Name, 0, 0);
                dbtn.Tag = db;

                foreach (var dt in db.Tables)
                {
                    var dttn = new TreeNode(dt.Name, 1, 1);
                    dttn.Tag = dt;

                    dbtn.Nodes.Add(dttn);
                }

                DBtreeView.Nodes.Add(dbtn);
            }

            DBtreeView.EndUpdate();

        }

        private void setDataGridView(DataTable t)
        {
            TableDataGridView.Columns.Clear();
            TableDataGridView.Rows.Clear();

            TableDataGridView.Tag = t;
            for (int i = 0; i < t.Columns.Count; i++)
            {
                TableDataGridView.Columns.Add(t.Columns[i].Name, $"{t.Columns[i].Name} ({t.Columns[i].SupportedDataType})");
            }
            foreach (var r in t.Rows)
            {
                string[] data = r.Data.Select(d => d.stringOutput()).ToArray();
                TableDataGridView.Rows.Add(data);
            }
        }
        private void CreateStripItem_Click(object sender, EventArgs e)
        {
            using (var cdbw = new CreateDBwindow())
            {
                if (cdbw.ShowDialog() == DialogResult.OK)
                {
                    PopulateTreeView();
                }
            }
        }

        private void DownloadStripItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "json files (*.json)|*.json";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    if (filePath == "") return;
                    try
                    {
                        var jsonSerializerOptions = new JsonSerializerOptions();
                        jsonSerializerOptions.Converters.Add(new SupportedTypeConverter());
                        DataBase? db = JsonSerializer.Deserialize<DataBase>(File.ReadAllText(filePath), jsonSerializerOptions);
                        if (db == null || db.Id == -1)
                        {
                            MessageBox.Show("цей json не є БД");
                            return;
                        }

                        if (!DBmanager.Bases.Contains(db))
                        {
                            DBmanager.addDB(db!);
                            for (int i = 0; i < db.Tables.Count; i++)
                            {
                                db.Tables[i].Parent = db;
                            }
                            File.Copy(filePath, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", db!.Name + ".json"));
                        }
                        else
                            MessageBox.Show("ця БД уже додана.");
                    }
                    catch (JsonException)
                    {
                        MessageBox.Show("цей json не є БД");
                        return;
                    }
                }
            }
            PopulateTreeView();
        }

        private void DBtreeView_MouseUp(object sender, MouseEventArgs e)
        {
            DBtreeView.SelectedNode = DBtreeView.GetNodeAt(e.Location);
            if (DBtreeView.SelectedNode == null)
            {
                FullMultiplyButton.Enabled = false;
                contextMenuStrip.Enabled = false;
            }
            else if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataBase))
            {
                FullMultiplyButton.Enabled = false;
                contextMenuStrip.Enabled = true;
            }

            else if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataTable))
            {
                FullMultiplyButton.Enabled = true;
                contextMenuStrip.Enabled = true;

                setDataGridView((DataTable)DBtreeView.SelectedNode.Tag);
            }

        }

        private void DeleteStripMenuItem_Click(object sender, EventArgs e)
        {


            if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataBase))
            {
                var dr = MessageBox.Show("Ви впевнені що хочете видалити цю БД?", "Видалення БД", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var db = (DataBase)DBtreeView.SelectedNode.Tag;
                    DBmanager.removeDB(db);
                    File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", db.Name + ".json"));
                }
            }
            else if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataTable))
            {
                var dr = MessageBox.Show("Ви впевнені що хочете видалити цю таблицю?", "Видалення таблиці", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var dt = (DataTable)(DBtreeView.SelectedNode.Tag);
                    //var db = (DataBase)(DBtreeView.SelectedNode.Parent.Tag);
                    dt.Parent.removeTable(dt);
                }

            }
            PopulateTreeView();
            TableDataGridView.Rows.Clear();
            TableDataGridView.Columns.Clear();
        }

        private void DBtreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && contextMenuStrip.Enabled)
            {
                if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataBase))
                {
                    AddTableStripMenuItem.Enabled = true;
                }

                else if (DBtreeView.SelectedNode.Tag.GetType() == typeof(DataTable))
                {
                    AddTableStripMenuItem.Enabled = false;
                }
                contextMenuStrip.Show(DBtreeView, e.Location);
            }
        }

        private void AddTableStripMenuItem_Click(object sender, EventArgs e)
        {
            var cdtw = new CreateDTwindow();
            var res = cdtw.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                if (cdtw.DRcolumnsCount == -1 || cdtw.DRtableName == string.Empty)
                {
                    MessageBox.Show("Створення відмінено: введено невірні дані.", "Помилка");
                    return;
                }
                var columns = new List<DataColumn>();

                for (int i = 0; i < cdtw.DRcolumnsCount; i++)
                {
                    var ecdw = new EnterColumnDataWindow(i);
                    var dr = ecdw.ShowDialog(this);

                    if (dr != DialogResult.OK) return;
                    if (ecdw.DRcolumnName == string.Empty || ecdw.DRChosenType == string.Empty)
                    {
                        MessageBox.Show("Створення відмінено: введено невірні дані.", "Помилка");
                        return;
                    }

                    var c = new DataColumn(ecdw.DRcolumnName, ecdw.DRChosenType);
                    columns.Add(c);
                }
                var db = (DataBase)DBtreeView.SelectedNode.Tag;
                db.addTable(cdtw.DRtableName, columns);
                PopulateTreeView();

            }
        }

        private void TableDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string input = (string)e.FormattedValue;
            if (input == null || input == string.Empty)//user doesn`t want to edit, did this unintentionally
            {
                TableDataGridView.CancelEdit();
                return;
            }
            var t = (DataTable)TableDataGridView.Tag;
            SupportedType? v = SupportMethods.createSupportedTypeInstance(t.Columns[e.ColumnIndex].SupportedDataType, input);

            if (v == null || v.isInvalid())
            {
                e.Cancel = true;
                MessageBox.Show("Введено некоректне значення. Тип колонки: " +
                    t.Columns[e.ColumnIndex].SupportedDataType);
            }
        }

        private void TableDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (TableDataGridView.Rows[e.RowIndex].IsNewRow) { return; }
            //save non-empty valid row
            var t = (DataTable)TableDataGridView.Tag;

            var cells = TableDataGridView.Rows[e.RowIndex].Cells;
            var data = new List<SupportedType>();
            for (int i = 0; i < cells.Count; i++)
            {
                var value = (string)cells[i].Value;
                if (value == null)
                {
                    MessageBox.Show($"error0 while saving row #{e.RowIndex}.");
                    return;
                }
                SupportedType? v = SupportMethods.createSupportedTypeInstance(t.Columns[i].SupportedDataType, value);

                if (v == null || v.isInvalid())
                {
                    MessageBox.Show($"error1 while saving row #{e.RowIndex}.");
                    return;
                }
                data.Add(v);
            }
            if (e.RowIndex < t.Rows.Count) // row is not new to save
            {
                t.EditRow(e.RowIndex, data);
            }
            else //e.RowIndex == t.Rows.Count (can`t be >, we save each row) => new row needs to be saved
            {
                t.AddRow(data);
            }
            MarkCurrentDBChanged();
        }

        private void TableDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TableDataGridView.EndEdit();
        }

        private void TableDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (TableDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                TableDataGridView.CancelEdit();
                return;
            }
            var cells = TableDataGridView.Rows[e.RowIndex].Cells;

            for (int i = 0; i < cells.Count; i++)
            {
                var value = (string?)cells[i].Value;
                if (value == null || value == string.Empty)
                {
                    e.Cancel = true;
                    MessageBox.Show("Залишання пустих комірок у рядку неприпустиме.");
                    return;
                }
                SupportedType? v = SupportMethods.createSupportedTypeInstance(
                    ((DataTable)TableDataGridView.Tag).Columns[i].SupportedDataType, value);
                if (v == null || v.isInvalid())
                {
                    e.Cancel = true;
                    MessageBox.Show("Не всі значення у рядку коректні.");
                    return;
                }
            }
        }

        private void TableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TableDataGridView.BeginEdit(true);
        }



        private void TableDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var t = (DataTable)TableDataGridView.Tag;
            t.RemoveRow(e.RowIndex);//multiselect turned off, only one row per time can be deleted.
            MarkCurrentDBChanged();
        }

        private void MarkCurrentDBChanged()
        {
            var t = (DataTable)TableDataGridView.Tag;
            if (t.Parent.Id == -1) return; // -1 means that database is fictive and this table
                                           // is result of operations on other tables
            t.Parent.WasChanged = true;
        }

        private void FullMultiplyButton_Click(object sender, EventArgs e)
        {
            var dt1 = (DataTable)DBtreeView.SelectedNode.Tag;

            var otc = new OperationTableChooser(dt1);
            var dr = otc.ShowDialog();

            if(dr == DialogResult.OK)
            {
                if (otc.DRtable == null) {
                    MessageBox.Show("Operation has been canceled.");
                    return;
                }
                var res = OperationsManager.performFullMultiplication(dt1, otc.DRtable, omanager);
                setDataGridView(res);
            }

        }
    }
}