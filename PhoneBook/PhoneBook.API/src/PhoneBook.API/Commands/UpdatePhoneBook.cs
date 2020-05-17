using System.ComponentModel.DataAnnotations;
using PhoneBook.Common.Types;

namespace PhoneBook.API.Commands
{
    public class UpdatePhoneBook:ICommand
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}