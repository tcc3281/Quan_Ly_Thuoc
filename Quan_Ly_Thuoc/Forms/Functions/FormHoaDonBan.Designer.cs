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
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnSuaSL = new System.Windows.Forms.Button();
			this.txtSL = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.listThuoc = new System.Windows.Forms.ListBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtSearchThuoc = new System.Windows.Forms.TextBox();
			this.btnSearchThuoc = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSL)).BeginInit();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
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
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.33679F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.66322F));
			this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel8, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 535);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(729, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(233, 529);
			this.panel5.TabIndex = 2;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lHDB);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(233, 378);
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
			this.lHDB.LabelEdit = true;
			this.lHDB.Location = new System.Drawing.Point(0, 0);
			this.lHDB.Name = "lHDB";
			this.lHDB.Size = new System.Drawing.Size(233, 378);
			this.lHDB.TabIndex = 0;
			this.lHDB.UseCompatibleStateImageBehavior = false;
			this.lHDB.View = System.Windows.Forms.View.Details;
			this.lHDB.DoubleClick += new System.EventHandler(this.lHDB_DoubleClick);
			// 
			// ten
			// 
			this.ten.Text = "Tên thuốc";
			this.ten.Width = 74;
			// 
			// sl
			// 
			this.sl.Text = "Số lượng";
			this.sl.Width = 98;
			// 
			// gia
			// 
			this.gia.Text = "Giá";
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnRemove);
			this.panel6.Controls.Add(this.btnSuaSL);
			this.panel6.Controls.Add(this.txtSL);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.btnThanhToan);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new System.Drawing.Point(0, 378);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(233, 151);
			this.panel6.TabIndex = 0;
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(119, 62);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(93, 30);
			this.btnRemove.TabIndex = 5;
			this.btnRemove.Text = "Xóa";
			this.btnRemove.UseVisualStyleBackColor = true;
			// 
			// btnSuaSL
			// 
			this.btnSuaSL.Location = new System.Drawing.Point(7, 62);
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
			this.txtSL.Location = new System.Drawing.Point(105, 19);
			this.txtSL.Name = "txtSL";
			this.txtSL.Size = new System.Drawing.Size(107, 28);
			this.txtSL.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 22);
			this.label1.TabIndex = 8;
			this.label1.Text = "Số lượng:";
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThanhToan.Location = new System.Drawing.Point(66, 98);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(105, 44);
			this.btnThanhToan.TabIndex = 7;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.listThuoc);
			this.panel8.Controls.Add(this.panel9);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(720, 529);
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
			this.listThuoc.Size = new System.Drawing.Size(720, 499);
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
			this.panel9.Size = new System.Drawing.Size(720, 30);
			this.panel9.TabIndex = 3;
			// 
			// txtSearchThuoc
			// 
			this.txtSearchThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSearchThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearchThuoc.Location = new System.Drawing.Point(0, 0);
			this.txtSearchThuoc.Name = "txtSearchThuoc";
			this.txtSearchThuoc.Size = new System.Drawing.Size(682, 26);
			this.txtSearchThuoc.TabIndex = 0;
			this.txtSearchThuoc.TextChanged += new System.EventHandler(this.txtSreachThuoc_TextChanged);
			// 
			// btnSearchThuoc
			// 
			this.btnSearchThuoc.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchThuoc.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchThuoc.Image")));
			this.btnSearchThuoc.Location = new System.Drawing.Point(682, 0);
			this.btnSearchThuoc.Name = "btnSearchThuoc";
			this.btnSearchThuoc.Size = new System.Drawing.Size(38, 30);
			this.btnSearchThuoc.TabIndex = 1;
			this.btnSearchThuoc.UseVisualStyleBackColor = true;
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
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSL)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
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
		private System.Windows.Forms.ColumnHeader ten;
		private System.Windows.Forms.ColumnHeader sl;
		private System.Windows.Forms.ColumnHeader gia;
		private System.Windows.Forms.ListView lHDB;
		private System.Windows.Forms.Button btnSuaSL;
		private System.Windows.Forms.NumericUpDown txtSL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRemove;
	}
}