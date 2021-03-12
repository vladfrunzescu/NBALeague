using System;
using NBALeague.Repository;
namespace NBALeague.Domain.Validator
{
    public class JucatorActivValidator : IValidator<JucatorActiv>
    {
        //aici avem repository pentru ca nu avem obiectul (ca la celelalte validatoare)
        private IRepository<string, Jucator> repoJucator;
        private IRepository<string, Meci> repoMeci;

        public JucatorActivValidator(IRepository<string, Jucator> repoJucator, IRepository<string, Meci> repoMeci)
        {
            this.repoJucator = repoJucator;
            this.repoMeci = repoMeci;
        }

        public void Validate(JucatorActiv entity)
        {
            string errors = "";

            if (entity.ID.Equals("") || entity.ID.Equals(" "))
            {
                errors += "ID jucator activ invalid!";
            }

            if (entity.IDJucator.Equals("") || entity.IDJucator.Equals(" "))
            {
                errors += "ID jucator invalid!";
            }

            if (entity.IDMeci.Equals("") || entity.IDMeci.Equals(" "))
            {
                errors += "ID meci invalid!";
            }

            if(entity.NrPuncteInscrise < 0)
            {
                errors += "Numar puncte invalid!";
            }

            if(repoJucator.FindOne(entity.IDJucator) == null)
            {
                errors += "ID Jucator inexistent!";
            }

            if (repoMeci.FindOne(entity.IDMeci) == null)
            {
                errors += "ID Meci inexistent!";
            }

            if (!errors.Equals(""))
            {
                throw new ValidationException(errors);
            }
        }
    }
}
