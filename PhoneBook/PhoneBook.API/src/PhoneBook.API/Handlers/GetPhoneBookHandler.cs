using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.API.Models;
using PhoneBook.API.Queries;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Handlers;
using PhoneBook.Common.Types;

namespace PhoneBook.API.Handlers
{
    public class GetPhoneBookHandler : IQueryHandler<GetPhoneBook, PhoneBookViewModel>
    {
        private readonly IPhoneBookRepository _repository;

        public GetPhoneBookHandler(IPhoneBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<PhoneBookViewModel> HandleAsync(GetPhoneBook query)
        {
            if (query.Id == default)
                throw new PhoneBookException("undefined id of phonebook");

            var entity = await _repository.GetById(query.Id);
            var model = new PhoneBookViewModel { Id = entity.Id, Name = entity.Name, Phone = entity.Phone };
            return model;
        }
    }
}