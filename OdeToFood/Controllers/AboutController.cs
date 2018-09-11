using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
	[Route("company/[controller]/[action]")]
	public class AboutController
	{

		public string Phone()
		{
			return "123456";
		}

		public string Adress()
		{
			return "USA";
		}
	}
}