namespace QuanLyHocSinh
{
    partial class fHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.listBox1 = new DevComponents.DotNetBar.ListBoxAdv();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtgvSystem = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblWatch1 = new DevComponents.DotNetBar.LabelX();
            this.txtSearchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearchStudent = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchClass = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchFaculty = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchSubject = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.tvSystem = new System.Windows.Forms.TreeView();
            this.btnShowClass = new DevComponents.DotNetBar.ButtonX();
            this.btnShowFaculty = new DevComponents.DotNetBar.ButtonX();
            this.btnShowSubject = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSystem)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(122)))), ((int)(((byte)(81))))), System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(23)))), ((int)(((byte)(13))))));
            // 
            // listBox1
            // 
            this.listBox1.AutoScroll = true;
            // 
            // 
            // 
            this.listBox1.BackgroundStyle.Class = "ListBoxAdv";
            this.listBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listBox1.CheckStateMember = null;
            this.listBox1.ContainerControlProcessDialogKey = true;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.DragDropSupport = true;
            this.listBox1.Location = new System.Drawing.Point(0, 500);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 181);
            this.listBox1.TabIndex = 0;
            this.listBox1.Text = "listBoxAdv1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.Controls.Add(this.listBox1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(178, 681);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::QuanLyHocSinh.Properties.Resources.anh_nen_cho_word_dep_nhat_111903694;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dtgvSystem
            // 
            this.dtgvSystem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvSystem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvSystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvSystem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvSystem.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvSystem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvSystem.EnableHeadersVisualStyles = false;
            this.dtgvSystem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgvSystem.Location = new System.Drawing.Point(0, 114);
            this.dtgvSystem.Name = "dtgvSystem";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvSystem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvSystem.Size = new System.Drawing.Size(615, 567);
            this.dtgvSystem.TabIndex = 6;
            this.dtgvSystem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSystem_CellContentClick);
            // 
            // lblWatch1
            // 
            // 
            // 
            // 
            this.lblWatch1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWatch1.Location = new System.Drawing.Point(559, 3);
            this.lblWatch1.Name = "lblWatch1";
            this.lblWatch1.Size = new System.Drawing.Size(75, 23);
            this.lblWatch1.TabIndex = 5;
            this.lblWatch1.Text = "Đồng hồ";
            // 
            // txtSearchName
            // 
            // 
            // 
            // 
            this.txtSearchName.Border.Class = "TextBoxBorder";
            this.txtSearchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchName.DisabledBackColor = System.Drawing.Color.White;
            this.txtSearchName.Location = new System.Drawing.Point(20, 12);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.PreventEnterBeep = true;
            this.txtSearchName.Size = new System.Drawing.Size(405, 21);
            this.txtSearchName.TabIndex = 0;
            this.txtSearchName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchStudent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStudent.Location = new System.Drawing.Point(20, 52);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(80, 25);
            this.btnSearchStudent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchStudent.TabIndex = 1;
            this.btnSearchStudent.Text = "Tìm học sinh";
            this.btnSearchStudent.Click += new System.EventHandler(this.btnSearchStudent_Click_1);
            // 
            // btnSearchClass
            // 
            this.btnSearchClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchClass.Location = new System.Drawing.Point(129, 52);
            this.btnSearchClass.Name = "btnSearchClass";
            this.btnSearchClass.Size = new System.Drawing.Size(80, 25);
            this.btnSearchClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchClass.TabIndex = 2;
            this.btnSearchClass.Text = "Tìm lớp";
            this.btnSearchClass.Click += new System.EventHandler(this.btnSearchClass_Click_1);
            // 
            // btnSearchFaculty
            // 
            this.btnSearchFaculty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchFaculty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFaculty.Location = new System.Drawing.Point(238, 52);
            this.btnSearchFaculty.Name = "btnSearchFaculty";
            this.btnSearchFaculty.Size = new System.Drawing.Size(80, 25);
            this.btnSearchFaculty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchFaculty.TabIndex = 3;
            this.btnSearchFaculty.Text = "Tìm khoa";
            this.btnSearchFaculty.Click += new System.EventHandler(this.btnSearchFaculty_Click_1);
            // 
            // btnSearchSubject
            // 
            this.btnSearchSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchSubject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSubject.Location = new System.Drawing.Point(346, 52);
            this.btnSearchSubject.Name = "btnSearchSubject";
            this.btnSearchSubject.Size = new System.Drawing.Size(80, 25);
            this.btnSearchSubject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchSubject.TabIndex = 4;
            this.btnSearchSubject.Text = "Tìm môn học";
            this.btnSearchSubject.Click += new System.EventHandler(this.btnSearchSubject_Click_1);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnSearchSubject);
            this.panelEx2.Controls.Add(this.btnSearchFaculty);
            this.panelEx2.Controls.Add(this.btnSearchClass);
            this.panelEx2.Controls.Add(this.btnSearchStudent);
            this.panelEx2.Controls.Add(this.txtSearchName);
            this.panelEx2.Controls.Add(this.lblWatch1);
            this.panelEx2.Controls.Add(this.dtgvSystem);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelEx2.Location = new System.Drawing.Point(449, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(615, 681);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 2;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.tvSystem);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx4.Location = new System.Drawing.Point(0, 271);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(271, 410);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            // 
            // tvSystem
            // 
            this.tvSystem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tvSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSystem.ForeColor = System.Drawing.Color.Black;
            this.tvSystem.FullRowSelect = true;
            this.tvSystem.Location = new System.Drawing.Point(0, 0);
            this.tvSystem.Name = "tvSystem";
            this.tvSystem.Size = new System.Drawing.Size(271, 410);
            this.tvSystem.TabIndex = 0;
            this.tvSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSystem_AfterSelect_1);
            // 
            // btnShowClass
            // 
            this.btnShowClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowClass.Location = new System.Drawing.Point(20, 10);
            this.btnShowClass.Name = "btnShowClass";
            this.btnShowClass.Size = new System.Drawing.Size(233, 23);
            this.btnShowClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowClass.TabIndex = 0;
            this.btnShowClass.Text = "Hiển thị lớp học";
            this.btnShowClass.Click += new System.EventHandler(this.btnShowClass_Click);
            // 
            // btnShowFaculty
            // 
            this.btnShowFaculty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowFaculty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowFaculty.Location = new System.Drawing.Point(20, 50);
            this.btnShowFaculty.Name = "btnShowFaculty";
            this.btnShowFaculty.Size = new System.Drawing.Size(233, 23);
            this.btnShowFaculty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowFaculty.TabIndex = 1;
            this.btnShowFaculty.Text = "Hiển thị khoa";
            this.btnShowFaculty.Click += new System.EventHandler(this.btnShowFaculty_Click);
            // 
            // btnShowSubject
            // 
            this.btnShowSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowSubject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSubject.Location = new System.Drawing.Point(20, 90);
            this.btnShowSubject.Name = "btnShowSubject";
            this.btnShowSubject.Size = new System.Drawing.Size(233, 23);
            this.btnShowSubject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowSubject.TabIndex = 2;
            this.btnShowSubject.Text = "Hiển thị môn học";
            this.btnShowSubject.Click += new System.EventHandler(this.btnShowSubject_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnShowSubject);
            this.panelEx3.Controls.Add(this.btnShowFaculty);
            this.panelEx3.Controls.Add(this.btnShowClass);
            this.panelEx3.Controls.Add(this.panelEx4);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(178, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(271, 681);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 1;
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSystem)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ListBoxAdv listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgvSystem;
        private DevComponents.DotNetBar.LabelX lblWatch1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchName;
        private DevComponents.DotNetBar.ButtonX btnSearchStudent;
        private DevComponents.DotNetBar.ButtonX btnSearchClass;
        private DevComponents.DotNetBar.ButtonX btnSearchFaculty;
        private DevComponents.DotNetBar.ButtonX btnSearchSubject;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private System.Windows.Forms.TreeView tvSystem;
        private DevComponents.DotNetBar.ButtonX btnShowClass;
        private DevComponents.DotNetBar.ButtonX btnShowFaculty;
        private DevComponents.DotNetBar.ButtonX btnShowSubject;
        private DevComponents.DotNetBar.PanelEx panelEx3;
    }
}