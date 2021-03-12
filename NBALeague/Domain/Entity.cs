using System;
using System.Collections.Generic;
using System.Text;

namespace NBALeague.Domain
{
    public class Entity<TID>
    {
        public TID ID { get; set; }

        public Entity(TID ID)
        {
            this.ID = ID;
        }

        public Entity() { }
    }
}
