using GalaSoft.MvvmLight.Command;
using Stock.Gui.Views;

namespace Stock.Gui.vpoutput {
    public class ConfigurationViewModel {

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConfigurationViewModel() {
            //  throw new global::System.Exception("Not implemented");
        }

        #region Properties

        private object configurationList;
        public object ConfigurationList {
            get {
                return configurationList;
            }
            set {
                configurationList = value;
            }
        }

        #endregion

        /// <summary>
        /// Load configuration off all components
        /// </summary>
        public void LoadConfiguration() {
            throw new global::System.Exception("Not implemented");
        }
        /// <summary>
        /// Button command which uses binding. Calls new window to be opened
        /// </summary>
        public GalaSoft.MvvmLight.Command.RelayCommand UserMngCommand() {
            throw new global::System.Exception("Not implemented");
        }
        public void Operation() {
            throw new global::System.Exception("Not implemented");
        }
        /// <summary>
        /// Command calls add new vault window
        /// </summary>
        public void AddNewVaultCommand() {
            throw new global::System.Exception("Not implemented");
        }
        /// <summary>
        /// Command calls manage branches window
        /// </summary>

        private RelayCommand _manageBranchesCommand;
        public RelayCommand ManageBranchesCommand {
            get {
                if (_manageBranchesCommand == null) {
                    _manageBranchesCommand = new RelayCommand(
                    () => {
                        var manageBranches = new ManageBranches();
                        manageBranches.Show();
                    },
                    () => true);
                }
                return _manageBranchesCommand;
            }
        }
        /// <summary>
        /// Command calls rules window
        /// </summary>
        public void OpenManageRulesCommand() {
            throw new global::System.Exception("Not implemented");
        }
    }
}
