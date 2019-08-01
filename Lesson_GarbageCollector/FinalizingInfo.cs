using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_GarbageCollector
{
    public static class FinalizingInfo
    {
        public static int Count { get; set; } = 0;
        public static long LastNumber { get; set; }
        public static long Total { get; set; }
    }
}
