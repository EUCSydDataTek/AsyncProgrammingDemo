// a. SimpleTask.cs

using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);                      // Kick off a new thread
            t.Start();                                          // running WriteY()

            for (int i = 0; i < 10000; i++) Console.Write("x"); // Simultaneously, do something on the main thread.
        }

        static void WriteY()
        {
            for (int i = 0; i < 10000; i++) Console.Write("y");
        }
    }
}