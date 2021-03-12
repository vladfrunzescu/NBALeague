using System;
namespace NBALeague.Domain
{
    public class ScorDTO
    {
        public ScorDTO()
        {
        }

        public Echipa Gazda { get; set; }

        public Echipa Oaspete { get; set; }

        public int ScorGazda;

        public int ScorOaspete;

        public ScorDTO(Echipa Gazda, Echipa Oaspete, int ScorGazda, int ScorOaspete)
        {
            this.Gazda = Gazda;
            this.Oaspete = Oaspete;
            this.ScorGazda = ScorGazda;
            this.ScorOaspete = ScorOaspete;
        }

        public override string ToString()
        {
            return "Echipa: " + Gazda + ", Scor: " + ScorGazda + "; Echipa: " + Oaspete + ", Scor: " + ScorOaspete;
        }
    }
}
