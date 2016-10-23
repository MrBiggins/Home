namespace SystemOfLinerEquation.ViewModels {
    public class MainWindowViewModel {
        public MainWindowViewModel() {
            var solver = new EquationManager.Solver
            {
                TextValue = "7\r\n8\r\n3\r\n4",
                TextCoefficients = "9 3 4 1\r\n4 3 4 1\r\n1 1 1 1\r\n2 3 4 5"
            };
            solver.SolveTheSystem();
            Text = solver.Text;
        }
        private string Text { get; set; }
    }
}
