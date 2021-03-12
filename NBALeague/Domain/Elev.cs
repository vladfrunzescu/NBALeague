using System;
namespace NBALeague.Domain
{
    public class Elev : Entity<string>
    {
        public string Nume { get; set; }

        public string Scoala { get; set; }

        public Elev(string ID, string Nume, String Scoala)
        {
            this.ID = ID;
            this.Nume = Nume;
            this.Scoala = Scoala;
        }

        public Elev() { }

        public override string ToString()
        {
            return ID + " " + Nume + " " + Scoala;
        }
    }
}
