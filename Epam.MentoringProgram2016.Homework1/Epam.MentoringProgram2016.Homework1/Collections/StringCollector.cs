using System.Collections.Generic;

namespace SouvenirMarket.AdminService.AdminCollections
{
    public class StringCollector
    {
        public List<string> List { get; private set; }

        public StringCollector()
        {
            List = new List<string>();
        }

        public void Add(string obj)
        {
            List.Add(obj);
        }
    }
}
