using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compiler.Core.Menegers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Compiler.UI.ViewModel {
    public class MainWindowViewModel : ViewModelBase {

    

        private string _code;
        public string Code {
            get {
                return _code;
            }
            set {
                if (_code == value) return;
                _code = value;
                RaisePropertyChanged(() => Code);
            }
        }

        private List<string> _veriables;
        public List<string> Veriables {
            get {
                return _veriables;
            }
            set {
                if (_veriables == value) return;
                _veriables = value;
                RaisePropertyChanged(() => Veriables);
            }
        }

        private Dictionary<int, string> _keyWords;
        public Dictionary<int, string> KeyWords {
            get {
                return _keyWords;
            }
            set {
                if (_keyWords == value) return;
                _keyWords = value;
                RaisePropertyChanged(() => KeyWords);
            }
        }

        private List<string> _functions;
        public List<string> Functions {
            get {
                return _functions;
            }
            set {
                if (_functions == value) return;
                _functions = value;
                RaisePropertyChanged(() => Functions);
            }
        }

        private Dictionary<int, string> _specialCharacters;
        public Dictionary<int, string> SpecialCharacters {
            get {
                return _specialCharacters;
            }
            set {
                if (_specialCharacters == value) return;
                _specialCharacters = value;
                RaisePropertyChanged(() => SpecialCharacters);
            }
        }

        #region Commands

        private RelayCommand _loadFileCommand;
        public RelayCommand LoadFileCommand {
            get {
                if (_loadFileCommand == null) {
                    _loadFileCommand = new RelayCommand(
                    OpenFile,
                    () => true);
                }
                return _loadFileCommand;
            }
        }


        private RelayCommand _compileCommand;
        public RelayCommand CompileCommand {
            get {
                if (_compileCommand == null) {
                    _compileCommand = new RelayCommand(
                        () => {
                            if (string.IsNullOrEmpty(Code)) {
                                MessageBox.Show("Select file for compilation first.", "Warning");
                                return;
                            }
                            CompileCode(Code);
                        },
                        () =>true);
                }
                return _compileCommand;
            }
        }

        #endregion



        private void OpenFile() {
            var openFileDialog1 = new OpenFileDialog { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" };
            var showDialog = openFileDialog1.ShowDialog();
            if (showDialog != null && (bool)showDialog) {
                try {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    Code = Convert.ToString(sr.ReadToEnd());
                    sr.Close();

                }
                catch (Exception ex) {
                    MessageBox.Show(string.Format("Failed to load file. {0}", ex.Message));
                }
            }
        }

        private void CompileCode(string code) {
            try {
                Veriables = new List<string>();
                Functions = new List<string>();
                KeyWords = new Dictionary<int, string>();
                var parser = new Parser();
                parser.ParseCode(code);
                Veriables = parser.VeriableList;
                KeyWords = parser.KeyWordList;
                Functions = parser.FunctionList;
                SpecialCharacters = parser.SpecSymbolList;
                MakeSentaxisAnalyzis(code);
                MessageBox.Show("Compiled Success","Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(string.Format("Compilation error. {0}", ex.Message),"Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
         
            }
        }

        private static void MakeSentaxisAnalyzis(string code) {
            int counter = 0;
            var splittedCode = code.Split('\n');
            var synth = new SyntaxisAnalyzer();
            foreach (var codeline in splittedCode) {
                counter++;
                var cdl = Regex.Replace(codeline, @"\r", string.Empty).ToLower();
                synth.CheckInputGrammar(cdl,counter);
            }
        }
    }
}
