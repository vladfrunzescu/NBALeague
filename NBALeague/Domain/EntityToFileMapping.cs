using System;
namespace NBALeague.Domain
{
    public class EntityToFileMapping
    {
        public EntityToFileMapping()
        {
        }

        public static Elev CreateElev(string line)
        {
            string[] fields = line.Split(',');
            Elev elev = new Elev()
            {
               // ID = Convert.ToInt64(fields[0]),
                ID = fields[0],
                Nume = fields[1],
                Scoala = fields[2]
            };

            return elev;
        }

        public static Echipa CreateEchipa(string line)
        {
            string[] fields = line.Split(',');
            Echipa echipa = new Echipa()
            {
                //ID = Convert.ToInt64(fields[0]),
                ID = fields[0],
                Nume = fields[1]
            };

            return echipa;
        }

        public static JucatorActiv CreateJucatorActiv(string line)
        {
            string[] fields = line.Split(',');
            JucatorActiv jucatorActiv = new JucatorActiv()
            {
                ID = fields[0] + "_" + fields[1],
                IDJucator = fields[0],
                IDMeci = fields[1],
                NrPuncteInscrise = Convert.ToInt32(fields[2]),
                Tip = (TipJucator)Enum.Parse(typeof(TipJucator), fields[3], true)
            };

            return jucatorActiv;
        }
    }
}
