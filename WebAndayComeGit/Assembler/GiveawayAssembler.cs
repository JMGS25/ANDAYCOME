using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class GiveawayAssembler
    {
        public GiveawayViewModel ConvertENToModelUI(GiveawayEN en)
        {
            GiveawayViewModel ga = new GiveawayViewModel();
            ga.Id = en.Id;
            ga.Precio = en.Precio;
            ga.Premio = en.Premio;
            ga.Winner = en.Winner;
            ga.Premium = en.Premium;

            return ga;
        }

        public IList<GiveawayViewModel> ConvertListENToModel(IList<GiveawayEN> ens)
        {
            IList<GiveawayViewModel> gas = new List<GiveawayViewModel>();
            foreach (GiveawayEN en in ens)
            {
                gas.Add(ConvertENToModelUI(en));
            }

            return gas;
        }

    }
}