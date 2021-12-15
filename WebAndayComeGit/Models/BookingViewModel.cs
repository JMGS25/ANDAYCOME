using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebAndayCome.Models
{
    public class BookingViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Restaurante reservado", Description = "Restaurante reservado", Name = "Restaurante ")]
        public string Restaurante { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Rutas de la reserva", Description = "Rutas de la reserva", Name = "Rutas ")]
        public IList<int> IdRuta { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Cliente que realizo la reserva", Description = "Cliente que realizo la reserva", Name = "Clientes ")]
        public String IdCliente { get; set; }


        [Display(Prompt = "Numero de comensales", Description = "Numero de comensales", Name = "Comensales ")]
        [Required(ErrorMessage = "Debe un numero de comensales")]
        [Range(1, 15, ErrorMessage = "debe haber al menos 1 comensal y maximo 15")]
        public int Guest { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Prompt = "Dia reservado", Description = "Dia reservado", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar un dia")]
        public Nullable<DateTime> Date { get; set; }

        [DataType(DataType.Time)]
        [Display(Prompt = "Hora reservada", Description = "Hora reservada", Name = "hora ")]
        [Required(ErrorMessage = "debe indicar una hora reservada")]
        public Nullable<DateTime> Hour{ get; set; }
    }
}