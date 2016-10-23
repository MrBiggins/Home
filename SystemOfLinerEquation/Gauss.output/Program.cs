using System;

namespace Gauss.output {
    internal class Program {
        private static void Main(string[] args) {

            var manager = new EquationManager.IterationManager();
            var matrix = new double[3, 4];

            var fielledMatrix = manager.GetMatrix(matrix);
            var matrixWithLeadingElement = manager.GetLeadingElement(fielledMatrix);
            var triangleMatrix = manager.DirectFlow(matrixWithLeadingElement, 3);
            Console.WriteLine("Triangle Matrix: \n");
            manager.ShowMatrix(triangleMatrix);
            Console.WriteLine();
            Console.WriteLine("Solutions:\n");
            var vals = manager.ReverseFlow(triangleMatrix, 3, 3);
            for (var i = 0; i < vals.Length; i++) {
                Console.WriteLine($"x{i+1}={vals[i]}\n");
            }
            Console.ReadLine();
        }
    }
}
