using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Environment.CurrentDirectory;
            Console.WriteLine("目前資料夾為: " + currentDir);

            string newDir = Path.Combine(currentDir + "\\txt");
            //Console.WriteLine(newDir);

            if (!Directory.Exists(newDir))
            {
                DirectoryInfo dinfo = Directory.CreateDirectory(newDir);
                Console.WriteLine("建立資料夾:" + newDir);
            }

            string filepath = Path.Combine(newDir, "myCourse.txt");

            if (File.Exists(filepath))
            {
                Console.WriteLine("檔案已存在，即將被覆蓋");
            }

            string[] myCourses = { "Visual Basic", "Visual C#", "ASP.NET", "jQuery", "jQuery Mobile" };

            File.WriteAllLines(filepath, myCourses);
            foreach (var course in File.ReadAllLines(filepath))
            {
                Console.WriteLine(course);
            }
            Console.ReadLine();
        }
    }
}
