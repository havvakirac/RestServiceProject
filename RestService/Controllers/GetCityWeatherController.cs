using RestService.Models;
using System.Web.Http;
using RestService.App_Data;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web;
using System.Net.Http;

namespace RestService.Controllers
{     
    public class GetCityWeatherController : ApiController
    {
        /// <summary>
        /// 
        /// GetCityId() metodunu çağırıp CityIdyi havadurumunu getiren Client()e gönderir
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Şehrin Hava Durumu</returns>
        //GET: api/GetCityWeather/5
        [AuthenticationFilter]
        public string Get(string id)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
         
            Client myClient;
            AdminControl adminControl;
            bool isNumeric = long.TryParse(id,out long cityId);

            if (isNumeric==true)//Sayi numeric ise kullanıcının admin olup olmadığına bakacak
            {
                myClient = new Client(cityId);                         
            }
            else// Şehir ismine göre sadece Admin(isAdmin="E") olan görebilecek
            {
                adminControl = new AdminControl();
                if (adminControl.IsAdmin(username) == true)
                {
                    GetCityId g = new GetCityId();
                    var ID = g.CityId(id);
                    myClient = new Client(ID);
                }
                else
                {
                    var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    throw new HttpResponseException(msg);
                }
            }             
            
            string strResponse = string.Empty;

            strResponse = myClient.MakeRequest();
            return strResponse;
        }        

        // POST: api/GetCityWeather
        [AuthenticationFilter]
        public void Post([FromBody]USER value)
        {
            EncryptionDecryption e = new EncryptionDecryption();
            string pasword = e.Encryption(value.Password);
            value.Password = pasword;

            UserPost post = new UserPost();
            post.JsonPut(value);
        }
        
    }
}