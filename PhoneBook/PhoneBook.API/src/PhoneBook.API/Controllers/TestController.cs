using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneBook.Common.Dispatchers;

namespace PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly PhoneBookController _controller;
        public TestController(IDispatcher dispatcher)
        {
            _controller = new PhoneBookController(dispatcher);
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var result = await _controller.Collection(new Queries.BrowsePhoneBooks());
            Console.WriteLine(JsonConvert.SerializeObject(result));
            return Ok(result);
        }
    }
}