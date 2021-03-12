using System;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
namespace NBALeague.Repository
{
    public class EchipaInFileRepository : InFileRepository<string, Echipa>
    {
        public EchipaInFileRepository()
        {
        }

        public EchipaInFileRepository(IValidator<Echipa> validator, string fileName) :
            base(validator,
                 fileName,
                 EntityToFileMapping.CreateEchipa)
        {

        }
    }
}
