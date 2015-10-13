using a2mbl.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.IManagers
{
    public interface  IBussinessManager
    {
        
        List<Business> GetBusinessFromMunicipalityId(int municipalityId);
        Business GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamed(string municipalityName, string businessName);
        Business GetBusinessFromId(int businessId);
        List<Business> GetBusinessFromMunicipalityIdAndFilters(BusinesFilter BussinessFilter);

    }
}
