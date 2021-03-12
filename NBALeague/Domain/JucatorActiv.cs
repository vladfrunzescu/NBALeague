using System;
namespace NBALeague.Domain
{
    public enum TipJucator
    {
        Rezerva, Participant
    }
    public class JucatorActiv : Entity<string>
    {
        public string IDJucator { get; set; }

        public string IDMeci { get; set; }

        public int NrPuncteInscrise { get; set; }

        public TipJucator Tip { get; set; }

        public JucatorActiv (string ID, string IDJucator, string IDMeci, int NrPuncteInscrise, TipJucator Tip)
        {
            this.ID = ID;
            this.IDJucator = IDJucator;
            this.IDMeci = IDMeci;
            this.NrPuncteInscrise = NrPuncteInscrise;
            this.Tip = Tip;
        }

        public JucatorActiv() { }

        public override string ToString()
        {
            return IDJucator + " " + IDMeci + " " + NrPuncteInscrise + " " + Tip;
        }
    }
}
