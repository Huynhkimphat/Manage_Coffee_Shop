using COFFEEMANGE.DAO;
using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEEMANGE
{
	public partial class fAdmin : Form
	{
		BindingSource foodList = new BindingSource();
		BindingSource categoryList = new BindingSource();
		BindingSource tableList = new BindingSource();
		BindingSource accountList = new BindingSource();
		public Account loginAccount;

		public fAdmin()
		{
			InitializeComponent();
			F_Load();
		}
		#region Methods
		List<Food> SearchFoodByName(string name)
		{
			List<Food> listFood= FoodDAO.Instance.SearchFoodByName(name);
			return listFood;
		}
		void F_Load()
		{
			dtgvFood.DataSource = foodList;
			dtgvFoodCategory.DataSource = categoryList;
			dtgvTable.DataSource = tableList;
			dtgvAccount.DataSource = accountList;
			LoadDateTimePickerBill();
			LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
			LoadListFood();
			AddFoodBinding();
			LoadCategoryIntoComboBox(cmbFoodCategory);
			LoadCategoryFood();
			AddCategoryBinding();
			LoadtableList();
			AddTableBinding();
			LoadAccountList();
			AddAccountBinding();
		}

		private void AddAccountBinding()
		{
			txtNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayname", true, DataSourceUpdateMode.Never));
			txtUsernameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
			nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
		}

		private void LoadAccountList()
		{
			accountList.DataSource = AccountDAO.Instance.GetListAccount();
		}

		private void AddTableBinding()
		{
			txtTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id",true,DataSourceUpdateMode.Never));
			txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
		}

		private void LoadtableList()
		{
			tableList.DataSource = TableDAO.Instance.LoadTableList();
		}

		void LoadDateTimePickerBill()
		{
			DateTime today = DateTime.Now;
			dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
			dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
		}
		void LoadListViewByDate(DateTime checkIn,DateTime checkOut)
		{
			dtgvBill.DataSource=BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
		}
		void LoadListFood()
		{
			foodList.DataSource = FoodDAO.Instance.GetListFood();
		}
		void LoadCategoryFood()
		{
			categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
		}
		void AddCategoryBinding()
		{
			txtCategoryID.DataBindings.Add(new Binding("Text", dtgvFoodCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
			txtCategoryName.DataBindings.Add(new Binding("Text", dtgvFoodCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
		}
		void AddFoodBinding()
		{
			txtFoodName.DataBindings.Add(new Binding("Text",dtgvFood.DataSource, "name",true,DataSourceUpdateMode.Never));
			txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "id",true,DataSourceUpdateMode.Never));
			nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "price",true,DataSourceUpdateMode.Never));
		}

		void LoadCategoryIntoComboBox(ComboBox cmb)
		{
			cmb.DataSource = CategoryDAO.Instance.GetListCategory();
			cmb.DisplayMember = "Name";
		}

		void AddAccount(string Username,string Displayname,int type)
		{
			if(AccountDAO.Instance.InsertAccount(Username, Displayname, type))
			{
				MessageBox.Show("Add account " + Username + " success.");
			}
			else
			{
				MessageBox.Show("Add account failed");
			}
			LoadAccountList();
		}
		void EditAccount(string Username, string Displayname, int type)
		{
			if (AccountDAO.Instance.UpdateAccountAdmin(Username, Displayname, type))
			{
				MessageBox.Show("Update account " + Username + " success.");
			}
			else
			{
				MessageBox.Show("Update account failed");
			}
			LoadAccountList();
		}
		void DeleteAccount(string Username)
		{
			if(loginAccount.Username.Equals(Username))
			{
				MessageBox.Show("Do not delete yourself");
				return;
			}

			if (AccountDAO.Instance.DeleteAccount(Username))
			{
				MessageBox.Show("Delete account " + Username + " success.");
			}
			else
			{
				MessageBox.Show("Delete account failed");
			}
			LoadAccountList();
		}
		void ResetPass(string username)
		{
			if(AccountDAO.Instance.ResetPassword(username))
			{
				MessageBox.Show("Reset password " + username + " success.");
			}
			else
			{
				MessageBox.Show("Reset fail.");
			}
			LoadAccountList();
		}
		#endregion

		#region Events
		private void btnResetPassword_Click(object sender, EventArgs e)
		{
			ResetPass(txtUsernameAccount.Text);
		}
		private void btnAddAccount_Click(object sender, EventArgs e)
		{

			AddAccount(txtUsernameAccount.Text,txtNameAccount.Text,Convert.ToInt32(nmAccountType.Value));
		}

		private void btnDeleteAccount_Click(object sender, EventArgs e)
		{
			DeleteAccount(txtUsernameAccount.Text);
		}

		private void btnChangeAccount_Click(object sender, EventArgs e)
		{
			EditAccount(txtUsernameAccount.Text, txtNameAccount.Text, Convert.ToInt32(nmAccountType.Value));
		}

		private void btnViewAccount_Click(object sender, EventArgs e)
		{
			LoadAccountList();
		}
		private void btnFindFood_Click(object sender, EventArgs e)
		{
			foodList.DataSource= SearchFoodByName(txtSearchFoodName.Text);
		}

		private void btnViewBill_Click(object sender, EventArgs e)
		{
			LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
		}
		private void btnViewFood_Click(object sender, EventArgs e)
		{
			LoadListFood();
		}
		private void txtFoodID_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (dtgvFood.SelectedCells.Count > 0)
				{
					int id = Convert.ToInt32(dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value);

					Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);
					if(cateogory!=null)
					{
						cmbFoodCategory.SelectedItem = cateogory;

						int index = -1;
						int i = 0;
						foreach (Category item in cmbFoodCategory.Items)
						{
							if (item.ID == cateogory.ID)
							{
								index = i;
								break;
							}
							i++;
						}

						cmbFoodCategory.SelectedIndex = index;
					}
				}
			}
			catch 
			{}

		}
		private void btnAddFood_Click(object sender, EventArgs e)
		{
			string name = txtFoodName.Text;
			int caterID = (cmbFoodCategory.SelectedItem as Category).ID;
			float price = (float)nmFoodPrice.Value;
			if (FoodDAO.Instance.InsertFood(name, caterID, price))
			{
				MessageBox.Show("Add " + name + " Success!!!");
				LoadListFood();
				if (insertFood != null)
				{
					insertFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}

		}

		private void btnChangeFood_Click(object sender, EventArgs e)
		{
			string name = txtFoodName.Text;
			int caterID = (cmbFoodCategory.SelectedItem as Category).ID;
			int idFood = Convert.ToInt32(txtFoodID.Text);
			float price = (float)nmFoodPrice.Value;
			if (FoodDAO.Instance.UpdateFood(idFood, name, caterID, price))
			{
				MessageBox.Show("Edit " + name + " Success!!!");
				LoadListFood();
				if (updateFood != null)
				{
					updateFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}

		private void btnDeleteFood_Click(object sender, EventArgs e)
		{
			int idFood = Convert.ToInt32(txtFoodID.Text);
			if (FoodDAO.Instance.DeleteFood(idFood))
			{
				MessageBox.Show("Delete Success!!!");
				LoadListFood();
				if(deleteFood!=null)
				{
					deleteFood(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}

		private void btnViewCategory_Click(object sender, EventArgs e)
		{
			LoadCategoryFood();
		}
		private void btnAddCaterogy_Click(object sender, EventArgs e)
		{
			string name = txtCategoryName.Text;
			if (CategoryDAO.Instance.InsertCategory(name))
			{
				MessageBox.Show("Add " + name + " Success!!!");
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);

				if (insertFood != null)
				{
					insertCategory(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}

		private void btnDeleteCategory_Click(object sender, EventArgs e)
		{
			int idCategory = Convert.ToInt32(txtCategoryID.Text);
			string name = txtCategoryName.Text;
			if (CategoryDAO.Instance.DeleteCategory(idCategory))
			{
				MessageBox.Show("Delete Success!!!");
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);
				if (deleteCategory != null)
				{
					deleteCategory(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}

		private void btnViewTable_Click(object sender, EventArgs e)
		{
			LoadtableList();
		}

		private void btnAddTable_Click(object sender, EventArgs e)
		{
			string name = txtTableName.Text;
			if (TableDAO.Instance.InsertTable(name))
			{
				MessageBox.Show("Add " + name + " Success!!!");
				LoadtableList();
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);
				if (insertTable != null)
				{
					insertTable(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}
		private void btnChangeCategory_Click(object sender, EventArgs e)
		{
			int idCategory = Convert.ToInt32(txtCategoryID.Text);
			string name = txtCategoryName.Text;
			if (CategoryDAO.Instance.UpdateCategory(idCategory, name))
			{
				MessageBox.Show("Edit " + name + " Success!!!");
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);
				if (updateCategory != null)
				{
					updateCategory(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}
		private void btnChangeTable_Click(object sender, EventArgs e)
		{
			int idTable = Convert.ToInt32(txtTableID.Text);
			string name = txtTableName.Text;
			if (TableDAO.Instance.UpdateTable(idTable, name))
			{
				MessageBox.Show("Edit " + name + " Success!!!");
				LoadtableList();
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);
				if (updateTale != null)
				{
					updateTale(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}
		private void buttonDeleteTable_Click(object sender, EventArgs e)
		{
			int idTable = Convert.ToInt32(txtTableID.Text);
			if (TableDAO.Instance.DeleteTable(idTable))
			{
				MessageBox.Show("Delete Success!!!");
				LoadtableList();
				LoadCategoryFood();
				LoadListFood();
				LoadCategoryIntoComboBox(cmbFoodCategory);
				if (deleteTable != null)
				{
					deleteTable(this, new EventArgs());
				}
			}
			else
			{
				MessageBox.Show("Error");
			}
		}


		#endregion
		private event EventHandler insertFood;
		public event EventHandler InsertFood
		{
			add { insertFood += value; }
			remove { insertFood -= value; }
		}

		private event EventHandler deleteFood;
		public event EventHandler DeleteFood
		{
			add { deleteFood += value; }
			remove { deleteFood -= value; }
		}

		private event EventHandler updateFood;
		public event EventHandler UpdateFood
		{
			add { updateFood += value; }
			remove { updateFood -= value; }
		}
		private event EventHandler insertCategory;
		public event EventHandler InsertCategory
		{
			add { insertCategory += value; }
			remove { insertCategory -= value; }
		}

		private event EventHandler deleteCategory;
		public event EventHandler DeleteCategory
		{
			add { deleteCategory += value; }
			remove { deleteCategory -= value; }
		}

		private event EventHandler updateCategory;
		public event EventHandler UpdateCategory
		{
			add { updateCategory += value; }
			remove { updateCategory -= value; }
		}

		private event EventHandler insertTable;
		public event EventHandler InsertTable
		{
			add { insertTable += value; }
			remove { insertTable -= value; }
		}

		private event EventHandler deleteTable;
		public event EventHandler DeleteTable
		{
			add { deleteTable += value; }
			remove { deleteTable -= value; }
		}

		private event EventHandler updateTale;
		public event EventHandler UpdateTale
		{
			add { updateTale += value; }
			remove { updateTale -= value; }
		}


	}
}
