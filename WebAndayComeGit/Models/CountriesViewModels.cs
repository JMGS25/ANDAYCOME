using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class CountriesViewModels
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre del país", Description = "Nombre del país", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el país")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }


        [ScaffoldColumn(false)]
        [Display(Prompt = "Nombre de la ciudad", Description = "Nombre de la ciudad", Name = "Ciudad ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la ciudad")]
        [StringLength(maximumLength: 200, ErrorMessage = "La ciudad no puede tener más de 200 caracteres")]
        public AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum Ciudad { get; set; }
    }
}