
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_Restaurant_check) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class RestaurantCEN
{
public int Check (int p_oid, int p_num)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CEN.AndayCome_Restaurant_check) ENABLED START*/

        // Write here your custom code...


        RestaurantCEN restaurantCEN = new RestaurantCEN ();
        int capacidad = -1;
        RestaurantEN restaurantEN = restaurantCEN.ReadOID (p_oid);

        if (restaurantEN.Capacity > 0) {
                Console.WriteLine ("El restaurante posee espacio para reservas");
                if (restaurantEN.Capacity - p_num >= 0) {
                        capacidad = restaurantEN.Capacity - p_num;
                        Console.WriteLine ("Las reservas pedidas pueden realizarse en el restaurante");
                }
                else{
                        Console.WriteLine ("El n�mero de reservas que se desean pedir superan a la cantidad de reservas disponibles en el restaurante");
                }
        }
        else{
                Console.WriteLine ("El restaurante no posee espacio para nuevas reservas");
        }
        return capacidad;

        /*PROTECTED REGION END*/
}
}
}
