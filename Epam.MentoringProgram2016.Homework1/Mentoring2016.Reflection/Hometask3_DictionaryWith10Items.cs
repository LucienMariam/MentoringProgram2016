using System;
using System.Collections.Generic;

namespace Mentoring2016.Reflection
{
    public class DictionaryReflectionCreator<TKey, TValue>
    {
        public Dictionary<TKey, TValue> CreateDictionary()
        {
            return (Dictionary<TKey, TValue>)Activator.CreateInstance(typeof(Dictionary<TKey, TValue>));
        }
    }
}
