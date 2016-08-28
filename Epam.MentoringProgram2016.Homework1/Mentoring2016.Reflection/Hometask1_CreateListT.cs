using System;
using System.Collections.Generic;

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
        
    }

    public abstract class AbstractClass: Interface
    {
        
    }

    public struct Structure
    {
        
    }

    public enum Enumeration
    {
        
    }

    public class Class: AbstractClass
    {
        
    }
}
