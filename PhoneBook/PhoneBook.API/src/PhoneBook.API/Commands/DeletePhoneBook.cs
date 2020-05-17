using PhoneBook.Common.Types;

namespace PhoneBook.API.Commands
{
    public class DeletePhoneBook : ICommand
    {
        public int Id { get; set; }
    }
}