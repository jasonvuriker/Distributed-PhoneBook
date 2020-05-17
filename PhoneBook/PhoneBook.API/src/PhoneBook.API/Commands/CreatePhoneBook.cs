using PhoneBook.Common.Handlers;
using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Commands
{
    public class CreatePhoneBook : ICommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
