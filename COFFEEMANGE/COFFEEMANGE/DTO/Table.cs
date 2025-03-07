﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COFFEEMANGE.DTO
{
	public class Table
	{
		public Table(int id, string name,string status)
		{
			this.ID = id;
			this.Name = name;
			this.Status = status;
		}
		public Table(DataRow row)
		{
			this.ID = (int)row["id"];
			this.Name=(string)row["name"];
			this.Status = (string)row["status"];
		}
		private string status;
		private string name;
		private int iD;

		public string Status { get => status; set => status = value; }
		public string Name { get => name; set => name = value; }
		public int ID { get => iD; set => iD = value; }
	}
}
