using System;
namespace NBALeague.UI
{
    public class UIException : ApplicationException
    {
        
        public UIException()
        {
        }

        public UIException(string message) : base(message) { }
    }
}
