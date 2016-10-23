using System;
using System.Linq;
using EquationManager.Interface;
using Microsoft.Win32.SafeHandles;

namespace EquationManager {
    public class IterationManager : IGauss {

        public double[,] GetMatrix(double[,] matrix) {
            for (var i = 1; i < matrix.GetLength(1); i++) {
                for (var j = 1; j < matrix.GetLength(1); j++) {
                    Console.WriteLine("Enter value for A" + i + j);
                    matrix[i - 1, j - 1] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine("Enter value for B" + i);
                matrix[i - 1, matrix.GetLength(0)] = Convert.ToDouble(Console.ReadLine());
            }

            return matrix;
        }

        public double[,] GetLeadingElement(double[,] matrix) {
            var isFinished = false;
            if (matrix[0, 0] > matrix[1, 0] && matrix[1, 0] > matrix[2, 0]) {
                Console.WriteLine("System has unique solution");

            } else while (isFinished == false) {
                    double tempMatrix;
                    if (matrix[0, 0] < matrix[1, 0] && matrix[1, 0] < matrix[2, 0]) {
                        for (var j = 0; j < matrix.GetLength(1); j++) {
                            tempMatrix = matrix[0, j];
                            matrix[0, j] = matrix[2, j];
                            matrix[2, j] = tempMatrix;
                        }
                    }

                    if (matrix[0, 0] < matrix[1, 0]) {
                        for (var j = 0; j < matrix.GetLength(1); j++) {
                            tempMatrix = matrix[0, j];
                            matrix[0, j] = matrix[1, j];
                            matrix[1, j] = tempMatrix;
                        }
                    }
                    if (matrix[1, 0] < matrix[2, 0]) {
                        for (var j = 0; j < matrix.GetLength(1); j++) {
                            tempMatrix = matrix[1, j];
                            matrix[1, j] = matrix[2, j];
                            matrix[2, j] = tempMatrix;
                        }
                    }
                    if ((matrix[1, 0] == matrix[2, 0])) {
                        if (matrix[1, 1] < matrix[2, 1]) {
                            for (var j = 0; j < matrix.GetLength(1); j++) {
                                tempMatrix = matrix[1, j];
                                matrix[1, j] = matrix[2, j];
                                matrix[2, j] = tempMatrix;
                            }
                        }
                    }
                    if (matrix[0, 0] > matrix[1, 0] && matrix[1, 0] >= matrix[2, 0]) {
                        isFinished = true;
                        tempMatrix = 0;
                    }
                }
            return matrix;

        }

        public double[,] DirectFlow(double[,] matrix, int height) {
            for (var row = 1; row < height; row++) {
                for (var column = row; column < height; column++) {
                    var coefficient = matrix[column, row - 1] / matrix[row - 1, row - 1];
                    for (var i = 0; i < matrix.GetLength(0); i++) {
                        matrix[column, i] = matrix[column, i] - coefficient * matrix[row - 1, i];
                    }
                }
            }
            return matrix;
        }

        public double[] ReverseFlow(double[,] matrix, int length, int height) {
            var xValues = new double[length];
            var x3 = matrix[height - 1, length] / matrix[height - 1, length - 1];
            var temp1 = x3 * matrix[height - 2, length - 1];
            var temp2 = matrix[height - 2, length] - temp1;
            var x2 = temp2 / matrix[height - 2, length - 2];
            var temp3 = x3 * matrix[height - 3, length - 1];
            var temp4 = x2 * matrix[height - 3, length - 2];
            var temp5 = matrix[height - 3, length] - temp3 - temp4;
            var x1 = temp5 / matrix[height - 3, length - 3];
            xValues[0] = x1;
            xValues[1] = x2;
            xValues[2] = x3;
            return xValues;
        }

        public void ShowMatrix(double[,] matrix) {
            for (var i = 0; i < matrix.GetLength(0); i++) {
                Console.WriteLine(matrix[i, 0] + "x(1)+" + matrix[i, 1] + "x(2)+" + matrix[i, 2] + "x(3) = " + matrix[i, 3]);
            }
        }

        public void CountNormaManhatten(double[,] m, int n) {
            var arr = new double[n];
            Console.WriteLine("Counting norm.");
            for (var i = 0; i < n; i++) {
                for (var j = 0; j < n; j++) {
                    arr[i] += m[i, j];
                }
            }
            var norma = arr.Concat(new double[] { 0 }).Max();
            Console.WriteLine("The norma of the matrix should be: {0}", norma);
        }
    }
}
