using PhoneBook.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Entities
{
    public class PhoneBook : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
