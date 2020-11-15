using COFFEEMANGE.DAO;
using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEEMANGE
{
	public partial class fAccountProfile : Form
	{
		private Account loginAccount;
		public Account LoginAccount { get => loginAccount; set { loginAccount = value; ChangeAccount(loginAccount); } }
		public fAccountProfile(Account acc)
		{
			InitializeComponent();
			this.LoginAccount = acc;
		}
		private void ChangeAccount(Account acc)
		{
			txtDisplayname.Text = LoginAccount.Displayname;
			txtLogin.Text = LoginAccount.Username;
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void UpdateAccountInfo()
		{
			string DisplayName = txtDisplayname.Text;
			string password = txtPassword.Text;
			string newpass = txtNewPassword.Text;
			string reenterpass = txtreenterpassword.Text;
			string username = txtLogin.Text;

			if (!newpass.Equals(reenterpass))
			{
				MessageBox.Show("Please re-enter the right new password");
			}
			else
			{
				if (AccountDAO.Instance.UpdataAccount(username, DisplayName, password, newpass))
				{
					MessageBox.Show("Success!!!");
					if(updateAccount!=null)
					{
						updateAccount(this,new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
					}
				}
				else
				{
					MessageBox.Show("Wrong PassWord");
				}
			}
		}
		private event EventHandler<AccountEvent> updateAccount;
		public event EventHandler<AccountEvent> UpdateAccount
		{
			add { updateAccount += value; }
			remove { updateAccount -= value; }
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateAccountInfo();
		}
	}
	public class AccountEvent:EventArgs
	{
		private Account account;

		public Account Account { get => account; set => account = value; }
		public AccountEvent(Account acc)
		{
			this.Account = acc;
		}
	}
}
