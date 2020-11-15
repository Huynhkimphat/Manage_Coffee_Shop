using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFFEEMANGE.DAO
{
	public class MenuLDAO
	{
		private static MenuLDAO instance;

		public static MenuLDAO Instance { get { if (instance == null) instance = new MenuLDAO(); return instance; }
										private  set => instance = value; }
		private MenuLDAO() { }

		public List<MenuL> GetListMenuByTable(int id)
		{
			List<MenuL> listMenu = new List<MenuL>();
			string query = "SELECT f.name AS Name, bi.[count] AS count, f.price AS price, f.price*bi.[count] AS total FROM BILLINFO AS bi, BILL AS b, Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status=0 AND b.idTable = "+id;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);

			foreach(DataRow item in data.Rows)
			{
				MenuL menu = new MenuL(item);
				listMenu.Add(menu);
			}
			return listMenu;
		}
	}
}
