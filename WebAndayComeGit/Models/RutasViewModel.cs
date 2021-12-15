using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class RutasViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Restaurantes de la ruta", Description = "Restaurantes que pertenecen a la ruta", Name = "Restaurantes ")]
        public IList<int> IdRestaurante { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Pais en el que se encuentra la ruta", Description = "Pais en el que se encuentra la ruta", Name = "Paises ")]
        public int IdPais { get; set; }


        [Display(Prompt = "Nombre de la ruta", Description = "Nombre de la ruta", Name = "Name ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la ruta")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Name { get; set; }


        [Display(Prompt = "Descripción de la ruta", Description = "Descripción de la ruta", Name = "Description ")]
        [Required(ErrorMessage = "Debe indicar una descripción para la ruta")]
        [StringLength(maximumLength: 2000, ErrorMessage = "La descripción no puede tener más de 2000 carácteres")]
        public string Description { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Prompt = "Dia de comienzo de la ruta", Description = "Dia de comienzo de la ruta", Name = "Start_date ")]
        [Required(ErrorMessage = "Debe indicar un dia en la que comience la ruta")]
        public Nullable<DateTime> Start_date { get; set; }


        [DataType(DataType.Date)]
        [Display(Prompt = "Dia en la que termina la ruta", Description = "Dia en la que termina la ruta", Name = "End_date ")]
        [Required(ErrorMessage = "Debe indicar un dia en la que comience la ruta")]
        public Nullable<DateTime> End_date { get; set; }


        [Display(Prompt = "Imagen de la ruta", Description = "Imagen de la ruta", Name = "Photo ")]
        [Required(ErrorMessage = "Debe indicar una imagen de la ruta")]
        public string Photo { get; set; }

               
    }
}