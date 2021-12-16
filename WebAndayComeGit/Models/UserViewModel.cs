using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class UserViewModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Teléfono")]

        public int telefono { get; set; }

        [Required]
        [Display(Name = "Nombre")]

        public string nombre { get; set; }


        [Required]
        [Display(Name = "Ciudad")]

        public int ciudad { get; set; }



        [Required]
        [Display(Name = "Foto")]

        public string foto { get; set; }
    }
}