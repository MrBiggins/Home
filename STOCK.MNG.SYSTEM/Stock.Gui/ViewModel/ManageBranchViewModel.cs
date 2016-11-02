using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Stock.DB;
using Stock.Gui.Events;

namespace Stock.Gui.ViewModel {
    public class ManageBranchViewModel : ViewModelBase {


        private string _name;
        public string Name {
            get {
                return _name;
            }
            set {
                if (_name == value) return;
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }



        public void SaveNewBranch() {
            StockDb.AddNewBranchToDb(new Branch {
                Name = Name
            });
        }



        private RelayCommand _addBranchCommand;
        public RelayCommand AddBranchCommand {
            get {
                if (_addBranchCommand == null) {
                    _addBranchCommand = new RelayCommand(
                          () => {
                              if (string.IsNullOrEmpty(Name)) {
                                  MessageBox.Show("Branch name is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                  return;
                              }
                              SaveNewBranch();
                              MessageBox.Show("Branch Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                              Messenger.Default.Send(new RiseClosingEvent());
                          },


                    () => true);
                }
                return _addBranchCommand;
            }
        }
    }
}
