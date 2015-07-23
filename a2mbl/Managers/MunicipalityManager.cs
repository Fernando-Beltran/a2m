using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Managers
{
    public static class MunicipalityManager
    {
        public static List<Municipality> getAllMunicipalities(){
        try{
             using (var db = new a2mbl.a2mContext())
                    {
                        List<Municipality> MunicipalityList = db.Municipalities.Where(item => item.Fk_Municipality_Status == (int)Common.MunicipalityStatus.Active).ToList();
                        return MunicipalityList;
                 
                    }
            }
            catch(Exception ex){
                throw;
            }
        }
    }
}
