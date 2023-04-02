using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
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
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var name = textBox_name.Text.Trim();
                var code = textBox_code.Text.Trim();
                var ageMin = textBox_ageMin.Text;
                var ageMax = textBox_ageMax.Text;
                var duo = checkBox_duo.Checked;

                var category = database.AgeCategory.Local.FirstOrDefault(x => x.Name == name || x.Code == code, null);

                if (category != null)
                {
                    category.Name = name;
                    category.Code = code;
                    category.AgeMin = int.Parse(ageMin);
                    category.AgeMax = !string.IsNullOrEmpty(ageMax) ? int.Parse(ageMax) : null;
                    category.Duo = duo;
                    database.AgeCategory.Update(category);
                }
                else
                {
                    database.AgeCategory.Add(new()
                    {
                        Name = name,
                        Code = code,
                        AgeMin = int.Parse(ageMin),
                        AgeMax = !string.IsNullOrEmpty(ageMax) ? int.Parse(ageMax) : null,
                        Duo = duo
                    });
                }
                database.SaveChanges();
                textBox_name.Clear();
                textBox_code.Clear();
                textBox_ageMin.Clear();
                textBox_ageMax.Clear();
                textBox_color.Clear();
                button_add.Text = "Přidat";
            }
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void textBox_name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var name = textBox_name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "Název kategorie je povinná položka");
            }
            else
                errorProvider.SetError(sender as TextBox, "");
        }

        private void textBox_code_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var code = textBox_code.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "Zkratka kategorie je povinná položka");
            }
            else
                errorProvider.SetError(sender as TextBox, "");
        }

        private void textBox_ageMin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ageMin = textBox_ageMin.Text;

            if (string.IsNullOrEmpty(ageMin))
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "Minimální věk je povinná položka");
            }
            else
                errorProvider.SetError(sender as TextBox, "");
        }

        private void textBox_ageMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ageMin = textBox_ageMin.Text;
            var ageMax = textBox_ageMax.Text;

            if (!string.IsNullOrEmpty(ageMax) && !string.IsNullOrEmpty(ageMin) && int.Parse(ageMin) > int.Parse(ageMax))
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "Maximální věk musí být větší než minimální");
            }
            else
                errorProvider.SetError(sender as TextBox, "");
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete smazat zvolenou kategorii?", "Smazat kategorii", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            database.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var category = (AgeCategory)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            textBox_name.Text = category.Name;
            textBox_code.Text = category.Code;
            textBox_ageMin.Text = category.AgeMin.ToString();
            textBox_ageMax.Text = category.AgeMax.HasValue ? category.AgeMax.Value.ToString() : string.Empty;
            button_add.Text = "Uložit";
        }
    }
}
