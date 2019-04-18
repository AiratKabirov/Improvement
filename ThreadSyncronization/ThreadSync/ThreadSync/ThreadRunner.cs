using System;
using System.Linq;
using System.Threading;

namespace ThreadSync
{
    public class ThreadRunner
    {
        ManualResetEvent manual = new ManualResetEvent(false);
        AutoResetEvent auto = new AutoResetEvent(false);

        public ThreadRunner(int i)
        {
            var range = Enumerable.Range(1, i);
            range.ToList().ForEach(num =>
            {
                new Thread(new ParameterizedThreadStart(Work)).Start(num);
                Thread.Sleep(10);
            });
        }

        private void Work(object i)
        {
            var threadNum =(int)i;
            switch(i)
            {
                case 1:
                    Console.WriteLine("Thread 1 started");
                    Thread.Sleep(100);
                    Console.WriteLine("Thread 1 set signal");
                    manual.Set();
                    Thread.Sleep(50);
                    Console.WriteLine("Thread 1 reset signal");
                    manual.Reset();
                    break;
                case 2:
                    Console.WriteLine("Thread 2 started");
                    Thread.Sleep(50);
                    Console.WriteLine("Thread 2 set signal");
                    auto.Set();
                    Thread.Sleep(100);
                    Console.WriteLine("Thread 2 set signal");
                    auto.Set();
                    Thread.Sleep(50);
                    break;
                case 3:
                    Console.WriteLine("Thread 3 is waiting for manual signal from Thread 1");
                    manual.WaitOne();
                    Console.WriteLine("Thread 3 received manual signal, continue working");
                    break;
                case 4:
                    Console.WriteLine("Thread 4 is waiting for manual signal from Thread 1");
                    manual.WaitOne();
                    Thread.Sleep(5);
                    Console.WriteLine("Thread 4 received manual signal, continue working");
                    break;
                case 5:
                    Console.WriteLine("Thread 5 is waiting for auto signal from Thread 2");
                    auto.WaitOne();
                    Console.WriteLine("Thread 5 received auto signal, continue working");
                    break;
                case 6:
                    Console.WriteLine("Thread 6 is waiting for auto signal from Thread 2");
                    auto.WaitOne();
                    Console.WriteLine("Thread 6 received auto signal, continue working");
                    break;
            }
        }
    }
}
