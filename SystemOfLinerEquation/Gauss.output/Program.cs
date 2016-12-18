using System;
using EquationManager;

namespace Gauss.output {
    internal class Program {
        private static void Main(string[] args) {
            var n = 3;
            var b = new double[n];
            var x = new double[n];



            var manager = new IterationManager();
           // var matrix = new double[3, 4];
            double[,] matrix = {{  1, -2,  1,  2 },
                         {  2, -5, -1, -1 },
                         { -7,  0,  1, -2 }};
            var fielledMatrix = /*manager.GetMatrix(matrix)*/matrix;

            //var matrixWithLeadingElement = manager.GetLeadingElement(fielledMatrix);

            var triangleMatrix = manager.DirectFlow(fielledMatrix, 3);

            Console.WriteLine("Triangle Matrix: \n");
            manager.ShowMatrix(triangleMatrix);
            Console.WriteLine();

            Console.WriteLine("Solutions:\n");
            var vals = manager.ReverseFlow(triangleMatrix, 4, 3);
            for (var i = 0; i < vals.Length; i++) {
                // Console.WriteLine($"x{i+1}={vals[i]}\n");
                Console.WriteLine(string.Format("x{0}={1}\n", i + 1, vals[i]));
            }

            /* Console.WriteLine("Gauss - Zeidel");

             for (var i = 0; i < n; i++) {
                 x[i] = 0;
             }

             var aMatrix = new double[3, 3];
             var bMatrix = new double[3];
             for (var i = 1; i < matrix.GetLength(1); i++) {
                 for (var j = 1; j < matrix.GetLength(1); j++) {

                     aMatrix[i - 1, j - 1] = matrix[i - 1, j - 1];
                 }

                 bMatrix[i - 1] = matrix[i - 1, matrix.GetLength(0)];

             }


             var test = new GaussZeidel(aMatrix, bMatrix, 500, n, x);
             var results = test.Algoritm();
             for (var i = 0; i < results.Length; i++) {
                 Console.WriteLine(string.Format("x{0}={1}\n", i + 1, results[i]));
             }

             manager.CountNormaManhatten(matrix, n);*/
            Console.ReadLine();
        }
    }
}
