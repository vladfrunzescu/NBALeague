using System;
namespace NBALeague.Domain
{
    public class JucatorActivDTO
    {
        public JucatorActivDTO()
        {
        }

        public Jucator Jucator { get; set; }

        public Meci Meci { get; set; }

        public int NrPuncteInscrise { get; set; }

        public TipJucator Tip { get; set; }

        public JucatorActivDTO(Jucator Jucator, Meci Meci, string IDMeci, int NrPuncteInscrise, TipJucator Tip)
        {
            this.Jucator = Jucator;
            this.Meci = Meci;
            this.NrPuncteInscrise = NrPuncteInscrise;
            this.Tip = Tip;
        }

        public override string ToString()
        {
            return Jucator + " " + Meci + " " + NrPuncteInscrise + " " + Tip;
        }
    }
}
