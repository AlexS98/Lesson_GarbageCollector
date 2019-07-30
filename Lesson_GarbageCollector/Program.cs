using System;
using System.IO;
using System.Linq;

namespace Lesson_GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("example.txt"))
            {
                Console.WriteLine(
                    streamReader
                        .ReadToEnd()
                        .Split(';')
                        .ToList()
                        .Select(x => long.TryParse(x, out long l) ? l : 0)
                        .Sum()
                    );
            }

            for (int i = 0; i < 200000; i++)
            {
                var test = new TestClass(i);
            }
        }
    }
}
