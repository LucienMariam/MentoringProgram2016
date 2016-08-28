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

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsInterface()
        {
            var interfaceListCreator = new ListTReflectionCreator<Interface>();
            List<Interface> list = interfaceListCreator.CreateList();
            var testClass = new Class();
            Interface elementToAdd = testClass;
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, elementToAdd);
            }

            int actual = list.Count;  // что быстрее тут отработает Count или Any() ? Ответ: если не предстоит связываться с Итератором, то Count быстрее.
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsAbstractClass()
        {
            var interfaceListCreator = new ListTReflectionCreator<AbstractClass>();
            List<AbstractClass> list = interfaceListCreator.CreateList();
            var testClass = new Class();
            AbstractClass elementToAdd = testClass;
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, elementToAdd);
            }

            int actual = list.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsStruct()
        {
            var interfaceListCreator = new ListTReflectionCreator<Structure>();
            List<Structure> list = interfaceListCreator.CreateList();
            Structure itemToAdd;
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, itemToAdd);
            }

            int actual = list.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsEnum()
        {
            var interfaceListCreator = new ListTReflectionCreator<Enumeration>();
            List<Enumeration> list = interfaceListCreator.CreateList();
            var itemToAdd = new Enumeration();
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, itemToAdd);
            }

            int actual = list.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsClass()
        {
            var interfaceListCreator = new ListTReflectionCreator<Class>();
            List<Class> list = interfaceListCreator.CreateList();
            var itemToAdd = new Class();
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, itemToAdd);
            }

            int actual = list.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsInt()
        {
            var interfaceListCreator = new ListTReflectionCreator<int>();
            List<int> list = interfaceListCreator.CreateList();
            int itemToAdd = 0;
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, itemToAdd);
            }

            int actual = list.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestList_IsEmpty_IfElementTypeIsString()
        {
            var interfaceListCreator = new ListTReflectionCreator<string>();
            List<string> list = interfaceListCreator.CreateList();
            string itemToAdd = "";
            Type[] genericType = list.GetType().GetGenericArguments();

            if (DefineIfTypeMayHaveInstance(genericType[0]))
            {
                Add5ElementsToList(list, itemToAdd);
            }

            int actual = list.Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }
    }
}