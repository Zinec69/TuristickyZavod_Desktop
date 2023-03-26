using turisticky_zavod.Data;
using turisticky_zavod.Forms;

namespace Forms
{
    public partial class AgeCategoriesEditor : Form
    {
        private readonly Database database = Database.Instance;

        public AgeCategoriesEditor()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView1, true);
        }

        private void AgeCategoriesEditor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = database.AgeCategory.Local.ToBindingList();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var name = textBox_name.Text.Trim();
            var code = textBox_code.Text.Trim();

            if (name.Length > 0 && code.Length > 0 && textBox_ageMin.Text.Length > 0)
            {
                database.AgeCategory.Add(new()
                {
                    Name = name,
                    Code = code,
                    AgeMin = int.Parse(textBox_ageMin.Text),
                    AgeMax = (textBox_ageMax.Text.Length > 0 && int.TryParse(textBox_ageMax.Text, out int ageMax)) ? ageMax : null
                });
                database.SaveChanges();
                textBox_name.Clear();
                textBox_code.Clear();
                textBox_ageMin.Clear();
                textBox_ageMax.Clear();
                textBox_color.Clear();
            }
            else
                MessageBox.Show("Nejsou vyplněna všechna povinná pole", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox_ageMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void textBox_ageMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private static bool HandleNumberOnlyField(KeyEventArgs e)
            => !((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || (e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right);

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AgeCategory ageCategory;
            var value = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (e.ColumnIndex == 0)
                ageCategory = database.AgeCategory.First(c => c.Code == dataGridView1[1, e.RowIndex].Value.ToString());
            else
                ageCategory = database.AgeCategory.First(c => c.Name == dataGridView1[0, e.RowIndex].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 0:
                    ageCategory.Name = value;
                    break;
                case 1:
                    ageCategory.Code = value;
                    break;
                case 2:
                    if (int.TryParse(value, out int ageMin))
                        ageCategory.AgeMin = ageMin;
                    else
                    {
                        MessageBox.Show("Chybná hodnota pole, změny nebyly uloženy", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case 3:
                    if (value.Length == 0)
                        ageCategory.AgeMax = null;
                    else if (int.TryParse(value, out int ageMax))
                        ageCategory.AgeMax = ageMax;
                    else
                    {
                        MessageBox.Show("Chybná hodnota pole, změny nebyly uloženy", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case 4:
                    ageCategory.Color = value;
                    break;
                case 5:
                    ageCategory.Duo = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                    break;
            }

            database.AgeCategory.Update(ageCategory);
            database.SaveChanges();
        }
    }
}
