
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;



/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CP.AndayCome_Giveaway_getWinner) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CP.AndayCome
{
public partial class GiveawayCP : BasicCP
{
public void GetWinner (int p_oid)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CP.AndayCome_Giveaway_getWinner) ENABLED START*/

        IGiveawayCAD giveawayCAD = null;
        GiveawayCEN giveawayCEN = null;
        ClientCAD clientCAD = null;
        ClientCEN clientCEN = null;
        TicketCAD ticketCAD = null;
        TicketCEN ticketCEN = null;


        try
        {
                SessionInitializeTransaction ();
                giveawayCAD = new GiveawayCAD (session);
                giveawayCEN = new GiveawayCEN (giveawayCAD);

                clientCAD = new ClientCAD (session);
                clientCEN = new ClientCEN (clientCAD);

                ticketCAD = new TicketCAD (session);
                ticketCEN = new TicketCEN (ticketCAD);
                // Write here your custom transaction ...

                //Console.WriteLine("\n ##### Intentando realizar sorteo... #####");
                //recuperar  el giveaway
                GiveawayEN giveawayEN = giveawayCEN.ReadOID (p_oid);
                //recduperar lista de clientes apuntados al givdeaway
                IList<ClientEN> list_clients = giveawayEN.Client;
                //cantidad de clientes partdicipando
                int size = list_clients.Count;

                Random rand = new Random (Guid.NewGuid ().GetHashCode ()); //le ponemos una semilla
                //genera ganador
                int winner = rand.Next (0, size);
                //asigna ganaddor
                giveawayEN.Winner = list_clients [winner].Email;
                //aplica cambios
                giveawayCAD.ModifyDefault (giveawayEN);
                //Console.WriteLine("\n #### Ganador encontrado con exito #####");
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }

        /*PROTECTED REGION END*/
}
}
}
