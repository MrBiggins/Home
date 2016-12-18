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
            KeywordItems = new List<CharacterItem>();
            ConstantItems = new List<CharacterItem>();
            StandartItems = new List<CharacterItem>();
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

        private List<CharacterItem> _constantItems;
        public List<CharacterItem> ConstantItems {
            get {
                return _constantItems;
            }
            set {
                if (_constantItems == value) return;
                _constantItems = value;
                RaisePropertyChanged(() => ConstantItems);
            }
        }

        private List<CharacterItem> _standartItems;
        public List<CharacterItem> StandartItems {
            get {
                return _standartItems;
            }
            set {
                if (_standartItems == value) return;
                _standartItems = value;
                RaisePropertyChanged(() => StandartItems);
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
            ConstantItems.Clear();
            StandartItems.Clear();
            KeywordItems.Clear();

            var bw = new BackgroundWorker();
            bw.DoWork += (sender, args) => {
                var parser = new Parser();
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { Output.Add("# ---start to parse code---"); }));
                parser.Start(source);

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    KeywordItems = parser.GlobalIndexList.Where(e => e.IsKeyword && !e.IsConstant).ToList();

                }));

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    IdentificatorsItems = parser.GlobalIndexList.Where(e => !e.IsKeyword && !e.IsConstant).ToList();

                }));

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    ConstantItems = parser.GlobalIndexList.Where(e => e.IsConstant).ToList();
                }));

                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    StandartItems = parser.GlobalIndexList.Where(e => !e.IsConstant).ToList();
                }));

                AnaliseLexical(source);
            };
            bw.RunWorkerCompleted += (sender, args) => {

                Output.Add("# ---finish to parse code---");
                if (args.Error != null) {
                    MessageBox.Show(args.Error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            };
            bw.RunWorkerAsync();
        }

        private static void AnaliseLexical(string source) {
            var lines = source.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var lineForAnalise = lines.FirstOrDefault();
            var syntaxCheck = new SyntaxisAnalyzer();
            syntaxCheck.CheckInputGrammar(lineForAnalise, 0);
        }
    }
}