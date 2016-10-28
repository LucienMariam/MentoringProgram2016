using NorthwindLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
	public class EntitiesManager
	{
	    private readonly ICategoriesCache catCache;
	    private readonly ICustomersCache custCache;
	    private readonly IRegionsCahce regCache;

		public EntitiesManager(ICategoriesCache cache)
		{
		    catCache = cache;
		    custCache = null;
		    regCache = null;
		}

        public EntitiesManager(ICustomersCache cache)
        {
            custCache = cache;
            catCache = null;
            regCache = null;
        }

        public EntitiesManager(IRegionsCahce cache)
        {
            regCache = cache;
            custCache = null;
            catCache = null;
        }

        public IEnumerable<Category> GetCategories()
		{
			Console.WriteLine("Get Categories");
			var user = Thread.CurrentPrincipal.Identity.Name;
			var categories = catCache?.Get(user);

			if (categories == null && catCache != null)
			{
				Console.WriteLine("From DB");

				using (var dbContext = new Northwind())
				{
					dbContext.Configuration.LazyLoadingEnabled = false;
					dbContext.Configuration.ProxyCreationEnabled = false;
					categories = dbContext.Categories.ToList();
					catCache.Set(user, categories);
				}
			}
			return categories;
		}

        public IEnumerable<Customer> GetCustomers()
        {
            Console.WriteLine("Get Customers");
            var user = Thread.CurrentPrincipal.Identity.Name;
            var customers = custCache?.Get(user);

            if (customers == null && custCache != null)
            {
                Console.WriteLine("From DB");

                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    customers = dbContext.Customers.ToList();
                    custCache.Set(user, customers);
                }
            }
            return customers;
        }

        public IEnumerable<Region> GetRegions()
        {
            Console.WriteLine("Get Regions");
            var user = Thread.CurrentPrincipal.Identity.Name;
            var regions = regCache?.Get(user);

            if (regions == null && regCache != null)
            {
                Console.WriteLine("From DB");

                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    regions = dbContext.Regions.ToList();
                    regCache.Set(user, regions);
                }
            }
            return regions;
        }
    }
}
