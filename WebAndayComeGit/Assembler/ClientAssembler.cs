using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class ClientAssembler
    {

        public ClientViewModel ConvertENToModelUI(ClientEN en)
        {
            ClientViewModel client = new ClientViewModel();
            client.Email = en.Email;
            client.Name = en.Name;
            client.Telefono = en.Tel;
            client.Pass = en.Pass;
            client.Photo = en.Photo;
            client.IdPais = en.Country.Id;
            client.Lang = en.Language;
            client.Premium = en.Premium;

            return client;
        }

        public IList<ClientViewModel> ConvertListENToModel(IList<ClientEN> ens)
        {
            IList<ClientViewModel> clients = new List<ClientViewModel>();
            foreach (ClientEN en in ens)
            {
                clients.Add(ConvertENToModelUI(en));
            }

            return clients;
        }

    }
}