using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class UsersController : ApiController
    {
      
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return new ObjectResult("Hello");
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult>OnPostUploadAsync()
        {
            var result = await Request.Content.ReadAsMultipartAsync();

            var requestJson = await result.Contents[0].ReadAsStringAsync();

            return ResponseMessage(requestJson);
        }
        
    }
}