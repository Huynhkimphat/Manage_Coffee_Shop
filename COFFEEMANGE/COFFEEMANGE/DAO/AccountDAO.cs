using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class AccountDAO
	{
		private static AccountDAO instance;

		public static AccountDAO Instance { 
			get
			{ 
				if(instance==null) 
				{
					instance = new AccountDAO();
				}
				return instance; 
			}
			private set => instance = value; }
		private AccountDAO() { }
		public bool Login(string username,string password)
		{
			string query = "USP_Login @userName , @passWord";
			DataTable res = DataProvider.Instance.ExecuteQuery(query,new object[] {username,password});
			return res.Rows.Count>0;
		}
		public bool UpdataAccount(string userName,string displayName,string pass,string newpass)
		{
			int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdataAccount @username , @DisplayName , @password , @newPassword ",new object[] { userName,displayName,pass,newpass});
			return result > 0;
		}
		public DataTable GetListAccount()
		{
			return DataProvider.Instance.ExecuteQuery("Select username, displayname, type from account");
		}
		public Account GetAccountByUserName(string username)
		{
			DataTable data=DataProvider.Instance.ExecuteQuery("Select * from Account where username = '" + username+"'");
			foreach(DataRow item in data.Rows)
			{
				return new Account(item);
			}
			return null;
		}
		public bool InsertAccount(string username, string displayname,int type)
		{
			string temp = String.Format("INSERT ACCOUNT (UserName, DisplayName, Type) VALUES ('{0}' , '{1}' , {2})", username, displayname, type);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public bool UpdateAccountAdmin( string username, string displayname, int type)
		{
			string temp = String.Format("UPDATE ACCOUNT SET DisplayName='{1}' , Type= {2} WHERE UserName='{0}'", username, displayname, type);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}

		public bool DeleteAccount(string username)
		{

			string temp = String.Format("DELETE ACCOUNT where UserName = '{0}'", username);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public bool ResetPassword(string username)
		{
			string temp = String.Format("UPDATE ACCOUNT SET password=0 WHERE UserName='{0}'", username);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
	}
}
