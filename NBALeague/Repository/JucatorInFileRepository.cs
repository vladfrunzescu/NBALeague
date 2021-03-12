using System;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace NBALeague.Repository
{
    public class JucatorInFileRepository : InFileRepository<string, Jucator>
    {
        public JucatorInFileRepository()
        {
        }

        public JucatorInFileRepository(IValidator<Jucator> validator, string fileName) :
            base(validator, fileName, null)  //nu avem createJucator in EntityToFileMapping
        {
            this.LoadFromFile();
        }

        private void LoadFromFile()
        {
            List<Echipa> echipe = DataReader.ReadData<Echipa>(ConfigurationManager.AppSettings["echipeFileName"],
                EntityToFileMapping.CreateEchipa);

            List<Elev> elevi = DataReader.ReadData<Elev>(ConfigurationManager.AppSettings["eleviFileName"],
                EntityToFileMapping.CreateElev);

            using (StreamReader stream = new StreamReader(fileName))
            {
                string record;
                while ((record = stream.ReadLine()) != null)
                {
                    string[] fields = record.Split(',');
                    Echipa echipa = echipe.Find(e => e.ID.Equals(fields[0]));
                    Elev elev = elevi.Find(el => el.ID.Equals(fields[1]));
                    string id = fields[0] + "_" + fields[1];


                    Jucator jucator = new Jucator()
                    {
                        ID = id,
                        Echipa = echipa,
                        Nume = elev.Nume,
                        Scoala = elev.Scoala
                    };

                    base.entities[jucator.ID] = jucator;
                }
            }
        }
    }
}
