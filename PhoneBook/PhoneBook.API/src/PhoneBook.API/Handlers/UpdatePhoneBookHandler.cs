using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.API.Commands;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Handlers;

namespace PhoneBook.API.Handlers
{
    public class UpdatePhoneBookHandler : ICommandHandler<UpdatePhoneBook>
    {
        private readonly IPhoneBookRepository _repository;
        private readonly IMapper _mapper;
        public UpdatePhoneBookHandler(IPhoneBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task HandleAsync(UpdatePhoneBook command)
        {
            var entity = await _repository.GetById(command.Id);
            _mapper.Map(command, entity);
            await _repository.Update(entity);
        }
    }
}