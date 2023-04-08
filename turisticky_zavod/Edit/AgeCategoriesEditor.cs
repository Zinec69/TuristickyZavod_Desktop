using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
{
    public partial class AgeCategoriesEditor : Form
    {
        private readonly Database database = Database.Instance;

        public AgeCategoriesEditor()
        {
            InitializeComponent();
            Program.SetDoubleBuffer(dataGridView_categories, true);
            Program.SetDoubleBuffer(dataGridView_checkpoints, true);
        }

        private void AgeCategoriesEditor_Load(object sender, EventArgs e)
        {
            dataGridView_categories.DataSource = database.AgeCategory.Local.ToBindingList();
            ClearInputs();
        }


        #region Button events

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var name = textBox_name.Text.Trim();
                var code = textBox_code.Text.Trim();
                var color = textBox_color.Text.Trim();
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
                    category.Color = color;
                    database.AgeCategory.Update(category);
                    if (database.SaveChanges() > 0)
                        Log($"Kategorie \"{category.Name}\" úspěšně změněna");
                    else
                        Log("Nastala chyba při ukládání změn");
                }
                else
                {
                    category = new()
                    {
                        Name = name,
                        Code = code,
                        AgeMin = int.Parse(ageMin),
                        AgeMax = !string.IsNullOrEmpty(ageMax) ? int.Parse(ageMax) : null,
                        Duo = duo,
                        Color = color
                    };
                    database.AgeCategory.Add(category);
                    database.SaveChanges();

                    var id = database.AgeCategory.OrderByDescending(x => x.ID).First().ID;
                    for (int i = 1; i <= 13; i++)
                    {
                        database.CheckpointAgeCategoryParticipation.Add(new() { AgeCategoryID = id, CheckpointID = i, IsParticipating = true });
                    }
                    if (database.SaveChanges() > 0)
                        Log($"Kategorie \"{category.Name}\" úspěšně přidána");
                    else
                        Log("Nastala chyba při ukládání změn");
                }
                var row = dataGridView_categories.Rows[^1];
                var rowCategory = (AgeCategory)row.DataBoundItem;
                row.Cells[0].Selected = true;
                dataGridView_checkpoints.DataSource = database.CheckpointAgeCategoryParticipation
                                                              .Local
                                                              .Where(x => x.AgeCategoryID == rowCategory.ID && x.CheckpointID != 1)
                                                              .ToList();
                ClearInputs();
            }
        }

        #endregion


        #region TextBox events

        private void TextBox_AgeMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_AgeMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_Name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void TextBox_Code_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void TextBox_AgeMin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void TextBox_AgeMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void TextBox_Color_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var color = textBox_color.Text.Trim();

            if (string.IsNullOrEmpty(color))
            {
                e.Cancel = true;
                errorProvider.SetError(sender as TextBox, "Barva je povinná položka");
            }
            else
                errorProvider.SetError(sender as TextBox, "");
        }

        private void TextBox_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save.PerformClick();
        }

        private void TextBox_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save.PerformClick();
        }

        private void TextBox_AgeMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save.PerformClick();
        }

        private void TextBox_AgeMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save.PerformClick();
        }

        private void TextBox_Color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save.PerformClick();
        }

        #endregion


        #region DataGridView_AgeCategories events

        private void DataGridView_AgeCategories_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_categories.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void DataGridView_AgeCategories_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Opravdu chcete smazat zvolenou kategorii?",
                "Smazat kategorii", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.No)
                e.Cancel = true;
        }

        private void DataGridView_AgeCategories_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var category = database.ChangeTracker.Entries<AgeCategory>().First(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Deleted).Entity;
            if (database.SaveChanges() > 0)
            {
                Log($"Kategorie \"{category.Name}\" úspěšně smazána");
                ClearInputs();
            }
            else
                Log("Nastala chyba při ukládání změn");
        }

        private void DataGridView_Categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var category = (AgeCategory)dataGridView_categories.CurrentRow.DataBoundItem;
                textBox_name.Text = category.Name;
                textBox_code.Text = category.Code;
                textBox_ageMin.Text = category.AgeMin.ToString();
                textBox_ageMax.Text = category.AgeMax.HasValue ? category.AgeMax.Value.ToString() : string.Empty;
                textBox_color.Text = category.Color;
                checkBox_duo.Checked = category.Duo;
                button_save.Text = "Uložit";

                dataGridView_checkpoints.DataSource = database.CheckpointAgeCategoryParticipation
                                                              .Local
                                                              .Where(x => x.AgeCategoryID == category.ID && x.CheckpointID != 1)
                                                              .ToList();

                ClearAllErrors();
            }
        }

        private void DataGridView_AgeCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView_categories.ClearSelection();
                dataGridView_categories.CurrentCell = null;
                ClearInputs();
                dataGridView_checkpoints.DataSource = null;
            }
        }

        #endregion


        #region DataGridView_Checkpoints events


        private void DataGridView_Checkpoints_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_checkpoints.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void DataGridView_Checkpoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var item = (CheckpointAgeCategoryParticipation)dataGridView_checkpoints.CurrentRow.DataBoundItem;
            if (database.SaveChanges() > 0)
                Log($"Účast kategorie \"{item.AgeCategory.Name}\" u stanoviště \"{item.Checkpoint.Name}\" úspěšně změněna na \"{(item.IsParticipating ? "Ano" : "Ne")}\"");
            else
                Log("Nastala chyba při ukládání změn");
        }

        private void DataGridView_Checkpoints_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView_categories.ClearSelection();
                dataGridView_categories.CurrentCell = null;
                ClearInputs();
                dataGridView_checkpoints.DataSource = null;
            }
        }

        #endregion


        private void Log(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        private void ClearInputs()
        {
            textBox_name.Clear();
            textBox_code.Clear();
            textBox_ageMin.Clear();
            textBox_ageMax.Clear();
            textBox_color.Clear();
            checkBox_duo.Checked = false;
            button_save.Text = "Přidat";
        }

        private void ClearAllErrors()
        {
            errorProvider.SetError(textBox_name, "");
            errorProvider.SetError(textBox_code, "");
            errorProvider.SetError(textBox_ageMin, "");
            errorProvider.SetError(textBox_ageMax, "");
            errorProvider.SetError(textBox_color, "");
        }

        private static bool HandleNumberOnlyField(KeyEventArgs e)
            => !((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || (e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right);
    }
}
