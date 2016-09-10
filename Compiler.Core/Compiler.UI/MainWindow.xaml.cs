using System.Windows;
using Compiler.UI.ViewModel;

namespace Compiler.UI {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
