using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Models;
using PhoneBook.API.Queries;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Handlers;
using PhoneBook.Common.Repository;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Handlers
{
    public class BrowsePhoneBooksHandler : IQueryHandler<BrowsePhoneBooks, PagedResult<PhoneBookViewModel>>
    {
        private readonly IPhoneBookRepository _repository;

        private readonly IMapper _mapper;

        public BrowsePhoneBooksHandler(IPhoneBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PhoneBookViewModel>> HandleAsync(BrowsePhoneBooks query)
        {
            var result = _repository.GetAll();
            if (!string.IsNullOrEmpty(query.SearchText))
                result = result.Where(s => s.Name.Contains(query.SearchText) || s.Phone.Contains(query.SearchText));

            var models = _mapper.ProjectTo<PhoneBookViewModel>(result);

            return new PagedResult<PhoneBookViewModel> { Data = models, Total = models.Count() };
        }
    }
}
