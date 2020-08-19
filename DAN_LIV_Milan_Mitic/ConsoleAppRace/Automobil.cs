using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    class Automobil : MotornoVozilo
    {
        public static Random r = new Random();
        static AutoResetEvent are = new AutoResetEvent(false);
        static readonly object o = new object();

        public string RegOznaka { get; set; }
        public int brojVrata { get; set; }
        public int zapreminaMotora { get; set; }
        public string TipPrenosa { get; set; }
        public string Proizvodjac { get; set; }
        public int BrojSaobracajne { get; set; }
        public int potrosnjaPoSekudni;

        private int preostaloGorivo;

        public int PreostaloGorivo
        {
            get
            {
                return preostaloGorivo;
            }
            set
            {
                if (PreostaloGorivo <= 100)
                {
                    preostaloGorivo = value;
                }
                else
                {
                    Console.WriteLine("Mozete sipati najvise 100 litara goriva");
                }
            }
        }

        public override void Kreni()
        {
            Console.WriteLine("\tAutomobil" + " " + RegOznaka + " " + "je krenuo");
        }

        public override void Zaustavi()
        {
            Console.WriteLine("\tAutomobil" + " " + RegOznaka + " " + "se zaustavio na semaforu");
        }

        public void Prefarbaj()
        {
            Boja = "Crvena";
            BrojSaobracajne = r.Next(10000, 100000);
        }

        public void PostaviNaStart()
        {
            Console.WriteLine("Automobil {0} je postavljen na startu", RegOznaka);
        }

        public void TrkajSe()
        {
            Stopwatch s = new Stopwatch();
            Stopwatch t = new Stopwatch();
            Stopwatch u = new Stopwatch();
            Stopwatch v = new Stopwatch();

            s.Start();
            while (s.ElapsedMilliseconds < 10000)
            {
                if (PreostaloGorivo > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Automobil {0} se krece", RegOznaka);
                    PreostaloGorivo = PreostaloGorivo - potrosnjaPoSekudni;
                }
                else
                {
                    Console.WriteLine("Automobil {0} je ostao bez goriva", RegOznaka);
                    return;
                }
            }
            s.Stop();

            Zaustavi();
            are.WaitOne();

            t.Start();
            Kreni();
            while (t.ElapsedMilliseconds < 3000)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Automobil {0} se krece", RegOznaka);
                PreostaloGorivo = PreostaloGorivo - potrosnjaPoSekudni;
            }
            t.Stop();

            lock (o)
            {
                if (PreostaloGorivo < 15)
                {
                    Console.WriteLine("\tAutomobil" + " " + RegOznaka + " " + "se zaustavio da sipa gorivo");
                    Console.WriteLine("\tAutomobil {0} je sipao gorivo.", RegOznaka);
                    PreostaloGorivo = 100;
                }
            }

            v.Start();
            while (v.ElapsedMilliseconds < 7000)
            {
                if (PreostaloGorivo > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Automobil {0} se krece", RegOznaka);
                    PreostaloGorivo = PreostaloGorivo - potrosnjaPoSekudni;
                }
                else
                {
                    Console.WriteLine("Automobil {0} je ostao bez goriva", RegOznaka);
                    return;
                }
            }
            v.Stop();

            Console.WriteLine("\n\t {0} je zavrsio trku!\n", RegOznaka);
        }

        public static void Semafor()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.ElapsedMilliseconds < 100000)
            {
                if (s.ElapsedMilliseconds % 2000 == 0)
                {
                    are.Set();
                }
                else
                {
                    are.Reset();
                }
            }
        }

    }
}
