using System.Threading.Tasks;
using NSubstitute;
using PhoneBook.API.Commands;
using PhoneBook.API.Handlers;
using PhoneBook.API.Repositories;
using Xunit;

namespace PhoneBook.API.Tests.Handlers
{
    public class CreatePhoneBookHandlerTests
    {
        // [Fact]
        // public async Task handle_async_published_create_phonebook_rejected_if_modelstate_is_invalid()
        // {
        //     var command = new CreatePhoneBook { Name = string.Empty, Phone = string.Empty };
        //     await _commandHandler.HandleAsync(Arg.Is<CreatePhoneBook>(command));

        //     // Assert.

        // }

        #region Essentials
        private readonly IPhoneBookRepository _repository;
        private readonly CreatePhoneBookHandler _commandHandler;

        public CreatePhoneBookHandlerTests()
        {
            _repository = Substitute.For<IPhoneBookRepository>();
            _commandHandler = new CreatePhoneBookHandler(_repository);
        }

        #endregion
    }


}