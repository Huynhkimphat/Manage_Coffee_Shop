using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DTO
{
	public class MenuL
	{
		public MenuL(string foodname,int count,float price,float total=0)
		{
			this.Foodname = foodname;
			this.Count = count;
			this.Price = price;
			this.Total = total;
		}
		public MenuL(DataRow row)
		{
			this.Foodname =row["Name"].ToString();
			this.Count = (int)row["count"];
			this.Price = (float)Convert.ToDouble(row["price"].ToString());
			this.Total = (float)Convert.ToDouble(row["total"].ToString());
		}
		private string foodname;
		private int count;
		private float price;
		private float total;

		public string Foodname { get => foodname; set => foodname = value; }
		public int Count { get => count; set => count = value; }
		public float Price { get => price; set => price = value; }
		public float Total { get => total; set => total = value; }
	}
}
