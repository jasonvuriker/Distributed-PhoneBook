using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.API.Commands;
using PhoneBook.API.Models;
using PhoneBook.API.Queries;
using PhoneBook.Common.Dispatchers;
using PhoneBook.Common.Filters;
using PhoneBook.Common.Types;

namespace PhoneBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public PhoneBookController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhoneBook command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _dispatcher.SendAsync(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Collection([FromQuery] BrowsePhoneBooks query)
        {
            var response = await _dispatcher.QueryAsync(query);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] DeletePhoneBook command)
        {
            await _dispatcher.SendAsync(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePhoneBook command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _dispatcher.SendAsync(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPhoneBook query)
        {
            var entity = await _dispatcher.QueryAsync(query);
            return Ok(entity);
        }

    }
}