using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationManager {
    public class GaussZeidel {
        public double Epsilon = 0.01;
        public int MatrixSize;
        public int K;
        public int NumberOfIterations;
        public double S;
        public double Xi;
        public double Diff = 1;
        public double[,] Matrix;
        public double[] Value;
        public double[] Roots;

        public GaussZeidel(double[,] matrix, double[] value, int numberOfIterations, int matrixSize, double[] roots) {
            Matrix = matrix;
            NumberOfIterations = numberOfIterations;
            Value = value;
            MatrixSize = matrixSize;
            Roots = roots;
        }

        public double[] Algoritm() {
            K = 0;
            while ((K <= NumberOfIterations) && (Diff >= Epsilon)) {
                K = K + 1;
                for (var i = 0; i < MatrixSize; i++) {
                    S = 0;
                    for (var j = 0; j < MatrixSize; j++) {
                        if (i != j) {
                            S += Matrix[i, j] * Roots[j];
                        }
                    }
                    Xi = (Value[i] - S) / Matrix[i, i];
                    Diff = Math.Abs(Xi - Roots[i]);
                    Roots[i] = Xi;
                }
            }
            return Roots;
        }
    }
}
