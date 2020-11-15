using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DTO
{
	public class BillInfo
	{
		private BillInfo(int iD,int billiD,int foodiD,int count)
		{
			this.ID = iD;
			this.BilliD = billiD;
			this.FoodiD = foodiD;
			this.Count = count;
		}
		public BillInfo(DataRow row)
		{
			this.ID = (int)row["iD"];
			this.BilliD = (int)row["idBill"];
			this.FoodiD = (int)row["idFood"];
			this.Count = (int)row["count"];
		}
		private int count;
		private int iD;
		private int billiD;
		private int foodiD;
		public int ID { get => iD; set => iD = value; }
		public int BilliD { get => billiD; set => billiD = value; }
		public int FoodiD { get => foodiD; set => foodiD = value; }
		public int Count { get => count; set => count = value; }
	}
}
