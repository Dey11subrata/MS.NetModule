using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using System.Data;
using System.Runtime.CompilerServices;

namespace StudentProgManagment.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public static List<SelectListItem> getAllCity() { 
            List<SelectListItem> list= new List<SelectListItem>();


            SqlConnection conn = GetConnection();
           


            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.Text;
                select.CommandText = "select * from City";
                SqlDataReader dr = select.ExecuteReader();

                while (dr.Read())
                {
                    City c = new City
                    {
                        CityId = dr.GetInt32("CityId"),
                        CityName = dr.GetString("CityName")
                    };
                    list.Add(new SelectListItem(c.CityName.ToString(), c.CityId.ToString()));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return list;
        }


        public static List<City> getAllCityDetails()
        {
            List<City> list = new List<City>(); // changes


            SqlConnection conn = GetConnection();



            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.Text;
                select.CommandText = "select * from City";
                SqlDataReader dr = select.ExecuteReader();

                while (dr.Read())
                {
                    City c = new City
                    {
                        CityId = dr.GetInt32("CityId"),
                        CityName = dr.GetString("CityName")
                    };
                    list.Add(c);// changes
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return list;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentProjects;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentProjects;Integrated Security=True;";

            return conn;

        }
    }


}
