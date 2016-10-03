using System;
using MemoryUsage.Memory;

namespace MemoryUsage {
    class Program {
        static void Main(string[] args) {
            var tests = new Test[1000000];
            try {
                for (var i = 0; i < tests.Length; i++) {
                    tests[i] = new Test();
                    tests[i].Method(i);
                    /*var test = new Test();
                    test.Method(i);*/
                }
            } catch (OutOfMemoryException ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Heap is overload");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ReadLine();
        }
    }
}
