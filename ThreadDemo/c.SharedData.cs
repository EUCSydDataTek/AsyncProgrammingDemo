// c. SharedData.cs
namespace ThreadDemo
{
    public class SharedData
    {
        static bool done = false;    // Static fields are shared between all threads

        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done");
                //done = true;
            }
        }
    }
}