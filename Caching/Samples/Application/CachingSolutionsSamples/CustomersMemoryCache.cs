using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    internal class CustomersMemoryCache: ICustomersCache
    {
        ObjectCache cache = MemoryCache.Default;
        string prefix = "Cache_Customers";
        private CacheItemPolicy policy = new CacheItemPolicy();

        public IEnumerable<Customer> Get(string forUser)
        {
            return (IEnumerable<Customer>)cache.Get(prefix + forUser);
        }

        public void Set(string forUser, IEnumerable<Customer> categories)
        {
            cache.Set(prefix + forUser, categories, ObjectCache.InfiniteAbsoluteExpiration);
            cache.Add(prefix, forUser, new DateTimeOffset(DateTime.UtcNow.AddMinutes(10)));
            policy.ChangeMonitors.Add(
                new SqlChangeMonitor(
                    new System.Data.SqlClient.SqlDependency(new SqlCommand("select * From dbo.UserProfile"))));
            cache.Add(prefix, forUser, policy);
        }
    }
}
