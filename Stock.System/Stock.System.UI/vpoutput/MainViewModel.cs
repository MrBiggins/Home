using GalaSoft.MvvmLight.Command;

namespace Stock.System.UI.vpoutput {
	/// <summary>
	/// This is main view model class. This class is data context for Main View xaml.
	/// 
	/// This view model contains links to other windows
	/// </summary>
	public class MainViewModel {

		public MainViewModel() {
			throw new global::System.Exception("Not implemented");
		}



        private RelayCommand _openConfigurationCommand;
        public RelayCommand OpenConfigurationCammand {
            get {
                if (_openConfigurationCommand == null) {
                    _openConfigurationCommand = new RelayCommand(
                    () => {
                        
                    },
                    () => true);
                }
                return _openConfigurationCommand;
            }
        }


        private RelayCommand _openBalanceOperationsCommand;
        public RelayCommand OpenBalanceOperationsCommand {
            get {
                if (_openBalanceOperationsCommand == null)
                {
                    _openBalanceOperationsCommand = new RelayCommand(
                        () => {

                        },
                        () => true);
                }
                return _openBalanceOperationsCommand;
            }
        }

		//private ConfigurationViewModel configurationViewModel;
		//public BalanceMovementViewModel BalanceMovementViewModel;

	}

}
