using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assemblers
{
    public class RestaurantAssembler
    {
        public RestaurantViewModel ConvertENToModelUI(RestaurantEN en)
        {
            RestaurantViewModel res = new RestaurantViewModel();
            res.Id = en.Id;
            res.Photo = en.Photo;
            res.Menu = en.Menu;
            res.Name = en.Name;
            res.Street = en.Street;
            res.Capacity = en.Capacity;
            res.City = en.Country.Name + ", " + en.Country.City;
            res.Propietario = en.Restaurant_Owner.Email;
            res.IdPais = en.Country.Id;
            if (en.Tags.Count > 0)
            {
                int i = 0;
                while (i < en.Tags.Count) {
                    if(i==0) res.Tags += " " + en.Tags[i].Name;
                    else res.Tags += ", " + en.Tags[i].Name;
                    i++;
                }
                
            }
            return res;
        }

        public IList<RestaurantViewModel> ConvertListENToModel(IList<RestaurantEN> rests)
        {
            IList<RestaurantViewModel> resv = new List<RestaurantViewModel>();
            foreach (RestaurantEN res in rests)
            {
                resv.Add(ConvertENToModelUI(res));
            }
            return resv;
        }
    }
}