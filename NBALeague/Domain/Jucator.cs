using System;
namespace NBALeague.Domain
{
    public class Jucator : Elev
    {
        public Echipa Echipa { get; set; }

        public Jucator(string ID, Echipa Echipa)
        {
            this.ID = ID;
            this.Echipa = Echipa;
        }

        public Jucator() { }

        public override string ToString()
        {
            return ID + " " + Nume + " " + Scoala + " " + Echipa;
        }
    }
}
