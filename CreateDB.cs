
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CP.AndayCome;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");

                CountryCEN country = new CountryCEN ();
                int c_oid = country.New_ (AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum.alic);

                //dependen de country
                //###########################
                ClientCEN cliente1 = new ClientCEN ();
                ClientCEN cliente2 = new ClientCEN ();
                ClientCEN cliente3 = new ClientCEN ();

                string cli1_oid = cliente1.New_ (123456789, "photo1", "1234", c_oid, "usuario1@gmail.com", AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum.spanish, "usuario1", false);
                string cli2_oid = cliente2.New_ (123456789, "photo2", "12345", c_oid, "usuario2@gmail.com", AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum.spanish, "usuario2", true);
                string cli3_oid = cliente3.New_ (123456789, "photo3", "123456", c_oid, "usuario3@gmail.com", AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum.english, "usuario3", false);

                AdminCEN admin = new AdminCEN ();

                admin.New_ (123456789, "photo1", "4321", c_oid, "ib50@gmail.com", AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum.spanish, "Ian");

                Restaurant_OwnerCEN rest_own1 = new Restaurant_OwnerCEN ();

                string res_onw_oid = rest_own1.New_ (123456789, "photo1", "4321", c_oid, "ib50@gmail.com", AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum.spanish, "Ian_el_jefesito");
                //------------------------------------


                //depende de un cliente
                //###########################

                PaymentCEN pay = new PaymentCEN ();
                pay.New_ (cli1_oid, true, DateTime.Today);

                ComentariosCEN coment = new ComentariosCEN ();
                coment.New_ ("comentario generico", cli2_oid, DateTime.Today);

                RatesCEN rate = new RatesCEN ();
                rate.New_ (cli1_oid, 3);

                RestaurantCEN rest = new RestaurantCEN ();
                int rest_oid = rest.New_ (res_onw_oid, "menu generico", "photo_res", "Mastur Bar", "calle false 123", 32);

                //------------------------------------


                //depende de un cliente y de un restaurante
                //###########################
                TicketCEN tic = new TicketCEN ();
                tic.New_ (cli3_oid, rest_oid, DateTime.Today, 3.4f);


                BookingCP book = new BookingCP ();
                BookingEN book_oid = book.New_(rest_oid, cli3_oid, DateTime.Now, DateTime.Now, 4);
                //------------------------------------


                //depende de un cliente, un restaurante, una reserva, y una country
                //###########################
                RouteCEN route = new RouteCEN ();
                //route.New_ (cli2_oid, new List<int> { book_oid }, c_oid, new List<int> { rest_oid }, DateTime.Now, DateTime.Now, "photo1", "una ruta generica", "ruta de rutas ruteando");
                //------------------------------------


                //No depende
                //###########################
                WallCEN wall = new WallCEN ();
                wall.New_ ();

                GiveawayCEN give = new GiveawayCEN ();
                give.New_ (20, true, "pin o chapa");

                TagsCEN tag = new TagsCEN ();
                tag.New_ ("Italiano");

                //------------------------------------







                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
