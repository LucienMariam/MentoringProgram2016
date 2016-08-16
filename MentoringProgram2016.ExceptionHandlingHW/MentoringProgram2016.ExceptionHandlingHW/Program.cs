using System;
using System.Linq;

namespace MentoringProgram2016.ExceptionHandlingHW
{
    class Program
    {
        static void Main(string[] args)
        {
            const string WordToStopInput = "1111";
            string inputString;

            do
            {
                inputString = Console.ReadLine();
                try
                {
                    Console.WriteLine(inputString.First());
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("The string is empty");
                }
            } while (inputString != WordToStopInput);
        }
    }
}
