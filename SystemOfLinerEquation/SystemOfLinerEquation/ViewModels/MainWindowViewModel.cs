using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfLinerEquation.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var solver = new EquationManager.Solver();
            solver.TextValue = "7\r\n8\r\n3\r\n4";
            solver.TextCoefficients = "9 3 4 1\r\n4 3 4 1\r\n1 1 1 1\r\n2 3 4 5";
            solver.SolveTheSystem();
            Text = solver.Text;
        }
        private string Text { get; set; }
    }
}
