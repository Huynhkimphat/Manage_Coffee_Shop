using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DTO
{
	public class Account
	{
		public Account(string username,string displayname,int type,string password=null)
		{
			this.Username = username;
			this.Displayname = displayname;
			this.Type = type;
			this.Password = password;
		}
		public Account(DataRow rows)
		{
			this.Username = rows["username"].ToString();
			this.Displayname = rows["displayname"].ToString();
			this.Type = (int)rows["type"];
			this.Password = rows["password"].ToString();
		}
		private string username;
		private string displayname;
		private string password;
		private int type;
		public string Username { get => username; set => username = value; }
		public string Displayname { get => displayname; set => displayname = value; }
		public string Password { get => password; set => password = value; }
		public int Type { get => type; set => type = value; }
	}
}
