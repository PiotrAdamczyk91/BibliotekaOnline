using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaOnline.Models
{
    public class Ksiazka
    {

        [Key]
        public int KsiazkaID { get; set; }
        [Required]
        [Display(Name = "Nazwa ksiązki")]
        public string Nazwa { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data wydania")]
        public DateTime DataWydania { get; set; }
        [Required]
        public string Opis { get; set; }

        public virtual ICollection<Rezerwacja> Rezerwacjas { get; set; }

    }
}
