using System;

namespace PhoneBook.Common.Types
{
    public class PhoneBookException : Exception
    {
        public string Code { get; }

        public PhoneBookException()
        {
        }

        public PhoneBookException(string code)
        {
            Code = code;
        }

        public PhoneBookException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public PhoneBookException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public PhoneBookException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public PhoneBookException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}