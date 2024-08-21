// d. LockData.cs

namespace ThreadDemo
{
    public class LockData
    {
        static bool done;
        static readonly object locker = new object();

        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done");
                    done = true;
                }
            }
        }
    }
}