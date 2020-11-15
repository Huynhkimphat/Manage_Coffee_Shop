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
	public partial class fLogin : Form
	{
		public fLogin()
		{
			InitializeComponent();
		}
		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtLogin.Text;
			string password = txtPassword.Text;
			if(Login(username,password))
			{
				Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
				fTableManager f = new fTableManager(loginAccount);
				this.Hide();
				f.ShowDialog();//Show dialog: show+ top most
							   //Show: just show
				this.Show();
			}
			else
			{
				MessageBox.Show("Wrong Information");
			}


		}
		bool Login(string username,string password)
		{
			return AccountDAO.Instance.Login(username, password);
		}
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(MessageBox.Show("Do you want to close?","Warning",MessageBoxButtons.OKCancel)!=System.Windows.Forms.DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
	}
}
