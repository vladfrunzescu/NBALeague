using System;
namespace NBALeague.Domain.Validator
{
    public class EchipaValidator : IValidator<Echipa>
    {

        public EchipaValidator() { }

        public void Validate(Echipa entity)
        {
            string errors = "";

            if (entity.ID.Equals("") || entity.ID.Equals(" "))
                {
                    errors += "ID echipa invalid!";
                }

                if (entity.Nume.Equals(""))
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
