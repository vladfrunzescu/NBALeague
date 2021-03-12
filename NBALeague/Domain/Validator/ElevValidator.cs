using System;
namespace NBALeague.Domain.Validator
{
    public class ElevValidator : IValidator<Elev>
    {
        public ElevValidator() { }

        public void Validate(Elev entity)
        {
            string errors = "";

            if (entity.ID.Equals("") || entity.ID.Equals(" "))
            {
                errors += "ID elev invalid!";
            }

            if (entity.Nume.Equals(""))
            {
                errors += "Nume elev invalid!";
            }

            if (entity.Scoala.Equals(""))
            {
                errors += "Numele scolii elevului este invalid!";
            }


            if (!errors.Equals(""))
            {
                throw new ValidationException(errors);
            }
        }
    }
}
