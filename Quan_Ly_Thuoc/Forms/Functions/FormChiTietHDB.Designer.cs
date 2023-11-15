namespace Quan_Ly_Thuoc.Forms.Functions
{
	partial class FormChiTietHDB
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
			this.btnHuy = new System.Windows.Forms.Button();
			this.btnCatHD = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.dgvCTHDB = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnHuy);
			this.groupBox1.Controls.Add(this.btnCatHD);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnThanhToan);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox1.Location = new System.Drawing.Point(563, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(239, 488);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// btnHuy
			// 
			this.btnHuy.Location = new System.Drawing.Point(80, 437);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(91, 41);
			this.btnHuy.TabIndex = 6;
			this.btnHuy.Text = "Hủy đơn";
			this.btnHuy.UseVisualStyleBackColor = true;
			// 
			// btnCatHD
			// 
			this.btnCatHD.Location = new System.Drawing.Point(136, 390);
			this.btnCatHD.Name = "btnCatHD";
			this.btnCatHD.Size = new System.Drawing.Size(91, 41);
			this.btnCatHD.TabIndex = 5;
			this.btnCatHD.Text = "Cất hóa đơn";
			this.btnCatHD.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(19, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tổng tiền:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(108, 117);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(119, 22);
			this.textBox2.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(108, 47);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(119, 22);
			this.textBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "GIảm giá:";
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Location = new System.Drawing.Point(20, 390);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(91, 41);
			this.btnThanhToan.TabIndex = 0;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			// 
			// dgvCTHDB
			// 
			this.dgvCTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCTHDB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCTHDB.Location = new System.Drawing.Point(0, 0);
			this.dgvCTHDB.Name = "dgvCTHDB";
			this.dgvCTHDB.RowHeadersWidth = 51;
			this.dgvCTHDB.RowTemplate.Height = 24;
			this.dgvCTHDB.Size = new System.Drawing.Size(563, 488);
			this.dgvCTHDB.TabIndex = 1;
			// 
			// FormChiTietHDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 488);
			this.Controls.Add(this.dgvCTHDB);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormChiTietHDB";
			this.Text = "ChiTietHDB";
			this.Load += new System.EventHandler(this.FormChiTietHDB_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThanhToan;
		private System.Windows.Forms.DataGridView dgvCTHDB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCatHD;
		private System.Windows.Forms.Button btnHuy;
	}
}