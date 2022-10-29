using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Battle_Param_Editor
{
    public partial class Form1 : Form
    {
        #region Variables
        public DataSet dsParamData = null;
        public int fileType;
        public IList<string> strDifficulties = new List<string> {
            "Normal",
            "Hard",
            "Very Hard",
            "Ultimate"
        };
        ParamDataManager paramDataManager = new ParamDataManager();
        #endregion

        public Form1()
        {
            InitializeComponent();
            SetDoubleBuffered(dgTableView);
#if (PUBLICRELEASE)
            addDifficultyToolStripMenuItem.Visible = false;
#endif
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region File load
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = ".";
                openFileDialog1.Filter = "Episode 1 Offline|*battleparamentry.dat|Episode 1 Online|*battleparamentry_on.dat|Episode 2 Offline|*battleparamentry_lab.dat|Episode 2 Online|*battleparamentry_lab_on.dat|Episode 4 Offline|*battleparamentry_ep4.dat|Episode 4 Online|*battleparamentry_ep4_on.dat|All files|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    CloseParamFile();
                    fileType = openFileDialog1.FilterIndex;
                    string fileName = openFileDialog1.FileName;
                    
                    if (openFileDialog1.FilterIndex == 1 || openFileDialog1.FilterIndex == 2) paramDataManager.SetEpisode(0);
                    if (openFileDialog1.FilterIndex == 3 || openFileDialog1.FilterIndex == 4) paramDataManager.SetEpisode(1);
                    if (openFileDialog1.FilterIndex == 5 || openFileDialog1.FilterIndex == 6) paramDataManager.SetEpisode(2);
                    if ((dsParamData = paramDataManager.LoadParamData(fileName)) != null)
                    {
                        if (setDifficulties() == false)
                        {
                            MessageBox.Show("An error occured whilst trying to set difficulties", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        cbStatisticTable.Enabled = true;
                        cbDifficulty.Enabled = true;
                        dataOperationsToolStripMenuItem.Enabled = true;
                        cbStatisticTable.SelectedIndex = 0;
                        cbDifficulty.SelectedIndex = 0;
                        saveToolStripMenuItem.Enabled = true;
                        this.Width = 860;
                        Status.Text = fileName;
                    }
                    else
                    {
                        MessageBox.Show("Param file format is invalid or not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                cbStatisticTable.Enabled = false;
                cbDifficulty.Enabled = false;
                dataOperationsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                Status.Text = "Ready";
                MessageBox.Show("An error occured whilst trying to open the selected file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDataSource(string tableName, DataTable dtData, string Filter)
        {
            dgTableView.DataSource = dtData;
            if (Filter != null)
            {
                (dgTableView.DataSource as DataTable).DefaultView.RowFilter = string.Format(Filter);
            }
        }

        private void LoadDataTable(DataTable dtData, string Filter)
        {
            SetDataSource(dtData.TableName, dtData, Filter);
        }

        private void FormatTable()
        {
            foreach (DataGridViewColumn col in dgTableView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (col.Name == "Offset" || col.Name == "Difficulty") col.Visible = false;
                if (col.Name == "Enemy Name" || col.Name == "Offset" || col.Name == "Difficulty") col.ReadOnly = true;
            }

            dgTableView.Columns["Enemy Name"].Width = 128;
            dgTableView.Columns["Enemy Name"].DisplayIndex = 0;

            if (GetTableName() == "Physical")
            {
                // Style
                dgTableView.Columns["ATP"].Width = 48;
                dgTableView.Columns["MST"].Width = 48;
                dgTableView.Columns["EVP"].Width = 48;
                dgTableView.Columns["HP"].Width = 48;
                dgTableView.Columns["DFP"].Width = 48;
                dgTableView.Columns["ATA"].Width = 48;
                dgTableView.Columns["LCK"].Width = 48;
                dgTableView.Columns["ESP"].Width = 48;
                dgTableView.Columns["Range 1"].Width = 64;
                dgTableView.Columns["Range 2"].Width = 64;
                dgTableView.Columns["Boost"].Width = 48;
                dgTableView.Columns["XP"].Width = 48;
                dgTableView.Columns["TP"].Width = 48;

                // Column order
                dgTableView.Columns["ATP"].DisplayIndex = 1;
                dgTableView.Columns["MST"].DisplayIndex = 2;
                dgTableView.Columns["EVP"].DisplayIndex = 3;
                dgTableView.Columns["HP"].DisplayIndex = 4;
                dgTableView.Columns["DFP"].DisplayIndex = 5;
                dgTableView.Columns["ATA"].DisplayIndex = 6;
                dgTableView.Columns["LCK"].DisplayIndex = 7;
                dgTableView.Columns["ESP"].DisplayIndex = 8;
                dgTableView.Columns["Range 1"].DisplayIndex = 9;
                dgTableView.Columns["Range 2"].DisplayIndex = 10;
                dgTableView.Columns["Boost"].DisplayIndex = 11;
                dgTableView.Columns["XP"].DisplayIndex = 12;
                dgTableView.Columns["TP"].DisplayIndex = 13;
            }

            if (GetTableName() == "Resist")
            {
                // Visibility
                dgTableView.Columns["Unknown 1"].Visible = false;
                dgTableView.Columns["Reserved 1"].Visible = false;
                dgTableView.Columns["Reserved 2"].Visible = false;
                dgTableView.Columns["Reserved 3"].Visible = false;
                dgTableView.Columns["Reserved 4"].Visible = false;
                dgTableView.Columns["Reserved 5"].Visible = false;

                // Style
                dgTableView.Columns["EFR"].Width = 48;
                dgTableView.Columns["EIC"].Width = 48;
                dgTableView.Columns["ETH"].Width = 48;
                dgTableView.Columns["ELT"].Width = 48;
                dgTableView.Columns["EDK"].Width = 48;

                // Column Order
                dgTableView.Columns["EFR"].DisplayIndex = 1;
                dgTableView.Columns["EIC"].DisplayIndex = 2;
                dgTableView.Columns["ETH"].DisplayIndex = 3;
                dgTableView.Columns["ELT"].DisplayIndex = 4;
                dgTableView.Columns["EDK"].DisplayIndex = 5;
            }

            else if (GetTableName() == "Attack")
            {
                // Visibility
                dgTableView.Columns["Unknown 1"].Visible = true;
                dgTableView.Columns["Unknown 6"].Visible = false;
                dgTableView.Columns["Unknown 7"].Visible = false;
                dgTableView.Columns["Unknown 8"].Visible = false;
                dgTableView.Columns["Unknown 9"].Visible = false;
                dgTableView.Columns["Unknown 10"].Visible = false;
                dgTableView.Columns["Unknown 11"].Visible = false;
                dgTableView.Columns["Unknown 12"].Visible = false;
                dgTableView.Columns["Angle X"].Visible = false;

                // Style
                dgTableView.Columns["Unknown 1"].Width = 72;
                dgTableView.Columns["Unknown 2"].Width = 72;
                dgTableView.Columns["Unknown 3"].Width = 72;
                dgTableView.Columns["Unknown 4"].Width = 72;
                dgTableView.Columns["Distance X"].Width = 72;
                dgTableView.Columns["Angle X "].Width = 72;
                dgTableView.Columns["Angle X "].DefaultCellStyle.Format = "#0.000\u00B0";
                dgTableView.Columns["Distance Y"].Width = 72;

                // Column Order
                dgTableView.Columns["Unknown 1"].DisplayIndex = 1;
                dgTableView.Columns["Unknown 2"].DisplayIndex = 2;
                dgTableView.Columns["Unknown 3"].DisplayIndex = 3;
                dgTableView.Columns["Unknown 4"].DisplayIndex = 4;
                dgTableView.Columns["Distance X"].DisplayIndex = 5;
                dgTableView.Columns["Angle X "].DisplayIndex = 6;
                dgTableView.Columns["Distance Y"].DisplayIndex = 7;
            }

            if (GetTableName() == "Movement")
            {
                // Visibility
                dgTableView.Columns["Unknown 1"].Visible = true;
                dgTableView.Columns["Unknown 6"].Visible = true;
                dgTableView.Columns["Unknown 7"].Visible = true;
                dgTableView.Columns["Unknown 8"].Visible = true;

                // Style
                dgTableView.Columns["Idle Move Speed"].Width = 120;
                dgTableView.Columns["Idle Animation Speed"].Width = 120;
                dgTableView.Columns["Move Speed"].Width = 120;
                dgTableView.Columns["Animation Speed"].Width = 120;
                dgTableView.Columns["Unknown 1"].Width = 72;
                dgTableView.Columns["Unknown 2"].Width = 72;
                dgTableView.Columns["Unknown 3"].Width = 72;
                dgTableView.Columns["Unknown 4"].Width = 72;
                dgTableView.Columns["Unknown 5"].Width = 72;
                dgTableView.Columns["Unknown 6"].Width = 72;
                dgTableView.Columns["Unknown 7"].Width = 72;
                dgTableView.Columns["Unknown 8"].Width = 72;

                // Column Order
                dgTableView.Columns["Idle Move Speed"].DisplayIndex = 1;
                dgTableView.Columns["Idle Animation Speed"].DisplayIndex = 2;
                dgTableView.Columns["Move Speed"].DisplayIndex = 3;
                dgTableView.Columns["Animation Speed"].DisplayIndex = 4;
                dgTableView.Columns["Unknown 1"].DisplayIndex = 5;
                dgTableView.Columns["Unknown 2"].DisplayIndex = 6;
                dgTableView.Columns["Unknown 3"].DisplayIndex = 7;
                dgTableView.Columns["Unknown 4"].DisplayIndex = 8;
                dgTableView.Columns["Unknown 5"].DisplayIndex = 9;
                dgTableView.Columns["Unknown 6"].DisplayIndex = 10;
                dgTableView.Columns["Unknown 7"].DisplayIndex = 11;
                dgTableView.Columns["Unknown 8"].DisplayIndex = 12;
            }
        }

        private void dgTableView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatTable();
            foreach (DataGridViewColumn col in dgTableView.Columns)
            {
                if (col.Name == "Enemy Name" || col.Name == "Offset")
                {
                    col.Frozen = true;
                    foreach (DataGridViewRow row in dgTableView.Rows)
                    {
                        if (row.Index % 2 == 0)
                        {
                            row.Cells[col.Name].Style.BackColor = Color.FromArgb(250, 250, 250);
                        }
                        else
                        {
                            row.Cells[col.Name].Style.BackColor = Color.FromArgb(240, 240, 200);
                        }
                    }
                }
            }
        }

        private void CloseParamFile()
        {
            try
            {
                dsParamData = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured whilst trying to Close the param data file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region File save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = ".";
                saveFileDialog1.Filter = "Episode 1 Offline|*battleparamentry.dat|Episode 1 Online|*battleparamentry_on.dat|Episode 2 Offline|*battleparamentry_lab.dat|Episode 2 Online|*battleparamentry_lab_on.dat|Episode 4 Offline|*battleparamentry_ep4.dat|Episode 4 Online|*battleparamentry_ep4_on.dat|All files|*.*";
                saveFileDialog1.FilterIndex = fileType;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    paramDataManager.SaveParamData(fileName, dsParamData);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured whilst trying to save file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Data Processing
        private bool setDifficulties()
        {
            DataRow[] dr = dsParamData.Tables["Constants"].Select("[Name] = 'DifficultyCount'");
            if (dr.Length > 0)
            {
                int difficultyCount = Convert.ToInt32(dr[0]["int"]);
                int difficultyItr = 0;
                cbDifficulty.Items.Clear();

                while (strDifficulties.Count < difficultyCount)
                {
                    strDifficulties.Add("Custom " + ++difficultyItr);
                }
                for (int i = 0; i < difficultyCount; i++)
                {
                    cbDifficulty.Items.Add(strDifficulties[i]);
                }

                return true;
            }
            else
                return false;
        }

        private string GetTableName()
        {
            string tableName = "";
            if (dgTableView.DataSource.GetType() == typeof(DataView))
                tableName = ((DataView)dgTableView.DataSource).Table.TableName;
            else
                tableName = ((DataTable)dgTableView.DataSource).TableName;
            return tableName;
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void dgTableView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if((GetTableName() == "Attack") && (dgTableView.Columns[e.ColumnIndex].Name == "Angle X "))
            {
                dsParamData.Tables["Attack"].Rows[e.RowIndex]["Angle X"] = Convert.ToUInt16(Convert.ToSingle(dsParamData.Tables["Attack"].Rows[e.RowIndex]["Angle X "]) * 182.0416666666667) % 0xFFFF;
            }
        }
        #endregion
        #region User UI
        private void cbStatisticTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selected = cbStatisticTable.Text.Split(' ');
            if (selected[0] == "Physical" || selected[0] == "Resist" || selected[0] == "Attack" || selected[0] == "Movement")
            {
                LoadDataTable(dsParamData.Tables[selected[0]], "[Enemy Name] <> 'INVALID' and [Difficulty] = " + cbDifficulty.SelectedIndex.ToString());
                //LoadDataTable(dsParamData.Tables[selected[0]], "[Difficulty] = " + cbDifficulty.SelectedIndex.ToString());
            }
            cbCopyTableTo.Items.Clear();
            cbCopyTableFrom.Items.Clear();
            if (cbDifficulty.SelectedIndex != -1)
            {
                for (int i = 0; i < cbDifficulty.Items.Count; i++)
                {
                    if (cbDifficulty.Items[cbDifficulty.SelectedIndex].ToString() != strDifficulties[i])
                    {
                        cbCopyTableTo.Items.Add(strDifficulties[i]);
                        cbCopyTableFrom.Items.Add(strDifficulties[i]);
                    }
                }
            }
            dgTableView.Focus();
        }


        private void cbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selected = cbStatisticTable.Text.Split(' ');
            if (selected[0] == "Physical" || selected[0] == "Resist" || selected[0] == "Attack" || selected[0] == "Movement")
            {
                LoadDataTable(dsParamData.Tables[selected[0]], "[Enemy Name] <> 'INVALID' and [Difficulty] = " + cbDifficulty.SelectedIndex.ToString());
                //LoadDataTable(dsParamData.Tables[selected[0]], "[Difficulty] = " + cbDifficulty.SelectedIndex.ToString());
            }
            cbCopyTableTo.Items.Clear();
            cbCopyTableFrom.Items.Clear();
            for (int i = 0; i < cbDifficulty.Items.Count; i++ )
            {
                if (cbDifficulty.Items[cbDifficulty.SelectedIndex].ToString() != strDifficulties[i])
                {
                    cbCopyTableTo.Items.Add(strDifficulties[i]);
                    cbCopyTableFrom.Items.Add(strDifficulties[i]);
                }
            }
            dgTableView.Focus();
        }

        private void addDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if (!PUBLICRELEASE)
            paramDataManager.AddTable("Physical", paramDataManager.physicalSizes);
            paramDataManager.AddTable("Attack", paramDataManager.attackSizes);
            paramDataManager.AddTable("Resist", paramDataManager.resistSizes);
            paramDataManager.AddTable("Movement", paramDataManager.movementSizes);

            strDifficulties = new List<string> {
                "Normal",
                "Hard",
                "Very Hard",
                "Ultimate"
            };

            DataRow[] dr = dsParamData.Tables["Constants"].Select("[Name] = 'DifficultyCount'");
            if (dr.Length > 0)
            {
                int difficultyCount = Convert.ToInt32(dr[0]["int"]);
                int difficultyItr = 0;
                cbDifficulty.Items.Clear();
                dr[0]["int"] = Convert.ToString(++difficultyCount);

                while (strDifficulties.Count < difficultyCount)
                {
                    strDifficulties.Add("Custom " + ++difficultyItr);
                }
                for (int i = 0; i < difficultyCount; i++)
                {
                    cbDifficulty.Items.Add(strDifficulties[i]);
                }
            }

            setDifficulties();
#endif
        }

        private void cbCopyTableTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataOperationsToolStripMenuItem.DropDown.Close();
            if (MessageBox.Show("Overwrite '" + cbCopyTableTo.Text.ToString() + "' table data with '" + cbDifficulty.Text.ToString() + "' table data?", "Copy confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!paramDataManager.CopyTable(cbDifficulty.Text.ToString(), cbCopyTableTo.Text.ToString(), strDifficulties))
                {
                    MessageBox.Show("Error copying table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cbCopyTableTo.Text = "Select table";
        }

        private void cbCopyTableFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataOperationsToolStripMenuItem.DropDown.Close();
            if (MessageBox.Show("Overwrite '" + cbDifficulty.Text.ToString() + "' table data with '" + cbCopyTableFrom.Text.ToString() + "' table data?", "Copy confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!paramDataManager.CopyTable(cbCopyTableFrom.Text.ToString(), cbDifficulty.Text.ToString(), strDifficulties))
                {
                    MessageBox.Show("Error copying table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cbCopyTableFrom.Text = "Select table";
        }

        private void dgTableView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = dgTableView.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1 && hti.ColumnIndex > 2)
                {
                    dgTableView.ClearSelection();
                    dgTableView.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected = true;
                    contextMenuStrip1.Show(dgTableView, e.Location);
                }
            }
        }

        private void dgTableView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex > 2)
            {
                dgTableView.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                dgTableView.Columns[e.ColumnIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void increaseByPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataModifier dataModifier = new DataModifier();
                dataModifier.ShowDialog();
                System.Type dataType;
                if (dataModifier.DialogResult == DialogResult.OK)
                {
                    dataModifier.Dispose();
                    foreach (DataGridViewCell cell in dgTableView.SelectedCells)
                    {
                        dataType = this.dsParamData.Tables[GetTableName()].Columns[cell.ColumnIndex].DataType;
                        if (dataType == typeof(System.Single))
                        {
                            cell.Value = Convert.ToSingle(Convert.ToSingle(cell.Value) + ((Convert.ToSingle(cell.Value) / 100) * Convert.ToSingle(dataModifier.nupAdjustment.Value))).ToString();
                        }
                        else if ((dataType == typeof(System.UInt16)) || (dataType == typeof(System.Int16)))
                        {
                            cell.Value = Convert.ToUInt16(Convert.ToSingle(cell.Value) + ((Convert.ToSingle(cell.Value) / 100) * Convert.ToSingle(dataModifier.nupAdjustment.Value))).ToString();
                        }
                        else if ((dataType == typeof(System.UInt32)) || (dataType == typeof(System.Int32)))
                        {
                            cell.Value = Convert.ToUInt32(Convert.ToSingle(cell.Value) + ((Convert.ToSingle(cell.Value) / 100) * Convert.ToSingle(dataModifier.nupAdjustment.Value))).ToString();
                        }
                    }
                }
                else
                {
                    dataModifier.Dispose();
                }
                dgTableView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured whilst increasing value: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void increaseByNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataModifier dataModifier = new DataModifier();
                dataModifier.ShowDialog();
                System.Type dataType;
                if (dataModifier.DialogResult == DialogResult.OK)
                {
                    dataModifier.Dispose();
                    foreach (DataGridViewCell cell in dgTableView.SelectedCells)
                    {
                        dataType = this.dsParamData.Tables[GetTableName()].Columns[cell.ColumnIndex].DataType;
                        if (dataType == typeof(System.Single))
                        {
                            cell.Value = Convert.ToSingle(Convert.ToSingle(cell.Value) + (Convert.ToSingle(dataModifier.nupAdjustment.Value))).ToString();
                        }
                        else if ((dataType == typeof(System.UInt16)) || (dataType == typeof(System.Int16)))
                        {
                            cell.Value = Convert.ToUInt16(Convert.ToSingle(cell.Value) + (Convert.ToUInt16(dataModifier.nupAdjustment.Value))).ToString();
                        }
                        else if ((dataType == typeof(System.UInt32)) || (dataType == typeof(System.Int32)))
                        {
                            cell.Value = Convert.ToUInt32(Convert.ToSingle(cell.Value) + (Convert.ToUInt32(dataModifier.nupAdjustment.Value))).ToString();
                        }
                    }
                }
                else
                {
                    dataModifier.Dispose();
                }
                dgTableView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured whilst increasing value: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgTableView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgTableView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
