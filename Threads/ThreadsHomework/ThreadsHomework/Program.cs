using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var DJ = new DJ();
            var dancers = new List<Dancer>();
            for (int i = 0; i < 20; i++)
            {
                dancers.Add(new Dancer(i.ToString()));
            }

            DJ.Start();
            dancers.ForEach(d => d.Start());

            Console.WriteLine("End of main");
        }
    }
}
