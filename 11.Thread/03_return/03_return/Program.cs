using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_return
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<bool> taskIsAM = Task.Run<bool>(() =>
            {
                Thread.Sleep(2000);
                return DateTime.Now.Hour < 12;
            });
            Console.WriteLine("現在是: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("waiting result ....");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Is AM?" + taskIsAM.Result);
            watch.Stop();
            Console.WriteLine("finish, spent time: {0}", watch.Elapsed.TotalSeconds);
            Console.Read();

            //Task<string> taskIsAM = Task.Run<string>(() =>
            //{
            //    Thread.Sleep(2000);
            //    return DateTime.Now.ToString();
            //});
            //Console.WriteLine("現在是: " + DateTime.Now.ToLongTimeString());
            //Console.WriteLine("waiting result ....");
            //Console.WriteLine("What time is it?" + taskIsAM.Result);
            //Console.WriteLine("finish");
            //Console.Read();
        }
    }
}
