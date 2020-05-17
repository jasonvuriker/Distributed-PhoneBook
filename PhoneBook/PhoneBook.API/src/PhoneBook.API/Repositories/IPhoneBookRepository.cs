using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Repositories
{
    public interface IPhoneBookRepository
    {
        IQueryable<PhoneBook.API.Entities.PhoneBook> GetAll();

        Task Create(Entities.PhoneBook entity);

        Task Delete(int id);

        Task Update(Entities.PhoneBook entity);

        Task<Entities.PhoneBook> GetById(int id);
    }
}
