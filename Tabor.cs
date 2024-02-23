using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erettsegi
{
    internal class Tabor
    {
        public int Honap1 {  get; set; }
        public int Nap1 {  get; set; }
        public int Honap2 { get; set; }
        public int Nap2 { get; set; }
        public string Diakok {  get; set; }
        public string Tema {  get; set; }

        public Tabor(string sor)
        {
            var v = sor.Split('\t');
            Honap1 = int.Parse(v[0]);
            Nap1 = int.Parse(v[1]);
            Honap2 = int.Parse(v[2]);
            Nap2 = int.Parse(v[3]);
            Diakok = v[4];
            Tema = v[5];
        }
    }
}
