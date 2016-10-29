using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Stock.Gui.Views;

namespace Stock.Gui.vpoutput {
    /// <summary>
    /// This is main view model class. This class is data context for Main View xaml.
    /// 
    /// This view model contains links to other windows
    /// </summary>
    public class MainViewModel : ViewModelBase {

        public MainViewModel() {
            ContentWindow = new MainView();
        }

        private UserControl _contentWindow;
        public UserControl ContentWindow {
            get {
                return _contentWindow;
            }
            set {
                if (Equals(_contentWindow, value)) return;
                _contentWindow = value;
                RaisePropertyChanged(() => ContentWindow);
            }
        }



        private RelayCommand _openConfigurationCommand;
        public RelayCommand OpenConfigurationCammand {
            get {
                if (_openConfigurationCommand == null) {
                    _openConfigurationCommand = new RelayCommand(
                    () => {
                        ContentWindow = new Configuration();
                    },
                    () => true);
                }
                return _openConfigurationCommand;
            }
        }


        private RelayCommand _openBalanceOperationsCommand;
        public RelayCommand OpenBalanceOperationsCommand {
            get {
                if (_openBalanceOperationsCommand == null) {
                    _openBalanceOperationsCommand = new RelayCommand(
                        () => {
                            ContentWindow = new BalanceMovement();
                        },
                        () => true);
                }
                return _openBalanceOperationsCommand;
            }
        }



        private RelayCommand _homeCommand;
        public RelayCommand HomeCommand {
            get {
                if (_homeCommand == null) {
                    _homeCommand = new RelayCommand(
                    () => {
                        ContentWindow = new MainView();
                    },
                    () => true);
                }
                return _homeCommand;
            }
        }
    }
}
