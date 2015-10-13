using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Common
{
    public class BusinesFilter
    {
        public Boolean IsOnlineOrder { get; set; }
        public Boolean IsOrderToHome { get; set; }
        public Boolean IsOrderToPickup { get; set; }
        public Boolean IsReserve { get; set; }
        public Boolean IsBrochure { get; set; }
        public Boolean IsDiaryMenu { get; set; }
        public string CurrentMunicipality { get; set; }
        public string CurrentBussiness { get; set; }
        public int CurrentBussinessId { get; set; }
        public int CurrentPage { get; set; }
    }
}
