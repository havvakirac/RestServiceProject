using RestService.App_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RestService.Controllers
{
    public class Client
    {
        public string Url { get; set; }       

        /// <summary>
        /// Gelen CityId ye göre URL adresini olşturan Client metodumuz
        /// </summary>
        /// <param name="cityID"></param>
        public Client(long cityID)
        {          
            Url = "http://api.openweathermap.org/data/2.5/forecast?id=" + cityID + "&appid=APIKEY";            
        }

        /// <summary>
        /// request oluşturulur
        ///streamReader ile datalar response edilir 
        ///deserializeJson metodu çağrılarak sonuçlar json formatta alınır
        /// </summary>
        /// <returns>json veriler</returns>
        public string MakeRequest()
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new AccessViolationException("err code:" + response.StatusCode);
                    }
                    else
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (StreamReader reader = new StreamReader(responseStream))
                                {
                                    strResponseValue = reader.ReadToEnd();
                                    deserializeJson(strResponseValue);                                    
                                }
                            }
                        }//end of Stream    
                    } //end of else                   
                }//end of HttpResponse
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":()}";
            }            
            return strResponseValue;
            
            // Convert to json format
            string  deserializeJson(string strJson)
            {
                Forecast myForecast = Newtonsoft.Json.JsonConvert.DeserializeObject<Forecast>(strJson);               
                return myForecast.ToString();
            }
        }
    }
}