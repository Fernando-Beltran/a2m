using a2mbl.Common;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2m.Models
{
    public class RequestBusinessFilter
    {  
        public Boolean IsOnlineOrder {get; set;}
        public Boolean IsOrderToHome {get; set;}
        public Boolean IsOrderToPickup {get; set;}
        public Boolean IsReserve {get; set;}
        public Boolean IsBrochure {get; set;}
        public Boolean IsDiaryMenu {get; set;}
        public string CurrentMunicipality { get; set; }
        public int CurrentBussinessId { get; set; }
        public string CurrentBussiness { get; set; }
        public int CurrentPage { get; set; }

        public BusinesFilter toBusinesFilter()
        {
            return new BusinesFilter()
            {
                CurrentBussiness = this.CurrentBussiness,
                CurrentMunicipality = this.CurrentMunicipality,
                CurrentPage = this.CurrentPage,
                IsBrochure = this.IsBrochure,
                IsDiaryMenu = this.IsDiaryMenu,
                IsOnlineOrder = this.IsOnlineOrder,
                IsOrderToHome = this.IsOrderToHome,
                IsOrderToPickup = this.IsOrderToPickup,
                IsReserve = this.IsReserve,
                CurrentBussinessId = this.CurrentBussinessId
            };
        
        }

        public RequestBusinessFilter() { 
        
        }
            
    }
}