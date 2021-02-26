using System;

namespace Business.CCS
{
    class DatabaseLoger : ILoger
    {
        public void Log()
        {
            Console.WriteLine("Veri Tabanına Loglandı.");
        }

    }
}