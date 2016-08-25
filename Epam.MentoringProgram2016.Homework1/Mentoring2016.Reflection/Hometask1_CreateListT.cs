using System;
using System.Collections.Generic;
using System.Reflection;


namespace Mentoring2016.Reflection
{
    class ListTReflectionCreator<T> where T : new()
    {
        public List<T> CreateList()
        {
            var list = (List<T>)Activator.CreateInstance(typeof(List<T>));
            Type listElement = list.GetType().GetTypeInfo().GetElementType();

            if (listElement.IsValueType || listElement.IsEquivalentTo(typeof(string)))
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new T());
                }
            }

            return list;
        }
    }
}
