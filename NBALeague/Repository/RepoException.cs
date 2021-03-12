using System;
namespace NBALeague.Repository
{
    public class RepoException : ApplicationException
    {
        public RepoException()
        {
        }

        public RepoException(string message) : base(message) { }
    }
}
