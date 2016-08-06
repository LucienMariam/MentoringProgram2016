using System;
using System.Text;


namespace Epam.MentoringProgram2016.Homework1.BCL
{
    public static class BCL_CharConcatination
    {
        public static string GetEachSecondCharInConcatinatedString(string[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            var resultString = new StringBuilder();

            for (int i = 1; i < array.Length; i+=2)
            {
                if(array[i] != null)
                    resultString.AppendLine(array[i]);
            }

            return resultString.ToString();
        }
    }
}
