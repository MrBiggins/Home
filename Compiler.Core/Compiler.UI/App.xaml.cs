using System;
using System.Windows;
using MahApps.Metro;

namespace Compiler.UI {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {

        public App() {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        private static void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            string errorMessage = $"Parser error accured: {e.Exception.Message}";
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e) {
           
        }
    }
}
