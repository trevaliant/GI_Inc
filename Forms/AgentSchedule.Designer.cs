
namespace GI_Inc.Forms
{
    partial class AgentSchedule
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentSchedule));
            System.Windows.Forms.Label agentIdLabel;
            System.Windows.Forms.Label agentNameLabel;
            System.Windows.Forms.Label agentDepartmentLabel;
            System.Windows.Forms.Label agentShiftLabel;
            System.Windows.Forms.Label workDay1Label;
            System.Windows.Forms.Label workDay2Label;
            System.Windows.Forms.Label workDay3Label;
            System.Windows.Forms.Label workDay4Label;
            System.Windows.Forms.Label workDay5Label;
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.u06P8DDataSet5 = new GI_Inc.DataSources.U06P8DDataSet5();
            this.agentSchedulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agentSchedulesTableAdapter = new GI_Inc.DataSources.U06P8DDataSet5TableAdapters.agentSchedulesTableAdapter();
            this.tableAdapterManager = new GI_Inc.DataSources.U06P8DDataSet5TableAdapters.TableAdapterManager();
            this.agentSchedulesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.agentSchedulesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.agentIdTextBox = new System.Windows.Forms.TextBox();
            this.agentNameTextBox = new System.Windows.Forms.TextBox();
            this.agentDepartmentTextBox = new System.Windows.Forms.TextBox();
            this.agentShiftTextBox = new System.Windows.Forms.TextBox();
            this.workDay1TextBox = new System.Windows.Forms.TextBox();
            this.workDay2TextBox = new System.Windows.Forms.TextBox();
            this.workDay3TextBox = new System.Windows.Forms.TextBox();
            this.workDay4TextBox = new System.Windows.Forms.TextBox();
            this.workDay5TextBox = new System.Windows.Forms.TextBox();
            this.txtViewSchedules = new System.Windows.Forms.RichTextBox();
            agentIdLabel = new System.Windows.Forms.Label();
            agentNameLabel = new System.Windows.Forms.Label();
            agentDepartmentLabel = new System.Windows.Forms.Label();
            agentShiftLabel = new System.Windows.Forms.Label();
            workDay1Label = new System.Windows.Forms.Label();
            workDay2Label = new System.Windows.Forms.Label();
            workDay3Label = new System.Windows.Forms.Label();
            workDay4Label = new System.Windows.Forms.Label();
            workDay5Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.u06P8DDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentSchedulesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentSchedulesBindingNavigator)).BeginInit();
            this.agentSchedulesBindingNavigator.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(837, 138);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(343, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 86);
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
            this.label1.Location = new System.Drawing.Point(115, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(605, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To Global Internetworking, Inc.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.txtViewSchedules);
            this.panel2.Controls.Add(agentIdLabel);
            this.panel2.Controls.Add(this.agentIdTextBox);
            this.panel2.Controls.Add(agentNameLabel);
            this.panel2.Controls.Add(this.agentNameTextBox);
            this.panel2.Controls.Add(agentDepartmentLabel);
            this.panel2.Controls.Add(this.agentDepartmentTextBox);
            this.panel2.Controls.Add(agentShiftLabel);
            this.panel2.Controls.Add(this.agentShiftTextBox);
            this.panel2.Controls.Add(workDay1Label);
            this.panel2.Controls.Add(this.workDay1TextBox);
            this.panel2.Controls.Add(workDay2Label);
            this.panel2.Controls.Add(this.workDay2TextBox);
            this.panel2.Controls.Add(workDay3Label);
            this.panel2.Controls.Add(this.workDay3TextBox);
            this.panel2.Controls.Add(workDay4Label);
            this.panel2.Controls.Add(this.workDay4TextBox);
            this.panel2.Controls.Add(workDay5Label);
            this.panel2.Controls.Add(this.workDay5TextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 587);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.GhostWhite;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(268, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "Agent Schedules";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // u06P8DDataSet5
            // 
            this.u06P8DDataSet5.DataSetName = "U06P8DDataSet5";
            this.u06P8DDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // agentSchedulesBindingSource
            // 
            this.agentSchedulesBindingSource.DataMember = "agentSchedules";
            this.agentSchedulesBindingSource.DataSource = this.u06P8DDataSet5;
            // 
            // agentSchedulesTableAdapter
            // 
            this.agentSchedulesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agentSchedulesTableAdapter = this.agentSchedulesTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = GI_Inc.DataSources.U06P8DDataSet5TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // agentSchedulesBindingNavigator
            // 
            this.agentSchedulesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.agentSchedulesBindingNavigator.BindingSource = this.agentSchedulesBindingSource;
            this.agentSchedulesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.agentSchedulesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.agentSchedulesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.agentSchedulesBindingNavigatorSaveItem});
            this.agentSchedulesBindingNavigator.Location = new System.Drawing.Point(0, 138);
            this.agentSchedulesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.agentSchedulesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.agentSchedulesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.agentSchedulesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.agentSchedulesBindingNavigator.Name = "agentSchedulesBindingNavigator";
            this.agentSchedulesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.agentSchedulesBindingNavigator.Size = new System.Drawing.Size(837, 25);
            this.agentSchedulesBindingNavigator.TabIndex = 4;
            this.agentSchedulesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // agentSchedulesBindingNavigatorSaveItem
            // 
            this.agentSchedulesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.agentSchedulesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("agentSchedulesBindingNavigatorSaveItem.Image")));
            this.agentSchedulesBindingNavigatorSaveItem.Name = "agentSchedulesBindingNavigatorSaveItem";
            this.agentSchedulesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.agentSchedulesBindingNavigatorSaveItem.Text = "Save Data";
            this.agentSchedulesBindingNavigatorSaveItem.Click += new System.EventHandler(this.agentSchedulesBindingNavigatorSaveItem_Click);
            // 
            // agentIdLabel
            // 
            agentIdLabel.AutoSize = true;
            agentIdLabel.Location = new System.Drawing.Point(37, 121);
            agentIdLabel.Name = "agentIdLabel";
            agentIdLabel.Size = new System.Drawing.Size(49, 13);
            agentIdLabel.TabIndex = 3;
            agentIdLabel.Text = "agent Id:";
            // 
            // agentIdTextBox
            // 
            this.agentIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "agentId", true));
            this.agentIdTextBox.Location = new System.Drawing.Point(138, 118);
            this.agentIdTextBox.Name = "agentIdTextBox";
            this.agentIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.agentIdTextBox.TabIndex = 4;
            // 
            // agentNameLabel
            // 
            agentNameLabel.AutoSize = true;
            agentNameLabel.Location = new System.Drawing.Point(37, 147);
            agentNameLabel.Name = "agentNameLabel";
            agentNameLabel.Size = new System.Drawing.Size(68, 13);
            agentNameLabel.TabIndex = 5;
            agentNameLabel.Text = "agent Name:";
            // 
            // agentNameTextBox
            // 
            this.agentNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "agentName", true));
            this.agentNameTextBox.Location = new System.Drawing.Point(138, 144);
            this.agentNameTextBox.Name = "agentNameTextBox";
            this.agentNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.agentNameTextBox.TabIndex = 6;
            // 
            // agentDepartmentLabel
            // 
            agentDepartmentLabel.AutoSize = true;
            agentDepartmentLabel.Location = new System.Drawing.Point(37, 173);
            agentDepartmentLabel.Name = "agentDepartmentLabel";
            agentDepartmentLabel.Size = new System.Drawing.Size(95, 13);
            agentDepartmentLabel.TabIndex = 7;
            agentDepartmentLabel.Text = "agent Department:";
            // 
            // agentDepartmentTextBox
            // 
            this.agentDepartmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "agentDepartment", true));
            this.agentDepartmentTextBox.Location = new System.Drawing.Point(138, 170);
            this.agentDepartmentTextBox.Name = "agentDepartmentTextBox";
            this.agentDepartmentTextBox.Size = new System.Drawing.Size(100, 20);
            this.agentDepartmentTextBox.TabIndex = 8;
            // 
            // agentShiftLabel
            // 
            agentShiftLabel.AutoSize = true;
            agentShiftLabel.Location = new System.Drawing.Point(37, 199);
            agentShiftLabel.Name = "agentShiftLabel";
            agentShiftLabel.Size = new System.Drawing.Size(61, 13);
            agentShiftLabel.TabIndex = 9;
            agentShiftLabel.Text = "agent Shift:";
            // 
            // agentShiftTextBox
            // 
            this.agentShiftTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "agentShift", true));
            this.agentShiftTextBox.Location = new System.Drawing.Point(138, 196);
            this.agentShiftTextBox.Name = "agentShiftTextBox";
            this.agentShiftTextBox.Size = new System.Drawing.Size(100, 20);
            this.agentShiftTextBox.TabIndex = 10;
            // 
            // workDay1Label
            // 
            workDay1Label.AutoSize = true;
            workDay1Label.Location = new System.Drawing.Point(37, 225);
            workDay1Label.Name = "workDay1Label";
            workDay1Label.Size = new System.Drawing.Size(61, 13);
            workDay1Label.TabIndex = 11;
            workDay1Label.Text = "work Day1:";
            // 
            // workDay1TextBox
            // 
            this.workDay1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "workDay1", true));
            this.workDay1TextBox.Location = new System.Drawing.Point(138, 222);
            this.workDay1TextBox.Name = "workDay1TextBox";
            this.workDay1TextBox.Size = new System.Drawing.Size(100, 20);
            this.workDay1TextBox.TabIndex = 12;
            // 
            // workDay2Label
            // 
            workDay2Label.AutoSize = true;
            workDay2Label.Location = new System.Drawing.Point(37, 251);
            workDay2Label.Name = "workDay2Label";
            workDay2Label.Size = new System.Drawing.Size(61, 13);
            workDay2Label.TabIndex = 13;
            workDay2Label.Text = "work Day2:";
            // 
            // workDay2TextBox
            // 
            this.workDay2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "workDay2", true));
            this.workDay2TextBox.Location = new System.Drawing.Point(138, 248);
            this.workDay2TextBox.Name = "workDay2TextBox";
            this.workDay2TextBox.Size = new System.Drawing.Size(100, 20);
            this.workDay2TextBox.TabIndex = 14;
            // 
            // workDay3Label
            // 
            workDay3Label.AutoSize = true;
            workDay3Label.Location = new System.Drawing.Point(37, 277);
            workDay3Label.Name = "workDay3Label";
            workDay3Label.Size = new System.Drawing.Size(61, 13);
            workDay3Label.TabIndex = 15;
            workDay3Label.Text = "work Day3:";
            // 
            // workDay3TextBox
            // 
            this.workDay3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "workDay3", true));
            this.workDay3TextBox.Location = new System.Drawing.Point(138, 274);
            this.workDay3TextBox.Name = "workDay3TextBox";
            this.workDay3TextBox.Size = new System.Drawing.Size(100, 20);
            this.workDay3TextBox.TabIndex = 16;
            // 
            // workDay4Label
            // 
            workDay4Label.AutoSize = true;
            workDay4Label.Location = new System.Drawing.Point(37, 303);
            workDay4Label.Name = "workDay4Label";
            workDay4Label.Size = new System.Drawing.Size(61, 13);
            workDay4Label.TabIndex = 17;
            workDay4Label.Text = "work Day4:";
            // 
            // workDay4TextBox
            // 
            this.workDay4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "workDay4", true));
            this.workDay4TextBox.Location = new System.Drawing.Point(138, 300);
            this.workDay4TextBox.Name = "workDay4TextBox";
            this.workDay4TextBox.Size = new System.Drawing.Size(100, 20);
            this.workDay4TextBox.TabIndex = 18;
            // 
            // workDay5Label
            // 
            workDay5Label.AutoSize = true;
            workDay5Label.Location = new System.Drawing.Point(37, 329);
            workDay5Label.Name = "workDay5Label";
            workDay5Label.Size = new System.Drawing.Size(61, 13);
            workDay5Label.TabIndex = 19;
            workDay5Label.Text = "work Day5:";
            // 
            // workDay5TextBox
            // 
            this.workDay5TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentSchedulesBindingSource, "workDay5", true));
            this.workDay5TextBox.Location = new System.Drawing.Point(138, 326);
            this.workDay5TextBox.Name = "workDay5TextBox";
            this.workDay5TextBox.Size = new System.Drawing.Size(100, 20);
            this.workDay5TextBox.TabIndex = 20;
            // 
            // txtViewSchedules
            // 
            this.txtViewSchedules.Location = new System.Drawing.Point(378, 108);
            this.txtViewSchedules.Name = "txtViewSchedules";
            this.txtViewSchedules.Size = new System.Drawing.Size(359, 356);
            this.txtViewSchedules.TabIndex = 21;
            this.txtViewSchedules.Text = "";
            // 
            // AgentSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 725);
            this.Controls.Add(this.agentSchedulesBindingNavigator);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgentSchedule";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgentSchedule";
            this.Load += new System.EventHandler(this.AgentSchedule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.u06P8DDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentSchedulesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentSchedulesBindingNavigator)).EndInit();
            this.agentSchedulesBindingNavigator.ResumeLayout(false);
            this.agentSchedulesBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private DataSources.U06P8DDataSet5 u06P8DDataSet5;
        private System.Windows.Forms.BindingSource agentSchedulesBindingSource;
        private DataSources.U06P8DDataSet5TableAdapters.agentSchedulesTableAdapter agentSchedulesTableAdapter;
        private DataSources.U06P8DDataSet5TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator agentSchedulesBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton agentSchedulesBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox agentIdTextBox;
        private System.Windows.Forms.TextBox agentNameTextBox;
        private System.Windows.Forms.TextBox agentDepartmentTextBox;
        private System.Windows.Forms.TextBox agentShiftTextBox;
        private System.Windows.Forms.TextBox workDay1TextBox;
        private System.Windows.Forms.TextBox workDay2TextBox;
        private System.Windows.Forms.TextBox workDay3TextBox;
        private System.Windows.Forms.TextBox workDay4TextBox;
        private System.Windows.Forms.TextBox workDay5TextBox;
        private System.Windows.Forms.RichTextBox txtViewSchedules;
    }
}