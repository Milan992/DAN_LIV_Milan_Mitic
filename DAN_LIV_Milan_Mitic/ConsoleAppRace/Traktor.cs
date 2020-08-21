using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    class Traktor : MotornoVozilo
    {
        public double VelicinaGume { get; set; }
        public int OsovinskiRazmak { get; set; }
        public string Pogon { get; set; }

        public override void Kreni()
        {
            base.Kreni();
        }

        public override void Zaustavi()
        {
            base.Zaustavi();
        }
    }
}
