using System;
using NBALeague.Repository;
using NBALeague.Domain;
using System.Linq;
using System.Collections.Generic;

namespace NBALeague.Service
{
    public class SuperService
    {
        private IRepository<string, Elev> repoElev;
        private IRepository<string, Echipa> repoEchipa;
        private IRepository<string, Meci> repoMeci;
        private IRepository<string, Jucator> repoJucator;
        private IRepository<string, JucatorActiv> repoJucatorActiv;

        public SuperService()
        {
        }

        public SuperService(
            IRepository<string, Elev> repoElev,
            IRepository<string, Echipa> repoEchipa,
            IRepository<string, Meci> repoMeci,
            IRepository<string, Jucator> repoJucator,
            IRepository<string, JucatorActiv> repoJucatorActiv
            )
        {
            this.repoElev = repoElev;
            this.repoEchipa = repoEchipa;
            this.repoMeci = repoMeci;
            this.repoJucator = repoJucator;
            this.repoJucatorActiv = repoJucatorActiv;
        }


        public List<Jucator> FindAllJucatori()
        {
            return repoJucator.FindAll().ToList();
        }

        public List<JucatorActiv> FindAllJucatoriActivi()
        {
            return repoJucatorActiv.FindAll().ToList();
        }

        public List<Meci> FindAllMeciuri()
        {
            return repoMeci.FindAll().ToList();
        }

        public Echipa FindEchipa(string idEchipa)
        {
            return repoEchipa.FindOne(idEchipa);
        }

        public Jucator FindJucator(string idJucator)
        {
            return repoJucator.FindOne(idJucator);
        }

        public Meci FindMeci(string idMeci)
        {
            return repoMeci.FindOne(idMeci);
        }


        public List<Jucator> JucatoriEchipa(string idEchipa)
        {
            List<Jucator> jucatori = this.FindAllJucatori();
            var jucatoriEchipa = from j in jucatori
                                           where j.Echipa.ID.Equals(idEchipa)
                                           select j;



            return jucatoriEchipa.ToList();
        }

        public List<JucatorActivDTO> JucatoriActiviMeci (string IDMeci, string IDEchipa)
        {
            List<JucatorActiv> jucatoriActivi = this.FindAllJucatoriActivi();

            var jucatoriActiviMeci = from ja in jucatoriActivi
                                     where ja.IDMeci.Equals(IDMeci) && ja.ID.Split('_').ElementAt(0).Equals(IDEchipa)
                                     select new JucatorActivDTO()
                                     { 
                                        Jucator = this.FindJucator(ja.IDJucator),
                                         Meci = this.FindMeci(IDMeci),
                                         NrPuncteInscrise = ja.NrPuncteInscrise,
                                         Tip = ja.Tip
                                     };

            return jucatoriActiviMeci.ToList();

        }

        public List<Meci> MeciuriPerioada(DateTime start, DateTime end)
        {
            List<Meci> meciuri = this.FindAllMeciuri();

            var meciuriPerioada = from m in meciuri
                                  where m.Data >= start && m.Data <= end
                                  select m;

            return meciuriPerioada.ToList();
        }

        public ScorDTO ScorMeci(string IDMeci)
        {
            Echipa Echipa1 = this.FindMeci(IDMeci).Gazda;
            Echipa Echipa2 = this.FindMeci(IDMeci).Oaspete;

            List<JucatorActivDTO> JucatoriEchipa1 = this.JucatoriActiviMeci(IDMeci, Echipa1.ID);
            List<JucatorActivDTO> JucatoriEchipa2 = this.JucatoriActiviMeci(IDMeci, Echipa2.ID);

            int ScorEchipa1 = 0;
            JucatoriEchipa1.ForEach(x => ScorEchipa1 += x.NrPuncteInscrise);

            int ScorEchipa2 = 0;
            JucatoriEchipa2.ForEach(x => ScorEchipa2 += x.NrPuncteInscrise);

            return new ScorDTO(Echipa1, Echipa2, ScorEchipa1, ScorEchipa2);
        }

    }
}
