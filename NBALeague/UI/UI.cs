using System;
using NBALeague.Domain.Validator;
using NBALeague.Domain;
using NBALeague.Repository;
using NBALeague.Service;

namespace NBALeague.UI
{
    public class UI
    {
        private SuperService service;

        public UI(SuperService service)
        {
            this.service = service;
        }

        public void run()
        {
            while(true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Sa se afiseze toti jucatorii unei echipe data.");
                Console.WriteLine("2. Sa se afiseze toti jucatorii activi ai unei echipe de la un anumit meci.");
                Console.WriteLine("3. Sa se afiseze toate meciurile dintr-o anumita perioada calendaristica.");
                Console.WriteLine("4. Sa se determine si sa se afiseze scorul de la un anumit meci.");
                Console.WriteLine("");
                Console.WriteLine("Numar comanda:");

                string cmd = Console.ReadLine();

                try
                {
                    int cmdNr = Convert.ToInt32(cmd);
                    if(cmdNr < 0 || cmdNr > 4)
                    {
                        throw new UIException("Comanda invalida!");
                    }
                    else if(cmdNr == 0)
                    {
                        Environment.Exit(0);
                    }
                    else if (cmdNr == 1)
                    {
                        //Sa se afiseze toti jucatorii unei echipe data
                        UIJucatoriEchipa();
                    }
                    else if (cmdNr == 2)
                    {
                        //Sa se afiseze toti jucatorii activi ai unei echipe de la un anumit meci
                        UIJucatoriActiviMeci();
                    }
                    else if (cmdNr == 3)
                    {
                        //Sa se afiseze toate meciurile dintr-o anumita perioada calendaristica
                        UIMeciuriPerioada();
                    }
                    else if (cmdNr == 4)
                    {
                        //Sa se determine si sa se afiseze scorul de la un anumit meci
                        UIScorMeci();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void UIJucatoriEchipa()
        {
            Console.WriteLine("ID echipa: ");
            string IDEchipa = Console.ReadLine();
            Console.WriteLine("");
            service.JucatoriEchipa(IDEchipa).ForEach(x => Console.WriteLine(x));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void UIJucatoriActiviMeci()
        {
            Console.WriteLine("ID meci: ");
            string IDMeci = Console.ReadLine();
            Console.WriteLine("ID echipa: ");
            string IDEchipa = Console.ReadLine();
            Console.WriteLine("");
            service.JucatoriActiviMeci(IDMeci, IDEchipa).ForEach(x => Console.WriteLine(x));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void UIMeciuriPerioada()
        {
            Console.WriteLine("Data de start (ZZ/LL/YYYY): ");
            string start = Console.ReadLine();
            Console.WriteLine("Data de final (ZZ/LL/YYYY): ");
            string end = Console.ReadLine();

            Console.WriteLine("");

            DateTime dateStart = DateTime.ParseExact(start, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateEnd = DateTime.ParseExact(end, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            service.MeciuriPerioada(dateStart, dateEnd).ForEach(x => Console.WriteLine(x));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void UIScorMeci()
        {
            Console.WriteLine("ID meci: ");
            string IDMeci = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(service.ScorMeci(IDMeci).ToString());
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
