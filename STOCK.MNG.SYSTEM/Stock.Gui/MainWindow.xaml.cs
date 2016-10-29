using System.Windows;
using MahApps.Metro.Controls;

namespace Stock.Gui {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();
            DataContext = new vpoutput.MainViewModel();
        }
    }
}
