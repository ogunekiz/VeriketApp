namespace VeriketApp.WinForm.UI
{
    partial class frmGetLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetLogs));
            btnGetLogs = new Button();
            dgvLogList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLogList).BeginInit();
            SuspendLayout();
            // 
            // btnGetLogs
            // 
            btnGetLogs.BackColor = SystemColors.ActiveCaption;
            btnGetLogs.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGetLogs.Location = new Point(566, 267);
            btnGetLogs.Name = "btnGetLogs";
            btnGetLogs.Size = new Size(206, 56);
            btnGetLogs.TabIndex = 2;
            btnGetLogs.Text = "Get Logs From CSV File";
            btnGetLogs.UseVisualStyleBackColor = false;
            btnGetLogs.Click += btnGetLogs_Click;
            // 
            // dgvLogList
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dgvLogList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLogList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLogList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLogList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLogList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLogList.Dock = DockStyle.Top;
            dgvLogList.Location = new Point(0, 0);
            dgvLogList.Name = "dgvLogList";
            dgvLogList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogList.Size = new Size(784, 250);
            dgvLogList.TabIndex = 3;
            // 
            // frmGetLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 347);
            Controls.Add(dgvLogList);
            Controls.Add(btnGetLogs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmGetLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veriket Application";
            ((System.ComponentModel.ISupportInitialize)dgvLogList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetLogs;
        private DataGridView dgvLogList;
    }
}