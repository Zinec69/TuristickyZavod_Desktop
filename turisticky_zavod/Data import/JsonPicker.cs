using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
{
    public partial class JsonPicker : Form
    {
        private readonly List<Runner> Runners;

        public JsonPicker(List<Runner> runners)
        {
            InitializeComponent();
            Runners = runners;
            Program.SetDoubleBuffer(dataGridView1, true);
            dataGridView1.DataSource = new SortableBindingList<Runner>(Runners);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int count = Runners.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                bool found = false;
                for (int j = 0; j < dataGridView1.SelectedRows.Count; j++)
                {
                    if (i == dataGridView1.SelectedRows[j].Index)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    Runners.RemoveAt(i);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
    }
}
