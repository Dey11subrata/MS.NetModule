using System.Diagnostics;

namespace Threading
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            /*  Stopwatch sw = new Stopwatch();*/

            Thread t1 = new Thread(new ThreadStart(Fun1));
            Thread t2 = new Thread(Fun2);
            t1.Start();
            t2.Start();
            //Fun1();
            //Fun2();
            for(int i=0; i<1000; i++)
            {
                Console.WriteLine("Main:"+i);
            }
            /*sw.Stop();
            Console.WriteLine("total time taken:"+sw.ElapsedMilliseconds);*/
            
        }

        static void Main2(string[] args)
        {
            /*  Stopwatch sw = new Stopwatch();*/
            // settting prioroty using threadpriority
            Thread t1 = new Thread(new ThreadStart(Fun1));
            Thread t2 = new Thread(Fun2);
            t1.Priority= ThreadPriority.Lowest;
            t2.Priority= ThreadPriority.Highest;
            t1.Start();
            t2.Start();
            //Fun1();
            //Fun2();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main:" + i);
            }
            /*sw.Stop();
            Console.WriteLine("total time taken:"+sw.ElapsedMilliseconds);*/

        }

        static void Main(string[] args)
        {
            /*  Stopwatch sw = new Stopwatch();*/
            // settting prioroty using threadpriority
            Thread t1 = new Thread(new ThreadStart(Fun1));
            Thread t2 = new Thread(Fun2);
            
            t1.Start();
            //t2.Start();
            //Fun1();
            //Fun2();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main:" + i);
            }

            // suppose there is some code which have to execute afrer t1 finish, then it must be gauranteed that untill t1 finished main would not execute that part. use Join in that case: have a look below.
            t1.Join(); // i.e main thread will wait till t1 finish, once t1 got finished main would resume it's execution.
            Console.WriteLine("code to be executed after t1 finish");
            /*sw.Stop();
            Console.WriteLine("total time taken:"+sw.ElapsedMilliseconds);*/

        }
        static void Fun1()
        {
            for(int i=0;i<1000; i++)
            {
                Console.WriteLine("Fun1:-"+i);
            }
        }static void Fun2()
        {
            for(int i=0;i<1000; i++)
            {
                Console.WriteLine("Fun2:-"+i);
            }
        }
    }
}