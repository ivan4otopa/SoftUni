using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsynchronousTimer.Classes;

namespace AsynchronousTimer
{
    class AsynchronousTimerTest
    {
        static void Main(string[] args)
        {
            Action<int> test = (number) => Console.WriteLine("{0}", number);

            AsyncTimer asyncTimer = new AsyncTimer(test, 10, 1000);

            asyncTimer.Run();
        }
    }
}
