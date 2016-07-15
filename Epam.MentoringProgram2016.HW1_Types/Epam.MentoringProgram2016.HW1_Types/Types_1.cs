using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// У вас  есть два класса Source и Destination. Между классами передается структура InfoData, содержащая данные о пользователе.
// Попытайтесь разорвать связь между классами через InfoData (класс Destination ничего не должен знать об этом типе)
// Оптимизируйте работу с точки зрения быстродействия.

namespace Epam.MentoringProgram2016.HW1_Types
{
    struct InfoData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class Source
    {
        internal static void CheckAndProceed<T>(List<T> data) where T: struct
        {
            //do something

            Destination.ProceedData(data);
        }
    }

    public static class Destination
    {
        internal static void ProceedData<T>(List<T> data) where T: struct
        {
            foreach (var item in data)
            {
                //do something
            }
        }
    }
}
