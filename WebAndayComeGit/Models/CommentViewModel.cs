using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class CommentViewModel
    {
        [ScaffoldColumn(false)] //para no mostrar la Clave primaria
        public int Id { get; set; }

        [Display(Prompt = "Autor del comentario", Description = "Contenido del comentario", Name = "Client")]
        [Required(ErrorMessage = "Debes rellenar este campo")]
        [StringLength(maximumLength: 150, ErrorMessage = "El nombre no puede tener mas de 200 caracteres")]
        public string Client { get; set; }

        [Display(Prompt = "Fecha del comentario", Description = "Contenido del comentario", Name = "Date")]
        [Required(ErrorMessage = "Debes rellenar este campo")]
       
        public Nullable<DateTime> Date { get; set; }

        [Display(Prompt = "Contenido del comentario", Description = "Contenido del comentario", Name = "Content")]
        [Required(ErrorMessage = "Debes rellenar este campo")]
        [StringLength(maximumLength: 500, ErrorMessage = "El nombre no puede tener mas de 200 caracteres")]
        public string Content { get; set; }

        [Display(Prompt = "Foto del usuario", Description = "Foto del usuario", Name = "Photo")]
        [Required(ErrorMessage = "Debes indicar la direccion de la foto")]
        public string Photo { get; set; }
    }
}