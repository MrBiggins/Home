using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Compiler.UI;

namespace Compiler.Core.Menegers {
    public class Parser {
        public string[] SplitText1;
        public Dictionary<int, string> KeyWordList;
        public List<string> VeriableList;
        public Dictionary<int, string> SpecSymbolList;
        public List<string> FunctionList;

        public string CodeText;
        public string CodeText1;
        public string[] SplitText;
        public char[] SplitText12;


        private readonly KeyWords _acceptableKeyWordList;
        private readonly SpecialCharacters _acceptableSpecSymbols;

        public Parser() {
            CompilerDefValues.LoadAllValues();
            VeriableList = new List<string>();
            KeyWordList = new Dictionary<int, string>();
            SpecSymbolList = new Dictionary<int, string>();
            FunctionList = new List<string>();
            _acceptableKeyWordList = CompilerDefValues.AcceptableKeyWordList;
            _acceptableSpecSymbols = CompilerDefValues.AcceptableSpecSymbols;
        }

        public void ParseCode(string code) {
            DetectKeyWords(code);
            DetectSpecialCharacters(code);
            DetectFunctions(code);
            DetectVeriables(code);
        }

        private void DetectKeyWords(string code) {
            //var xmldoc = new XmlDocument();
            //xmldoc.Load("keyWordList.xml");
            //_acceptableKeyWordList = KeyWords.Deserialize(xmldoc.InnerXml);
            var splitText = code.Split(' ', ',', '.', ';', ':', '=', '(', ')', '+', '-', '{', '}', '[', ']', '>', '<', '=');
            var splittedList = splitText.ToList();
            splittedList.RemoveAll(string.IsNullOrEmpty);
            foreach (var s in splittedList) {
                var keyword = Regex.Replace(s, @"\s+", string.Empty).ToLower();
                var match = _acceptableKeyWordList.KeyWord.FirstOrDefault(e => e.value == keyword);
                if (match != null) {
                    if (KeyWordList.All(e => e.Value != keyword))
                        KeyWordList.Add(_acceptableKeyWordList.KeyWord.Where(e => e.value == keyword).Select(e => e.index).FirstOrDefault(), keyword);
                }
            }
        }

        private void DetectSpecialCharacters(string code) {
            //var xmldoc = new XmlDocument();
            //xmldoc.Load("SpecialCharacters.xml");
            //_acceptableSpecSymbols = SpecialCharacters.Deserialize(xmldoc.InnerXml);
            var splitText = code.Split(' ').ToList();
            splitText.RemoveAll(string.IsNullOrEmpty);
            foreach (var s in splitText) {
                var keyword = Regex.Replace(s, @"\s+", string.Empty).ToLower();
                foreach (var character in keyword) {
                    var match = _acceptableSpecSymbols.SpecialCharacter.FirstOrDefault(e => e.value.ToCharArray(0, e.value.Count()).Any(d => d == character));
                    if (match != null)
                        if (!SpecSymbolList.ContainsKey(match.index)) {
                            SpecSymbolList.Add(match.index, character.ToString());
                        }
                }
            }
        }

        private void DetectFunctions(string code) {
            const string extractFuncRegex = (".*\\((.*)\\)");
            var lines = code.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            foreach (var line in lines) {
                var match = Regex.Match(line, extractFuncRegex);
                if (match.Success) {
                    var functionLine = match.Groups[0].Value;
                    var splittedFunctionLine = functionLine.Split(' ');
                    var item = splittedFunctionLine.FirstOrDefault(e => e.Contains("("));
                    if (item != null) { FunctionList.Add(item.Remove(item.IndexOf("(", StringComparison.Ordinal) + 1).Replace("(", string.Empty)); }
                    var functionParams = match.Groups[1].Value;
                    var splittedParams = functionParams.Split(',');
                    foreach (var veriable in splittedParams) {
                        var splittedVer = veriable.Split(';');
                        foreach (var it in splittedVer) {
                            var idver = it.Contains(":") ? it.Substring(0, it.LastIndexOf(':')) : it;

                            VeriableList.Add(idver.Replace(" ", string.Empty));
                        }
                    }
                }
            }
        }

        private void DetectVeriables(string code) {
            var lines = code.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var currentLine = lines.Where(e => e.Contains("var")).ToList();

            foreach (var line in currentLine) {
                var newLine = line.Replace("var", string.Empty);
                var splittedLinesList = newLine.Split(';').ToList();
                splittedLinesList.RemoveAll(string.IsNullOrEmpty);
                foreach (var veriable in splittedLinesList) {
                    var idver = veriable.Substring(0, veriable.LastIndexOf(':'));

                    VeriableList.Add(idver);
                }
            }
        }
    }
}
