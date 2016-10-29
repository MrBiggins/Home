using System;
using GalaSoft.MvvmLight.Command;

namespace GraphViewUI.ViewModel {
    internal class StartCommand : RelayCommand {
        public StartCommand(Action execute, Func<bool> canExecute) : base(execute, canExecute) {
        }
    }
}