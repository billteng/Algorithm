using System;
using System.Threading;

namespace Thread_Demo1
{
    public class ServerClass
    {
        // The method that will be called when the thread is started. 
        public void InstanceMethod()
        {
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");

            // Pause for a moment to provide a delay to make 
            // threads more apparent.
            Thread.Sleep(3000);
            Console.WriteLine(
                "The instance method called by the worker thread has ended.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine(
                "ServerClass.StaticMethod is running on another thread.");

            // Pause for a moment to provide a delay to make 
            // threads more apparent.
            Thread.Sleep(6000);
            Console.WriteLine(
                "The static method called by the worker thread has ended.");
        }
    }
}
