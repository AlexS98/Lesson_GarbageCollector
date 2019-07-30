using System;

namespace Lesson_GarbageCollector
{
    public class TestClass : IDisposable
    {
        public long Number { get; set; }

        public TestClass(long number)
        {
            Number = number;
        }

        public void Dispose()
        {
            Console.WriteLine($"\t{Number} disposed.");
        }

        ~TestClass()
        {
            if (Math.Abs(FinalizingInfo.LastNumber - Number) == 1)
            {
                FinalizingInfo.LastNumber = Number;
                FinalizingInfo.Count++;
            }
            else
            {
                Console.WriteLine((FinalizingInfo.Count > 0) ? $"Count - {FinalizingInfo.Count}" : "");
                Console.Write($"\t{Number} finalized. ");
                FinalizingInfo.LastNumber = Number;
                FinalizingInfo.Count = 0;
            }
        }
    }
}
