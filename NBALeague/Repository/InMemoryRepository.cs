using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
namespace NBALeague.Repository
{
    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E:Entity<ID>
    {
        
        protected IValidator<E> validator;
        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

        public InMemoryRepository()
        {
        }

        public InMemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
        }

        public E Delete(ID id)
        {
            if (id == null)
            {
                throw new RepoException("ID-ul nu poate fi null!");
            }

           E copy = entities[id];
           if( entities.Remove(id))
            {
                return copy;
            }
            return null;
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values.ToList<E>();
        }

        public E FindOne(ID id)
        {
            if (entities.ContainsKey(id))
            {
                return entities[id];
            }
            else
            {
                return null;
            }
        }

        public E Save(E entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Entitatea nu poate fi null!");
            }

            validator.Validate(entity);

            if (entities.ContainsKey(entity.ID))
            {
                return null;
            }

            entities[entity.ID] = entity;
            return entity;
        }

        public E Update(E entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entitatea nu poate fi null!");
            }

            validator.Validate(entity);

            if (entities.ContainsKey(entity.ID))
            {
                entities[entity.ID] = entity;
                return entity;
            }

            return null;
        }
    }
}
