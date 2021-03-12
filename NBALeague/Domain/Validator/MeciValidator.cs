using System;
namespace NBALeague.Domain.Validator
{
    public class MeciValidator : IValidator<Meci>
    {
        public MeciValidator(){ }
        public void Validate(Meci entity)
        {
            string errors = "";

            if (entity.ID.Equals("") || entity.ID.Equals(" "))
            {
                errors += "ID meci invalid!";
            }

            if (entity.Gazda.ID.Equals("") || entity.Gazda.ID.Equals(" "))
            {
                errors += "ID gazda invalid!";
            }

            if (entity.Gazda.Nume.Equals(""))
            {
                errors += "Nume gazda invalid!";
            }

            if (entity.Oaspete.ID.Equals("") || entity.Oaspete.ID.Equals(" "))
            {
                errors += "ID oaspeti invalid!";
            }

            if (entity.Oaspete.Nume.Equals(""))
            {
                errors += "Nume oaspeti invalid!";
            }

            if(entity.Data <= DateTime.Now)
            {
                errors += "Data invalida!";
            }

            if (!errors.Equals(""))
            {
                throw new ValidationException(errors);
            }
        }

    }
}
