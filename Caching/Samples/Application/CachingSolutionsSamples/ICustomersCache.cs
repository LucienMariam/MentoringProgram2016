using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public interface ICustomersCache
    {
        IEnumerable<Customer> Get(string forUser);
        void Set(string forUser, IEnumerable<Customer> categories);
    }
}
