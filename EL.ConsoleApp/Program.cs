using System;
using System.IO;

namespace EL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = new DirectoryInfo(@"..\..\..\..").FullName;

            var str2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase("aaron");

            Console.WriteLine(str2);
            Console.ReadKey();
        }
    }
}
