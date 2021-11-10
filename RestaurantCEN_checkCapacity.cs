
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


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_Restaurant_checkCapacity) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class RestaurantCEN
{
public bool CheckCapacity (int p_num)
{           bool capacidad = false;
            RestaurantEN restEN = new RestaurantEN();
            if(restEN.Capacity > 0)
            {
                Console.WriteLine("El restaurante posee espacio para reservas");
                if(restEN.Capacity - p_num >= 0)
                {
                    capacidad = true;
                    Console.WriteLine("Las reservas pedidas pueden realizarse en el restaurante");
                }
                else
                {
                    Console.WriteLine("El número de reservas que se desean pedir superan a la cantidad de reservas disponibles en el restaurante");
                }
            }
            else
            {
                Console.WriteLine("El restaurante no posee espacio para nuevas reservas");
            }
            return capacidad;
}
}
}
