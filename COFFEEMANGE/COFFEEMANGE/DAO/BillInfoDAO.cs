﻿using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class BillInfoDAO
	{
		private static BillInfoDAO instance;

		public static BillInfoDAO Instance { get { if (instance == null) instance = new BillInfoDAO();return instance; }
											private set => instance = value; }
		private BillInfoDAO() { }
		public List<BillInfo> GetListBillInfo(int id)
		{
			List<BillInfo> listBillInfo = new List<BillInfo>();
			DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE idBill = " + id);
			foreach (DataRow item in data.Rows)
			{
				BillInfo info = new BillInfo(item);
				listBillInfo.Add(info);
			}

			return listBillInfo;
		}
		public void InsertBillInfo(int idBill,int idFood,int count)
		{
			DataProvider.Instance.ExecuteNonQuery("USP_INSERTBILLINFO @idBill , @idFood , @count", new object[] { idBill,idFood,count});
		}
		public void DeleteBillInfoByFoodId(int id)
		{
			DataProvider.Instance.ExecuteQuery("Delete BillInfo WHERE idFood = " + id);
		}
		public void DeleteBillInfoByBillId(int id)
		{
			DataProvider.Instance.ExecuteQuery("Delete BillInfo WHERE idBill = " + id);
		}
	}
}
