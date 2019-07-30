using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_GarbageCollector
{
    public class TestClass : IDisposable
    {
        public string Name { get; set; }

        public TestClass(string name)
        {
            Name = name;
        }

        public void Dispose()
        {
            Console.WriteLine($"\t{Name} disposed.");
        }

        ~TestClass()
        {
            Console.WriteLine($"\t{Name} finalized.");
        }
    }
}
