using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NBALeague.Domain;
using NBALeague.Domain.Validator;
using NBALeague.Repository;
using NBALeague.Service;
using NBALeague.UI;

namespace NBALeague
{
    public class MainClass
    {
        private static SuperService service;
        public static void Main(string[] args)
        {
            initialize();
            UI.UI ui = new UI.UI(service);
            ui.run();
        }

        static public void initialize()
        {
            string eleviFileName = ConfigurationManager.AppSettings["eleviFileName"];
            string echipeFileName = ConfigurationManager.AppSettings["echipeFileName"];
            string meciuriFileName = ConfigurationManager.AppSettings["meciuriFileName"];
            string jucatoriFileName = ConfigurationManager.AppSettings["jucatoriFileName"];
            string jucatoriActiviFileName = ConfigurationManager.AppSettings["jucatoriActiviFileName"];

            generate(eleviFileName, echipeFileName, meciuriFileName, jucatoriFileName, jucatoriActiviFileName);

            IValidator<Elev> elevValidator = new ElevValidator();
            ElevInFileRepository elevRepo = new ElevInFileRepository(elevValidator, eleviFileName);

            IValidator<Echipa> echipaValidator = new EchipaValidator();
            EchipaInFileRepository echipaRepo = new EchipaInFileRepository(echipaValidator, echipeFileName);

            IValidator<Meci> meciValidator = new MeciValidator();
            MeciInFileRepository meciRepo = new MeciInFileRepository(meciValidator, meciuriFileName);

            IValidator<Jucator> jucatorValidator = new JucatorValidator();
            JucatorInFileRepository jucatorRepo = new JucatorInFileRepository(jucatorValidator, jucatoriFileName);

            IValidator<JucatorActiv> jucatorActivValidator = new JucatorActivValidator(jucatorRepo, meciRepo);
            JucatorActivInFileRepository jucatorActivRepo = new JucatorActivInFileRepository(jucatorActivValidator, jucatoriActiviFileName);

            service = new SuperService(elevRepo, echipaRepo, meciRepo, jucatorRepo, jucatorActivRepo);
        }


