using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
using log4net;
using a2mbl.Common;

namespace a2mbl.Managers
{
    public static class MunicipalityManager
    {
        /// <summary>
        /// Obtiene toda la lista de municipios
        /// </summary>
        /// <returns>Listado de todos los municipios de A2M</returns>
        public static List<Municipality> getAllMunicipalities()
        {
            try
            {               
                using (var db = new a2mbl.a2mContext())
                {
                    List<Municipality> MunicipalityList = db.Municipalities.Include("Municipality_Status").ToList();
                    return MunicipalityList;

                }
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene toda la lista de municipios
        /// </summary>
        /// <returns>Listado de todos los municipios de A2M</returns>
        public static List<Municipality> getAllActiveMunicipalities()
        {
            try
            {
                using (var db = new a2mbl.a2mContext())
                {
                    List<Municipality> MunicipalityList = 
                        db.Municipalities
                        .Include("Municipality_Status")
                        .Where(item => item.Fk_Municipality_Status == (int)Common.MunicipalityStatus.Active).ToList();
                    return MunicipalityList;

                }
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }
        /// Obtiene el municipio por nombre normalizado
        /// </summary>
        /// <returns>El municipio por nombre normalizado o null si no lo encuentra        
        /// </returns>
        /// <example>
        /// Sevilla la Nueva ==> sevilla-la-nueva
        /// </example>
        public static Municipality getMunicipalityByNormalizedName(string normalizedName)
        {
            try
            {
                List<Municipality> MunicipalityList = getAllActiveMunicipalities();
                return MunicipalityList.Where(item => item.Name.ToA2MUrlName() == normalizedName).SingleOrDefault();              
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }

    }
}
