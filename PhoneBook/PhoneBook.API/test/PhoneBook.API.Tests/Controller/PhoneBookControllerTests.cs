using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSubstitute;
using PhoneBook.API.Commands;
using PhoneBook.API.Controllers;
using PhoneBook.API.Handlers;
using PhoneBook.API.Models;
using PhoneBook.API.Queries;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Dispatchers;
using PhoneBook.Common.Types;
using Xunit;
using Xunit.Abstractions;

namespace PhoneBook.API.Tests.Controller
{
    public class PhoneBookControllerTests
    {

        #region GetPhoneBook

        [Theory]
        [MemberData(nameof(GetPhoneBookSuccesMocks))]
        public async Task GetPhoneBookByIdMustSuccess(GetPhoneBook query, PhoneBookViewModel expected)
        {
            _dispatcher.QueryAsync(query).Returns(Task.FromResult(expected));

            var result = await _controller.Get(query);
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
            Assert.Equal(expected, okResult.Value);
        }


        // [Fact]
        // public async Task GetPhoneBookByIdModelStateError()
        // {
        //     var query = new GetPhoneBook();
        //     _controller.ModelState.AddModelError("Name","The Name field is required.");

        //     var result = await _controller.Get(query);
        //     Assert.IsType<BadRequestObjectResult>(result);
        // }

        public static IEnumerable<object[]> GetPhoneBookSuccesMocks()
        {
            yield return new object[] { new GetPhoneBook { Id = 2 }, new PhoneBookViewModel { Id = 2, Name = "Jasur", Phone = "+998998431129" } };
            yield return new object[] { new GetPhoneBook { Id = 4 }, new PhoneBookViewModel { Id = 4, Name = "Maksim", Phone = "+998946461129" } };
            yield return new object[] { new GetPhoneBook { Id = 5 }, new PhoneBookViewModel { Id = 5, Name = "Eugene", Phone = "+998998231429" } };
        }

        #endregion

        #region BrowsePhoneBookCollection

        [Fact]
        public async Task GetPhoneBookAllMustSuccess()
        {
            var list = new List<PhoneBookViewModel>{
                new PhoneBookViewModel { Id = 2, Name = "Jasur", Phone = "+998998431129" },
                new PhoneBookViewModel { Id = 4, Name = "Maksim", Phone = "+998946461129"},
                new PhoneBookViewModel { Id = 5, Name = "Eugene", Phone = "+998998231429"}
            };
            var expected = new PagedResult<PhoneBookViewModel>() { Data = list, Total = list.Count };

            var query = new BrowsePhoneBooks();
            _dispatcher.QueryAsync(query).Returns(Task.FromResult(expected));

            var result = await _controller.Collection(query);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.Equal(expected, okResult.Value);
        }

        #endregion

        #region DeletePhoneBook

        [Fact]
        public async Task DeletePhoneBookMustSuccess()
        {
            var command = new DeletePhoneBook { Id = 1 };
            var result = _controller.Delete(command);

            await _dispatcher.Received().SendAsync(Arg.Is<DeletePhoneBook>(x => x.Id == 1));

            Assert.IsType<OkResult>(result.Result);
        }

        #endregion

        #region CreatePhoneBook

        [Fact]
        public async Task CreatePhoneBookSuccessReturnOkResult()
        {
            var command = new CreatePhoneBook { Name = "Jasur", Phone = "+998998431129" };

            var result = _controller.Create(command);

            await _dispatcher.Received().SendAsync(Arg.Is<CreatePhoneBook>(x => x != null));

            Assert.IsType<OkResult>(result.Result);
        }

        [Fact]
        public async Task CreatePhoneBookFailModelStateReturnBadRequest()
        {
            var command = new CreatePhoneBook { Name = null, Phone = null };

            _controller.ModelState.AddModelError("Name", "The Name field is required.");
            _controller.ModelState.AddModelError("Phone", "The Phone field is required.");
            var result = _controller.Create(command);

            await _dispatcher.DidNotReceive().SendAsync(Arg.Is<CreatePhoneBook>(x => x != null));

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        #endregion

        #region UpdatePhoneBook

        [Fact]
        public async Task UpdatePhoneBookSuccessReturnOkResult()
        {
            var command = new UpdatePhoneBook { Id = 4, Name = "Jasur", Phone = "+998998431129" };

            var result = _controller.Update(command);

            await _dispatcher.Received().SendAsync(Arg.Is<UpdatePhoneBook>(x => x != null));

            Assert.IsType<OkResult>(result.Result);
        }

        [Fact]
        public async Task UpdatePhoneBookFailModelStateReturnBadRequest()
        {
            var command = new UpdatePhoneBook { Id = 4, Name = null, Phone = null };

            _controller.ModelState.AddModelError("Name", "The Name field is required.");
            _controller.ModelState.AddModelError("Phone", "The Phone field is required.");
            var result = _controller.Update(command);

            await _dispatcher.DidNotReceive().SendAsync(Arg.Is<UpdatePhoneBook>(x => x != null));

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        #endregion

        #region ARRANGE

        private readonly IDispatcher _dispatcher;
        private readonly PhoneBookController _controller;
        private readonly IPhoneBookRepository _repository;

        public PhoneBookControllerTests()
        {
            _repository = Substitute.For<IPhoneBookRepository>();
            _dispatcher = Substitute.For<IDispatcher>();
            _controller = new PhoneBookController(_dispatcher);
        }

        #endregion
    }
}