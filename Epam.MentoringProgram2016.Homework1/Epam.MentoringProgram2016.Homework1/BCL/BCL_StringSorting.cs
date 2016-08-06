using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.MentoringProgram2016.Homework1.BCL
{
    public class BCL_StringSorting
    {
        private readonly List<string> _array;

        public BCL_StringSorting(string[] array)
        {
            if (array == null || array.Contains(null))
                throw new ArgumentNullException();
            
            _array = new List<string>(array);
        }

        public string[] AlphabeticSorting()
        {
            string temp;

            for (int i = 0; i < _array.Count; i++)
            {
                for (int j = i + 1; j < _array.Count; j++)
                {
                    if (string.Compare(_array[i], _array[j], StringComparison.Ordinal) > 0)
                    {
                        temp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = temp;
                    }
                }
            }

            return _array.ToArray();
        }
    }
}
