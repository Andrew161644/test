using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController: ControllerBase
    {
        public MainController()
        {
            Console.WriteLine("Created");
        }
        // GET api/app
        [HttpGet]
        public async Task<ActionResult<string>> Get(int id)
        {
              return Ok("Hello c# service");
        }
    }
}