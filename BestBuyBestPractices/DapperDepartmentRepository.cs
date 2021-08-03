using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;

namespace BestBuyBestPractices
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
		private readonly IDbConnection _connection;

		public DapperDepartmentRepository(IDbConnection connection)
		{
			//Constructor 
			_connection = connection;
		}

		public IEnumerable<Department> GetAllDepartments()
		{
			var depos = _connection.Query<Department>("SELECT * FROM Departments");
			return depos;
		}

		public void InsertDepartment(string newDepartmentName)
		{
			_connection.Execute("Insert Into Departments (Name) Values (@departmentName);", new { departmentName = newDepartmentName });
		}
	}
}
