using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindLibrary;
using System.Runtime.Caching;

namespace CachingSolutionsSamples
{
	internal class CategoriesMemoryCache : ICategoriesCache
	{
	    private ObjectCache cache;
	    private string prefix;

	    public CategoriesMemoryCache()
	    {
            prefix = "Cache_Categories";
            cache = MemoryCache.Default;
        }

        public IEnumerable<Category> Get(string forUser)
		{
			return (IEnumerable<Category>) cache.Get(prefix + forUser);
		}

		public void Set(string forUser, IEnumerable<Category> categories)
		{
            cache.Set(prefix + forUser, categories, ObjectCache.InfiniteAbsoluteExpiration);
            cache.Add(prefix, forUser, new DateTimeOffset(DateTime.UtcNow.AddMinutes(10)));
        }
	}
}
