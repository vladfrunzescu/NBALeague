using System;
namespace NBALeague.Domain
{
    public class Echipa : Entity<string>
    {
        public string Nume { get; set; }

        public Echipa(string ID, string Nume)
        {
            this.ID = ID;
            this.Nume = Nume;
        }

        public Echipa(string Nume)
        { 
            this.Nume = Nume;
        }

        public Echipa() {}

        public override string ToString()
        {
            return ID + " " + Nume;
        }
    }
}
