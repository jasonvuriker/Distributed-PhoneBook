using PhoneBook.API.Models;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Queries
{
    public class BrowsePhoneBooks : IQuery<PagedResult<PhoneBookViewModel>>
    {
        public string SearchText { get; set; }
    }
}