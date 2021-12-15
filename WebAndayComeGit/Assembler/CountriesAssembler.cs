using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class CountriesAssembler
    {
        public CountriesViewModels ConvertENToModelUI(CountryEN en)
        {
            CountriesViewModels country = new CountriesViewModels();
            country.id = en.Id;
            country.Nombre = en.Name;
            country.Ciudad = en.City;
            return country;


        }
        public IList<CountriesViewModels> ConvertListENToModel(IList<CountryEN> ens)
        {
            IList<CountriesViewModels> countrys = new List<CountriesViewModels>();
            foreach (CountryEN en in ens)
            {
                countrys.Add(ConvertENToModelUI(en));
            }
            return countrys;
        }
    }
}