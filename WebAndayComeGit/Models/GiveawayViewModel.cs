using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class GiveawayViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Prompt = "Premio del sorteo", Description = "Premio del sorteo", Name = "Premio ")]
        public string Premio { get; set; }

        [Display(Prompt = "Ganador de sorteo", Description = "Ganador de sorteo", Name = "Ganador ")]
        public string Winner { get; set; }

        [Display(Prompt = "Precio del sorteo", Description = "Precio del sorteo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe haber un precio")]
        public int Precio { get; set; }

        [Display(Prompt = "Usuario premium", Description = "Usuario premium", Name = "Premium ")]
        public bool Premium { get; set; }
    }
}