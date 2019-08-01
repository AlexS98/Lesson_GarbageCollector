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
            Console.WriteLine($"{Number} disposed.");
        }

        ~TestClass()
        {
            if (Math.Abs(FinalizingInfo.LastNumber - Number) == 1)
            {
                FinalizingInfo.LastNumber = Number;
                FinalizingInfo.Total++;
                FinalizingInfo.Count++;
            }
            else
            {
                Console.WriteLine((FinalizingInfo.Count > 1) ? $"Count - {FinalizingInfo.Count}" : "");
                Console.Write($"{Number} finalized. ");
                FinalizingInfo.LastNumber = Number;
                FinalizingInfo.Total++;
                FinalizingInfo.Count = 1;
            }
        }
    }
}
