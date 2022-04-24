using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkatreszRaktar.Models
{
    public class Kereses
    {
        public string MegnevezesKeres { get; set; }
        public string TipusKeres { get; set; }

        public SelectList TipusLista { get; set; }
        public List<Alkatresz> AlkatreszLista { get; set; }
    }
}
