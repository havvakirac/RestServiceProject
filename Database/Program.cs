using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestService.App_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
           
            

            using (StreamReader r = new StreamReader("C:\\Users\\Havva\\Desktop\\city.list.json"))
            {
                CITYLISTDBEntities1 db = new CITYLISTDBEntities1();
                string json = r.ReadToEnd();
                List<City> list = JsonConvert.DeserializeObject<List<City>>(json);
                var city = new CityList();

                foreach (var item in list)
                {
                    city.City_ID = item.Id;
                    city.City_Name = item.Name;
                    city.City_Name = item.Country;
                    city.Lat = Convert.ToDecimal(item.Coord.Lat);
                    city.Lon = Convert.ToDecimal(item.Coord.Lon);
                  //  db.CityLists.Add(city);
                 
                }
                
                


                    //return Json("Eklendi");


            }
        } 
       
    }
}
