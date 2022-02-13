using System.Windows.Forms;

namespace DHCP_Server_KP_Project
{
    public partial class TableRezervingIPForm : Form
    {
        public TableRezervingIPForm()
        {
            InitializeComponent();
        }

        public void ClearTable() { MainTable.Rows.Clear(); }
        public void AddRowTable()
        {
            if(MainTable.Columns.Count>0)
                MainTable.Rows.Add();
        }
        public void AddValueTable(int i, int j, string value)
        {
            MainTable.Rows[i].Cells[j].Value = value;
        }
        public string GetValue(int i, int j)
        {
            if (i >= 0 && i < GetCountRow())
            {
                return MainTable.Rows[i].Cells[j].Value.ToString();
            }
            return "";
        }
        public bool DeleteRow(int i)
        {
            if (i >= 0 && i < GetCountRow())
            {
                MainTable.Rows.Remove(MainTable.Rows[i]);
                return true;
            }
            return false;
        }
        public int GetCountRow() { return MainTable.Rows.Count; }

        private void закрытьToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
        }
    }
}
