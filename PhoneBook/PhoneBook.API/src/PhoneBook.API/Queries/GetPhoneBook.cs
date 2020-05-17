using System.ComponentModel.DataAnnotations;
using PhoneBook.API.Models;
using PhoneBook.Common.Types;

namespace PhoneBook.API.Queries
{
    public class GetPhoneBook : IQuery<PhoneBookViewModel>
    {
        [Required]
        public int Id { get; set; }
    }
}