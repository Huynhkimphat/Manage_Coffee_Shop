using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DTO
{
	public class Bill
	{
		public Bill(int id,DateTime? dateCheckin,DateTime dateCheckout,int status,int discount=0)
		{
			this.iD = id;
			this.DateCheckIn = dateCheckin;
			this.DateCheckOut = DateCheckOut;
			this.Status = status;
			this.Discount = discount;
		}
		public Bill(DataRow row)
		{
			this.iD = (int)row["id"];
			this.DateCheckIn = (DateTime?)row["DateCheckIn"];
			var DataCheckOutTemp = row["DateCheckOut"];
			if(DataCheckOutTemp.ToString()!="")
			{
				this.DateCheckOut = (DateTime?)DataCheckOutTemp;
			}	
			
			this.Status = (int)row["status"];


			if(row["DISCOUNT"].ToString() != "")
			{
				this.Discount = (int)row["DISCOUNT"];
			}
			
		}
		private int discount;
		private DateTime? dateCheckIn;
		private DateTime? dateCheckOut;
		private int iD;
		private int status;
		public int ID { get => iD; set => iD = value; }
		public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
		public int Status { get => status; set => status = value; }
		public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
		public int Discount { get => discount; set => discount = value; }
	}
}
