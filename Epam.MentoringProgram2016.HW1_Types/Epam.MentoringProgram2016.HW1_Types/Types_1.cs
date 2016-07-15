using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MentoringProgram2016.HW1_Types
{
    struct InfoData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Source
    {
        internal void CheckAndProceed(List<InfoData> data)
        {
            var dest = new Destination();

            //do something

            dest.ProceedData(data);
        }
    }

    class Destination
    {
        internal void ProceedData(List<InfoData> data)
        {
            foreach (var item in data)
            {
                //do something
            }
        }
    }
}
