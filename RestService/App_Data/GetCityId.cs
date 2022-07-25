using RestService.App_Data;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RestService.Controllers
{    
    public class GetCityId
    {
        /// <summary>
        /// Gelen şehir adına göre dbye bağlanarak şehrin IDsini döndüren mtd
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>cityID</returns>
        public long CityId(string cityName)
        {
            City city = new City();
            SqlConnection con=new SqlConnection();            
            SqlDataAdapter da=new SqlDataAdapter();
            con = new SqlConnection("data source = KRC; initial catalog = CITYLISTDB; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework");

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GET_CITY",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CITY_NAME", cityName));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        city.Id = Convert.ToInt64(reader[0]);                  
                    }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }       
            con.Close();
       
            return city.Id;     
         
        }
    }
}