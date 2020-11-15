using COFFEEMANGE.DAO;
using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEEMANGE
{
	public partial class fTableManager : Form
	{
		private Account loginAccount;

		public Account LoginAccount { get => loginAccount; set { loginAccount = value;ChangeAccount(loginAccount.Type); } }

		public fTableManager(Account acc)
		{
			InitializeComponent();
			this.LoginAccount = acc;
			LoadTable();
			LoadCategory();
			loadComboBoxTable(cmbSwitchTable);
		}
		#region Method
		void ChangeAccount(int type)
		{
			adminToolStripMenuItem.Enabled = type ==1;
			accountToolStripMenuItem.Text += " (" + loginAccount.Displayname + ")";
		}
		void LoadCategory()
		{
			List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
			cmbCategory.DataSource = listCategory;
			cmbCategory.DisplayMember = "Name";
		}

		void LoadFoodListByCategoryID(int id)
		{
			List<Food> listfood = FoodDAO.Instance.GetFoodByCategoryID(id);
			cmbFood.DataSource = listfood;
			cmbFood.DisplayMember = "Name";
		}

		void LoadTable()
		{
			flpTable.Controls.Clear();
			List<Table> tableList=TableDAO.Instance.LoadTableList();
			foreach(Table item in tableList)
			{
				Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
				btn.Text = item.Name + Environment.NewLine + item.Status;
				btn.Click += btn_click;
				btn.Tag = item;
				switch(item.Status)
				{
					case "Empty":
						btn.BackColor = Color.Aqua;
						break;
					default:
						btn.BackColor = Color.LightPink;
						break;
				}
				flpTable.Controls.Add(btn);

			}
		}

		void showBill(int id)
		{
			lsvBill.Items.Clear();
			List<MenuL> listBillInfo = MenuLDAO.Instance.GetListMenuByTable(id);
			float totalprice = 0;
			foreach(MenuL item in listBillInfo)
			{
				ListViewItem lsvItem = new ListViewItem(item.Foodname.ToString());
				lsvItem.SubItems.Add(item.Count.ToString());
				lsvItem.SubItems.Add(item.Price.ToString());
				lsvItem.SubItems.Add(item.Total.ToString());
				totalprice += (float)Convert.ToDouble(item.Total.ToString());
				lsvBill.Items.Add(lsvItem);
			}
			CultureInfo culture = new CultureInfo("vi-VN");
			//Thread.CurrentThread.CurrentCulture = culture;
			txtTotalPirce.Text = totalprice.ToString("c",culture);

		}
		void loadComboBoxTable(ComboBox cmb)
		{
			cmb.DataSource = TableDAO.Instance.LoadTableList();
			cmb.DisplayMember = "Name";
		}
		#endregion

		#region Event
		private void btn_click(object sender, EventArgs e)
		{
			int tableId=((sender as Button).Tag as Table).ID;
			lsvBill.Tag = (sender as Button).Tag;
			showBill(tableId);
			
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			fAccountProfile f = new fAccountProfile(loginAccount);
			f.UpdateAccount += F_UpdateAccount;
			f.ShowDialog();
		}

		private void F_UpdateAccount(object sender, AccountEvent e)
		{
			accountToolStripMenuItem.Text = "Account (" + e.Account.Displayname + ")";
		}


		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAdmin f = new fAdmin();
			f.loginAccount = LoginAccount;
			f.InsertFood += F_InsertFood;
			f.DeleteFood += F_DeleteFood;
			f.UpdateFood += F_UpdateFood;
			f.InsertCategory += F_InsertCategory;
			f.UpdateCategory += F_UpdateCategory;
			f.DeleteCategory += F_DeleteCategory;
			f.InsertTable += F_InsertTable;
			f.UpdateTale += F_UpdateTale;
			f.DeleteTable += F_DeleteTable;
			f.ShowDialog();	
				
		}

		private void F_DeleteTable(object sender, EventArgs e)
		{
			LoadTable();
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}
		private void F_UpdateTale(object sender, EventArgs e)
		{
			LoadTable();
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}
		private void F_InsertTable(object sender, EventArgs e)
		{
			LoadTable();
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}
		private void F_DeleteCategory(object sender, EventArgs e)
		{
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}

		private void F_UpdateCategory(object sender, EventArgs e)
		{
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}

		private void F_InsertCategory(object sender, EventArgs e)
		{
			LoadCategory();
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}

		private void F_UpdateFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
		}

		private void F_DeleteFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if (lsvBill.Tag != null)
				showBill((lsvBill.Tag as Table).ID);
			LoadTable();
		}

		private void F_InsertFood(object sender, EventArgs e)
		{
			LoadFoodListByCategoryID((cmbCategory.SelectedItem as Category).ID);
			if(lsvBill.Tag!=null)
				showBill((lsvBill.Tag as Table).ID);
		}

		private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = 0;
			ComboBox cb = sender as ComboBox;
			if (cb.SelectedItem==null)
			{
				return;
			}
			Category selected = cb.SelectedItem as Category;
			id = selected.ID;
			LoadFoodListByCategoryID(id);
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;
			if (table == null)
			{
				MessageBox.Show("Please choose table");
				return;
			}
				
			int idBill = BillDAO.Instance.GetUncheckedBillIDByTableID(table.ID);
			int foodID = (cmbFood.SelectedItem as Food).ID;
			int count = (int)nmFoodCount.Value;

			if (idBill==-1)//Bill does not exist// id bill will be the max=>GetMaxBillID
			{
				BillDAO.Instance.InsertBill(table.ID);
				BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBillID(), foodID, count);
			}
			else// Bill exist=> idBill
			{
				BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
			}
			showBill(table.ID);
			LoadTable();
		}
		private void btnCheckOut_Click(object sender, EventArgs e)
		{
			Table table = lsvBill.Tag as Table;
			int idBill = BillDAO.Instance.GetUncheckedBillIDByTableID(table.ID);
			int discount = (int)nmDiscount.Value;
			double TotalPrice = Convert.ToDouble(txtTotalPirce.Text.Split(',')[0]);
			double finalPrice = TotalPrice - (TotalPrice / 100) * discount;
			finalPrice *= 1000;
			if(idBill!=-1)
			{
				if(MessageBox.Show(String.Format("Do you want to check out for {0}\n Total= {1}000 - ({1}000/100) x {2} = {3} ",table.Name, TotalPrice,discount,finalPrice),"Notice",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
				{
					BillDAO.Instance.CheckOut(idBill,discount,(float)finalPrice); 
					showBill(table.ID);
					LoadTable();
				}
			}

		}

		private void btnSwitchTable_Click(object sender, EventArgs e)
		{
			
			int id1 = (lsvBill.Tag as Table).ID;
			int id2 = (cmbSwitchTable.SelectedItem as Table).ID;
			if (MessageBox.Show(String.Format("Do you want to change from {0} to {1}", (lsvBill.Tag as Table).Name, (cmbSwitchTable.SelectedItem as Table).Name),"Notice",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
			{
				TableDAO.Instance.SwitchTable(id1, id2);
				LoadTable();
			}
			
		}
		#endregion

	}
}
