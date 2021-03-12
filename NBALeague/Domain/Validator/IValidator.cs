using System;
namespace NBALeague.Domain.Validator
{
    public interface IValidator<E>
    {
        void Validate(E entity);

    }
}
