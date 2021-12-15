using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class AdminViewModel
    {

        [ScaffoldColumn(false)]
        [Display(Prompt = "Pais en el que se encuentra el administrador", Description = "Pais en el que se encuentra el administrador", Name = "Paises ")]
        public int IdPais { get; set; }

        [Display(Prompt = "Idioma del administrador", Description = "Idioma del administrador", Name = "Lenguajes ")]
        [Required(ErrorMessage = "Debe indicar un idioma para el administrador")]
        public AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum Lang { get; set; }

        [Display(Prompt = "Email del administrador", Description = "Email del administrador", Name = "Email ")]
        [Required(ErrorMessage = "Debe indicar un email para el administrador")]
        [StringLength(maximumLength: 500, ErrorMessage = "El email puede tener como mucho 500 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "contraseña del administrador", Description = "contraseña del administrador", Name = "Contraseña ")]
        [Required(ErrorMessage = "Debe indicar una contraseña para el administrador")]
        [StringLength(maximumLength: 500, ErrorMessage = "La contraseña puede tener como mucho 500 caracteres")]
        public string Pass { get; set; }

        [Display(Prompt = "Nombre del administrador", Description = "Nombre del administrador", Name = "Name ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el administrador")]
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