namespace Quan_Ly_Thuoc
{
    partial class FormHoaDonNhap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.cmbNVThucHien = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThanhTienHDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbThuoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddTHuoc = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.txtSL = new System.Windows.Forms.NumericUpDown();
            this.txtKhuyenMai = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewThuoc = new System.Windows.Forms.ListView();
            this.mathuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenthuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.km = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvCTHDN = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(894, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn nhập";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.txtDonGia, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblMaHD, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNgayNhap, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtMaHD, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayNhap, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbNCC, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTenNhanVien, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbNVThucHien, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblKhachHang, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtThanhTienHDN, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbThuoc, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnAddTHuoc, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnIn, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtSL, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtKhuyenMai, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(888, 212);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonGia.Location = new System.Drawing.Point(712, 87);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(173, 26);
            this.txtDonGia.TabIndex = 11;
            this.txtDonGia.Text = "0";
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHD.Location = new System.Drawing.Point(3, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(171, 42);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Mã hóa đơn:";
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayNhap.Location = new System.Drawing.Point(180, 128);
            this.txtNgayNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.Size = new System.Drawing.Size(349, 26);
            this.txtNgayNhap.TabIndex = 9;
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMaHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaHD.Location = new System.Drawing.Point(180, 2);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(349, 26);
            this.txtMaHD.TabIndex = 4;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayNhap.Location = new System.Drawing.Point(3, 126);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(171, 42);
            this.lblNgayNhap.TabIndex = 3;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // cmbNCC
            // 
            this.cmbNCC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNCC.FormattingEnabled = true;
            this.cmbNCC.Location = new System.Drawing.Point(180, 86);
            this.cmbNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNCC.Name = "cmbNCC";
            this.cmbNCC.Size = new System.Drawing.Size(349, 28);
            this.cmbNCC.TabIndex = 8;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNhanVien.Location = new System.Drawing.Point(3, 42);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(171, 42);
            this.lblTenNhanVien.TabIndex = 0;
            this.lblTenNhanVien.Text = "Nhân viên thực hiện:";
            // 
            // cmbNVThucHien
            // 
            this.cmbNVThucHien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbNVThucHien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNVThucHien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNVThucHien.FormattingEnabled = true;
            this.cmbNVThucHien.Location = new System.Drawing.Point(180, 44);
            this.cmbNVThucHien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNVThucHien.Name = "cmbNVThucHien";
            this.cmbNVThucHien.Size = new System.Drawing.Size(349, 28);
            this.cmbNVThucHien.TabIndex = 7;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhachHang.Location = new System.Drawing.Point(3, 84);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(171, 42);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Nhà cung cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 44);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tổng tiền:";
            // 
            // txtThanhTienHDN
            // 
            this.txtThanhTienHDN.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtThanhTienHDN.Location = new System.Drawing.Point(180, 170);
            this.txtThanhTienHDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThanhTienHDN.Name = "txtThanhTienHDN";
            this.txtThanhTienHDN.ReadOnly = true;
            this.txtThanhTienHDN.Size = new System.Drawing.Size(134, 26);
            this.txtThanhTienHDN.TabIndex = 11;
            this.txtThanhTienHDN.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(535, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 42);
            this.label2.TabIndex = 12;
            this.label2.Text = "Thuốc:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(535, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 42);
            this.label3.TabIndex = 13;
            this.label3.Text = "Số lượng:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbThuoc
            // 
            this.cmbThuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbThuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbThuoc.FormattingEnabled = true;
            this.cmbThuoc.Location = new System.Drawing.Point(712, 2);
            this.cmbThuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbThuoc.Name = "cmbThuoc";
            this.cmbThuoc.Size = new System.Drawing.Size(173, 28);
            this.cmbThuoc.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(535, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 42);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đơn giá:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(535, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 42);
            this.label5.TabIndex = 17;
            this.label5.Text = "Khuyến mãi:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddTHuoc
            // 
            this.btnAddTHuoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddTHuoc.Location = new System.Drawing.Point(535, 170);
            this.btnAddTHuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTHuoc.Name = "btnAddTHuoc";
            this.btnAddTHuoc.Size = new System.Drawing.Size(125, 40);
            this.btnAddTHuoc.TabIndex = 20;
            this.btnAddTHuoc.Text = "Thêm thuốc";
            this.btnAddTHuoc.UseVisualStyleBackColor = true;
            this.btnAddTHuoc.Click += new System.EventHandler(this.btnAddTHuoc_Click);
            // 
            // btnIn
            // 
            this.btnIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIn.Location = new System.Drawing.Point(712, 170);
            this.btnIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(74, 40);
            this.btnIn.TabIndex = 21;
            this.btnIn.Text = "In HD";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // txtSL
            // 
            this.txtSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSL.Location = new System.Drawing.Point(712, 44);
            this.txtSL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(173, 26);
            this.txtSL.TabIndex = 22;
            this.txtSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtKhuyenMai
            // 
            this.txtKhuyenMai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKhuyenMai.Location = new System.Drawing.Point(712, 129);
            this.txtKhuyenMai.Name = "txtKhuyenMai";
            this.txtKhuyenMai.Size = new System.Drawing.Size(173, 26);
            this.txtKhuyenMai.TabIndex = 23;
            this.txtKhuyenMai.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewThuoc, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.52669F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.47331F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 562);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // listViewThuoc
            // 
            this.listViewThuoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mathuoc,
            this.tenthuoc,
            this.sl,
            this.dg,
            this.km});
            this.listViewThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewThuoc.FullRowSelect = true;
            this.listViewThuoc.GridLines = true;
            this.listViewThuoc.HideSelection = false;
            this.listViewThuoc.Location = new System.Drawing.Point(3, 242);
            this.listViewThuoc.Name = "listViewThuoc";
            this.listViewThuoc.Size = new System.Drawing.Size(894, 317);
            this.listViewThuoc.TabIndex = 1;
            this.listViewThuoc.UseCompatibleStateImageBehavior = false;
            this.listViewThuoc.View = System.Windows.Forms.View.Details;
            // 
            // mathuoc
            // 
            this.mathuoc.Text = "Mã Thuốc";
            this.mathuoc.Width = 100;
            // 
            // tenthuoc
            // 
            this.tenthuoc.Text = "Tên Thuốc";
            this.tenthuoc.Width = 100;
            // 
            // sl
            // 
            this.sl.Text = "Số Lượng";
            this.sl.Width = 100;
            // 
            // dg
            // 
            this.dg.Text = "Đơn giá";
            this.dg.Width = 100;
            // 
            // km
            // 
            this.km.Text = "Khuyến mãi";
            this.km.Width = 100;
            // 
            // dgvCTHDN
            // 
            this.dgvCTHDN.ColumnHeadersHeight = 29;
            this.dgvCTHDN.Location = new System.Drawing.Point(0, 0);
            this.dgvCTHDN.Name = "dgvCTHDN";
            this.dgvCTHDN.RowHeadersWidth = 51;
            this.dgvCTHDN.Size = new System.Drawing.Size(240, 150);
            this.dgvCTHDN.TabIndex = 0;
            // 
            // FormHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HoaDonNhap";
            this.Load += new System.EventHandler(this.FormHoaDonNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.ComboBox cmbNVThucHien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker txtNgayNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThanhTienHDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbThuoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddTHuoc;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.NumericUpDown txtSL;
		private System.Windows.Forms.DataGridView dgvCTHDN;
        private System.Windows.Forms.ListView listViewThuoc;
        private System.Windows.Forms.ColumnHeader mathuoc;
        private System.Windows.Forms.ColumnHeader tenthuoc;
        private System.Windows.Forms.ColumnHeader sl;
        private System.Windows.Forms.ColumnHeader dg;
        private System.Windows.Forms.ColumnHeader km;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtKhuyenMai;
    }
}