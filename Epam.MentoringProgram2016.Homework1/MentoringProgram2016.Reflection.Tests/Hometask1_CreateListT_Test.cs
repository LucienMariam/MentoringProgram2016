using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mentoring2016.Reflection;

namespace MentoringProgram2016.Reflection.Tests
{
    [TestClass]
    public class Hometask1_CreateListT_Test
    {
        private bool DefineIfTypeMayHaveInstance(Type listElement)
        {
            if (listElement.IsAbstract || listElement.IsInterface)
            {
                return false;
            }

            return true;
        }

        private void Add5ElementsToList<T>(List<T> list, T elementToAdd)
        {
            if (list != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(elementToAdd);
                }              
            }
        }

        private List<T> ComposeListTWith5ItemsDynamically<T>()
        {
            var interfaceListCreator = new ListTReflectionCreator<T>();
            List<T> list = interfaceListCreator.CreateList();
            T elementToAdd = default(T);
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, elementToAdd);
            }
            return list;
        } 

        private int ReturnNumberOfListTElements<T>()
        {
            return ComposeListTWith5ItemsDynamically<T>().Count; // что быстрее тут отработает Count или Any() ? Ответ: если не предстоит связываться с Итератором, то Count быстрее.
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsInterface()
        {
            int actual = ReturnNumberOfListTElements<Interface>();  
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsAbstractClass()
        {
            int actual = ReturnNumberOfListTElements<AbstractClass>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_Has5Items_IfElementTypeIsStruct()
        {
            int actual = ReturnNumberOfListTElements<Structure>();
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_Has5Items_IfElementTypeIsEnum()
        {
            int actual = ReturnNumberOfListTElements<Enumeration>();
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_Has5Items_IfElementTypeIsClass()
        {
            int actual = ReturnNumberOfListTElements<Class>();
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_Has5Items_IfElementTypeIsInt()
        {
            int actual = ReturnNumberOfListTElements<int>();
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_Has5Items_IfElementTypeIsString()
        {
            int actual = ReturnNumberOfListTElements<string>();
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }
    }
}