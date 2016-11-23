using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Infastructure.Events;
using Core.Infastructure.Interface;
using GalaSoft.MvvmLight.Messaging;

namespace Core.Infastructure {
    public class Parser : ICompiler {

        #region global variables

        public List<char> ListOfChars;
        public List<char> ListOfConstants;
        public List<char> ListOfDelimeiters;
        public List<char> TempCharacterList;

        public List<CharacterItem> GlobalIndexList;

        private readonly KeyWords _keyWordTable;
        private readonly SpecialCharacters _delimitersTable;

        #endregion

        public Parser() {

            ListOfChars = new List<char>();
            ListOfConstants = new List<char>();
            ListOfDelimeiters = new List<char>();
            GlobalIndexList = new List<CharacterItem>();
            TempCharacterList = new List<char>();

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var keyWordTableXml = File.ReadAllText(Path.Combine(baseDir, @"XML/keyWordList.xml"));
            _keyWordTable = KeyWords.Deserialize(keyWordTableXml);

            var delimitersTableXml = File.ReadAllText(Path.Combine(baseDir, @"XML/SpecialCharacters.xml"));
            _delimitersTable = SpecialCharacters.Deserialize(delimitersTableXml);
        }

        public void GetChar(char a) {
            var type = CheckCharacterType(a);

            switch (type) {
                case CharacterType.WhiteSPace:
                    MapKeywords();
                    break;

                case CharacterType.Delimiter:
                    var isLookuped = CheckNextSymbol(a);
                    if (!isLookuped) {
                        ListOfDelimeiters.Add(a);
                        MapKeywords();
                    }

                    break;

                case CharacterType.Letter:
                    ListOfChars.Add(a);
                    break;

                case CharacterType.Digit:
                    ListOfConstants.Add(a);

                    break;
                case CharacterType.Uknown:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Lookup(string lexem) {
            var isKeword = _keyWordTable.KeyWord.Any(e => string.Equals(e.value, lexem,
                StringComparison.CurrentCultureIgnoreCase));
            if (!isKeword) {
                isKeword = _delimitersTable.SpecialCharacter.Any(e => string.Equals(e.value,
                    lexem, StringComparison.CurrentCultureIgnoreCase));
            }
            return isKeword;
        }

        public void Add(string identificator, bool isKeyword) {
            if (isKeyword) {
                var keywordValue = ResolveKeyWordIndex(identificator);
                if (GlobalIndexList.All(e => e.Value != identificator)) {
                    var nextIndex = 0;
                    var currentIndex = GlobalIndexList.LastOrDefault(e => e.IsKeyword);
                    if (currentIndex != null) {
                        nextIndex = currentIndex.LookupIndex + 1;
                    }
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = nextIndex,
                        IsKeyword = true,
                        Value = identificator,
                        LexemType = LexemType.TRM
                    });
                }
            }
            else {
                if (GlobalIndexList.All(e => e.Value != identificator)) {
                    var nextIndex = 0;
                    var currentIndex = GlobalIndexList.LastOrDefault(e => e.IsKeyword != true && e.IsConstant != true);
                    if (currentIndex != null) {
                        nextIndex = currentIndex.LookupIndex + 1;
                    }
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = nextIndex,
                        IsKeyword = false,
                        Value = identificator,
                        LexemType = LexemType.IDN
                    });
                }
            }
        }

        public CharacterType CheckCharacterType(char a) {
            return CharTypeResolver.Resolve(a);
        }

        public bool CheckNextSymbol(char current) {
            if (current == ':') {
                if (!TempCharacterList.Contains(':'))
                    TempCharacterList.Add(current);
                return false;
            }
            if (current == '=') {
                if (TempCharacterList.Any()) {
                    TempCharacterList.Add(current);
                    var array = TempCharacterList.ToArray();
                    var str = new string(array);
                    var isKeword = Lookup(str);
                    if (isKeword) {
                        Add(str, true);
                        TempCharacterList.Clear();
                        return true;
                    }
                }
            }
            return false;
        }

        public void Start(string code) {
            foreach (var t in code) {
                Messenger.Default.Send(new LogEvent($"# ---parse char: {t}---"));
                GetChar(t);
            }
        }

        private void MapKeywords() {
            var arrayOfChars = ListOfChars.ToArray();
            if (arrayOfChars.Length != 0) {
                var str = new string(arrayOfChars);
                var isKeword = Lookup(str);
                Add(str, isKeword);
                ListOfChars.Clear();
            }
            var arraOfDelimiters = ListOfDelimeiters.ToArray();
            if (arraOfDelimiters.Length != 0) {
                var str = new string(arraOfDelimiters);
                var isKeword = Lookup(str);
                Add(str, isKeword);
                ListOfDelimeiters.Clear();
            }
            var arrayOfConstants = ListOfConstants.ToArray();
            if (arrayOfConstants.Length != 0) {
                var str = new string(arrayOfConstants);
                if (GlobalIndexList.All(e => e.Value != str)) {
                    var nextIndex = 0;
                    var currentIndex = GlobalIndexList.LastOrDefault(e => e.IsConstant);
                    if (currentIndex != null) {
                        nextIndex = currentIndex.LookupIndex + 1;
                    }
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = nextIndex,
                        IsConstant = true,
                        Value = str
                    });
                }
                ListOfConstants.Clear();
            }
        }

        private int ResolveKeyWordIndex(string identificator) {
            SpecialCharactersSpecialCharacter delimiter = null;
            var keywordValue = 0;

            var keyWordsKeyWord = _keyWordTable.KeyWord.FirstOrDefault(e => String.Equals(e.value, identificator, StringComparison.CurrentCultureIgnoreCase));

            if (keyWordsKeyWord == null) {
                delimiter = _delimitersTable.SpecialCharacter.FirstOrDefault(e => e.value == identificator);
            }

            if (keyWordsKeyWord != null) {
                keywordValue = keyWordsKeyWord.index;
            }

            if (delimiter != null) {
                if (!delimiter.isAlowed) { throw new Exception($"The {delimiter.value} symbol is not allowed!"); }
                keywordValue = delimiter.index;
            }
            return keywordValue;
        }
    }
}
