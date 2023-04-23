using turisticky_zavod.Data;

namespace turisticky_zavod.Forms
{
    public partial class AgeCategoriesEditor : Form
    {
        private readonly Database database;

        public AgeCategoriesEditor()
        {
            InitializeComponent();

            database = Database.Instance;

            Program.SetDoubleBuffer(dataGridView_categories, true);
            Program.SetDoubleBuffer(dataGridView_checkpoints, true);
        }

        private void AgeCategoriesEditor_Load(object sender, EventArgs e)
        {
            dataGridView_categories.DataSource = database.AgeCategory.Local.ToBindingList();
            ClearInputs();
        }


        #region Button AgeCategory events

        private void Button_AgeCategory_Save_Click(object sender, EventArgs e)
        {
            if (Validate_AgeCategory_TextBoxes())
            {
                var name = textBox_name_category.Text.Trim();
                var code = textBox_code.Text.Trim();
                var color = textBox_color.Text.Trim();
                var ageMin = textBox_ageMin.Text;
                var ageMax = textBox_ageMax.Text;
                var type = comboBox_type.SelectedIndex switch
                {
                    0 => CategoryType.DEFAULT,
                    1 => CategoryType.DUOS,
                    2 => CategoryType.RELAY
                };

                var category = database.AgeCategory.Local.FirstOrDefault(x => x.Name == name || x.Code == code, null);

                if (category != null)
                {
                    category.Name = name;
                    category.Code = code;
                    category.AgeMin = int.Parse(ageMin);
                    category.AgeMax = !string.IsNullOrEmpty(ageMax) ? int.Parse(ageMax) : null;
                    category.Type = type;
                    category.Color = color;
                    database.AgeCategory.Update(category);
                    if (database.SaveChanges() > 0)
                    {
                        Log($"Age category \"{category.Name}\" edited successfully", "Data");
                        LogToUser($"Kategorie \"{category.Name}\" úspěšně změněna");
                    }
                    else
                    {
                        Log("Failed editing Age category", "Data");
                        LogToUser("Nastala chyba při ukládání změn");
                    }
                }
                else
                {
                    category = new()
                    {
                        Name = name,
                        Code = code,
                        AgeMin = int.Parse(ageMin),
                        AgeMax = !string.IsNullOrEmpty(ageMax) ? int.Parse(ageMax) : null,
                        Type = type,
                        Color = color
                    };
                    database.AgeCategory.Add(category);
                    database.SaveChanges();

                    var id = database.AgeCategory.Local.OrderByDescending(x => x.ID).First().ID;
                    for (int i = 1; i <= 13; i++)
                    {
                        database.CheckpointAgeCategoryParticipation.Add(new() { AgeCategoryID = id, CheckpointID = i, IsParticipating = true });
                    }
                    if (database.SaveChanges() > 0)
                    {
                        Log($"Age category {category.Name} added successfully", "Data");
                        LogToUser($"Kategorie \"{category.Name}\" úspěšně přidána");
                    }
                    else
                    {
                        Log("Failed adding new Age category", "Data");
                        LogToUser("Nastala chyba při ukládání změn");
                    }
                }
                var row = dataGridView_categories.Rows[0];
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

        #region Button Checkpoint events

        private void Button_Checkpoint_Save_Click(object sender, EventArgs e)
        {
            if (Validate_Checkpoint_TextBoxes())
            {
                var edit = button_save_checkpoint.Text == "Upravit";
                var name = textBox_name_checkpoint.Text.Trim();
                var disqualifiable = checkBox_disqualifiable.Checked;

                if (edit)
                {
                    var participation = (CheckpointAgeCategoryParticipation)dataGridView_checkpoints.CurrentRow.DataBoundItem;
                    var checkpoint = database.Checkpoint.Local.First(x => x.ID == participation.CheckpointID);
                    checkpoint.Name = name;
                    checkpoint.Disqualifiable = disqualifiable;

                    database.Checkpoint.Update(checkpoint);
                }
                else
                {
                    var checkpoint = new Checkpoint { Name = name, Disqualifiable = disqualifiable };
                    database.Checkpoint.Add(checkpoint);

                    var categories = database.AgeCategory.Local.ToList();
                    foreach (var category in categories)
                        database.CheckpointAgeCategoryParticipation.Add(new() { AgeCategoryID = category.ID, Checkpoint = checkpoint, IsParticipating = true });
                }

                var currentCategory = (AgeCategory)dataGridView_categories.CurrentRow.DataBoundItem;

                database.SaveChanges();

                dataGridView_checkpoints.DataSource = database.CheckpointAgeCategoryParticipation
                                                              .Local
                                                              .Where(x => x.AgeCategoryID == currentCategory.ID && x.CheckpointID != 1)
                                                              .ToList();
                ClearInputs();
            }
        }

        #endregion

        #region TextBox AgeCategory events

        private bool Validate_AgeCategory_TextBoxes()
        {
            var isValidated = true;

            var name = textBox_name_category.Text.Trim();
            var code = textBox_code.Text.Trim();
            var ageMin = textBox_ageMin.Text;
            var ageMax = textBox_ageMax.Text;
            var color = textBox_color.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_name_category, "Název kategorie je povinná položka");
            }
            else if (button_save_category.Text == "Přidat" && database.AgeCategory.Local.Any(x => x.Name == name))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_name_category, "Kategorie s tímto názvem již existuje");
            }
            else
            {
                foreach (var ch in name)
                {
                    if (!char.IsLetter(ch) && ch != ' ' & ch != '-')
                    {
                        isValidated = false;
                        errorProvider_category.SetError(textBox_name_category, $"Název kategorie obsahuje nepovolené znaky: {ch}");
                        break;
                    }
                }

                errorProvider_category.SetError(textBox_name_category, string.Empty);
            }

