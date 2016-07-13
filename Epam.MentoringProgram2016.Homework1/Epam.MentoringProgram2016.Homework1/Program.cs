using System;
using System.Diagnostics;

//We need to create a code for generate a N-length list of simple number, this list will be start with 2. After the list has been generated, we need to get sum all elements of this list divided by index of this element+1 and we need to get integer part of this sum, method Math.Floor()
//An example:
//List for 4 elements: 2, 3, 5, 7.
//Result: Math.Floor( 2/1 + 3/2 + 5/3 + 7/4) = Math.Floor(6.916666666666667) = 6

namespace Epam.MentoringProgram2016.Homework1
{
    class Program
    {
        static void Main()
        {
            var filler = new ArrayFiller();
            var generator = new StrangeNumberGenerator(filler.GetArray(4));
            Debug.WriteLine("==== {0} ====", generator.GenerateStrangeNumber());
        }
    }


    public class ArrayFiller
    {
        public int[] GetArray(int arrLength)
        {
            int[] array = new int[arrLength];
            var generator = new Random(DateTime.Now.Second);

            array[0] = 2;
            int lastSequenceNumber = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = generator.Next(lastSequenceNumber + 1, lastSequenceNumber * 2 + 1);
                lastSequenceNumber = array[i];
            }

            return array;
        }
    }

    public class StrangeNumberGenerator
    {
        private int[] array;
        public int[] Array
        {
            get
            {
                return array;
            }

            set
            {
                if (value.Length > 0)
                    array = value;

                else throw new MemberAccessException();
            }
        }

        public StrangeNumberGenerator(int[] array)
        {
            Array = array;
        }

        public int GenerateStrangeNumber()
        {
            double sumAccumulator = array[0];

            for (int i = 1; i < array.Length; i++)
                sumAccumulator += array[i] / (i + 1.0);


            for (int i = 0; i < array.Length; i++)
                Debug.WriteLine(array[i]);

            Debug.WriteLine("==== {0} ====", sumAccumulator);

            return Convert.ToInt32(Math.Floor(sumAccumulator));
        }
    }
}