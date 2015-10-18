using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
using log4net;
using a2mbl.Common;
using a2mbl.IManagers;
using a2mbl.Wrapper;
using a2mbl.Linq;
using LinqKit;

namespace a2mbl.Managers
{

    public class BussinessManager : IBussinessManager
    {
        /// <summary>
        /// Obtiene la lista de negocios filtrados
        /// </summary>
        /// <param name="BussinessFilter">Filtros</param>
        /// <returns>Lista de municipios que cumplen el filtro</returns>
        public List<Business> GetBusinessFromMunicipalityIdAndFilters(BusinesFilter BussinessFilter, int PageSize)
        {
            var predicate = PredicateBuilder.False<Business>();

           using (var db = new a2mbl.a2mContext())
                {
                     List<Business> BusinessList = db.Businesses
                        .Include("Business_Status")
                        .Include("Categories")
                        .ToList();

                     if (BussinessFilter.IsOnlineOrder)
                     {
                         BusinessList = BusinessList.Where(p => p.Is_A2M == true).ToList();                         
                     }
                     if (BussinessFilter.IsOrderToHome)
                     {
                         BusinessList = BusinessList.Where(p => p.Allow_Shipping == true).ToList();
                     }
                     if (BussinessFilter.IsOrderToPickup)
                     {
                         BusinessList = BusinessList.Where(p => p.Allow_PickUp == true).ToList();
                     }
                     if (BussinessFilter.IsDiaryMenu)
                     {
                         BusinessList = BusinessList.Where(p => p.Has_DiaryMenu == true).ToList();
                     }
                     if (BussinessFilter.IsBrochure)
                     {
                         BusinessList = BusinessList.Where(p => p.Has_Pdf == true).ToList();
                     }

                    return BusinessList;
                }
          
        }

        /// <summary>
        /// Obtiene la lista de negocios de un municipio
        /// </summary>
        /// <param name="municipalityId">Identificador del municipio</param>
        /// <returns>Lista de municipios activos</returns>
        public List<Business> GetBusinessFromMunicipalityId(int municipalityId){
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
        public Business GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamed(string municipalityName,string businessName)
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
        public Business GetBusinessFromMunicipalityNormalizedNameAndBusinessNormalizedNamedFiltered(string municipalityName, string businessName, List<BusinessFilterCriteria> filters)
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
        public Business GetBusinessFromId(int businessId)
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
       
        public bool ValidateLogin(string phone,string password) {
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

        private IQueryable<Business> GetBussinessManagerBaseQuery(a2mContext context, List<BusinessFilterCriteria> filters, int bussinessId, int? categoryId)
        {
            IQueryable<Business> query = context.Businesses.Where(item => item.Pk_Business == bussinessId);

            //if (categoryId.HasValue)
            //    query = query.Where(item => item.NetworkNodeCategoryId == categoryId);

            if (filters != null)
            {
                //DynamicWhere result = GenerateDynamicWhere(filters);
                //if (!string.IsNullOrEmpty(result.WhereClause))
                //        query = query.Where(result.WhereClause, result.Params);
            }

            return query;

        }
       
    }
}
