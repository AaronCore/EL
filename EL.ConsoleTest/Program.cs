using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace EL.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = new DirectoryInfo(@"..\..\..\..").FullName;
            var ss = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase("aaron");

            Console.WriteLine(ss);
            Console.ReadKey();
        }
    }
}
