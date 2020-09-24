using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        // GET: /HelloWorld/
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}