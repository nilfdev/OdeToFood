using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRestaurantData _restaurantData;
		private readonly IGreeter _greeter;

		public HomeController(IRestaurantData restaurantData, IGreeter greeter)
		{
			_restaurantData = restaurantData;
			_greeter = greeter;
		}

		public IActionResult Index()
		{
			var model = new HomeIndexViewModel
			{
				Restaurants = _restaurantData.GetAll(),
				CurrentMessage = _greeter.GetMessageOfTheDay()
			};

			return View(model);
		}

		public IActionResult Details(int id)
		{
			var model = _restaurantData.Get(id);

			if (model == null)
			{
				return RedirectToAction(nameof(this.Index));
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(RestaurantEditModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var newRestaurant = new Restaurant
			{
				Name = model.Name,
				Cuisine = model.Cuisine
			};
			newRestaurant = _restaurantData.Add(newRestaurant);

			return RedirectToAction(nameof(this.Details), new { id = newRestaurant.Id, foo = "bar" });

		}
	}
}
