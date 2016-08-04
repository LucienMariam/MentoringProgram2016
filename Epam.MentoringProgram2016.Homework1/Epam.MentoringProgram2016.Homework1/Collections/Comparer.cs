using System;
using System.Collections.Generic;

namespace SouvenirMarket.AdminService.AdminCollections
{
    public class Comparer<T>: IComparer<T> where T: IComparable
    {
        public T InnerObject { get; private set; }

        public Comparer(T sample)
        {
            InnerObject = sample;
        }

        public int CompareWith(T outerObject)
        {
            return InnerObject.CompareTo(outerObject);
        }

        public int Compare(T newInnerObject, T outerObject)
        {
            InnerObject = newInnerObject;
            return InnerObject.CompareTo(outerObject);
        }
    }
}
