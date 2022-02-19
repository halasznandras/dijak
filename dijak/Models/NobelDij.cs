using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dijak.Models
{
    public class NobelDij
    {
        public int Id { get; set; }
        public int Evszam { get; set; }
        public string Tipus { get; set; }
        public string KeresztNev { get; set; }
        public string VezetekNev { get; set; }
        public NobelDij()
        {}
        public NobelDij(string sor)
        {
            string[] adat = sor.Split(";");
            Evszam = Convert.ToInt32(adat[0]);
            Tipus = adat[1];
            KeresztNev = adat[2];
            VezetekNev = adat[3];
        }
    }
}
