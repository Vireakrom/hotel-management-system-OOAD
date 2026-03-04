namespace HotelManagementSystem.UI.Staff
{
    partial class StaffManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblRoleFilter = new System.Windows.Forms.Label();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblStaffCount = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1050, 60);
            this.panelTop.TabIndex = 0;
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Staff Management";
            // panelFilter
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelFilter.Controls.Add(this.btnRefresh);
            this.panelFilter.Controls.Add(this.btnSearch);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.lblSearch);
            this.panelFilter.Controls.Add(this.cmbRoleFilter);
            this.panelFilter.Controls.Add(this.lblRoleFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFilter.Size = new System.Drawing.Size(1050, 60);
            this.panelFilter.TabIndex = 1;
            // lblRoleFilter
            this.lblRoleFilter.AutoSize = true;
            this.lblRoleFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRoleFilter.Location = new System.Drawing.Point(15, 20);
            this.lblRoleFilter.Name = "lblRoleFilter";
            this.lblRoleFilter.TabIndex = 0;
            this.lblRoleFilter.Text = "Role:";
            // cmbRoleFilter
            this.cmbRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoleFilter.Location = new System.Drawing.Point(65, 17);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(150, 25);
            this.cmbRoleFilter.TabIndex = 1;
            this.cmbRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoleFilter_SelectedIndexChanged);
            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(230, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtSearch.Location = new System.Drawing.Point(295, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 26);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(575, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(675, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // panelActions
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.btnDeactivate);
            this.panelActions.Controls.Add(this.btnEdit);
            this.panelActions.Controls.Add(this.btnAdd);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelActions.Location = new System.Drawing.Point(900, 120);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(10);
            this.panelActions.Size = new System.Drawing.Size(150, 430);
            this.panelActions.TabIndex = 3;
            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(13, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 48);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Staff";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(13, 73);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 48);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // btnDeactivate
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(13, 133);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(124, 48);
            this.btnDeactivate.TabIndex = 2;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelBottom.Controls.Add(this.lblStaffCount);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 550);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1050, 50);
            this.panelBottom.TabIndex = 4;
            // lblStaffCount
            this.lblStaffCount.AutoSize = true;
            this.lblStaffCount.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblStaffCount.Location = new System.Drawing.Point(15, 15);
            this.lblStaffCount.Name = "lblStaffCount";
            this.lblStaffCount.TabIndex = 0;
            this.lblStaffCount.Text = "Total Staff: 0";
            // dgvStaff
            this.dgvStaff.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaff.Location = new System.Drawing.Point(0, 120);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.Size = new System.Drawing.Size(900, 430);
            this.dgvStaff.TabIndex = 2;
            this.dgvStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellDoubleClick);
            // StaffManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StaffManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Management";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblRoleFilter;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblStaffCount;
        private System.Windows.Forms.DataGridView dgvStaff;
    }
}
