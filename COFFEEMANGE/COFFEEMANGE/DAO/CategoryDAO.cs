using COFFEEMANGE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DAO
{
	public class CategoryDAO
	{
		private static CategoryDAO instance;

		public static CategoryDAO Instance { get { if (instance == null) instance = new CategoryDAO(); return instance; } 
			private set => instance = value; }
		private CategoryDAO() { }

		public List<Category> GetListCategory()
		{
			List<Category> list = new List<Category>();
			string query = "select * from FOODCATEGORY";
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach(DataRow item in data.Rows)
			{
				Category category = new Category(item);
				list.Add(category);
			}
			return list;
		}

		public Category GetCategoryByID(int id)
		{
			Category category = null;
			string query = "select * from FOODCATEGORY where id = "+id;
			DataTable data = DataProvider.Instance.ExecuteQuery(query);
			foreach (DataRow item in data.Rows)
			{
				category = new Category(item);
				return category;
			}
			return category;
		}
		public bool InsertCategory(string Name)
		{
			string temp = String.Format("INSERT FOODCATEGORY(name) VALUES ('{0}')", Name);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
		public bool UpdateCategory(int idCategory, string Name)
		{
			string temp = String.Format("UPDATE FOODCATEGORY SET name='{0}' WHERE id={1}", Name, idCategory);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}

		public bool DeleteCategory(int idCategory)
		{
			FoodDAO.Instance.DeleteFoodByCategoryID(idCategory);
			string temp = String.Format("DELETE FOODCATEGORY where id = {0}", idCategory);
			int res = DataProvider.Instance.ExecuteNonQuery(temp);
			return res > 0;
		}
	}
}
