using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
	public interface IGreeter
	{
		string GetMessageOfTheDay();
	}
	public class Greeter : IGreeter
	{
		private IConfiguration _configuration;
		private ICustomService _customService;

		public Greeter(IConfiguration configuration, ICustomService customService)
		{
			_configuration = configuration;
			_customService = customService;
		}

		public string GetMessageOfTheDay()
		{
			return _configuration["Greeting"];
		}
	}
}