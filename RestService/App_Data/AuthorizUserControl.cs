using Newtonsoft.Json;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;

namespace RestService
{
    public class AuthorizUserControl
    {
        private static List<USER> authorizUserList;
        /// <summary>
        /// Yetkili olan kullanıcıların listesini getiren metod
        /// MyJson Store da kullanıcılar tutuluyo
        /// Admin ise E, !=> H
        /// </summary>
        public List<USER> GetUserList()
        {
            if (authorizUserList == null)
            {
                authorizUserList = new List<USER>();
                string strResponseValue = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.myjson.com/bins/h5hyo");
                request.Method = "GET";

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new AccessViolationException("err code:" + response.StatusCode);
                        }

                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (StreamReader reader = new StreamReader(responseStream))
                                {
                                    strResponseValue = reader.ReadToEnd();
                                    authorizUserList = JsonConvert.DeserializeObject<List<USER>>(strResponseValue);
                                }
                            }
                        }//end of stream using
                    }//httpwebresponse using end
                }
                catch (Exception ex)
                {
                    strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":()}";
                }
            }//EndIf
            return authorizUserList;
        }
    }
}