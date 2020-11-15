using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class TableDAO
	{
		private static TableDAO instance;

		internal static TableDAO Instance 
		{ 
			get
			{
				if(instance==null)
				{
					instance = new TableDAO();
				}
				return instance;
			}
			private set => instance = value;
		}

		public static int TableWidth = 100;
		public static int TableHeight = 100;
		private TableDAO() { }
		public void SwitchTable(int id1,int id2)
		{
			DataProvider.Instance.ExecuteQuery("USP_SWITCHTABLE @idTable1 , @idTable2", new object[] { id1, id2 });
		}
		public List<Table> LoadTableList()
		{
			List<Table> tableList = new List<Table>();
			DataTable data = DataProvider.Instance.ExecuteQuery("USP_GETTABLELIST");
			foreach(DataRow item in data.Rows)
			{
				Table table = new Table(item);
				tableList.Add(table);
			}
			return tableList;
		}
		public bool InsertTable(string Name)
		{
			string temp = String.Format("INSERT TABLEFOOD(name) VALUES ('{0}')", Name);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public bool UpdateTable(int idTable, string Name)
		{
			string temp = String.Format("UPDATE TABLEFOOD SET name='{0}' WHERE id={1}", Name, idTable);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}

		public bool DeleteTable(int idTable)
		{
			BillDAO.Instance.DeleteBillByTableID(idTable);
			string temp = String.Format("DELETE TABLEFOOD where id = {0}", idTable);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
	}
}
