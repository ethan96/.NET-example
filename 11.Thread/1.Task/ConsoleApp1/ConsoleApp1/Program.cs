using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task myTask = new Task(() => 
            //{
            //    Console.WriteLine("Lambda, id:" + Thread.CurrentThread.ManagedThreadId);
            //});

            //Task myTask = new Task(() => Test());

            //Console.WriteLine("LINQ, id: " + Thread.CurrentThread.ManagedThreadId);

            //myTask.Start();

            Task ma = new Task(() => CallMA());
            ma.Start();
            Console.WriteLine("Do something.....");
            Console.ReadLine();
        }

        public static void Test()
        {
            Console.WriteLine("Lambda, id:" + Thread.CurrentThread.ManagedThreadId);
        }

        public static void CallMA()
        {
            MAMigration.MAMigration m = new MAMigration.MAMigration();
            string msg = m.HelloKiity();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(msg);
        }
    }
}
