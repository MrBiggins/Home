using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Core.Infastructure.Events;
using Core.Infastructure.Interface;
using GalaSoft.MvvmLight.Messaging;

namespace Core.Infastructure {
    public class Parser : ICompiler {


        public List<char> ListOfChars;
        public List<char> ListOfConstants;
        public List<char> ListOfDelimeiters;
        public List<char> TempCharacterList;

        public List<CharacterItem> GlobalIndexList;

        private readonly KeyWords _keyWordTable;
        private readonly SpecialCharacters _delimitersTable;

        public Parser() {

            ListOfChars = new List<char>();
            ListOfConstants = new List<char>();
            ListOfDelimeiters = new List<char>();
            GlobalIndexList = new List<CharacterItem>();
            TempCharacterList = new List<char>();
            var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(baseDir, @"XML/keyWordList.xml");
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
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = keywordValue,
                        IsKeyword = true,
                        Value = identificator
                    });
                }
            } else {
                if (GlobalIndexList.All(e => e.Value != identificator)) {
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = 0,
                        IsKeyword = false,
                        Value = identificator
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
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = 0,
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

            var keyWordsKeyWord = _keyWordTable.KeyWord.FirstOrDefault(e => e.value == identificator);

            if (keyWordsKeyWord == null) {
                delimiter = _delimitersTable.SpecialCharacter.FirstOrDefault(e => e.value == identificator);
            }

            if (keyWordsKeyWord != null) {
                keywordValue = keyWordsKeyWord.index;
            }

            if (delimiter != null) {
                keywordValue = delimiter.index;
            }
            return keywordValue;
        }
    }
}