        public static void generate(string fileNameElevi, string fileNameEchipe, string fileNameMeciuri, string fileNameJucatori, string fileNameJucatoriActivi)
        {
     

            List<string> numeScoli = new List<string>();
            numeScoli.Add("Scoala Gimnaziala \"Horea\"");
            numeScoli.Add("Scoala Gimnaziala \"Octavian Goga\"");
            numeScoli.Add("Liceul Teoretic \"Lucian Blaga\"");
            numeScoli.Add("Scoala Gimnaziala \"Ioan Bob\"");
            numeScoli.Add("Scoala Gimnaziala \"Ion Creanga\"");
            numeScoli.Add("Colegiul National Pedagogic \"Gheorghe Lazar\"");
            numeScoli.Add("Scoala Gimnaziala Internationala SPECTRUM");
            numeScoli.Add("Colegiul National \"Emil Racovita\"");
            numeScoli.Add("Colegiul National \"George Cosbuc\"");
            numeScoli.Add("Scoala Gimnaziala \"Ion Agarbiceanu\"");
            numeScoli.Add("Liceul Teoretic \"Avram Iancu\"");
            numeScoli.Add("Scoala Gimnaziala \"Constantin Brancusi\"");
            numeScoli.Add("Liceul Teoretic \"Onisifor Ghibu\"");
            numeScoli.Add("Liceul Teoretic \"Onisifor Ghibu\"");
            numeScoli.Add("Liceul cu Program Sportiv Cluj-Napoca");
            numeScoli.Add("Liceul Teoretic \"Nicolae Balcescu\"");
            numeScoli.Add("Liceul Teoretic \"Gheorghe Sincai\"");
            numeScoli.Add("Scoala \"Nicolae Titulescu\"");
            numeScoli.Add("Scoala Gimnaziala \"Liviu Rebreanu\"");
            numeScoli.Add("Scoala Gimnaziala \"Iuliu Hatieganu\"");
            numeScoli.Add("Liceul Teoretic \"Bathory Istvan\"");
            numeScoli.Add("Colegiul National \"George Baritiu\"");
            numeScoli.Add("Liceul Teoretic \"Apaczai Csere Janos\"");
            numeScoli.Add("Seminarul Teologic Ortodox");
            numeScoli.Add("Liceul de Informatica \"Tiberiu Popoviciu\"");
            numeScoli.Add("Scoala Gimnaziala \"Alexandru Vaida – Voevod\"");
            numeScoli.Add("Liceul Teoretic ELF");
            numeScoli.Add("Scoala Gimnaziala \"Gheorghe Sincai\" Floresti");

            List<string> numeEchipe = new List<string>();
            numeEchipe.Add("Houston Rockets");
            numeEchipe.Add("Los Angeles Lakers");
            numeEchipe.Add("LA Clippers");
            numeEchipe.Add("Chicago Bulls");
            numeEchipe.Add("Cleveland Cavaliers");
            numeEchipe.Add("Utah Jazz");
            numeEchipe.Add("Brooklyn Nets");
            numeEchipe.Add("New Orleans Pelicans");
            numeEchipe.Add("Indiana Pacers");
            numeEchipe.Add("Toronto Raptors");
            numeEchipe.Add("Charlotte Hornets");
            numeEchipe.Add("Phoenix Suns");
            numeEchipe.Add("Portland TrailBlazers");
            numeEchipe.Add("Golden State Warriors");
            numeEchipe.Add("Washington Wizards");
            numeEchipe.Add("San Antonio Spurs");
            numeEchipe.Add("Orlando Magic");
            numeEchipe.Add("Denver Nuggets");
            numeEchipe.Add("Detroit Pistons");
            numeEchipe.Add("Atlanta Hawks");
            numeEchipe.Add("Dallas Mavericks");
            numeEchipe.Add("Sacramento Kings");
            numeEchipe.Add("Oklahoma City Thunder");
            numeEchipe.Add("Boston Celtics");
            numeEchipe.Add("New York Knicks");
            numeEchipe.Add("Minnesota Timberwolves");
            numeEchipe.Add("Miami Heat");
            numeEchipe.Add("Milwaukee Bucks");

            //SCRIEREA IN FISIERUL ECHIPE
            string linesEchipe = "";
            int contor = 0;
            for (contor = 0; contor < 28; contor++)
            {
                linesEchipe += "e" + (contor + 1).ToString() + "," + numeEchipe.ElementAt(contor) + "\n";
            }

            string newLinesEchipe = linesEchipe.Remove(linesEchipe.Length - 1, 1);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEchipe))
            {
               
                    file.WriteLine(newLinesEchipe);
                
            }
            /////

            List<string> numeElevi = new List<string>();
            numeElevi.Add("Matei");
            numeElevi.Add("Ioan");
            numeElevi.Add("Andrei");
            numeElevi.Add("Catalin");
            numeElevi.Add("Calin");
            numeElevi.Add("Avram");
            numeElevi.Add("Iancu");
            numeElevi.Add("Mircea");
            numeElevi.Add("Dan");
            numeElevi.Add("Daniel");
            numeElevi.Add("Ion");
            numeElevi.Add("Ionel");
            numeElevi.Add("Vasile");
            numeElevi.Add("Danut");
            numeElevi.Add("Mihai");
            numeElevi.Add("Nicolae");

            //SCRIEREA IN FISIERUL ELEVI
            string linesElevi = "";
            int idElev = 1, random1 = 0, random2 = 0, i = 0;
            Random rnd = new Random();
            for (contor = 0; contor < 28; contor++)
            {
                for (i = 0; i < 15; i++)
                {
                    random1 = rnd.Next(0, numeElevi.Count);
                    random2 = rnd.Next(0, numeElevi.Count);
                    linesElevi += "el" + idElev.ToString() + "," + numeElevi.ElementAt(random1) + " " + numeElevi.ElementAt(random2) + "," + numeScoli.ElementAt(contor) + "\n";
                    idElev++;
                }
            }

