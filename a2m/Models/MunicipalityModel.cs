using a2mbl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2m.Models
{
    public class MunicipalityModel
    {
        public Municipality Municipality { get; set; }
        public List<Business> BusinessList { get; set; }
    }
}