//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CITYLIST
    {
        public long Id { get; set; }
        public Nullable<long> City_ID { get; set; }
        public string City_Name { get; set; }
        public string Country { get; set; }
        public Nullable<long> Lat { get; set; }
        public Nullable<long> Lon { get; set; }
    }
}
