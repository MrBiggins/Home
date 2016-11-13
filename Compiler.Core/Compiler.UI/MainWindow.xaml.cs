using System.Windows;
using Compiler.UI.ViewModel;
using MahApps.Metro.Controls;

namespace Compiler.UI {

    public partial class MainWindow : MetroWindow {
        private readonly MainViewModel _model;
        public MainWindow() {
            InitializeComponent();
            _model = new MainViewModel();
            DataContext = _model;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            var sourceText = Source.Text;
            _model.Compile(sourceText);
        }
    }
}
