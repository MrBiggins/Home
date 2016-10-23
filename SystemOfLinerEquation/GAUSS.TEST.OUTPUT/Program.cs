using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquationManager;

namespace GAUSS.TEST.OUTPUT {
    internal class Program {
        private static void Main(string[] args)
        {

            var solver = new Solver {
                TextValue = "7\r\n8\r\n3\r\n4",
                TextCoefficients = "9 3 4 1\r\n4 3 4 1\r\n1 1 1 1\r\n2 3 4 5"
            };
            solver.SolveTheSystem();
            Console.WriteLine(solver.Text);
            Console.ReadLine();
        }
    }
}
