using System;

namespace CalculatorExample {
    internal class Program {
        private class Calc { public int Add(int x, int y) { return x + y; } }

        private static void Main(string[] args) {
            var c = new Calc();
            var ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}.", ans);
            Console.ReadLine();
        }
    }
}
