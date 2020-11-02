using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBAPI_MVC_Crud.Models
{
    public class RegionClass
    {
        public int RowNumber { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public string Unit { get; set; }
    }
}