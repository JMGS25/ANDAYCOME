using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAndayCome.Models
{
    public class WallViewModel
    {
        [ScaffoldColumn(false)] //para no mostrar la Clave primaria
        public int Id { get; set; }

        [Display(Prompt = "Muro", Description = "Comentarios del muro", Name = "Muro")]
        [Required(ErrorMessage = "No se encuentra el muro")]
        public CommentViewModel CommentViewModel { get; set; }
}
}