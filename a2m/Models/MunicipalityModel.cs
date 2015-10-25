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
        public List<Business> BusinessListByPage
        {
            get
            {
                return BusinessList.Take(PageSize).Skip(CurrentPage * PageSize).ToList();
            }
        }
        public int CurrentPage { get; set; }
        public int PageSize
        {
            get
            {
                return A2MApplication.ResultsPaginateSize;
            }
        }
        public int NextResults
        {
            get
            {
                if (AreMoreResults)
                {
                    var pending = TotalResults - (A2MApplication.ResultsPaginateSize * (CurrentPage + 1));
                    if (pending < 0) return 0;
                    if (pending > A2MApplication.ResultsPaginateSize) return A2MApplication.ResultsPaginateSize;
                    else return pending;
                }
                return 0;

            }
        }

        public int TotalResults { get {
            if (BusinessList == null) return 0;
            return BusinessList.Count;
        } }

        public bool HaveMorePages
        {
            get
            {
                if (CurrentPage * PageSize < TotalResults) return true;
                return false;
            }
        }
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