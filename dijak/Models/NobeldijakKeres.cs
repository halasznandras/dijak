using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dijak.Models
{
    public class NobeldijakKeres
    {
        public int Ev { get; set; }
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public List<NobelDij> NobelDij { get; set; }
        public SelectList Tipusok { get; set; }

    }
}
