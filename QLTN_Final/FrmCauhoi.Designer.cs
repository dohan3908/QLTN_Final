namespace QLTN_Final
{
    partial class FrmCauhoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCauhoi));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grdDSCH = new System.Windows.Forms.DataGridView();
            this.MaCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAnA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAnB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DapAnDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comGT = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comTruong = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDung = new System.Windows.Forms.TextBox();
            this.lblDung = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCauHoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDel = new System.Windows.Forms.Button();
            this.toolTip8 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolTip9 = new System.Windows.Forms.ToolTip(this.components);
            this.btnInbaocao = new System.Windows.Forms.Button();
            this.toolTip10 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip11 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.toolTip12 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSCH)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1303, 55);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(1249, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 8;
            this.toolTip12.SetToolTip(this.btnBack, "Home");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // grdDSCH
            // 
            this.grdDSCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDSCH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCauHoi,
            this.MaHP,
            this.MaGV,
            this.NoiDung,
            this.DapAnA,
            this.DapAnB,
            this.DapAnC,
            this.DapAnD,
            this.DapAnDung,
            this.LoaiCauHoi,
            this.MucDo});
            this.grdDSCH.Location = new System.Drawing.Point(3, 62);
            this.grdDSCH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDSCH.Name = "grdDSCH";
            this.grdDSCH.RowHeadersWidth = 51;
            this.grdDSCH.RowTemplate.Height = 24;
            this.grdDSCH.Size = new System.Drawing.Size(795, 404);
            this.grdDSCH.TabIndex = 9;
            this.grdDSCH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MaCauHoi
            // 
            this.MaCauHoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaCauHoi.DataPropertyName = "MaCauHoi";
            this.MaCauHoi.HeaderText = "Mã Câu Hỏi";
            this.MaCauHoi.MinimumWidth = 6;
            this.MaCauHoi.Name = "MaCauHoi";
            this.MaCauHoi.Width = 128;
            // 
            // MaHP
            // 
            this.MaHP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaHP.DataPropertyName = "MaHP";
            this.MaHP.HeaderText = "Mã học phần";
            this.MaHP.MinimumWidth = 6;
            this.MaHP.Name = "MaHP";
            this.MaHP.Width = 137;
            // 
            // MaGV
            // 
            this.MaGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaGV.DataPropertyName = "MaGV";
            this.MaGV.HeaderText = "Mã Giảng Viên";
            this.MaGV.MinimumWidth = 6;
            this.MaGV.Name = "MaGV";
            this.MaGV.Width = 150;
            // 
            // NoiDung
            // 
            this.NoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung ";
            this.NoiDung.MinimumWidth = 6;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 115;
            // 
            // DapAnA
            // 
            this.DapAnA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DapAnA.DataPropertyName = "DapAnA";
            this.DapAnA.HeaderText = "Đáp án A";
            this.DapAnA.MinimumWidth = 6;
            this.DapAnA.Name = "DapAnA";
            this.DapAnA.Width = 112;
            // 
            // DapAnB
            // 
            this.DapAnB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DapAnB.DataPropertyName = "DapAnB";
            this.DapAnB.HeaderText = "Đáp án B";
            this.DapAnB.MinimumWidth = 6;
            this.DapAnB.Name = "DapAnB";
            this.DapAnB.Width = 112;
            // 
            // DapAnC
            // 
            this.DapAnC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DapAnC.DataPropertyName = "DapAnC";
            this.DapAnC.HeaderText = "Đáp án C";
            this.DapAnC.MinimumWidth = 6;
            this.DapAnC.Name = "DapAnC";
            this.DapAnC.Width = 112;
            // 
            // DapAnD
            // 
            this.DapAnD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DapAnD.DataPropertyName = "DapAnD";
            this.DapAnD.HeaderText = "Đáp án D";
            this.DapAnD.MinimumWidth = 6;
            this.DapAnD.Name = "DapAnD";
            this.DapAnD.Width = 113;
            // 
            // DapAnDung
            // 
            this.DapAnDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DapAnDung.DataPropertyName = "DapAnDung";
            this.DapAnDung.HeaderText = "Đáp án Đúng";
            this.DapAnDung.MinimumWidth = 6;
            this.DapAnDung.Name = "DapAnDung";
            this.DapAnDung.Width = 140;
            // 
            // LoaiCauHoi
            // 
            this.LoaiCauHoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LoaiCauHoi.DataPropertyName = "LoaiCauHoi";
            this.LoaiCauHoi.HeaderText = "Loại câu hỏi";
            this.LoaiCauHoi.MinimumWidth = 6;
            this.LoaiCauHoi.Name = "LoaiCauHoi";
            this.LoaiCauHoi.Width = 130;
            // 
            // MucDo
            // 
            this.MucDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MucDo.DataPropertyName = "MucDo";
            this.MucDo.HeaderText = "Mức độ";
            this.MucDo.MinimumWidth = 6;
            this.MucDo.Name = "MucDo";
            this.MucDo.Width = 97;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.comGT);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comTruong);
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(826, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(451, 114);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Học phần";
            // 
            // comGT
            // 
            this.comGT.FormattingEnabled = true;
            this.comGT.Items.AddRange(new object[] {
            "Chủ nghĩa xã hội khoa học",
            "Kinh tế vi mô",
            "Hệ thống thông tin quản lý"});
            this.comGT.Location = new System.Drawing.Point(161, 30);
            this.comGT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comGT.Name = "comGT";
            this.comGT.Size = new System.Drawing.Size(283, 28);
            this.comGT.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(412, 68);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(33, 35);
            this.btnRefresh.TabIndex = 16;
            this.toolTip11.SetToolTip(this.btnRefresh, "Nạp lại");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter.Location = new System.Drawing.Point(372, 68);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(33, 35);
            this.btnFilter.TabIndex = 15;
            this.toolTip10.SetToolTip(this.btnFilter, "Lọc");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 14;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comTruong
            // 
            this.comTruong.FormattingEnabled = true;
            this.comTruong.Items.AddRange(new object[] {
            "MaHP",
            "MaGV",
            "LoaiCauHoi",
            "MucDo"});
            this.comTruong.Location = new System.Drawing.Point(17, 30);
            this.comTruong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comTruong.Name = "comTruong";
            this.comTruong.Size = new System.Drawing.Size(137, 28);
            this.comTruong.TabIndex = 12;
            this.comTruong.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtDung);
            this.groupBox3.Controls.Add(this.lblDung);
            this.groupBox3.Controls.Add(this.txtD);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtC);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtB);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtA);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtNoiDung);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtMaCauHoi);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.Location = new System.Drawing.Point(826, 184);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(451, 364);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết ";
            // 
            // txtDung
            // 
            this.txtDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDung.Location = new System.Drawing.Point(53, 326);
            this.txtDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDung.Name = "txtDung";
            this.txtDung.Size = new System.Drawing.Size(383, 28);
            this.txtDung.TabIndex = 13;
            // 
            // lblDung
            // 
            this.lblDung.AutoSize = true;
            this.lblDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDung.Location = new System.Drawing.Point(12, 330);
            this.lblDung.Name = "lblDung";
            this.lblDung.Size = new System.Drawing.Size(29, 22);
            this.lblDung.TabIndex = 12;
            this.lblDung.Text = "T.";
            // 
            // txtD
            // 
            this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.Location = new System.Drawing.Point(54, 275);
            this.txtD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(383, 28);
            this.txtD.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "D. ";
            // 
            // txtC
            // 
            this.txtC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(54, 225);
            this.txtC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(383, 28);
            this.txtC.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "C. ";
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(53, 171);
            this.txtB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(384, 28);
            this.txtB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "B. ";
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(54, 120);
            this.txtA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(383, 28);
            this.txtA.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "A. ";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(108, 74);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(329, 28);
            this.txtNoiDung.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Câu hỏi: ";
            // 
            // txtMaCauHoi
            // 
            this.txtMaCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCauHoi.Location = new System.Drawing.Point(134, 35);
            this.txtMaCauHoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaCauHoi.Name = "txtMaCauHoi";
            this.txtMaCauHoi.Size = new System.Drawing.Size(303, 28);
            this.txtMaCauHoi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã câu hỏi: ";
            // 
            // btnFirst
            // 
            this.btnFirst.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFirst.BackgroundImage")));
            this.btnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirst.Location = new System.Drawing.Point(7, 12);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 44);
            this.btnFirst.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnFirst, "Dòng đầu tiên ");
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLast.BackgroundImage")));
            this.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLast.Location = new System.Drawing.Point(69, 12);
            this.btnLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 44);
            this.btnLast.TabIndex = 1;
            this.toolTip2.SetToolTip(this.btnLast, "Dòng cuối cùng");
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Location = new System.Drawing.Point(130, 12);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 44);
            this.btnNext.TabIndex = 2;
            this.toolTip3.SetToolTip(this.btnNext, "Xuống dưới");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPre.BackgroundImage")));
            this.btnPre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPre.Location = new System.Drawing.Point(192, 14);
            this.btnPre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(39, 44);
            this.btnPre.TabIndex = 3;
            this.toolTip4.SetToolTip(this.btnPre, "Lên trên");
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnPre);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Location = new System.Drawing.Point(14, 485);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(260, 62);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Location = new System.Drawing.Point(86, 11);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 44);
            this.btnEdit.TabIndex = 5;
            this.toolTip5.SetToolTip(this.btnEdit, "Sửa câu hỏi ");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(22, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 44);
            this.btnAdd.TabIndex = 4;
            this.toolTip5.SetToolTip(this.btnAdd, "Thêm câu hỏi");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDel.BackgroundImage")));
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.Location = new System.Drawing.Point(148, 11);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(39, 44);
            this.btnDel.TabIndex = 6;
            this.toolTip7.SetToolTip(this.btnDel, "Xóa câu hỏi");
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Location = new System.Drawing.Point(212, 11);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(39, 44);
            this.btnUpdate.TabIndex = 7;
            this.toolTip8.SetToolTip(this.btnUpdate, "Cập nhập");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnInbaocao
            // 
            this.btnInbaocao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInbaocao.BackgroundImage")));
            this.btnInbaocao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInbaocao.Location = new System.Drawing.Point(744, 485);
            this.btnInbaocao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInbaocao.Name = "btnInbaocao";
            this.btnInbaocao.Size = new System.Drawing.Size(54, 62);
            this.btnInbaocao.TabIndex = 29;
            this.toolTip9.SetToolTip(this.btnInbaocao, "Xuất báo cáo");
            this.btnInbaocao.UseVisualStyleBackColor = true;
            this.btnInbaocao.Click += new System.EventHandler(this.btnInbaocao_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.btnDel);
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Location = new System.Drawing.Point(342, 485);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(258, 62);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // FrmCauhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 562);
            this.Controls.Add(this.btnInbaocao);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDSCH);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCauhoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCauhoi";
            this.Load += new System.EventHandler(this.FrmCauhoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDSCH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBack;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView grdDSCH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comTruong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCauHoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comGT;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip8;
        private System.Windows.Forms.ToolTip toolTip11;
        private System.Windows.Forms.ToolTip toolTip10;
        private System.Windows.Forms.ToolTip toolTip9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtDung;
        private System.Windows.Forms.Label lblDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAnA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAnB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DapAnDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucDo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInbaocao;
        private System.Windows.Forms.ToolTip toolTip12;
    }
}