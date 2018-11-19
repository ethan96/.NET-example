using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_waitall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("開始執行一堆工作 ...id:" + Thread.CurrentThread.ManagedThreadId);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            Task[] manyTasks = new Task[] {
                 Task.Run (()=>{
                    Thread.Sleep(5000);
                     Console.WriteLine("task 1 ...id:" + Thread.CurrentThread.ManagedThreadId);
                }),
                Task.Run (()=>{
                        Thread.Sleep(500);
                        Console.WriteLine("task 2 ...id:" + Thread.CurrentThread.ManagedThreadId);
                })
            };
            Console.WriteLine("before Wait All ");
            Task.WaitAll(manyTasks);
            watch.Stop();
            Console.WriteLine("Wait All - complete, time: {0}", watch.Elapsed.ToString("ss"));
            Console.Read();


            //Console.WriteLine("開始執行一堆工作 ...id:" + Thread.CurrentThread.ManagedThreadId);

            //Task[] manyTasks = new Task[] {
            //     Task.Run (()=>{
            //        Thread.Sleep(2000);
            //         Console.WriteLine("task 1 ...id:" + Thread.CurrentThread.ManagedThreadId);
            //    }),
            //    Task.Run (()=>{
            //            Thread.Sleep(500);
            //            Console.WriteLine("task 2 ...id:" + Thread.CurrentThread.ManagedThreadId);
            //    })
            //};
            //Console.WriteLine("before Wait Any ");
            //Task.WaitAny(manyTasks);
            //Console.WriteLine("Wait Any - complete");
            //Console.Read();
        }
    }
}
