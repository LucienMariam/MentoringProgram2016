using System;

namespace Mentoring2016.Reflection
{
    public class Friday13Manager
    {
        public event Func<int> Friday13;
    }

    public class Friday13Handler
    {
        public int ReturnDayOfTheFriday13()
        {
            return 13;
        }
    }
}
