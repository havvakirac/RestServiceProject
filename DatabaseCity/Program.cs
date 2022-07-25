using Newtonsoft.Json;
using RestService.App_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCity
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (StreamReader r = new StreamReader("C:\\Users\\Havva\\Desktop\\city.list.json"))
            //{
            //    CITYLISTDBEntities db = new CITYLISTDBEntities();
            //    string json = r.ReadToEnd();
            //List<City> list = JsonConvert.DeserializeObject<List<City>>(json);

            //    var city = new CITYLIST();
            //     foreach (var item in list)
            //    {
            //        city.City_ID = item.Id;
            //        city.City_Name = item.Name;
            //        city.Country= item.Country;
            //        city.Lat = Convert.ToInt64(item.Coord.Lat);
            //        city.Lon = Convert.ToInt64(item.Coord.Lon);
            //        db.CITYLISTs.Add(city);
            //        db.SaveChanges();

            //    }    
            //}

            //using (StreamReader r = new StreamReader("C:\\Users\\Havva\\Desktop\\user.json"))
            //{
            //    CITYLISTDBEntities db = new CITYLISTDBEntities();
            //    string json = r.ReadToEnd();
            //    List<USER> list = JsonConvert.DeserializeObject<List<USER>>(json);

            //    var usr = new USER();
            //    foreach (var item in list)
            //    {
            //        usr.User_Name = item.User_Name;
            //        usr.Password = item.Password;
            //        db.USERs.Add(usr);
            //        db.SaveChanges();
            //    }
            //}
        }

    }
}
