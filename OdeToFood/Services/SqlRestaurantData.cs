using System;
using System.Collections.Generic;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
	public class SqlRestaurantData : IRestaurantData
	{
		private OdeToFoodDbContext _context;

		public SqlRestaurantData(OdeToFoodDbContext context)
		{
			_context = context;
		}

		public Restaurant Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Restaurant> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
