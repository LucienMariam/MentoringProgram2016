using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.MentoringProgram2016.Homework1;

namespace Epam.MentoringProgram2016.HW1.Tests
{
    [TestClass]
    public class StrangeNumberGeneratorTest
    {
        [TestMethod]
        public void Array_2_3_5_7_MustBeProcessedAsOutput_6()
        {
            int[] sampleArray = { 2, 3, 5, 7 };
            var generator = new StrangeNumberGenerator(sampleArray);

            Assert.AreEqual(6, generator.GenerateStrangeNumber());
        }

        [TestMethod]
        public void Array_2_3_6_8_MustBeProcessedAsOutput_7()
        {
            int[] sampleArray = { 2, 3, 6, 8 };
            var generator = new StrangeNumberGenerator(sampleArray);

            Assert.AreEqual(7, generator.GenerateStrangeNumber());
        }

        [TestMethod]
        public void Array_2_4_6_12_MustBeProcessedAsOutput_9()
        {
            int[] sampleArray = { 2, 4, 6, 12 };
            var generator = new StrangeNumberGenerator(sampleArray);

            Assert.AreEqual(9, generator.GenerateStrangeNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowExceptionIfArrayIsEmpty()
        {
            int[] sampleArray = null;
            var generator = new StrangeNumberGenerator(sampleArray);
        }
    }
}
