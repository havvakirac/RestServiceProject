using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace RestService
{
    /// <summary>
    /// Kullanıcının Admin kontrolü
    /// </summary>
    public class AdminControl
    {
        public bool IsAdmin(string name)
        {
            AuthorizUserControl cntr = new AuthorizUserControl();
            var kisi = (from item in cntr.GetUserList()
                        where item.User_Name == name
                        select item).SingleOrDefault();
            
            if (kisi.IsAdmin == "E")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}