using System;
namespace NBALeague.Domain.Validator
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message) { }
    }
}
