namespace Quan_Ly_Thuoc.Forms.Search
{
    partial class SearchThuoc
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageName = new System.Windows.Forms.TabPage();
            this.tlp_Medicine = new System.Windows.Forms.TableLayoutPanel();
            this.txt_search_name = new System.Windows.Forms.TextBox();
            this.btn_search_name = new System.Windows.Forms.Button();
            this.gb_res_name = new System.Windows.Forms.GroupBox();
            this.listBoxName = new System.Windows.Forms.ListBox();
            this.tabPageFunction = new System.Windows.Forms.TabPage();
            this.tlp_Fuction = new System.Windows.Forms.TableLayoutPanel();
            this.btn_search_function = new System.Windows.Forms.Button();
            this.gb_res_function = new System.Windows.Forms.GroupBox();
            this.listBoxFunction = new System.Windows.Forms.ListBox();
            this.cmb_search_function = new System.Windows.Forms.ComboBox();
            this.tabPageIngredient = new System.Windows.Forms.TabPage();
            this.tlp_Ingredient = new System.Windows.Forms.TableLayoutPanel();
            this.cmb_search_ingredient = new System.Windows.Forms.ComboBox();
            this.btn_search_ingredient = new System.Windows.Forms.Button();
            this.gb_res_ingredient = new System.Windows.Forms.GroupBox();
            this.listBoxIngredient = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tabPageName.SuspendLayout();
            this.tlp_Medicine.SuspendLayout();
            this.gb_res_name.SuspendLayout();
            this.tabPageFunction.SuspendLayout();
            this.tlp_Fuction.SuspendLayout();
            this.gb_res_function.SuspendLayout();
            this.tabPageIngredient.SuspendLayout();
            this.tlp_Ingredient.SuspendLayout();
            this.gb_res_ingredient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageName);
            this.tabControl.Controls.Add(this.tabPageFunction);
            this.tabControl.Controls.Add(this.tabPageIngredient);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(988, 491);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageName
            // 
            this.tabPageName.Controls.Add(this.tlp_Medicine);
            this.tabPageName.Location = new System.Drawing.Point(4, 29);
            this.tabPageName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageName.Name = "tabPageName";
            this.tabPageName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageName.Size = new System.Drawing.Size(980, 458);
            this.tabPageName.TabIndex = 0;
            this.tabPageName.Text = "Tìm theo tên thuốc";
            this.tabPageName.UseVisualStyleBackColor = true;
            // 
            // tlp_Medicine
            // 
            this.tlp_Medicine.ColumnCount = 2;
            this.tlp_Medicine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Medicine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlp_Medicine.Controls.Add(this.txt_search_name, 0, 0);
            this.tlp_Medicine.Controls.Add(this.btn_search_name, 1, 0);
            this.tlp_Medicine.Controls.Add(this.gb_res_name, 0, 1);
            this.tlp_Medicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Medicine.Location = new System.Drawing.Point(3, 2);
            this.tlp_Medicine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp_Medicine.Name = "tlp_Medicine";
            this.tlp_Medicine.RowCount = 2;
            this.tlp_Medicine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Medicine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Medicine.Size = new System.Drawing.Size(974, 454);
            this.tlp_Medicine.TabIndex = 1;
            // 
            // txt_search_name
            // 
            this.txt_search_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_search_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search_name.Location = new System.Drawing.Point(3, 2);
            this.txt_search_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_search_name.Name = "txt_search_name";
            this.txt_search_name.Size = new System.Drawing.Size(835, 30);
            this.txt_search_name.TabIndex = 0;
            this.txt_search_name.TextChanged += new System.EventHandler(this.txt_search_name_TextChanged);
            // 
            // btn_search_name
            // 
            this.btn_search_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_search_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_name.Location = new System.Drawing.Point(844, 2);
            this.btn_search_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search_name.Name = "btn_search_name";
            this.btn_search_name.Size = new System.Drawing.Size(127, 37);
            this.btn_search_name.TabIndex = 1;
            this.btn_search_name.Text = "Tìm kiếm";
            this.btn_search_name.UseVisualStyleBackColor = true;
            this.btn_search_name.Click += new System.EventHandler(this.btn_search_name_Click);
            // 
            // gb_res_name
            // 
            this.tlp_Medicine.SetColumnSpan(this.gb_res_name, 2);
            this.gb_res_name.Controls.Add(this.listBoxName);
            this.gb_res_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_res_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_res_name.Location = new System.Drawing.Point(3, 43);
            this.gb_res_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_name.Name = "gb_res_name";
            this.gb_res_name.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_name.Size = new System.Drawing.Size(968, 409);
            this.gb_res_name.TabIndex = 2;
            this.gb_res_name.TabStop = false;
            this.gb_res_name.Text = "Kết quả";
            // 
            // listBoxName
            // 
            this.listBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxName.FormattingEnabled = true;
            this.listBoxName.ItemHeight = 25;
            this.listBoxName.Location = new System.Drawing.Point(3, 25);
            this.listBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxName.Name = "listBoxName";
            this.listBoxName.Size = new System.Drawing.Size(962, 382);
            this.listBoxName.TabIndex = 0;
            this.listBoxName.DoubleClick += new System.EventHandler(this.listBoxName_DoubleClick);
            // 
            // tabPageFunction
            // 
            this.tabPageFunction.Controls.Add(this.tlp_Fuction);
            this.tabPageFunction.Location = new System.Drawing.Point(4, 29);
            this.tabPageFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFunction.Name = "tabPageFunction";
            this.tabPageFunction.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFunction.Size = new System.Drawing.Size(980, 458);
            this.tabPageFunction.TabIndex = 1;
            this.tabPageFunction.Text = "Tìm kiếm theo chức năng";
            this.tabPageFunction.UseVisualStyleBackColor = true;
            // 
            // tlp_Fuction
            // 
            this.tlp_Fuction.ColumnCount = 2;
            this.tlp_Fuction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Fuction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlp_Fuction.Controls.Add(this.btn_search_function, 0, 0);
            this.tlp_Fuction.Controls.Add(this.gb_res_function, 0, 1);
            this.tlp_Fuction.Controls.Add(this.cmb_search_function, 0, 0);
            this.tlp_Fuction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Fuction.Location = new System.Drawing.Point(3, 2);
            this.tlp_Fuction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp_Fuction.Name = "tlp_Fuction";
            this.tlp_Fuction.RowCount = 2;
            this.tlp_Fuction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Fuction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Fuction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Fuction.Size = new System.Drawing.Size(974, 454);
            this.tlp_Fuction.TabIndex = 0;
            // 
            // btn_search_function
            // 
            this.btn_search_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_search_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_function.Location = new System.Drawing.Point(844, 2);
            this.btn_search_function.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search_function.Name = "btn_search_function";
            this.btn_search_function.Size = new System.Drawing.Size(127, 37);
            this.btn_search_function.TabIndex = 4;
            this.btn_search_function.Text = "Tìm kiếm";
            this.btn_search_function.UseVisualStyleBackColor = true;
            this.btn_search_function.Click += new System.EventHandler(this.btn_search_function_Click);
            // 
            // gb_res_function
            // 
            this.tlp_Fuction.SetColumnSpan(this.gb_res_function, 2);
            this.gb_res_function.Controls.Add(this.listBoxFunction);
            this.gb_res_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_res_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_res_function.Location = new System.Drawing.Point(3, 43);
            this.gb_res_function.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_function.Name = "gb_res_function";
            this.gb_res_function.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_function.Size = new System.Drawing.Size(968, 409);
            this.gb_res_function.TabIndex = 3;
            this.gb_res_function.TabStop = false;
            this.gb_res_function.Text = "Kết quả";
            // 
            // listBoxFunction
            // 
            this.listBoxFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFunction.FormattingEnabled = true;
            this.listBoxFunction.ItemHeight = 25;
            this.listBoxFunction.Location = new System.Drawing.Point(3, 25);
            this.listBoxFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFunction.Name = "listBoxFunction";
            this.listBoxFunction.Size = new System.Drawing.Size(962, 382);
            this.listBoxFunction.TabIndex = 0;
            this.listBoxFunction.DoubleClick += new System.EventHandler(this.listBoxFunction_DoubleClick);
            // 
            // cmb_search_function
            // 
            this.cmb_search_function.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_search_function.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_search_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_search_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search_function.Location = new System.Drawing.Point(3, 2);
            this.cmb_search_function.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_search_function.Name = "cmb_search_function";
            this.cmb_search_function.Size = new System.Drawing.Size(835, 33);
            this.cmb_search_function.TabIndex = 1;
            // 
            // tabPageIngredient
            // 
            this.tabPageIngredient.Controls.Add(this.tlp_Ingredient);
            this.tabPageIngredient.Location = new System.Drawing.Point(4, 29);
            this.tabPageIngredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageIngredient.Name = "tabPageIngredient";
            this.tabPageIngredient.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageIngredient.Size = new System.Drawing.Size(980, 458);
            this.tabPageIngredient.TabIndex = 2;
            this.tabPageIngredient.Text = "Tìm kiếm theo thành phần";
            this.tabPageIngredient.UseVisualStyleBackColor = true;
            // 
            // tlp_Ingredient
            // 
            this.tlp_Ingredient.ColumnCount = 2;
            this.tlp_Ingredient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Ingredient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlp_Ingredient.Controls.Add(this.cmb_search_ingredient, 0, 0);
            this.tlp_Ingredient.Controls.Add(this.btn_search_ingredient, 1, 0);
            this.tlp_Ingredient.Controls.Add(this.gb_res_ingredient, 0, 1);
            this.tlp_Ingredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Ingredient.Location = new System.Drawing.Point(3, 2);
            this.tlp_Ingredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp_Ingredient.Name = "tlp_Ingredient";
            this.tlp_Ingredient.RowCount = 2;
            this.tlp_Ingredient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_Ingredient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Ingredient.Size = new System.Drawing.Size(974, 454);
            this.tlp_Ingredient.TabIndex = 0;
            // 
            // cmb_search_ingredient
            // 
            this.cmb_search_ingredient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_search_ingredient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_search_ingredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_search_ingredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search_ingredient.Location = new System.Drawing.Point(3, 2);
            this.cmb_search_ingredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_search_ingredient.Name = "cmb_search_ingredient";
            this.cmb_search_ingredient.Size = new System.Drawing.Size(835, 33);
            this.cmb_search_ingredient.TabIndex = 0;
            // 
            // btn_search_ingredient
            // 
            this.btn_search_ingredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_search_ingredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_ingredient.Location = new System.Drawing.Point(844, 2);
            this.btn_search_ingredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search_ingredient.Name = "btn_search_ingredient";
            this.btn_search_ingredient.Size = new System.Drawing.Size(127, 37);
            this.btn_search_ingredient.TabIndex = 1;
            this.btn_search_ingredient.Text = "Tìm kiếm";
            this.btn_search_ingredient.UseVisualStyleBackColor = true;
            this.btn_search_ingredient.Click += new System.EventHandler(this.btn_search_ingredient_Click);
            // 
            // gb_res_ingredient
            // 
            this.tlp_Ingredient.SetColumnSpan(this.gb_res_ingredient, 2);
            this.gb_res_ingredient.Controls.Add(this.listBoxIngredient);
            this.gb_res_ingredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_res_ingredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_res_ingredient.Location = new System.Drawing.Point(3, 43);
            this.gb_res_ingredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_ingredient.Name = "gb_res_ingredient";
            this.gb_res_ingredient.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_res_ingredient.Size = new System.Drawing.Size(968, 409);
            this.gb_res_ingredient.TabIndex = 2;
            this.gb_res_ingredient.TabStop = false;
            this.gb_res_ingredient.Text = "Kết quả";
            // 
            // listBoxIngredient
            // 
            this.listBoxIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxIngredient.FormattingEnabled = true;
            this.listBoxIngredient.ItemHeight = 25;
            this.listBoxIngredient.Location = new System.Drawing.Point(3, 25);
            this.listBoxIngredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxIngredient.Name = "listBoxIngredient";
            this.listBoxIngredient.Size = new System.Drawing.Size(962, 382);
            this.listBoxIngredient.TabIndex = 0;
            this.listBoxIngredient.DoubleClick += new System.EventHandler(this.listBoxIngredient_DoubleClick);
            // 
            // SearchThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 491);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SearchThuoc";
            this.Text = "Tìm kiếm thuốc";
            this.Load += new System.EventHandler(this.Search_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageName.ResumeLayout(false);
            this.tlp_Medicine.ResumeLayout(false);
            this.tlp_Medicine.PerformLayout();
            this.gb_res_name.ResumeLayout(false);
            this.tabPageFunction.ResumeLayout(false);
            this.tlp_Fuction.ResumeLayout(false);
            this.gb_res_function.ResumeLayout(false);
            this.tabPageIngredient.ResumeLayout(false);
            this.tlp_Ingredient.ResumeLayout(false);
            this.gb_res_ingredient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageName;
        private System.Windows.Forms.TabPage tabPageFunction;
        private System.Windows.Forms.TableLayoutPanel tlp_Fuction;
        private System.Windows.Forms.ComboBox cmb_search_ingredient;
        private System.Windows.Forms.Button btn_search_ingredient;
        private System.Windows.Forms.GroupBox gb_res_ingredient;
        private System.Windows.Forms.TableLayoutPanel tlp_Medicine;
        private System.Windows.Forms.Button btn_search_name;
        private System.Windows.Forms.GroupBox gb_res_name;
        private System.Windows.Forms.TabPage tabPageIngredient;
        private System.Windows.Forms.TableLayoutPanel tlp_Ingredient;
        private System.Windows.Forms.GroupBox gb_res_function;
        private System.Windows.Forms.ComboBox cmb_search_function;
        private System.Windows.Forms.Button btn_search_function;
        private System.Windows.Forms.ListBox listBoxName;
        private System.Windows.Forms.ListBox listBoxFunction;
        private System.Windows.Forms.ListBox listBoxIngredient;
        private System.Windows.Forms.TextBox txt_search_name;
    }
}