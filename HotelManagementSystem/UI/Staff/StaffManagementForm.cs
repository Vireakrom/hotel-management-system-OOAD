using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagementSystem.UI.Staff
{
    public partial class StaffManagementForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly HousekeepingTaskRepository _taskRepo = new HousekeepingTaskRepository();
        private List<User> _allStaff;

        // Maps UserId → active task count for Housekeeping staff
        private Dictionary<int, int> _activeTaskCounts = new Dictionary<int, int>();

        public StaffManagementForm()
        {
            InitializeComponent();
            this.Load += StaffManagementForm_Load;
        }

        private void StaffManagementForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            PopulateRoleFilter();
            LoadStaff();
        }

        // ── Grid setup ───────────────────────────────────────────────────────────

        private void SetupGrid()
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.MultiSelect = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.RowTemplate.Height = 30;
            dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

            dgvStaff.Columns.Clear();
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId",       HeaderText = "ID",           DataPropertyName = "UserId",    Width = 40,  Visible = false });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName",     HeaderText = "Full Name",    DataPropertyName = "FullName",  FillWeight = 20 });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUsername", HeaderText = "Username",     DataPropertyName = "Username",  FillWeight = 15 });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole",     HeaderText = "Role",         DataPropertyName = "Role",      FillWeight = 12 });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail",    HeaderText = "Email",        DataPropertyName = "Email",     FillWeight = 22 });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhone",    HeaderText = "Phone",        DataPropertyName = "Phone",     FillWeight = 13 });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLastLogin",
                HeaderText = "Last Login",
                DataPropertyName = "LastLogin",
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy HH:mm" }
            });

            // Active tasks column — populated manually in ApplyRowStyling
            var colTasks = new DataGridViewTextBoxColumn
            {
                Name = "colTasks",
                HeaderText = "Active Tasks",
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvStaff.Columns.Add(colTasks);

            dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgvStaff.RowsDefaultCellStyle.BackColor = Color.White;
            dgvStaff.CellFormatting += DgvStaff_CellFormatting;
        }

        private void PopulateRoleFilter()
        {
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.Add("All Roles");
            cmbRoleFilter.Items.Add("Admin");
            cmbRoleFilter.Items.Add("Manager");
            cmbRoleFilter.Items.Add("FrontDesk");
            cmbRoleFilter.Items.Add("Housekeeping");
            cmbRoleFilter.SelectedIndex = 0;
        }

        // ── Data loading ──────────────────────────────────────────────────────────

        private void LoadStaff()
        {
            try
            {
                _allStaff = _userRepo.GetAll();
                BuildActiveTaskCounts();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildActiveTaskCounts()
        {
            _activeTaskCounts.Clear();
            try
            {
                var activeTasks = _taskRepo.GetTasksByStatus("InProgress")
                    .Concat(_taskRepo.GetTasksByStatus("Pending"))
                    .Where(t => t.AssignedToUserId.HasValue)
                    .GroupBy(t => t.AssignedToUserId.Value)
                    .ToDictionary(g => g.Key, g => g.Count());

                _activeTaskCounts = activeTasks;
            }
            catch { /* non-critical; leave counts empty */ }
        }

        private void ApplyFilters()
        {
            if (_allStaff == null) return;
            string roleFilter = cmbRoleFilter.SelectedItem?.ToString() ?? "All Roles";
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = _allStaff.AsEnumerable();

            if (roleFilter != "All Roles")
                filtered = filtered.Where(u => u.Role == roleFilter);

            if (!string.IsNullOrEmpty(search))
                filtered = filtered.Where(u =>
                    u.FullName.ToLower().Contains(search) ||
                    u.Username.ToLower().Contains(search) ||
                    (u.Email != null && u.Email.ToLower().Contains(search)));

            var list = filtered.ToList();

            dgvStaff.DataSource = null;
            dgvStaff.DataSource = list;

            // Fill "Active Tasks" column manually
            for (int i = 0; i < dgvStaff.Rows.Count; i++)
            {
                var user = (User)dgvStaff.Rows[i].DataBoundItem;
                if (user.Role == "Housekeeping")
                {
                    int count = _activeTaskCounts.ContainsKey(user.UserId) ? _activeTaskCounts[user.UserId] : 0;
                    dgvStaff.Rows[i].Cells["colTasks"].Value = count;
                }
                else
                {
                    dgvStaff.Rows[i].Cells["colTasks"].Value = "-";
                }
            }

            dgvStaff.BeginInvoke(new Action(() => {
                dgvStaff.CurrentCell = null;
                dgvStaff.ClearSelection();
            }));

            lblStaffCount.Text = $"Showing: {list.Count} staff member(s)";
        }

        // ── Cell formatting — colour-code rows by role ────────────────────────────

        private void DgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvStaff.Rows[e.RowIndex].DataBoundItem == null) return;
            var user = (User)dgvStaff.Rows[e.RowIndex].DataBoundItem;

            Color rowColor;
            if (user.Role == "Admin")
                rowColor = Color.FromArgb(253, 245, 230);       // soft amber
            else if (user.Role == "Manager")
                rowColor = Color.FromArgb(235, 245, 255);       // soft blue
            else if (user.Role == "Housekeeping")
                rowColor = Color.FromArgb(235, 255, 240);       // soft green
            else
                rowColor = Color.White;

            if (e.ColumnIndex == 0)
                dgvStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor;
        }

        // ── Button handlers ───────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new AddEditStaffDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                LoadStaff();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) return;

            var fresh = _userRepo.GetById(user.UserId);
            if (fresh == null)
            {
                MessageBox.Show("Staff member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadStaff();
                return;
            }

            var dialog = new AddEditStaffDialog(fresh);
            if (dialog.ShowDialog() == DialogResult.OK)
                LoadStaff();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) return;

            var confirm = MessageBox.Show(
                $"Deactivate staff member: {user.FullName} ({user.Username})?\n\n" +
                "They will no longer be able to log in.",
                "Confirm Deactivation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                if (_userRepo.Delete(user.UserId))
                {
                    MessageBox.Show("Staff member deactivated successfully.", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaff();
                }
                else
                {
                    MessageBox.Show("Failed to deactivate staff member.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) => ApplyFilters();
        private void btnRefresh_Click(object sender, EventArgs e) { txtSearch.Clear(); cmbRoleFilter.SelectedIndex = 0; LoadStaff(); }
        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == (char)Keys.Enter) { ApplyFilters(); e.Handled = true; } }
        private void dgvStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) btnEdit_Click(sender, e); }

        private User GetSelectedUser()
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff member.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return (User)dgvStaff.SelectedRows[0].DataBoundItem;
        }
    }
}
