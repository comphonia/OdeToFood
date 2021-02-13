using System;

namespace OdeToFood.Data
{
    public class Test
    {
        public Guid Counter;

        public Test()
        {
            Counter = Guid.NewGuid();
        }

        public Guid GetGuid => Counter;

    }
}
