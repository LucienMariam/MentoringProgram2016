using System.Collections.Generic;

namespace SouvenirMarket.AdminService.AdminCollections
{
    public class StringFinder
    {
        readonly HashSet<string> _list;

        public StringFinder(IEnumerable<string> list)
        {
            _list = new HashSet<string>(list);
        }
        

        public bool SearchString(string ob)
        {
            return _list.Contains(ob);
        }

        public string GetStringWithValue(string ob)
        {
            if (!SearchString(ob)) return "";

            var iterator = _list.GetEnumerator();

            for(;;)
            {
                if (iterator.Current.Contains(ob))
                    return iterator.Current;

                iterator.MoveNext();
            }
        }
    }
}
