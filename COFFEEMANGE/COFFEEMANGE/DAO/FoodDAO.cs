using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class FoodDAO
	{
		private static FoodDAO instance;

		public static FoodDAO Instance
		{
			get { if (instance == null) instance = new FoodDAO(); return instance; }
			private set => instance = value;
		}
		private FoodDAO() { }

		public List<Food> GetFoodByCategoryID(int id)
		{
			List<Food> list = new List<Food>();
			string query = "select * from food where idCategory = "+id;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Food food = new Food(item);
				list.Add(food);
			}
			return list;
		}

		public List<Food> GetListFood()
		{
			List<Food> list = new List<Food>();
			string query = "select * from food" ;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Food food = new Food(item);
				list.Add(food);
			}
			return list;
		}

		public List<Food> SearchFoodByName(string name)
		{
			List<Food> list = new List<Food>();
			string query = String.Format("select * from food where name like '%{0}%'",name);
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Food food = new Food(item);
				list.Add(food);
			}
			return list;
		}

		public bool InsertFood(string Name, int id,float price)
		{
			string temp = String.Format("INSERT FOOD (name,idCategory,price) VALUES ('{0}' , {1} , {2})", Name, id, price);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);	
			return res>0;
		}
		public bool UpdateFood(int idFood,string Name, int id, float price)
		{
			string temp = String.Format("UPDATE food SET name='{0}' , idCategory={1} , price={2} WHERE id={3}", Name, id, price,idFood);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}

		public bool DeleteFood(int idFood)
		{
			BillInfoDAO.Instance.DeleteBillInfoByFoodId(idFood);
			string temp = String.Format("DELETE FOOD where id = {0}",idFood);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public void DeleteFoodByCategoryID(int id)
		{
			string query = "SELECT * from food where idCategory= " + id;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				Food food = new Food(item);
				DeleteFood(food.ID);
			}
		}
	}
}
