using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mentoring2016.Reflection;

namespace MentoringProgram2016.Reflection.Tests
{
    [TestClass]
    public class Hometask2_AddHandlerToClassEvent_Test
    {
        [TestMethod]
        public void SomeMethod()
        {
            var friday13EventManager = new Friday13Manager();
            var friday13Handler = new Friday13Handler();
            EventInfo eventInfo = friday13EventManager.GetType().GetEvent("Friday13");
            Func<int> dateGetter = () => friday13Handler.ReturnDayOfTheFriday13();
            
            eventInfo.AddEventHandler(friday13EventManager, dateGetter);

            int actual = (int)friday13EventManager.RaiseEvent();
            int expected = 13;
            
            Assert.AreEqual(expected, actual);
        }
    }
}
