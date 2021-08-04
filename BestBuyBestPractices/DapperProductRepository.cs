using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
	public class DapperProductRepository : IProductRepository
	{
		private readonly IDbConnection _connection;

		public DapperProductRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public void CreateProduct(string name, double price, int categoryID)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _connection.Query<Product>("Select * From Products;");
			
		}
	}
}
