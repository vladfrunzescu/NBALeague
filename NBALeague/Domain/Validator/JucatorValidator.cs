using System;
namespace NBALeague.Domain.Validator
{
    public class JucatorValidator : IValidator<Jucator>
    {
        public JucatorValidator() { }
        public void Validate(Jucator entity)
        {
            string errors = "";

            if (entity.ID.Equals("") || entity.ID.Equals(" "))
            {
                errors += "ID jucator invalid!";
            }

            if (entity.Nume.Equals(""))
            {
                errors += "Nume jucator invalid!";
            }

            if (entity.Scoala.Equals(""))
            {
                errors += "Numele scolii este invalid!";
            }

            if (entity.Echipa.ID.Equals("") || entity.Echipa.ID.Equals(" "))
            {
                errors += "ID echipa invalid!";
            }

            if (entity.Echipa.Nume.Equals(""))
            {
                errors += "Nume echipa invalid!";
            }

            if (!errors.Equals(""))
            {
                throw new ValidationException(errors);
            }
        }
    }
}
