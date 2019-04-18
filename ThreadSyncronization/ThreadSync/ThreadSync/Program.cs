using System;
using System.Threading;

namespace ThreadSync
{
    class Program
    {
        static Mutex globalMutex;

        static bool IsSingleInstance()
        {
            try
            {
                // Try to open existing mutex.
                Mutex.OpenExisting("ThreadSync");
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                Program.globalMutex = new Mutex(true, "ThreadSync");

                // Only one instance.
                return true;
            }
            // More than one instance.
            return false;
        }

        static void Main()
        {
            if (!Program.IsSingleInstance())
            {
                Console.WriteLine("More than one instance"); // Exit program.
            }
            else
            {
                Console.WriteLine("One instance"); // Continue with program.
                ThreadRunner tR = new ThreadRunner(6);
            }

            globalMutex.ReleaseMutex();
            globalMutex.Dispose();
            Console.ReadLine();
        }
    }
}

