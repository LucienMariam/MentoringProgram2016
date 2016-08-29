using System;

namespace Mentoring2016.Reflection
{
    public class Friday13Manager
    {
        public event Func<int> Friday13;

        public int? RaiseEvent()
        {
            return Friday13?.Invoke();
        }
    }

    public class Friday13Handler
    {
        public int ReturnDayOfTheFriday13()
        {
            return 13;
        }
    }
}
