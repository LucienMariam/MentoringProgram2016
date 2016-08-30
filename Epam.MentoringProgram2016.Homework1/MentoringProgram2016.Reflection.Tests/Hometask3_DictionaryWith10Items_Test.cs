using System;
using System.Collections.Generic;
using Mentoring2016.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MentoringProgram2016.Reflection.Tests
{
    [TestClass]
    public class Hometask3_DictionaryWithMaxNumberOfItemsItems_Test
    {
        private const int MaxNumberOfItems = 10;

        private bool DefineIfTypesMayHaveInstance(Type key, Type value)
        {
            if (key.IsAbstract || key.IsInterface || value.IsAbstract || value.IsInterface || key.IsEnum)
            {
                return false;
            }

            return true;
        }

        private void AddMaxNumberOfItemsItemsToDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey[] arrayOfValues = null)
        {
            if (dictionary != null)
            {
                TKey key = default(TKey);
                TValue value = default(TValue);

                if (arrayOfValues == null)
                {
                   for (int i = 0; i < MaxNumberOfItems; i++)
                    {
                        key = (TKey)Activator.CreateInstance(typeof(TKey));
                        dictionary.Add(key, value);
                    }
                }
                else
                {
                    for (int i = 0; i < MaxNumberOfItems; i++)
                    {
                        key = arrayOfValues[i];
                        dictionary.Add(key, value);
                    }
                } 
            }
        }

        private Dictionary<TKey, TValue> ComposeDictionaryWithMaxNumberOfItemsItemsDynamically<TKey, TValue>(TKey[] arrayOfValues = null) 
        {
            var dictionaryCreator = new DictionaryReflectionCreator<TKey, TValue>();
            Dictionary<TKey, TValue> dictionary = dictionaryCreator.CreateDictionary();
            Type[] genericType = dictionary.GetType().GetGenericArguments();

            if (DefineIfTypesMayHaveInstance(genericType[0], genericType[1]))
            {
                AddMaxNumberOfItemsItemsToDictionary(dictionary, arrayOfValues);
            }
            return dictionary;
        }

        private int ReturnNumberOfDictionaryItems<TKey, TValue>(TKey[] arrayOfValues = null)
        {
            return ComposeDictionaryWithMaxNumberOfItemsItemsDynamically<TKey, TValue>(arrayOfValues).Count;
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsInterface_AndValueTypeIsValueType()
        {
            int actual = ReturnNumberOfDictionaryItems<Interface, int>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsInterface_AndValueTypeIsInterface()
        {
            int actual = ReturnNumberOfDictionaryItems<Interface, Interface>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_HasMaxNumberOfItemsItems_IfKeyTypeIsValueType_AndValueTypeIsValueType()
        {
            int[] arrayOfItems = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int actual = ReturnNumberOfDictionaryItems<int, int>(arrayOfItems);
            int expected = MaxNumberOfItems;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsAbstractClass_AndValueTypeIsAbstractClass()
        {
            int actual = ReturnNumberOfDictionaryItems<AbstractClass, AbstractClass>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsValueType_AndValueTypeIsAbstractClass()
        {
            int actual = ReturnNumberOfDictionaryItems<int, AbstractClass>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_HasMaxNumberOfItemsItems_IfKeyTypeIsStruct_AndValueTypeIsStruct()
        {
            Structure[] arrayOfItems = new Structure[MaxNumberOfItems];

            for (int i = 0; i < MaxNumberOfItems; i++)
            {
                arrayOfItems[i].UniqueId = i;
            }

            int actual = ReturnNumberOfDictionaryItems<Structure, Structure>(arrayOfItems);
            int expected = MaxNumberOfItems;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsAbstract_AndValueTypeIsStruct()
        {
            int actual = ReturnNumberOfDictionaryItems<Interface, Structure>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsStruct_AndValueTypeIsAbstract()
        {
            int actual = ReturnNumberOfDictionaryItems<Structure, Interface>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsEnum_AndValueTypeIsAbstract()
        {
            int actual = ReturnNumberOfDictionaryItems<Enumeration, Interface>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsAbstract_AndValueTypeIsEnum()
        {
            int actual = ReturnNumberOfDictionaryItems<Interface, Enumeration>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_IsEmpty_IfKeyTypeIsEnum_AndValueTypeIsEnum()
        {
            int actual = ReturnNumberOfDictionaryItems<Enumeration, Enumeration>();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_HasMaxNumberOfItemsItems_IfKeyTypeIsClass_AndValueTypeIsClass()
        {
            int actual = ReturnNumberOfDictionaryItems<Class, Class>();
            int expected = MaxNumberOfItems;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDictionary_HasMaxNumberOfItemsItems_IfKeyTypeIsString_AndValueTypeIsString()
        {
            string[] arrayOfItems = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            int actual = ReturnNumberOfDictionaryItems<string, string>(arrayOfItems);
            int expected = MaxNumberOfItems;

            Assert.AreEqual(expected, actual);
        }
    }
}
