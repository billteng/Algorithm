using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo1
{
    /// <summary>
    /// Oct 5, 2014
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            /* Creating a new Thread object creates a new managed thread.
             * The Thread class has constructors that take a ThreadStart delegate
             * or a ParameterizedThreadStart delegate; the delegate wraps the 
             * method that is invoked by the new thread when you call the Start method. 
             * Calling Start more than once causes a ThreadStateException to be thrown.
             * 
             * The Start method returns immediately, often before the new thread 
             * has actually started. You can use the ThreadState and IsAlive properties 
             * to determine the state of the thread at any one moment, but these 
             * properties should never be used for synchronizing the activities of threads.
             */
            #region Creating a Thread with ThreadStart Delegate

            ServerClass serverObject = new ServerClass();

            // Create the thread object, passing in the 
            // serverObject.InstanceMethod method using a 
            // ThreadStart delegate.
            Thread InstanceCaller = new Thread(
                new ThreadStart(serverObject.InstanceMethod));

            // Start the thread.
            InstanceCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");

            // Create the thread object, passing in the 
            // serverObject.StaticMethod method using a 
            // ThreadStart delegate.
            Thread StaticCaller = new Thread(
                new ThreadStart(ServerClass.StaticMethod));

            // Start the thread.
            StaticCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new StaticCaller thread.");

            #endregion

            /* In the .NET Framework version 2.0, the ParameterizedThreadStart delegate 
             * provides an easy way to pass an object containing data to a thread when you 
             * call the Thread.Start method overload. See ParameterizedThreadStart 
             * for a code example.

             * Using the ParameterizedThreadStart delegate is not a type-safe way to 
             * pass data, because the Thread.Start method overload accepts any object. An 
             * alternative is to encapsulate the thread procedure and the data in a helper 
             * class and use the ThreadStart delegate to execute the thread procedure. 
             * This technique is shown in the two code examples that follow.

             * Neither of these delegates has a return value, because there is no place to
             * return the data from an asynchronous call. To retrieve the results of a thread
             * method, you can use a callback method, as demonstrated in the second code example.
             */
            #region Passing Data to Threads and Retrieving Data from Threads
            // Supply the state information required by the task.
            ThreadWithState tws = new ThreadWithState(
                "This report displays the number {0}.", 88,
                 new ExampleCallback(ResultCallback));

            // Create a thread to execute the task, and then 
            // start the thread.
            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            
            t.Join();
            // Blocks the calling thread until a thread terminates.

            Console.WriteLine(
                "Independent task has completed; main thread ends.");
            #endregion


            // For it to close when someone presses any key.
            Console.ReadKey();

            // For when the user types something and presses enter.
            // Console.ReadLine();

        }

        // The callback method must match the signature of the 
        // callback delegate. 
        // 
        public static void ResultCallback(int lineCount)
        {
            Console.WriteLine(
                "Independent task printed {0} lines.", lineCount);
        }
    }
}
