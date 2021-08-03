using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
	public interface IDepartmentRepository
	{
		//Saying we need a method called GetAllDepartments() that return a collection
		//that conforms to IEnumerable<T>
		IEnumerable<Department> GetAllDepartments();

		void InsertDepartment(string newDepartmentName);
	}
}
