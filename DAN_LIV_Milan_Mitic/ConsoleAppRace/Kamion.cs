using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRace
{
    class Kamion : MotornoVozilo
    {
        public double Nosivost { get; set; }
        public double Visina { get; set; }
        public int BrojSedista { get; set; }

        public override void Kreni()
        {
            base.Kreni();
        }

        public override void Zaustavi()
        {
            base.Zaustavi();
        }

        public void Natovari() { }

        public void Istovari() { }
    }
}
