using Microsoft.AspNetCore.Mvc;

namespace EnvironmentRepro.Controllers
{
	[Route("")]
	[ApiController]
    public class HomeController
	{

		[HttpGet]
	    public ActionResult<string> Get()
		{
			return Startup.EnvironmentName;
		}
    }
}
