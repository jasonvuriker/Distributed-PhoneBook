using PhoneBook.API.Commands;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Handlers
{
    public class CreatePhoneBookHandler : ICommandHandler<CreatePhoneBook>
    {
        private readonly IPhoneBookRepository _repository;

        public CreatePhoneBookHandler(IPhoneBookRepository repository)
        {
            _repository = repository;
        }
        
        public async Task HandleAsync(CreatePhoneBook command)
        {
            await _repository.Create(new Entities.PhoneBook { Name = command.Name, Phone = command.Phone });
        }
    }
}
