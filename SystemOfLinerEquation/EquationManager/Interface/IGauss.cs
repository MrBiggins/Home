﻿namespace EquationManager.Interface {
    public interface IGauss {
        double[,] GetMatrix(double[,] matrix);
        double[,] GetLeadingElement(double[,] matrix);
        double[,] DirectFlow(double[,] matrix, int height);
        double[] ReverseFlow(double[,] matrix, int length, int height);

        void CountNormaManhatten(double[,] m, int n);

        void ShowMatrix(double[,] matrix);
    }
}
