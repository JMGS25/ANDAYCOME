using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class RutasAssembler
    {
        public RutasViewModel ConvertENToModelUI(RouteEN en)
        {
            RutasViewModel ruta = new RutasViewModel();
            ruta.Id = en.Id;
            ruta.Name = en.Name;
            ruta.Description = en.Description;
            ruta.Start_date = en.Start_date;
            ruta.End_date = en.End_date;
            ruta.Photo = en.Photo;
            ruta.IdPais = en.Countries.Id;

            return ruta;
        }

        public IList<RutasViewModel> ConvertListENToModel(IList<RouteEN> ens)
        {
            IList<RutasViewModel> rutas = new List<RutasViewModel>();
            foreach(RouteEN en in ens)
            {
                rutas.Add(ConvertENToModelUI(en));
            }

            return rutas;
        }
    }
}
