using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
	public class HomePageModel : PageModel
	{
		private readonly IRestaurantData _restaurantData;

		public IEnumerable<Restaurant> CurrentRestaurants { get; set; }

		public HomePageModel(IRestaurantData restaurantData)
		{
			_restaurantData = restaurantData;
		}
		public void OnGet()
		{
			CurrentRestaurants = _restaurantData.GetAll(); ;
		}
	}
}