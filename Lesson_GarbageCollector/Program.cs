using System;
using System.IO;
using System.Linq;

namespace Lesson_GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //put example.txt into Lesson_GarbageCollector\bin\Debug\netcoreapp2.2
            //data separator - ';'
            using (var streamReader = new StreamReader("example.txt"))
            {
                var startMemory = GC.GetTotalMemory(true);
                streamReader
                    .ReadToEnd()
                    .Split(';')
                    .ToList()
                    .Select(x =>
                        long.TryParse(x, out long l)
                            ? new TestClass(l)
                            : null)
                    .Where(x => x != null)
                    .ToList()
                    .ForEach(x => x.Dispose());
                /*
                 * string dataFromFile = streamReader.ReadToEnd();
                 * string[] splittedData = dataFromFile.Split(';');
                 * foreach (string i in splittedData)
                 * {
                 *     if (long.TryParse(i, out long l))
                 *     {
                 *         TestClass testEntity = new TestClass(l);
                 *         testEntity.Dispose();
                 *     }
                 * }
                 */
                var endMemory = GC.GetTotalMemory(true);
                Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }

            for (int i = 0; i < 200000; i++)
            {
                var test = new TestClass(i);
            }

            //GC.Collect();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\n Generation {i}, count: {GC.CollectionCount(i)}");
            }

            Console.WriteLine($"\n Total finalized - {FinalizingInfo.Total}");
        }
    }
}
