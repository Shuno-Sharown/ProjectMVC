//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.helper
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Nullable<int> CateID { get; set; }
        public string changefreq { get; set; }
        public Nullable<double> priority { get; set; }
        public Nullable<System.DateTime> datemodified { get; set; }
        public string image { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
