using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
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
			this._configuration = configuration;
			this._customService = customService;
		}

		public string GetMessageOfTheDay()
		{
			return _configuration["Greeting"];
		}
	}
}