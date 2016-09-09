using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationManager {
    public class Solver {
        #region Properties

        public string Text { get; set; }

        public string TextValue { get; set; }

        public string TextCoefficients { get; set; }

        #endregion

        #region Methods

        public void SolveTheSystem() {
            const double tiny = 0.00001;
            string txt = "";
            int num_rows, num_cols;
            double[,] arr = LoadArray(out num_rows, out num_cols);
            double[,] orig_arr = LoadArray(out num_rows, out num_cols);
            PrintArray(arr);
            PrintArray(orig_arr);
            for (int r = 0; r < num_rows - 1; r++) {
                if (Math.Abs(arr[r, r]) < tiny) {
                    for (int r2 = r + 1; r2 < num_rows; r2++) {
                        if (Math.Abs(arr[r2, r]) > tiny) {
                            for (int c = 0; c <= num_cols; c++) {
                                double tmp = arr[r, c];
                                arr[r, c] = arr[r2, c];
                                arr[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }
                if (Math.Abs(arr[r, r]) > tiny) {
                    for (int r2 = r + 1; r2 < num_rows; r2++) {
                        double factor = -arr[r2, r] / arr[r, r];
                        for (int c = r; c <= num_cols; c++) {
                            arr[r2, c] = arr[r2, c] + factor * arr[r, c];
                        }
                    }
                }
            }
            PrintArray(arr);

            if (arr[num_rows - 1, num_cols - 1] == 0) {
                bool all_zeros = true;
                for (int c = 0; c <= num_cols + 1; c++) {
                    if (arr[num_rows - 1, c] != 0) {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros) {
                    txt = "The solution is not unique";
                }
                else {
                    txt = "There is no solution";
                }
            }
            else {
                for (int r = num_rows - 1; r >= 0; r--) {
                    double tmp = arr[r, num_cols];
                    for (int r2 = r + 1; r2 < num_rows; r2++) {
                        tmp -= arr[r, r2] * arr[r2, num_cols + 1];
                    }
                    arr[r, num_cols + 1] = tmp / arr[r, r];
                }
                txt = "       Values:";
                for (int r = 0; r < num_rows; r++) {
                    txt += "\r\nx" + r.ToString() + " = " +
                        arr[r, num_cols + 1].ToString();
                }
                txt += "\r\n    Check:";
                for (int r = 0; r < num_rows; r++) {
                    double tmp = 0;
                    for (int c = 0; c < num_cols; c++) {
                        tmp += orig_arr[r, c] * arr[c, num_cols + 1];
                    }
                    txt += "\r\n" + tmp.ToString();
                }

                txt = txt.Substring("\r\n".Length + 1);
            }

            Text = txt;
        }

        private double[,] LoadArray(out int num_rows, out int num_cols) {
            // Build the augmented matrix.
            string[] value_rows = TextValue.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] coef_rows = TextCoefficients.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] one_row = coef_rows[0].Split(
                new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            num_rows = coef_rows.GetUpperBound(0) + 1;
            num_cols = one_row.GetUpperBound(0) + 1;
            double[,] arr = new double[num_rows, num_cols + 2];
            for (int r = 0; r < num_rows; r++) {
                one_row = coef_rows[r].Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < num_cols; c++) {
                    arr[r, c] = double.Parse(one_row[c]);
                }
                arr[r, num_cols] = double.Parse(value_rows[r]);
            }

            return arr;
        }

        private void PrintArray(double[,] arr) {
            for (int r = arr.GetLowerBound(0); r <= arr.GetUpperBound(0); r++) {
                for (int c = arr.GetLowerBound(1); c <= arr.GetUpperBound(1); c++) {
                    Console.Write(arr[r, c] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        #endregion
    }
}
