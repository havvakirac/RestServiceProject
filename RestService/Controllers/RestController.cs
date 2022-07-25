using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class RestController : ApiController
    {           
        public string Get()
        { 
            //Client myClient = new Client();
            string strResponse = string.Empty;
            
            //strResponse = myClient.makeRequest();
            //Console.WriteLine(strResponse);
           
            return strResponse;
        }  
    }
}
