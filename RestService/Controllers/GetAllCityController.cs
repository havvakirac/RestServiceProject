using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SOAPService;

namespace RestService.Controllers
{
  
    public class GetAllCityController : ApiController
    {
        // GET: api/GetAllCity/5
        public List<CITYLIST> Get()
        {
            SOAPService.GetCityServiceasmx client = new GetCityServiceasmx();
            List<CITYLIST> list = new List<CITYLIST>();
            var cityList = client.GetCityAndId();
            foreach (var item in cityList)
            {
                CITYLIST c = new CITYLIST
                {
                    City_ID = item.City_ID,
                    City_Name = item.City_Name
                };

                list.Add(c);
            }

            return list;
        }

    }
}
