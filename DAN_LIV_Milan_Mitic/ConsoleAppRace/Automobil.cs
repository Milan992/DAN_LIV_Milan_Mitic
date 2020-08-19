using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    class Automobil : MotornoVozilo
    {
        public string RegOznaka { get; set; }
        public int brojVrata { get; set; }
        public int zapreminaMotora { get; set; }
        public string TipPrenosa { get; set; }
        public string Proizvodjac { get; set; }
        public int BrojSaobracajne { get; set; }

        public override void Kreni()
        {
            base.Kreni();
        }

        public override void Zaustavi()
        {
            base.Zaustavi();
        }

        public void Prefarbaj() { }

    }
}
