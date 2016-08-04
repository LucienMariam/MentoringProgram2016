using System.Collections.Generic;
using System.Linq;


namespace SouvenirMarket.AdminService.AdminCollections
{
    public class Box<T>
    {
        readonly T[] _box;

        public Box(T[] anotherCollection)
        {
            _box = new T[anotherCollection.Length];
            anotherCollection.CopyTo(_box, 0);
        }

        public bool Contains(T obj)
        {
            return _box.Contains(obj);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T obj in _box)
            {
                if (obj == null)
                    break;

                yield return obj;
            }
        } 
    }
}
