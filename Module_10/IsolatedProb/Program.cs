using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IsolatedProb
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Synchronous();
            //AsynchronousOldStyle();
            //AsynchronousModern();
            //ChainingTasks();
            //ExceptionMisery();
            //MoreAwait();
            //MultipleTasks();
            //CancellationTokenSource nikko = new CancellationTokenSource();
            //CancellingTasks(nikko.Token);
            //Console.ReadLine();
            //nikko.Cancel();
            //ParallelDemo();
            //ConcurrentIssues();

            Semaphore sem = new Semaphore(10, 10);
            Parallel.For(0, 50, idx => {
                Console.WriteLine($"{idx} is waiting");
                sem.WaitOne();
                Console.WriteLine($"{idx} goes in");
                Task.Delay(9000).Wait();
                sem.Release();
                Console.WriteLine($"{idx} goes out");
            });

            // Warning!!!! Be aware of .Wait() and .Result in combiniation with async and await!!!
            // They're both blocking statement
            // Task.WaitAll() and Task.WaitAny()    also blocking. Use WhenAll() and WhenAny() instead

            Console.WriteLine("End Main Thread");
            Console.ReadLine();
        }

        static object stick = new object();
        private static void ConcurrentIssues()
        {
            List<int> list = new List<int>(); /// Not thread safe
            ConcurrentBag<int> bag = new ConcurrentBag<int>();  // Thread safe
            
            int number = 0;

            Parallel.For(0, 10, idx => {
                lock (stick)
                {
                    int nr = number;
                    Task.Delay(1000).Wait();
                    nr++;
                    number = nr;
                }
            });

            Console.WriteLine(number);

        }

        private static void ParallelDemo()
        {
            //Parallel.For(0, 100, idx => {
            //    Task.Delay(10000).Wait();
            //    Console.WriteLine($"Task {idx}");
            //});
            for (int i = 0; i < 100; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(10000);
                    Console.WriteLine($"Task");
                });
            }
            Console.WriteLine("Done");

        }

        private static void CancellingTasks(CancellationToken terminator)
        {
           
            Task.Run(() => {
                do
                {
                    Task.Delay(500).Wait();
                    Console.WriteLine("Complete");
                    if (terminator.IsCancellationRequested)
                    {
                        return;
                    }
                }
                while (true);
            });


        }

        private static async void MultipleTasks()
        {
            Task[] tasks = new Task[10];

            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Task.Delay(1000).Wait();
                    Console.WriteLine($"Running task {i}");
                    
                });
            }
            await Task.WhenAny(tasks);
            Console.WriteLine("And Continue");

        }

        private static async Task MoreAwait()
        {
            await Task.Run(() => Console.WriteLine("T1"));
            Console.WriteLine("Finished T1");
            await Task.Delay(1000);
            await Task.Run(() => Console.WriteLine("T2"));
            Console.WriteLine("Finished T2");
            await Task.Delay(1000);
            await Task.Run(() => Console.WriteLine("T3"));
            Console.WriteLine("Finished T3");
            await Task.Delay(1000);
            await Task.Run(() => Console.WriteLine("T4"));
            Console.WriteLine("Finished T4");

        }

        private static async Task ExceptionMisery()
        {
            Task.Run(() =>
            {
                Console.WriteLine("Something");
                throw new Exception("oops");
            }).ContinueWith(pt => { 
                if (pt.Exception != null)
                {
                    Console.WriteLine(pt.Exception.InnerException.Message);
                }
            });

            try
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Something");
                    throw new Exception("oops");
                });
             }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ChainingTasks()
        {
            Task<int> t1 = new Task<int>(() => {
                Console.WriteLine("Task 1");
                return 42;
            });
            t1.ContinueWith(pt =>
            {
                Console.WriteLine("Task 2");
                Console.WriteLine(pt.Result);
            });
            t1.ContinueWith(pt => {
                Console.WriteLine("Task 3");
                Console.WriteLine(pt.Result);
            });

            t1.Start();
        }

        private static async Task AsynchronousModern()
        {
            //Task<int> t1 = new Task<int>(() => SpecialAdd(5, 6));
            //t1.Start();

            //Task<int> t1 = Task.Run<int>(() => SpecialAdd(7, 8));
            //int res = await t1;  // return;

            int res = await SpecialAddAsync(9, 10);
            Console.WriteLine("Ah. Task is ready. Now we continue with this function");
            Console.WriteLine(res);
        }

        private static void AsynchronousOldStyle()
        {
            Func<int, int, int> del = SpecialAdd;
            IAsyncResult ar = del.BeginInvoke(2, 3, ares=> {
                int res = del.EndInvoke(ares);
                Console.WriteLine(res);
            }, null);


            //while(!ar.iscompleted)
            //{
            //    console.write(".");
            //    task.delay(100).wait();
            //}           
        }

        private static void Synchronous()
        {
            int res = SpecialAdd(3, 4);
            Console.WriteLine(res);
        }

        static int SpecialAdd(int a, int b)
        {
            Task.Delay(5000).Wait();
            return a + b;
        }
        static  Task<int> SpecialAddAsync(int a, int b)
        {
            return Task.Run<int>(() => SpecialAdd(a, b));
        }
    }
}
