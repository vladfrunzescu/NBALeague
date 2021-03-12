using System;
using System.Collections.Generic;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
using System.IO;
using System.Configuration;
namespace NBALeague.Repository
{
    public class MeciInFileRepository : InFileRepository<string, Meci> 
    {
        public MeciInFileRepository()
        {
        }

        public MeciInFileRepository(IValidator<Meci> validator, string fileName) :
            base(validator, fileName, null)
        {
            this.LoadFromFile();
        }

        private void LoadFromFile()
        {
            List<Echipa> gazde = DataReader.ReadData<Echipa>(ConfigurationManager.AppSettings["echipeFileName"],
                EntityToFileMapping.CreateEchipa);

            List<Echipa> oaspeti = DataReader.ReadData<Echipa>(ConfigurationManager.AppSettings["echipeFileName"],
                EntityToFileMapping.CreateEchipa);

            using (StreamReader stream = new StreamReader(fileName))
            {
                string record;
                while((record = stream.ReadLine()) != null)
                {
                    string[] fields = record.Split(',');
                    Echipa gazda = gazde.Find(g => g.ID.Equals(fields[1]));
                    Echipa oaspete = oaspeti.Find(o => o.ID.Equals(fields[2]));
                    string id = fields[0];


                    Meci meci = new Meci()
                    {
                        ID = id,
                        Gazda = gazda,
                        Oaspete = oaspete,
                        Data = DateTime.ParseExact(fields[3], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    };

                    base.entities[meci.ID] = meci;
                }
            }
        }
    }
}
