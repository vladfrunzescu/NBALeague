using System;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
using System.Configuration;
using System.IO;
namespace NBALeague.Repository
{
    public class JucatorActivInFileRepository : InFileRepository<string, JucatorActiv>
    {
        public JucatorActivInFileRepository()
        {
        }

        public JucatorActivInFileRepository(IValidator<JucatorActiv> validator, string fileName) :
            base(validator, fileName, EntityToFileMapping.CreateJucatorActiv)
        {
        }
    }
}
