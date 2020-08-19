using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    abstract class MotornoVozilo
    {
        public double ZapreminaMotora { get; set; }
        public int Tezina { get; set; }
        public string Kategorija { get; set; }
        public string TipMotora { get; set; }
        public string Boja { get; set; }
        public int BrojMotora { get; set; }

        public virtual void Kreni() { }

        public virtual void Zaustavi() { }
    }
}
