using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Kamion kamion1 = new Kamion();
            Kamion kamion2 = new Kamion();

            Traktor traktor1 = new Traktor();
            Traktor traktor2 = new Traktor();

            Automobil automobil1 = new Automobil();
            automobil1.RegOznaka = "SO111AA";
            Automobil automobil2 = new Automobil();
            automobil2.RegOznaka = "SO222BB";

            List<Kamion> listaKamiona = new List<Kamion> { kamion1, kamion2 };
            List<Traktor> listaTraktora = new List<Traktor> { traktor1, traktor2 };
            List<Automobil> listaAutomobila = new List<Automobil> { automobil1, automobil2};

            Stopwatch s = new Stopwatch();

            s.Start();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(s.ElapsedMilliseconds/1000);
            }
            s.Stop();
            Console.Clear();

            foreach (var automobil in listaAutomobila)
            {
                automobil.PostaviNaStart();
                automobil.PreostaloGorivo = 100;
                automobil.potrosnjaPoSekudni = r.Next(6, 9);
            }
            Automobil automobil3 = new Automobil();
            automobil3.Boja = "narandzasta";
            automobil3.Proizvodjac = "Golf";
            automobil3.RegOznaka = "SO333CC";
            automobil3.potrosnjaPoSekudni = r.Next(6, 9);
            automobil3.PreostaloGorivo = 100;
            automobil3.PostaviNaStart();

            Thread t1 = new Thread(() => automobil1.TrkajSe());
            Thread t2 = new Thread(() => automobil2.TrkajSe());
            Thread t3 = new Thread(() => automobil3.TrkajSe());
            Thread semafor = new Thread(() => Automobil.Semafor());

            semafor.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            
            Console.ReadLine();
        }
    }
}
