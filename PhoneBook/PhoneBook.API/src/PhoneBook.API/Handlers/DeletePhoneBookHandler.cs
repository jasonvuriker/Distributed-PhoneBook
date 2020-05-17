using System.Threading.Tasks;
using PhoneBook.API.Commands;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Handlers;

namespace PhoneBook.API.Handlers
{
    public class DeletePhoneBookHandler : ICommandHandler<DeletePhoneBook>
    {
        private readonly IPhoneBookRepository _repository;
        public DeletePhoneBookHandler(IPhoneBookRepository repository)
        {
            _repository = repository;

        }
        public Task HandleAsync(DeletePhoneBook command)
        {
            _repository.Delete(command.Id);

            return Task.CompletedTask;
        }
    }
}