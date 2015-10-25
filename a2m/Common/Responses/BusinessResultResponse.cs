using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2m.Common.Responses
{
    public class BusinessResultResponse: JSONResponse
    {
        public string ResultHtmlView { get; set; }
        public int PageSize { get; set; }
        public int TotalResult { get; set; }
        public int NextPage { get; set; }
        public int NextResults
        {
            get
            {
                if (AreMoreResults)
                {
                    var pending = TotalResult - (A2MApplication.ResultsPaginateSize * (NextPage));
                    if (pending < 0) return 0;
                    if (pending > A2MApplication.ResultsPaginateSize) return A2MApplication.ResultsPaginateSize;
                    else return pending;
                }
                return 0;

            }
        }

        public bool AreMoreResults
        {
            get
            {
                if (ResultHtmlView == null || ResultHtmlView == string.Empty) return false;
                if (TotalResult < A2MApplication.ResultsPaginateSize * NextPage)
                {
                    return false;
                }
                return true;
            }
        } 
    }
}