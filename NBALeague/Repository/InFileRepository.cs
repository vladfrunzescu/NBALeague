using System;
using System.Collections.Generic;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
namespace NBALeague.Repository
{ 
    public delegate E CreateEntity<E>(string line);

    public abstract class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E:Entity<ID>
    {
        protected string fileName;
        protected CreateEntity<E> createEntity;

        public InFileRepository()
        {
        }

        public InFileRepository(IValidator<E> validator, string fileName, CreateEntity<E> createEntity) :
        base(validator)
        {
            this.fileName = fileName;
            this.createEntity = createEntity;

            if(createEntity != null)
            {
                LoadFromFile();
            }
        }

        protected virtual void LoadFromFile()
        {
            List<E> list = DataReader.ReadData(fileName, createEntity);
            list.ForEach(x => entities[x.ID] = x);
        }
    }
}
