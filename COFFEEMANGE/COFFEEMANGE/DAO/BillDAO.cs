using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class BillDAO
	{
		private static BillDAO instance;

		internal static BillDAO Instance 
		{
			get
			{
				if (instance == null) instance = new BillDAO();
				return instance;
			}
			private set => instance = value;
		}
		private BillDAO() { }


		public int GetUncheckedBillIDByTableID(int id)
		{
			DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idTable = " + id + " AND status = 0");

			if (data.Rows.Count > 0)
			{
				Bill bill = new Bill(data.Rows[0]);
				return bill.ID;
			}

			return -1;
		}

		public void CheckOut(int id,int discount,float totalPrice)
		{
			string query = "UPDATE bill SET bill.[status]= 1 , "+" DISCOUNT = "+ discount+ ", DateCheckOut = GETDATE() , totalPrice = "+totalPrice+" WHERE id = " + id;
			DataProvider.Instance.ExecuteNonQuery(query);
		}

		public DataTable GetBillListByDate(DateTime checkIn,DateTime checkOut)
		{
			return DataProvider.Instance.ExecuteQuery("USP_GETLISTVIEWBYDATE @checkIn , @checkOut",new object[] {checkIn,checkOut });
		}
		public void InsertBill(int id)
		{
			DataProvider.Instance.ExecuteNonQuery("USP_INSERTBILL @idTable",new object[] { id });
		}
		public int GetMaxBillID()
		{
			try
			{
				return (int)DataProvider.Instance.ExecuteScalar("Select MAX(id) from Bill");
			}
			catch
			{
				return 1;
			}
		}
		public bool DeleteBil(int idBill)
		{
			BillInfoDAO.Instance.DeleteBillInfoByBillId(idBill);
			string temp = String.Format("DELETE Bill where id = {0}", idBill);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public void DeleteBillByTableID (int id)
		{
			string query = "SELECT * from Bill where idTable= " + id;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Bill bill = new Bill(item);
				DeleteBil(bill.ID);
			}
		}
	}
}
