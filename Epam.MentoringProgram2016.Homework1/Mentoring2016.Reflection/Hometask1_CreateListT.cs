using System;
using System.Collections.Generic;
using System.Data;

namespace Mentoring2016.Reflection
{
    public class ListTReflectionCreator<T>
    {
        public List<T> CreateList()
        {
            return (List<T>)Activator.CreateInstance(typeof(List<T>));
        }
    }

    public interface Interface
    {
        int UniqueId { get; set; }
    }

    public abstract class AbstractClass: Interface
    {
        public int UniqueId { get; set; }
    }

    public struct Structure
    {
        public int UniqueId;
    }

    public enum Enumeration
    {
        One,
        Two,
        Three,
        Four,
        Five
    }

    public class Class: AbstractClass
    {
        public new int UniqueId { get; set; }
    }
}
