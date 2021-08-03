using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace BestBuyBestPractices
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Configuration

			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			string connString = config.GetConnectionString("DefaultConnection");
			#endregion

			IDbConnection conn = new MySqlConnection(connString);
			DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

			Console.WriteLine("Current departments:");
			Console.WriteLine("PLease press enter...");
			Console.ReadLine();

			var depos = repo.GetAllDepartments();
			Print(depos);

			Console.WriteLine("Adda department?");
			string userResponse = Console.ReadLine();
			if(userResponse.ToLower() == "yes")
			{
				Console.WriteLine("Department name?");
				userResponse = Console.ReadLine();
				repo.InsertDepartment(userResponse);
			}
		}

		private static void Print(IEnumerable<Department> depos)
		{
			foreach (var depo in depos)
			{
				Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
			}

		}
	}
}
