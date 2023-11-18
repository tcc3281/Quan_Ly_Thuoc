namespace Quan_Ly_Thuoc
{
    partial class FormHoaDonBan
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHoaDonBan));
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lHDB = new System.Windows.Forms.ListView();
			this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel8 = new System.Windows.Forms.Panel();
			this.listThuoc = new System.Windows.Forms.ListBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtSearchThuoc = new System.Windows.Forms.TextBox();
			this.btnSearchThuoc = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.cmbKH = new System.Windows.Forms.ComboBox();
			this.cmbNV = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblMa = new System.Windows.Forms.Label();
			this.btnCatHD = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnSuaSL = new System.Windows.Forms.Button();
			this.txtSL = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSL)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(965, 535);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.43005F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.07772F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.3886F));
			this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 535);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(480, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(236, 529);
			this.panel5.TabIndex = 2;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lHDB);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(236, 529);
			this.panel7.TabIndex = 1;
			// 
			// lHDB
			// 
			this.lHDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ten,
            this.sl,
            this.gia});
			this.lHDB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lHDB.FullRowSelect = true;
			this.lHDB.GridLines = true;
			this.lHDB.HideSelection = false;
			this.lHDB.Location = new System.Drawing.Point(0, 0);
			this.lHDB.Name = "lHDB";
			this.lHDB.Size = new System.Drawing.Size(236, 529);
			this.lHDB.TabIndex = 0;
			this.lHDB.UseCompatibleStateImageBehavior = false;
			this.lHDB.View = System.Windows.Forms.View.Details;
			// 
			// ten
			// 
			this.ten.Text = "Tên thuốc";
			// 
			// sl
			// 
			this.sl.Text = "Số lượng";
			// 
			// gia
			// 
			this.gia.Text = "Giá";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.listThuoc);
			this.panel8.Controls.Add(this.panel9);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(471, 529);
			this.panel8.TabIndex = 3;
			// 
			// listThuoc
			// 
			this.listThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listThuoc.FormattingEnabled = true;
			this.listThuoc.ItemHeight = 22;
			this.listThuoc.Location = new System.Drawing.Point(0, 30);
			this.listThuoc.Name = "listThuoc";
			this.listThuoc.Size = new System.Drawing.Size(471, 499);
			this.listThuoc.TabIndex = 4;
			this.listThuoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listThuoc_MouseDoubleClick);
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtSearchThuoc);
			this.panel9.Controls.Add(this.btnSearchThuoc);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(471, 30);
			this.panel9.TabIndex = 3;
			// 
			// txtSearchThuoc
			// 
			this.txtSearchThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSearchThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearchThuoc.Location = new System.Drawing.Point(0, 0);
			this.txtSearchThuoc.Name = "txtSearchThuoc";
			this.txtSearchThuoc.Size = new System.Drawing.Size(433, 26);
			this.txtSearchThuoc.TabIndex = 0;
			this.txtSearchThuoc.TextChanged += new System.EventHandler(this.txtSreachThuoc_TextChanged);
			// 
			// btnSearchThuoc
			// 
			this.btnSearchThuoc.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchThuoc.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchThuoc.Image")));
			this.btnSearchThuoc.Location = new System.Drawing.Point(433, 0);
			this.btnSearchThuoc.Name = "btnSearchThuoc";
			this.btnSearchThuoc.Size = new System.Drawing.Size(38, 30);
			this.btnSearchThuoc.TabIndex = 1;
			this.btnSearchThuoc.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.cmbKH);
			this.panel6.Controls.Add(this.cmbNV);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Controls.Add(this.label3);
			this.panel6.Controls.Add(this.lblMa);
			this.panel6.Controls.Add(this.btnCatHD);
			this.panel6.Controls.Add(this.btnRemove);
			this.panel6.Controls.Add(this.btnSuaSL);
			this.panel6.Controls.Add(this.txtSL);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.btnThanhToan);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(722, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(240, 529);
			this.panel6.TabIndex = 0;
			// 
			// cmbKH
			// 
			this.cmbKH.FormattingEnabled = true;
			this.cmbKH.Location = new System.Drawing.Point(14, 175);
			this.cmbKH.Name = "cmbKH";
			this.cmbKH.Size = new System.Drawing.Size(200, 24);
			this.cmbKH.TabIndex = 16;
			// 
			// cmbNV
			// 
			this.cmbNV.FormattingEnabled = true;
			this.cmbNV.Location = new System.Drawing.Point(14, 95);
			this.cmbNV.Name = "cmbNV";
			this.cmbNV.Size = new System.Drawing.Size(200, 24);
			this.cmbNV.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 137);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 20);
			this.label4.TabIndex = 14;
			this.label4.Text = "Khách hàng:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 20);
			this.label3.TabIndex = 13;
			this.label3.Text = "Nhân viên:";
			// 
			// lblMa
			// 
			this.lblMa.AutoSize = true;
			this.lblMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMa.Location = new System.Drawing.Point(10, 19);
			this.lblMa.Name = "lblMa";
			this.lblMa.Size = new System.Drawing.Size(106, 20);
			this.lblMa.TabIndex = 12;
			this.lblMa.Text = "Mã hóa đơn: ";
			// 
			// btnCatHD
			// 
			this.btnCatHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCatHD.Location = new System.Drawing.Point(121, 463);
			this.btnCatHD.Name = "btnCatHD";
			this.btnCatHD.Size = new System.Drawing.Size(111, 57);
			this.btnCatHD.TabIndex = 11;
			this.btnCatHD.Text = "Cất hóa đơn";
			this.btnCatHD.UseVisualStyleBackColor = true;
			this.btnCatHD.Click += new System.EventHandler(this.btnCatHD_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(121, 284);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(93, 30);
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "Xóa";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnSuaSL
			// 
			this.btnSuaSL.Location = new System.Drawing.Point(9, 284);
			this.btnSuaSL.Name = "btnSuaSL";
			this.btnSuaSL.Size = new System.Drawing.Size(89, 30);
			this.btnSuaSL.TabIndex = 10;
			this.btnSuaSL.Text = "Thay đổi";
			this.btnSuaSL.UseVisualStyleBackColor = true;
			this.btnSuaSL.Click += new System.EventHandler(this.btnSuaSL_Click);
			// 
			// txtSL
			// 
			this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSL.Location = new System.Drawing.Point(114, 241);
			this.txtSL.Name = "txtSL";
			this.txtSL.Size = new System.Drawing.Size(107, 28);
			this.txtSL.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 243);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 22);
			this.label1.TabIndex = 8;
			this.label1.Text = "Số lượng:";
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThanhToan.Location = new System.Drawing.Point(9, 463);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(106, 57);
			this.btnThanhToan.TabIndex = 7;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
			// 
			// FormHoaDonBan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(965, 535);
			this.Controls.Add(this.panel1);
			this.Name = "FormHoaDonBan";
			this.Text = "Xuất hóa đơn";
			this.Load += new System.EventHandler(this.FormHoaDon_Load);
			this.SizeChanged += new System.EventHandler(this.FormHoaDon_SizeChanged);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSL)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtSearchThuoc;
        private System.Windows.Forms.Button btnSearchThuoc;
        private System.Windows.Forms.ListBox listThuoc;
		private System.Windows.Forms.Button btnThanhToan;
		private System.Windows.Forms.Button btnSuaSL;
		private System.Windows.Forms.NumericUpDown txtSL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnCatHD;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblMa;
		private System.Windows.Forms.ComboBox cmbKH;
		private System.Windows.Forms.ComboBox cmbNV;
		private System.Windows.Forms.ListView lHDB;
		private System.Windows.Forms.ColumnHeader ten;
		private System.Windows.Forms.ColumnHeader sl;
		private System.Windows.Forms.ColumnHeader gia;
	}
}