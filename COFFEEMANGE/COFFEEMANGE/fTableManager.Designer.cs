namespace COFFEEMANGE
{
	partial class fTableManager
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lsvBill = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtTotalPirce = new System.Windows.Forms.TextBox();
			this.cmbSwitchTable = new System.Windows.Forms.ComboBox();
			this.btnSwitchTable = new System.Windows.Forms.Button();
			this.nmDiscount = new System.Windows.Forms.NumericUpDown();
			this.btnDiscount = new System.Windows.Forms.Button();
			this.btnCheckOut = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
			this.btnAdd = new System.Windows.Forms.Button();
			this.cmbFood = new System.Windows.Forms.ComboBox();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
			this.menuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.accountToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(869, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// adminToolStripMenuItem
			// 
			this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
			this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.adminToolStripMenuItem.Text = "Admin";
			this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
			// 
			// accountToolStripMenuItem
			// 
			this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
			this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.accountToolStripMenuItem.Text = "Account";
			// 
			// profileToolStripMenuItem1
			// 
			this.profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
			this.profileToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
			this.profileToolStripMenuItem1.Text = "Profile";
			this.profileToolStripMenuItem1.Click += new System.EventHandler(this.profileToolStripMenuItem1_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lsvBill);
			this.panel2.Location = new System.Drawing.Point(499, 88);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(358, 338);
			this.panel2.TabIndex = 1;
			// 
			// lsvBill
			// 
			this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lsvBill.GridLines = true;
			this.lsvBill.HideSelection = false;
			this.lsvBill.Location = new System.Drawing.Point(3, 3);
			this.lsvBill.Name = "lsvBill";
			this.lsvBill.Size = new System.Drawing.Size(352, 332);
			this.lsvBill.TabIndex = 0;
			this.lsvBill.UseCompatibleStateImageBehavior = false;
			this.lsvBill.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 131;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Amount";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Price";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Total";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtTotalPirce);
			this.panel3.Controls.Add(this.cmbSwitchTable);
			this.panel3.Controls.Add(this.btnSwitchTable);
			this.panel3.Controls.Add(this.nmDiscount);
			this.panel3.Controls.Add(this.btnDiscount);
			this.panel3.Controls.Add(this.btnCheckOut);
			this.panel3.Location = new System.Drawing.Point(502, 432);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(358, 56);
			this.panel3.TabIndex = 2;
			// 
			// txtTotalPirce
			// 
			this.txtTotalPirce.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotalPirce.ForeColor = System.Drawing.Color.OrangeRed;
			this.txtTotalPirce.Location = new System.Drawing.Point(176, 12);
			this.txtTotalPirce.Name = "txtTotalPirce";
			this.txtTotalPirce.ReadOnly = true;
			this.txtTotalPirce.Size = new System.Drawing.Size(100, 29);
			this.txtTotalPirce.TabIndex = 1;
			this.txtTotalPirce.Text = "0";
			this.txtTotalPirce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbSwitchTable
			// 
			this.cmbSwitchTable.FormattingEnabled = true;
			this.cmbSwitchTable.Location = new System.Drawing.Point(0, 32);
			this.cmbSwitchTable.Name = "cmbSwitchTable";
			this.cmbSwitchTable.Size = new System.Drawing.Size(89, 21);
			this.cmbSwitchTable.TabIndex = 6;
			// 
			// btnSwitchTable
			// 
			this.btnSwitchTable.Location = new System.Drawing.Point(0, 0);
			this.btnSwitchTable.Name = "btnSwitchTable";
			this.btnSwitchTable.Size = new System.Drawing.Size(89, 28);
			this.btnSwitchTable.TabIndex = 5;
			this.btnSwitchTable.Text = "Switch Table";
			this.btnSwitchTable.UseVisualStyleBackColor = true;
			this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
			// 
			// nmDiscount
			// 
			this.nmDiscount.Location = new System.Drawing.Point(95, 33);
			this.nmDiscount.Name = "nmDiscount";
			this.nmDiscount.Size = new System.Drawing.Size(75, 20);
			this.nmDiscount.TabIndex = 3;
			this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnDiscount
			// 
			this.btnDiscount.Location = new System.Drawing.Point(95, 0);
			this.btnDiscount.Name = "btnDiscount";
			this.btnDiscount.Size = new System.Drawing.Size(75, 28);
			this.btnDiscount.TabIndex = 4;
			this.btnDiscount.Text = "Discount";
			this.btnDiscount.UseVisualStyleBackColor = true;
			// 
			// btnCheckOut
			// 
			this.btnCheckOut.Location = new System.Drawing.Point(283, 0);
			this.btnCheckOut.Name = "btnCheckOut";
			this.btnCheckOut.Size = new System.Drawing.Size(75, 55);
			this.btnCheckOut.TabIndex = 3;
			this.btnCheckOut.Text = "Check Out";
			this.btnCheckOut.UseVisualStyleBackColor = true;
			this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.nmFoodCount);
			this.panel4.Controls.Add(this.btnAdd);
			this.panel4.Controls.Add(this.cmbFood);
			this.panel4.Controls.Add(this.cmbCategory);
			this.panel4.Location = new System.Drawing.Point(499, 27);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(358, 59);
			this.panel4.TabIndex = 3;
			// 
			// nmFoodCount
			// 
			this.nmFoodCount.Location = new System.Drawing.Point(308, 19);
			this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.nmFoodCount.Name = "nmFoodCount";
			this.nmFoodCount.Size = new System.Drawing.Size(47, 20);
			this.nmFoodCount.TabIndex = 0;
			this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(227, 0);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 55);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// cmbFood
			// 
			this.cmbFood.FormattingEnabled = true;
			this.cmbFood.Location = new System.Drawing.Point(0, 30);
			this.cmbFood.Name = "cmbFood";
			this.cmbFood.Size = new System.Drawing.Size(221, 21);
			this.cmbFood.TabIndex = 1;
			// 
			// cmbCategory
			// 
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(0, 3);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(221, 21);
			this.cmbCategory.TabIndex = 0;
			this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
			// 
			// flpTable
			// 
			this.flpTable.AutoScroll = true;
			this.flpTable.Location = new System.Drawing.Point(12, 30);
			this.flpTable.Name = "flpTable";
			this.flpTable.Size = new System.Drawing.Size(481, 428);
			this.flpTable.TabIndex = 5;
			// 
			// fTableManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(869, 492);
			this.Controls.Add(this.flpTable);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fTableManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CoffeeManage";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView lsvBill;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ComboBox cmbFood;
		private System.Windows.Forms.NumericUpDown nmFoodCount;
		private System.Windows.Forms.FlowLayoutPanel flpTable;
		private System.Windows.Forms.Button btnCheckOut;
		private System.Windows.Forms.Button btnDiscount;
		private System.Windows.Forms.NumericUpDown nmDiscount;
		private System.Windows.Forms.Button btnSwitchTable;
		private System.Windows.Forms.ComboBox cmbSwitchTable;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TextBox txtTotalPirce;
	}
}