            string newLinesElevi = linesElevi.Remove(linesElevi.Length - 1, 1);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameElevi))
            {
               
                    file.WriteLine(newLinesElevi);
            
            }
            /////

            //SCRIEREA IN FISIERUL JUCATORI
            string linesJucatori = "";
            idElev = 1;
            for (contor = 1; contor <= 28; contor++)
            {
                for (i = 1; i <= 8; i++)
                {
                    linesJucatori += "e" + contor.ToString() + "," + "el" + idElev.ToString() + "\n";
                    idElev++;
                }
                idElev += 7;
            }
            // e1 => el1 - el15
            // e2 => el16 - el30
            // e2 => el31 - el45
            //...
            // e(n) => el((n-1)*15 + 1) - el(n*15)

            string newLinesJucatori = linesJucatori.Remove(linesJucatori.Length - 1, 1);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameJucatori))
            {
                
                    file.WriteLine(newLinesJucatori);
               
            }
            /////

            //SCRIEREA IN FISIERUL MECIURI SI JUCATORI ACTIVI
            List<string> tipuriJucatoriActivi = new List<string>();
            tipuriJucatoriActivi.Add("Participant");
            tipuriJucatoriActivi.Add("Rezerva");
            string linesJucatoriActivi = "";

            string linesMeciuri = "";
            for (contor = 1; contor <= 20; contor++)
            {
                int zi = rnd.Next(1, 29);
                int luna = rnd.Next(1, 13);
                int an = rnd.Next(2019, 2021);

                random1 = rnd.Next(1, 29);
                random2 = rnd.Next(1, 29);
                while (random1 == random2)
                {
                    random2 = rnd.Next(0, numeElevi.Count);
                }
                linesMeciuri += "m" + contor.ToString() + "," + "e" + random1.ToString() + "," + "e" + random2.ToString() + "," + zi.ToString() + "/" + luna.ToString() + "/" + an.ToString() + "\n";

                for (i = 0; i < 4; i++)
                {
                    linesJucatoriActivi += "e" + random1.ToString() + "_" + "el" + (i + (random1 - 1) * 15 + 1).ToString() + "," + "m" + contor.ToString() + "," + rnd.Next(1, 11).ToString() + "," + tipuriJucatoriActivi.ElementAt(0) + "\n";
                }
                linesJucatoriActivi += "e" + random1.ToString() + "_" + "el" + (i + (random1 - 1) * 15 + 1).ToString() + "," + "m" + contor.ToString() + "," + "0" + "," + tipuriJucatoriActivi.ElementAt(1) + "\n";

                for (i = 0; i < 4; i++)
                {
                    linesJucatoriActivi += "e" + random2.ToString() + "_" + "el" + (i + (random2 - 1) * 15 + 1).ToString() + "," + "m" + contor.ToString() + "," + rnd.Next(1, 11).ToString() + "," + tipuriJucatoriActivi.ElementAt(0) + "\n";
                }
                linesJucatoriActivi += "e" + random2.ToString() + "_" + "el" + (i + (random2 - 1) * 15 + 1).ToString() + "," + "m" + contor.ToString() + "," + "0" + "," + tipuriJucatoriActivi.ElementAt(1) + "\n";

            }


            string newLinesMeciuri = linesMeciuri.Remove(linesMeciuri.Length - 1, 1);


            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameMeciuri))
            {
                
                    file.WriteLine(newLinesMeciuri);
                
            }

            string newLinesJucatoriActivi = linesJucatoriActivi.Remove(linesJucatoriActivi.Length - 1, 1);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameJucatoriActivi))
            {
                
                    file.WriteLine(newLinesJucatoriActivi);
                
            }
            /////
        }
    }
}

// Entities:
// Echipa(id, nume)
// Elev(id, nume, scoala)
// Jucator(echipa)
// Meci(Echipa, Echipa, Data)
// JucatorActiv(idJucator, idMeci, nrPuncteInscrise, tip: Rezerva, Participant)