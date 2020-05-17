using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PhoneBook.API.Handlers;
using PhoneBook.API.Models;
using PhoneBook.API.Queries;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Types;
using Xunit;

namespace PhoneBook.API.Tests.Handlers
{
    public class GetPhoneBookHandlerTests
    {
        [Theory]
        [MemberData(nameof(GetSuccessMocks))]
        public async Task MustGetSingleById(Entities.PhoneBook input, GetPhoneBook query, PhoneBookViewModel expected)
        {
            _repository.GetById(query.Id).Returns(Task.FromResult(input));
            var result = await _handler.HandleAsync(query);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetPhoneBookByIdMustThrowException()
        {
            var query = new GetPhoneBook();
            await Assert.ThrowsAsync<PhoneBookException>(() => _handler.HandleAsync(query));
        }

        public static IEnumerable<object[]> GetSuccessMocks()
        {
            yield return new object[]
            {
                new Entities.PhoneBook { Id = 4, Name = "Jasur", Phone = "+998946461129" },
                new GetPhoneBook { Id = 4 } ,
                new PhoneBookViewModel { Id = 4, Name = "Jasur", Phone = "+998946461129" }
            };
        }


        #region ARRANGE

        private readonly GetPhoneBookHandler _handler;

        private readonly IPhoneBookRepository _repository;
        public GetPhoneBookHandlerTests()
        {
            _repository = Substitute.For<IPhoneBookRepository>();
            _handler = new GetPhoneBookHandler(_repository);
        }

        #endregion
    }
}