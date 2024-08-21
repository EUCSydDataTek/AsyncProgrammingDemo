// b. SeparateMemoryStack.cs
namespace ThreadDemo
{
    class SeperateMemoryStack
    {
        static void Main(string[] args)
        {
            new Thread(Go).Start();       // Call Go() on a new thread
            Go();                         // Call Go() on the main thread
        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }
    }
}