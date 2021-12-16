using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class ClientViewModel
    {

        [ScaffoldColumn(false)]
        [Display(Prompt = "Pais en el que se encuentra el Cliente", Description = "Pais en el que se encuentra el Cliente", Name = "Paises ")]
        public int IdPais { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "El Cliente es premium", Description = "El Cliente es premium", Name = "Premium")]
        public bool Premium { get; set; }

        [Display(Prompt = "Idioma del Cliente", Description = "Idioma del Cliente", Name = "Lenguajes ")]
        [Required(ErrorMessage = "Debe indicar un idioma para el administrador")]
        public AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum Lang { get; set; }

        [Display(Prompt = "Email del Cliente", Description = "Email del Cliente", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un email para el Cliente")]
        [StringLength(maximumLength: 500, ErrorMessage = "El email puede tener como mucho 500 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "contraseña del Cliente", Description = "contraseña del Cliente", Name = "Contraseña ")]
        [Required(ErrorMessage = "Debe indicar una contraseña para el Cliente")]
        [StringLength(maximumLength: 500, ErrorMessage = "La contraseña puede tener como mucho 500 caracteres")]
        public string Pass { get; set; }

        [Display(Prompt = "Nombre del Cliente", Description = "Nombre del Cliente", Name = "Name ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el Cliente")]
        [StringLength(maximumLength: 500, ErrorMessage = "El nombre no puede tener más de 500 caracteres")]
        public string Name { get; set; }

        [Display(Prompt = "Telefono de contacto", Description = "Telefono de contacto", Name = "Telefono ")]
        [Required(ErrorMessage = "Debe indicar un telefono de contacto")]
        [Range(100000000, 999999999, ErrorMessage = "debe de ser un numero de 9 digitos.")]
        public int Telefono { get; set; }

        [Display(Prompt = "Imagen de perfil", Description = "Imagen de perfil", Name = "Photo ")]
        [Required(ErrorMessage = "Debe indicar una imagen de perfil")]
        public string Photo { get; set; }

    }
}