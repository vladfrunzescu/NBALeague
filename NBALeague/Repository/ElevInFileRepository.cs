using System;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
namespace NBALeague.Repository
{
    public class ElevInFileRepository : InFileRepository<string, Elev>
    {
        public ElevInFileRepository()
        {
        }

        public ElevInFileRepository(IValidator<Elev> validator, string fileName) :
            base(validator, fileName, EntityToFileMapping.CreateElev)
        {

        }

    }
}
