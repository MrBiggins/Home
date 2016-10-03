using System;

namespace MemoryUsage.Memory {
    internal class Test {
        int[] _arr = new int[1000000];
        public void Method(int i) {
            Console.WriteLine(i);
        }
        ~Test() {
            Console.WriteLine("Object " + GetHashCode() + "deleted");
        }
    }
}
