using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Core.Infastructure;
using Core.Infastructure.Events;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Compiler.UI.ViewModel {

    public class MainViewModel : ViewModelBase {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {
            Messenger.Default.Register<LogEvent>(this, ReceiveMessage);
            Output = new ObservableCollection<string>();
        }


        #region Events

        private void ReceiveMessage(LogEvent action) {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                Output.Add(action.Message);
            }));
            
        }

        #endregion

        private List<CharacterItem> _keywordsItems;
        public List<CharacterItem> KeywordItems {
            get {
                return _keywordsItems;
            }
            set {
                if (_keywordsItems == value) return;
                _keywordsItems = value;
                RaisePropertyChanged(() => KeywordItems);
            }
        }

        private List<CharacterItem> _identificatorsItems;
        public List<CharacterItem> IdentificatorsItems {
            get {
                return _identificatorsItems;
            }
            set {
                if (_identificatorsItems == value) return;
                _identificatorsItems = value;
                RaisePropertyChanged(() => IdentificatorsItems);
            }
        }


        private ObservableCollection<string> _output;
        public ObservableCollection<string> Output {
            get {
                return _output;
            }
            set {
                if (_output == value) return;
                _output = value;
                RaisePropertyChanged(() => Output);
            }
        }

        public void Compile(string source) {

            Output.Clear();
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, args) => {
                var parser = new Parser();
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { Output.Add("# start to parse code"); }));
                parser.Start(source);

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    KeywordItems = parser.GlobalIndexList.Where(e => e.IsKeyword).ToList();
                }));

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    IdentificatorsItems = parser.GlobalIndexList.Where(e => !e.IsKeyword).ToList();
                }));


                var constants = parser.GlobalIndexList.Where(e => e.IsConstant).Select(d => d.Value).ToList();
            };
            bw.RunWorkerCompleted += (sender, args) => {
                if (args.Error != null)
                    MessageBox.Show(args.Error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };
            bw.RunWorkerAsync();
        }
    }
}