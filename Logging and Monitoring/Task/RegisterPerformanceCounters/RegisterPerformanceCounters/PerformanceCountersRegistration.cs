using System;
using System.Diagnostics;


namespace RegisterPerformanceCounters
{
    public class PerformanceCountersRegistration
    {
        private const string CategoryName = "High Category";
        private const string CounterName = "PerformoCounter";
        private const string LoginCounterHelp = "Counts the successful Login attempts";

        static void Main(string[] args)
        {
            if (!PerformanceCounterCategory.Exists(CategoryName))
            {
                var counterDataCollection = new CounterCreationDataCollection();
                var loginCounter = new CounterCreationData(CounterName, LoginCounterHelp,
                    PerformanceCounterType.NumberOfItems32);

                counterDataCollection.Add(loginCounter);

                try
                {
                    PerformanceCounterCategory.Create(CategoryName, "", PerformanceCounterCategoryType.MultiInstance,
                        counterDataCollection);
                }
                catch (UnauthorizedAccessException)
                {
                   Console.WriteLine("Do not have permissions");
                   Console.ReadKey();
                }
                Console.WriteLine("Category created");
                Console.ReadKey();
            }
        }
    }
}
