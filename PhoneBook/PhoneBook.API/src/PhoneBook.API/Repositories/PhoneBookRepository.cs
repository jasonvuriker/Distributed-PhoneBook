using PhoneBook.API.Entities;
using PhoneBook.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly IRepository<Entities.PhoneBook> _repository;
        public PhoneBookRepository(IRepository<Entities.PhoneBook> repository)
        {
            _repository = repository;
        }

        public async Task Create(Entities.PhoneBook entity)
        {
            await _repository.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            _repository.Delete(id);
            return Task.CompletedTask;
        }

        public IQueryable<Entities.PhoneBook> GetAll()
        {
            return _repository.Query();
        }

        public async Task<Entities.PhoneBook> GetById(int id)
        {
            return await _repository.SingleAsync(id);
        }

        public Task Update(Entities.PhoneBook entity)
        {
            _repository.Update(entity);
            return Task.CompletedTask;
        }
    }
}
