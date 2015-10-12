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
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get {
            if (BusinessList == null) return 0;
            return BusinessList.Count;
        } }

        public bool AreMoreResults {
            get {
                if (BusinessList == null) return false;
                if (BusinessList.Count < A2MApplication.ResultsPaginateSize * CurrentPage) {
                    return false;
                }
                return true;
            } 
        } 
    }
}