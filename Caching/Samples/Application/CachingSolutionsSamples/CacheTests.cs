using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindLibrary;
using System.Linq;
using System.Threading;

namespace CachingSolutionsSamples
{
	[TestClass]
	public class CacheTests
	{
		[TestMethod]
		public void CategoriesMemoryCache()
		{
			var categoryManager = new EntitiesManager(new CategoriesMemoryCache());

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(categoryManager.GetCategories().Count());
				Thread.Sleep(100);
			}
		}

		[TestMethod]
		public void CategoriesRedisCache()
		{
			var categoryManager = new EntitiesManager(new CategoriesRedisCache("localhost"));

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(categoryManager.GetCategories().Count());
				Thread.Sleep(100);
			}
		}

        [TestMethod]
        public void CustomersMemoryCache()
        {
            var categoryManager = new EntitiesManager(new CustomersMemoryCache());

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCustomers().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void RegionsRedisCache()
        {
            var categoryManager = new EntitiesManager(new RegionsRedisCache("localhost"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetRegions().Count());
                Thread.Sleep(100);
            }
        }
    }
}
