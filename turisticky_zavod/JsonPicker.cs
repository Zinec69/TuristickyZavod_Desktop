using Data;

namespace Forms
{
    public partial class JsonPicker : Form
    {
        private bool[] Orders = new bool[7] { true, true, true, true, true, true, true };

        private List<Runner> Runners;

        public JsonPicker(List<Runner> runners)
        {
            InitializeComponent();
            Runners = runners;
            Program.SetDoubleBuffer(dataGridView1, true);
            dataGridView1.DataSource = Runners;
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    Runners = (Orders[0] ? Runners.OrderBy(r => r.RunnerID) : Runners.OrderByDescending(r => r.RunnerID)).ToList();
                    Orders[0] = !Orders[0];
                    break;
                case 1:
                    Runners = (Orders[1] ? Runners.OrderBy(r => r.FirstName) : Runners.OrderByDescending(r => r.FirstName)).ToList();
                    Orders[1] = !Orders[1];
                    break;
                case 2:
                    Runners = (Orders[2] ? Runners.OrderBy(r => r.LastName) : Runners.OrderByDescending(r => r.LastName)).ToList();
                    Orders[2] = !Orders[2];
                    break;
                case 3:
                    Runners = (Orders[3] ? Runners.OrderBy(r => r.Team) : Runners.OrderByDescending(r => r.Team)).ToList();
                    Orders[3] = !Orders[3];
                    break;
                case 4:
                    Runners = (Orders[4] ? Runners.OrderBy(r => r.StartTime) : Runners.OrderByDescending(r => r.StartTime)).ToList();
                    Orders[4] = !Orders[4];
                    break;
                case 5:
                    Runners = (Orders[5] ? Runners.OrderBy(r => r.FinishTime) : Runners.OrderByDescending(r => r.FinishTime)).ToList();
                    Orders[5] = !Orders[5];
                    break;
                case 6:
                    Runners = (Orders[6] ? Runners.OrderBy(r => r.Disqualified) : Runners.OrderByDescending(r => r.Disqualified)).ToList();
                    Orders[6] = !Orders[6];
                    break;
            }
            dataGridView1.DataSource = Runners;
        }
    }
}
