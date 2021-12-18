using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class RestaurantViewModel
    {
        [ScaffoldColumn(false)] //para no mostrar la Clave primaria
        public int Id { get; set; }


        [Display(Prompt = "Menu del restaurante", Description = "Menu del restaurante", Name = "Menú")]
        [Required(ErrorMessage = "Debes indicar la direccion de la foto")]
        public string Menu { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Ciudad en el que se encuentra el restaurante", Description = "Ciudad en el que se encuentra el restaurante", Name = "Ciudad ")]
        public int IdPais { get; set; }

        [Display(Prompt = "Posibles propietarios", Description = "Posibles propietarios", Name = "Propietario ")]
        public string IdPropietario { get; set; }


        [Display(Prompt = "Ciudad del restaurante", Description = "Ciudad del restaurante", Name = "Ciudad")]
        public string City { get; set; }


        [Display(Prompt = "Menu del restaurante", Description = "Menu del restaurante", Name = "Photo")]
        [Required(ErrorMessage = "Debes indicar la direccion de la foto")]
        public string Photo { get; set; }

        [Display(Prompt = "Nombre del restaurante", Description = "Nombre del restaurante", Name = "Nombre")]
        [Required(ErrorMessage = "Debes indicar un nombre para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener mas de 200 caracteres")]
        public string Name { get; set; }


        [Display(Prompt = "Calle del restaurante", Description = "Calle del restaurante", Name = "Calle")]
        [Required(ErrorMessage = "Debes indicar una calle para el restaurante")]
        [StringLength(maximumLength: 200, ErrorMessage = "La calle no puede tener mas de 200 caracteres")]
        public string Street { get; set; }



        [ScaffoldColumn(false)]
        [Display(Prompt = "Tags del restaurante", Description = "Tags del restaurante", Name = "Tags")]
        public string Tags { get; set; }


        [Display(Prompt = "Capacidad del restaurante", Description = "Capacidad del restaurante", Name = "Capacidad")]
        [Required(ErrorMessage = "Debes indicar una capacidad para el restaurante")]

        [Range(minimum: 0, maximum: 1000, ErrorMessage = "La capacidad debe ser entre 0 y 1000")]
        public int Capacity { get; set; }



    }
}