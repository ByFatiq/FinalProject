using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    class FileLoger : ILoger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya Loglandı.");
        }
    }
}