            if (string.IsNullOrEmpty(code))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_code, "Zkratka kategorie je povinná položka");
            }
            else if (button_save_category.Text == "Přidat" && database.AgeCategory.Local.Any(x => x.Name == code))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_code, "Kategorie s touto zkratkou již existuje");
            }
            else
            {
                foreach (var ch in code)
                {
                    if (!char.IsLetter(ch) && ch != ' ' & ch != '-')
                    {
                        isValidated = false;
                        errorProvider_category.SetError(textBox_code, $"Zkratka kategorie obsahuje nepovolené znaky: {ch}");
                        break;
                    }
                }

                errorProvider_category.SetError(textBox_code, string.Empty);
            }

            if (string.IsNullOrEmpty(ageMin))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_ageMin, "Minimální věk je povinná položka");
            }
            else
                errorProvider_category.SetError(textBox_ageMin, string.Empty);

            if (!string.IsNullOrEmpty(ageMax) && !string.IsNullOrEmpty(ageMin) && int.Parse(ageMin) > int.Parse(ageMax))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_ageMax, "Maximální věk musí být větší než minimální");
            }
            else
                errorProvider_category.SetError(textBox_ageMax, string.Empty);

            if (string.IsNullOrEmpty(color))
            {
                isValidated = false;
                errorProvider_category.SetError(textBox_color, "Barva je povinná položka");
            }
            else
            {
                foreach (var ch in code)
                {
                    if (!char.IsLetter(ch) && ch != ' ')
                    {
                        isValidated = false;
                        errorProvider_category.SetError(textBox_color, $"Barva obsahuje nepovolené znaky: {ch}");
                        break;
                    }
                }

                errorProvider_category.SetError(textBox_color, string.Empty);
            }

            if (comboBox_type.SelectedIndex == -1)
            {
                isValidated = false;
                errorProvider_category.SetError(comboBox_type, "Typ je povinnná položka");
            }
            else
                errorProvider_category.SetError(comboBox_type, string.Empty);

            return isValidated;
        }

        private void TextBox_AgeCategory_AgeMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_AgeCategory_AgeMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = false;
            else if (HandleNumberOnlyField(e))
                e.SuppressKeyPress = true;
        }

        private void TextBox_AgeCategory_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_category.PerformClick();
        }

        private void TextBox_AgeCategory_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_category.PerformClick();
        }

        private void TextBox_AgeCategory_AgeMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_category.PerformClick();
        }

        private void TextBox_AgeCategory_AgeMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_category.PerformClick();
        }

        private void TextBox_AgeCategory_Color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_category.PerformClick();
        }

        #endregion

        #region TextBox Checkpoint events

        private bool Validate_Checkpoint_TextBoxes()
        {
            var isValidated = true;

            if (string.IsNullOrEmpty(textBox_name_checkpoint.Text))
            {
                isValidated = false;
                errorProvider_checkpoint.SetError(textBox_name_checkpoint, "Název stanoviště je povinná položka");
            }
            else if (button_save_checkpoint.Text == "Přidat" && database.Checkpoint.Local.Any(x => x.Name == textBox_name_checkpoint.Text.Trim()))
            {
                isValidated = false;
                errorProvider_checkpoint.SetError(textBox_name_checkpoint, "Stanoviště s tímto názvem již existuje");
            }
            else
                errorProvider_checkpoint.SetError(textBox_name_checkpoint, string.Empty);

            return isValidated;
        }

        private void TextBox_Name_Checkpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button_save_checkpoint.PerformClick();
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
                Log($"Age category {category.Name} deleted successfully", "Data");
                LogToUser($"Kategorie \"{category.Name}\" úspěšně smazána");
                ClearInputs();
            }
            else
            {
                Log("Failed deleting Age category", "Data");
                LogToUser("Nastala chyba při ukládání změn");
            }
        }

        private void DataGridView_AgeCategories_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView_categories.CurrentRow != null)
            {
                var category = (AgeCategory)dataGridView_categories.CurrentRow.DataBoundItem;
                textBox_name_category.Text = category.Name;
                textBox_code.Text = category.Code;
                textBox_ageMin.Text = category.AgeMin.ToString();
                textBox_ageMax.Text = category.AgeMax.HasValue ? category.AgeMax.Value.ToString() : string.Empty;
                textBox_color.Text = category.Color;
                comboBox_type.SelectedIndex = (int)category.Type;
                button_save_category.Text = "Upravit";

                dataGridView_checkpoints.DataSource = database.CheckpointAgeCategoryParticipation
                                                              .Local
                                                              .Where(x => x.AgeCategoryID == category.ID && x.CheckpointID != 1)
                                                              .ToList();

                ClearAllErrors();
            }
        }

        private void DataGridView_AgeCategories_Sorted(object sender, EventArgs e)
            => ClearInputs();

        private void DataGridView_AgeCategories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView_categories.ClearSelection();
                dataGridView_checkpoints.ClearSelection();
                ClearInputs();
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

        private void DataGridView_Checkpoints_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;

            var participation = (CheckpointAgeCategoryParticipation)dataGridView_checkpoints.CurrentRow.DataBoundItem;

            if (e.ColumnIndex == 1)
            {
                participation.IsParticipating = !participation.IsParticipating;

                database.CheckpointAgeCategoryParticipation.Update(participation);

                if (database.SaveChanges() > 0)
                {
                    Log($"Age category {participation.AgeCategory.Name}'s participation in checkpoint " +
                        $"\"{participation.Checkpoint.Name}\" changed successfully", "Data");
                    LogToUser($"Účast kategorie \"{participation.AgeCategory.Name}\" u stanoviště \"{participation.Checkpoint.Name}\" " +
                        $"úspěšně změněna na \"{(participation.IsParticipating ? "Ano" : "Ne")}\"");
                }
                else
                {
                    Log("Failed changing Age category's checkpoint participation", "Data");
                    LogToUser("Nastala chyba při ukládání změn");
                }
            }
            else
            {
                var checkpoint = participation.Checkpoint;
                checkpoint.Disqualifiable = !checkpoint.Disqualifiable;

                database.Checkpoint.Update(checkpoint);

                if (database.SaveChanges() > 0)
                {
                    Log($"Disqualifiability of checkpoint {checkpoint.Name} changed successfully", "Data");
                    LogToUser($"Diskvalifikačnost stanoviště \"{checkpoint.Name}\" úspěšně změněna na \"{(checkpoint.Disqualifiable ? "Ano" : "Ne")}\"");
                }
                else
                {
                    Log("Failed changing Checkpoint's disqualifiability", "Data");
                    LogToUser("Nastala chyba při ukládání změn");
                }
            }
        }

        private void DataGridView_Checkpoints_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;

            if (dataGridView_checkpoints.CurrentRow != null
                && MessageBox.Show("Opravdu chcete smazat zvolené stanoviště?",
                "Smazat stanoviště", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                var participation = (CheckpointAgeCategoryParticipation)dataGridView_checkpoints.CurrentRow.DataBoundItem;
                var checkpoint = participation.Checkpoint;

                foreach (var p in database.CheckpointAgeCategoryParticipation.Local.Where(x => x.CheckpointID == checkpoint.ID))
                    database.CheckpointAgeCategoryParticipation.Remove(p);

                database.Checkpoint.Remove(checkpoint);

                if (database.SaveChanges() > 0)
                {
                    Log($"Checkpoint {checkpoint.Name} deleted successfully", "Data");
                    LogToUser($"Stanoviště \"{checkpoint.Name}\" úspěšně smazáno");

                    dataGridView_checkpoints.DataSource = database.CheckpointAgeCategoryParticipation
                                                                  .Local
                                                                  .Where(x => x.AgeCategoryID == participation.AgeCategoryID && x.CheckpointID != 1)
                                                                  .ToList();

                    ClearInputs();

                    dataGridView_checkpoints.CurrentCell = null;
                }
                else
                {
                    Log("Failed deleting Checkpoint", "Data");
                    LogToUser("Nastala chyba při ukládání změn");
                }
            }
        }

        private void DataGridView_Checkpoints_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView_checkpoints.CurrentRow != null)
            {
                var participation = (CheckpointAgeCategoryParticipation)dataGridView_checkpoints.CurrentRow.DataBoundItem;
                var checkpoint = participation.Checkpoint;

                textBox_name_checkpoint.Text = checkpoint.Name;
                checkBox_disqualifiable.Checked = checkpoint.Disqualifiable;

                button_save_checkpoint.Text = "Upravit";
            }
        }

        private void DataGridView_Checkpoints_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView_categories.ClearSelection();
                dataGridView_checkpoints.ClearSelection();
                ClearInputs();
            }
        }

        #endregion


        private void LogToUser(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        public void Log(string message, string type)
        {
            try
            {
                Invoke(() =>
                {
                    database.Log.Add(new Log
                    {
                        Message = message,
                        Type = type
                    });
                    database.SaveChanges();
                });
            }
            catch (ObjectDisposedException) { }
        }

        private void ClearInputs()
        {
            textBox_name_category.Clear();
            textBox_code.Clear();
            textBox_ageMin.Clear();
            textBox_ageMax.Clear();
            textBox_color.Clear();
            comboBox_type.SelectedIndex = -1;
            button_save_category.Text = "Přidat";

            textBox_name_checkpoint.Clear();
            checkBox_disqualifiable.Checked = false;
            button_save_checkpoint.Text = "Přidat";
        }

        private void ClearAllErrors()
        {
            errorProvider_category.SetError(textBox_name_category, string.Empty);
            errorProvider_category.SetError(textBox_code, string.Empty);
            errorProvider_category.SetError(textBox_ageMin, string.Empty);
            errorProvider_category.SetError(textBox_ageMax, string.Empty);
            errorProvider_category.SetError(textBox_color, string.Empty);
            errorProvider_category.SetError(comboBox_type, string.Empty);

            errorProvider_checkpoint.SetError(textBox_name_checkpoint, string.Empty);
        }

        private static bool HandleNumberOnlyField(KeyEventArgs e)
            => !((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                || (e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right);
    }
}
