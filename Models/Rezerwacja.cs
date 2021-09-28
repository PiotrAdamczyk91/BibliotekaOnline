using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaOnline.Models
{
    public class Rezerwacja
    {
        [Key]
        public int RezerwacjaID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data rezerwacji")]
        public DateTime DataRezerwacji { get; set; }
        [Required]
        [Display(Name = "ID użytkownika")]
        public string UserID { get; set; }
        [Required]
        [Display(Name = "Nazwa książki")]
        public int KsiazkaID { get; set; }

        public Ksiazka Ksiazka { get; set; }
    }
}
