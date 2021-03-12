using System;
namespace NBALeague.Domain
{
    public class Meci : Entity<string>
    {
        public Echipa Gazda { get; set; }

        public Echipa Oaspete { get; set; }

        public DateTime Data { get; set; }

        public Meci(string ID, Echipa Gazda, Echipa Oaspete, DateTime Data)
        {
            this.ID = ID;
            this.Gazda = Gazda;
            this.Oaspete = Oaspete;
            this.Data = Data;
        }

        public Meci() { }

        public override string ToString()
        {
            return ID + " " + Gazda + " " + Oaspete + " " + Data;
        }
    }
}
