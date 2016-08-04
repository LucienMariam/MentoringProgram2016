using System.Collections;
using System.Collections.Generic;


namespace SouvenirMarket.AdminService.AdminCollections
{
    public class IntCollection: IEnumerable
    {
        readonly List<int> _array;

        public IntCollection(int[] initialCollection)
        {
            _array = new List<int>(initialCollection);
        }

        public int this[int index]
        {
            get { return _array[index]; }
            set { _array.Insert(index, value); }
        }

        public int Count => _array.Count;

        public IEnumerator GetEnumerator()
        {
            return new IntCollectionIterator(this);
        }
    }
}
