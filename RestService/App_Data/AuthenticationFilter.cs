using Newtonsoft.Json;
using RestService.Controllers;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestService
{
    public class AuthenticationFilter : AuthorizationFilterAttribute
    {
        /// <summary>
        /// İstek gönderen kullanıcının yetkisinin olup olmadığını kontrol eder
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string userName = String.Empty;
            string userPassword = String.Empty;
            string IsAdmin = string.Empty;

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                userPassword = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
            }

            //EncryptionDecryption ed = new EncryptionDecryption();
            //userPassword = ed.Encryption(userPassword);

            if (userName != null && userPassword != null) //Yetkili kullanıcılar listesinde böyle bi kullanıcı var mı?
            {
                AuthorizUserControl cntr = new AuthorizUserControl();
                var kisi = (from item in cntr.GetUserList()
                            where item.User_Name == userName
                            where item.Password == userPassword
                            select item).SingleOrDefault();
               
                if (kisi == null)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }

                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);//İşlem yapan kullanıcıyı tutar
            }
        }
    }
}





/*       if (userName != null && userPassword != null)// User_Name ve Password kontrolü SPde kullanıcı Admin değilse yetki verilmiyor!
       {
               USER usr = new USER();
               SqlConnection con = new SqlConnection();
               SqlDataAdapter da = new SqlDataAdapter();
               con = new SqlConnection("data source = KRC; initial catalog = CITYLISTDB; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework");
               try
               {
                   con.Open();
                   SqlCommand cmd = new SqlCommand("SP_USER", con);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@NAME", userName));
                   cmd.Parameters.Add(new SqlParameter("@PASSWORD", userPassword));

                   using (SqlDataReader rdr = cmd.ExecuteReader())
                   {
                       while (rdr.Read())
                       {
                           usr.User_Name = rdr[0].ToString();
                           usr.Password = rdr[1].ToString();
                       }
                   }

                   if (usr.User_Name==null||usr.Password==null)
                   {
                       actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                   }

               }
               catch (Exception ex)
               {
                   throw ex;
               }
               con.Close();
       }*/


//if (userName != null && userPassword != null)
//{
//    string strResponseValue = string.Empty;
//    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.myjson.com/bins/h5hyo");
//    request.Method = "GET";

//    try
//    {
//        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
//        {
//            if (response.StatusCode != HttpStatusCode.OK)
//            {
//                throw new AccessViolationException("err code:" + response.StatusCode);
//            }

//            using (Stream responseStream = response.GetResponseStream())
//            {
//                if (responseStream != null)
//                {
//                    using (StreamReader reader = new StreamReader(responseStream))
//                    {
//                        strResponseValue = reader.ReadToEnd();
//                        deserializeJson(strResponseValue);
//                        //  Forecast myForecast = Newtonsoft.Json.JsonConvert.DeserializeObject<Forecast>(strResponseValue);

//                    }
//                }
//            }
//        }

//    }
//    catch (Exception ex)
//    {
//        strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":()}";
//    }
//    // Convert to json format
//    void deserializeJson(string strJson)
//    {
//        List<USER> list = JsonConvert.DeserializeObject<List<USER>>(strJson);
//        var kisi = (from item in list
//                    where item.User_Name == userName
//                    where item.Password == userPassword
//                    where item.IsAdmin == "E"
//                    select item).SingleOrDefault();

//        if (kisi == null)
//        {
//            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
//        }
//    }

//} //End if 

//    public override void OnAuthorization(HttpActionContext actionContext)
//    {
//        if (actionContext.Request.Headers.Authorization == null)
//        {
//            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//        }
//        else
//        {
//            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
//            string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
//            string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
//            string username = usernamePasswordArray[0];
//            string password = usernamePasswordArray[1];

//            if (UserControl.UserLogin(username,password)==true)
//            {
//                Thread.CurrentPrincipal = new GenericPrincipal(
//                    new GenericIdentity(username), null);
//            }
//        else
//        {
//            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//        }
//    }
//}
//}