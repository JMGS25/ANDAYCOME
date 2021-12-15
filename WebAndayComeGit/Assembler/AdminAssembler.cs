using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class AdminAssembler
    {
        public AdminViewModel ConvertENToModelUI(AdminEN en)
        {
            AdminViewModel admin = new AdminViewModel();
            admin.Email = en.Email;
            admin.Name = en.Name;
            admin.Telefono = en.Tel;
            admin.Pass = en.Pass;
            admin.Photo = en.Photo;
            admin.IdPais= en.Country.Id;
            admin.Lang = en.Language;

            return admin;
        }

        public IList<AdminViewModel> ConvertListENToModel(IList<AdminEN> ens)
        {
            IList<AdminViewModel> admins = new List<AdminViewModel>();
            foreach (AdminEN en in ens)
            {
                admins.Add(ConvertENToModelUI(en));
            }

            return admins;
        }
    }
}
