using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
using log4net;
using a2mbl.Common;
using a2mbl.IManagers;

namespace a2mbl.Managers
{

    public class BussinessManager 
    {       
        /// <summary>
        /// Obtiene la lista de negocios de un municipio
        /// </summary>
        /// <param name="municipalityId">Identificador del municipio</param>
        /// <returns>Lista de municipios activos</returns>
        public static List<Business> GetBusinessFromMunicipalityId(int municipalityId){
            try
            {
               
                using (var db = new a2mbl.a2mContext())
                {
                    List<Business> BusinessList = db.Businesses
                        .Include("Business_Status")
                        .Include("Categories")
                        .Where(item => item.Fk_Municipality == municipalityId).ToList();
                    return BusinessList;
                }
            }
            catch(Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un negocio desde el nombre normalizado de un municipio y su negocio
        /// </summary>        
        /// <param name="businessName"></param>
        /// <param name="municipalityName"></param>
        /// <returns>Negocio</returns>
        public static Business GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamed(string municipalityName,string businessName)
        {
            try
            {
                using (var db = new a2mbl.a2mContext())
                {
                    List<Business> BusinessList = db.Businesses
                        .Include("Business_Status")
                        .Include("Categories")
                        .Include("Municipality").ToList();
                    
                    return BusinessList.Where(item => item.Name.ToA2MUrlName() == businessName && item.Municipality.Name.ToA2MUrlName() == municipalityName).SingleOrDefault();             
                    
                    
                }
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un negocio desde el nombre normalizado de un municipio y su negocio
        /// </summary>        
        /// <param name="businessName"></param>
        /// <param name="municipalityName"></param>
        /// <param name="filters">Filtros</param>
        /// <returns>Negocio</returns>
        public static Business GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamedFiltered(string municipalityName, string businessName, List<LinqFilter> filters)
        {
            try
            {
                using (var db = new a2mbl.a2mContext())
                {
                    List<Business> BusinessList = db.Businesses
                        .Include("Business_Status")
                        .Include("Categories")
                        .Include("Municipality").ToList();

                    return BusinessList.Where(item => item.Name.ToA2MUrlName() == businessName && item.Municipality.Name.ToA2MUrlName() == municipalityName).SingleOrDefault();


                }
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }


        /// <summary>
        /// Obtiene el negocio apartir de su ID
        /// </summary>
        /// <param name="municipalityId">Identificador del negocio</param>
        /// <returns>Negocio</returns>
        public static Business GetBusinessFromId(int businessId)
        {
            try
            {
                using (var db = new a2mbl.a2mContext())
                {
                    Business Business = db.Businesses
                        .Include("Business_Status")
                        .Include("Categories")
                        .Where(item => item.Pk_Business == businessId).SingleOrDefault();
                    return Business;
                }
            }
            catch (Exception ex)
            {
                LogWrapper.GetLogger().Error(ex);
                throw;
            }
        }
       
        public static bool ValidateLogin(string phone,string password) {
            try
            {
                //a2mbl.a2mContext dbContext = new a2mbl.a2mContext();
                //IQueryable<a2mbl.Business> list = dbContext.Businesses.Select(item => item.Phone != "");4
                /*
                   // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: "); 
                var name = Console.ReadLine(); 
 
                var blog = new Blog { Name = name }; 
                db.Blogs.Add(blog); 
                db.SaveChanges(); 
 
                // Display all Blogs from the database 
                var query = from b in db.Blogs 
                            orderby b.Name 
                            select b; 
 
                Console.WriteLine("All blogs in the database:"); 
                foreach (var item in query) 
                { 
                    Console.WriteLine(item.Name); 
                } 
 
                Console.WriteLine("Press any key to exit..."); 
                Console.ReadKey(); 
                 */
                using (var db = new a2mbl.a2mContext())
                {

                    var query = from b in db.Businesses
                                orderby b.Name
                                select b;
                    a2mbl.Business business = db.Businesses.Include("Municipality").Where(item => item.Phone.Equals(phone)).SingleOrDefault();

                    foreach (a2mbl.Business item in query)
                    {
                      //  var a = "";
                    }
                }
                return true;
            }
            catch {
                return false;
            }
           
        }
        
    }
}
