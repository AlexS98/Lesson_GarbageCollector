using System;
using System.IO;
using System.Linq;

namespace Lesson_GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //put example.txt into Lesson_GarbageCollector\bin\Debug\netcoreapp2.2, data separator - ';'
            using (var streamReader = new StreamReader("example.txt"))
            {
                streamReader
                    .ReadToEnd()
                    .Split(';')
                    .ToList()
                    .Select(x => long.TryParse(x, out long l) ? new TestClass(l) : null)
                    .Where(x => x != null)
                    .ToList()
                    .ForEach(x => x.Dispose());
            }

            for (int i = 0; i < 200000; i++)
            {
                var test = new TestClass(i);
            }
            Console.WriteLine($"\n Total finalized - {FinalizingInfo.Total}");
        }
    }
}
