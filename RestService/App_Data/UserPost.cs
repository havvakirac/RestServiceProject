using Newtonsoft.Json;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace RestService
{
    public class UserPost
    {
       /// <summary>
       /// Gelen kullanıcı listede yoksa listeye ekler
       /// </summary>
       /// <param name="user"></param>
        public void JsonPut(USER user)
        {
            AuthorizUserControl authorizUser = new AuthorizUserControl();
            List<USER> list = new List<USER>();
            list.AddRange(authorizUser.GetUserList());
            
            USER u = new USER
            {
                Id = user.Id,
                User_Name = user.User_Name,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };

                var kisi = (from item in list
                            where item.User_Name == u.User_Name
                            where item.Password == u.Password
                            where item.IsAdmin == "E"
                            select item).SingleOrDefault();

                if (kisi != null)
                {                    
                    Put(list);
                }
                else
                {
                    list.Add(u);
                    Put(list);
                }   
        }

        /// <summary>
        /// Gelen obj parametresini Json formatta Web apiye ekleyen metod
        /// </summary>
        /// <param name="obj"></param>
        public void Put(object obj)
        {
            string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            HttpWebRequest request = WebRequest.CreateHttp("https://api.myjson.com/bins/h5hyo");
            //api.myjson.com/bins/1gq04l  
            request.Method = "PUT";
            request.AllowWriteStreamBuffering = false;
            request.ContentType = "application/json";
            //request.Accept = "Accept=application/json";
            request.SendChunked = false;
            request.ContentLength = serializedObject.Length;
            
            try
            {
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(serializedObject);
                }

                var response = request.GetResponse() as HttpWebResponse;
            }
            catch (HttpException e)
            {
                 throw e;
            }            
        }
    }
}