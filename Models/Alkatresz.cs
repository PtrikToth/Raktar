using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkatreszRaktar.Models
{
    public class Alkatresz
    {
        public int Id { get; set; }

        [Display(Name = "Megnevezés")]
        [StringLength(60)]
        public string Megnevezes { get; set; }

        [Display(Name = "Gyártó")]
        [StringLength(60)]
        public string Gyarto { get; set; }

        [Display(Name = "Típus")]
        [StringLength(30)]
        public string Tipus { get; set; }

        [Display(Name = "Beszerzési ár")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BeszerzesiAr { get; set; }
    }
}
