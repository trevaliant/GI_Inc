
namespace GI_Inc
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApptReports = new System.Windows.Forms.Button();
            this.btnModifyCustomer = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnModifyAppointment = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnAgentSchedules = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvApptList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnCustomerReports = new System.Windows.Forms.Button();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 138);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(373, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Global Appointments, Inc Tracker.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(327, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dashboard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // btnApptReports
            // 
            this.btnApptReports.BackColor = System.Drawing.Color.Transparent;
            this.btnApptReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApptReports.Location = new System.Drawing.Point(254, 263);
            this.btnApptReports.Margin = new System.Windows.Forms.Padding(25);
            this.btnApptReports.Name = "btnApptReports";
            this.btnApptReports.Padding = new System.Windows.Forms.Padding(5);
            this.btnApptReports.Size = new System.Drawing.Size(168, 70);
            this.btnApptReports.TabIndex = 8;
            this.btnApptReports.Text = "Appointment Reports";
            this.btnApptReports.UseVisualStyleBackColor = false;
            this.btnApptReports.Click += new System.EventHandler(this.btnApptReports_Click);
            // 
            // btnModifyCustomer
            // 
            this.btnModifyCustomer.Location = new System.Drawing.Point(254, 25);
            this.btnModifyCustomer.Margin = new System.Windows.Forms.Padding(25);
            this.btnModifyCustomer.Name = "btnModifyCustomer";
            this.btnModifyCustomer.Padding = new System.Windows.Forms.Padding(15);
            this.btnModifyCustomer.Size = new System.Drawing.Size(168, 69);
            this.btnModifyCustomer.TabIndex = 1;
            this.btnModifyCustomer.Text = "Modify Client";
            this.btnModifyCustomer.UseVisualStyleBackColor = true;
            this.btnModifyCustomer.Click += new System.EventHandler(this.btnModifyCustomer_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(25, 144);
            this.btnAddAppointment.Margin = new System.Windows.Forms.Padding(25);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddAppointment.Size = new System.Drawing.Size(168, 69);
            this.btnAddAppointment.TabIndex = 3;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnModifyAppointment
            // 
            this.btnModifyAppointment.Location = new System.Drawing.Point(254, 144);
            this.btnModifyAppointment.Margin = new System.Windows.Forms.Padding(25);
            this.btnModifyAppointment.Name = "btnModifyAppointment";
            this.btnModifyAppointment.Padding = new System.Windows.Forms.Padding(5);
            this.btnModifyAppointment.Size = new System.Drawing.Size(168, 69);
            this.btnModifyAppointment.TabIndex = 4;
            this.btnModifyAppointment.Text = "Modify Appointment";
            this.btnModifyAppointment.UseVisualStyleBackColor = true;
            this.btnModifyAppointment.Click += new System.EventHandler(this.btnModifyAppointment_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(25, 25);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(25);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Padding = new System.Windows.Forms.Padding(12);
            this.btnAddCustomer.Size = new System.Drawing.Size(168, 69);
            this.btnAddCustomer.TabIndex = 0;
            this.btnAddCustomer.Text = "Add Client";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnAgentSchedules
            // 
            this.btnAgentSchedules.BackColor = System.Drawing.Color.Transparent;
            this.btnAgentSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgentSchedules.Location = new System.Drawing.Point(25, 263);
            this.btnAgentSchedules.Margin = new System.Windows.Forms.Padding(25);
            this.btnAgentSchedules.Name = "btnAgentSchedules";
            this.btnAgentSchedules.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgentSchedules.Size = new System.Drawing.Size(168, 69);
            this.btnAgentSchedules.TabIndex = 7;
            this.btnAgentSchedules.Text = "Agent Information";
            this.btnAgentSchedules.UseVisualStyleBackColor = false;
            this.btnAgentSchedules.Click += new System.EventHandler(this.btnAgentSchedules_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(781, 746);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 57);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvApptList
            // 
            this.dgvApptList.AllowUserToAddRows = false;
            this.dgvApptList.AllowUserToDeleteRows = false;
            this.dgvApptList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApptList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApptList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvApptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApptList.Location = new System.Drawing.Point(73, 641);
            this.dgvApptList.Name = "dgvApptList";
            this.dgvApptList.ReadOnly = true;
            this.dgvApptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApptList.Size = new System.Drawing.Size(686, 162);
            this.dgvApptList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(237, 586);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "Upcoming Appointments";
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(484, 25);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(25);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Padding = new System.Windows.Forms.Padding(15);
            this.btnDeleteCustomer.Size = new System.Drawing.Size(168, 69);
            this.btnDeleteCustomer.TabIndex = 2;
            this.btnDeleteCustomer.Text = "Deactivate Client";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnCustomerReports
            // 
            this.btnCustomerReports.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerReports.Location = new System.Drawing.Point(484, 263);
            this.btnCustomerReports.Margin = new System.Windows.Forms.Padding(25);
            this.btnCustomerReports.Name = "btnCustomerReports";
            this.btnCustomerReports.Padding = new System.Windows.Forms.Padding(5);
            this.btnCustomerReports.Size = new System.Drawing.Size(168, 70);
            this.btnCustomerReports.TabIndex = 6;
            this.btnCustomerReports.Text = "Customer Reports";
            this.btnCustomerReports.UseVisualStyleBackColor = false;
            this.btnCustomerReports.Click += new System.EventHandler(this.btnCustomerReports_Click);
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAppointment.Location = new System.Drawing.Point(484, 144);
            this.btnDeleteAppointment.Margin = new System.Windows.Forms.Padding(25);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteAppointment.Size = new System.Drawing.Size(168, 69);
            this.btnDeleteAppointment.TabIndex = 5;
            this.btnDeleteAppointment.Text = "Deactivate Appointment";
            this.btnDeleteAppointment.UseVisualStyleBackColor = true;
            this.btnDeleteAppointment.Click += new System.EventHandler(this.btnDeleteAppointment_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.btnApptReports, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteAppointment, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteCustomer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnModifyCustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddAppointment, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnModifyAppointment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddCustomer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAgentSchedules, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCustomerReports, 1, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(73, 186);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 358);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(918, 815);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvApptList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModifyAppointment;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnModifyCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAgentSchedules;
        private System.Windows.Forms.Button btnApptReports;
        private System.Windows.Forms.DataGridView dgvApptList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnDeleteAppointment;
        private System.Windows.Forms.Button btnCustomerReports;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}