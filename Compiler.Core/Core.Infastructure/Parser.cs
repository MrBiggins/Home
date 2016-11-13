using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Infastructure.Interface;

namespace Core.Infastructure {
    public class Parser : ICompiler {


        public List<char> ListOfChars;
        public List<char> ListOfInts;
        public List<char> ListOfDelimeiters;

        public List<CharacterItem> GlobalIndexList;

        private readonly KeyWords _keyWordTable;
        private readonly SpecialCharacters _delimitersTable;

        public Parser() {
            ListOfChars = new List<char>();
            ListOfInts = new List<char>();
            ListOfDelimeiters = new List<char>();
            GlobalIndexList = new List<CharacterItem>();

            var keyWordTableXml = File.ReadAllText(@"C:/GIT/Compiler.Core/LexicalTest/bin/Debug/XML/keyWordList.xml");
            _keyWordTable = KeyWords.Deserialize(keyWordTableXml);

            var delimitersTableXml = File.ReadAllText(@"C:/GIT/Compiler.Core/LexicalTest/bin/Debug/XML/SpecialCharacters.xml");
            _delimitersTable = SpecialCharacters.Deserialize(delimitersTableXml);
        }

        public void GetChar(char a) {
            var type = CheckCharacterType(a);

            switch (type) {
                case CharacterType.WhiteSPace:
                    MapKeywords();
                    break;

                case CharacterType.Delimiter:
                    ListOfDelimeiters.Add(a);
                    MapKeywords();
                    break;

                case CharacterType.Letter:
                    ListOfChars.Add(a);
                    break;

                case CharacterType.Digit:
                    ListOfInts.Add(a);
                    break;
                case CharacterType.Uknown:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }



        public void Lookup(string lexem) {
            var isKeword = _keyWordTable.KeyWord.Any(e => string.Equals(e.value, lexem,
                StringComparison.CurrentCultureIgnoreCase));
            if (!isKeword) {
                isKeword = _delimitersTable.SpecialCharacter.Any(e => string.Equals(e.value,
                    lexem, StringComparison.CurrentCultureIgnoreCase));
            }
            Add(lexem, isKeword);
        }

        public void Add(string identificator, bool isKeyword) {
            if (isKeyword) {

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
                if (GlobalIndexList.All(e => e.Value != identificator)) {
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = keywordValue,
                        IsKeyword = true,
                        Value = identificator
                    });
                }

            } else {
                GlobalIndexList.Add(new CharacterItem {
                    LookupIndex = 0,
                    IsKeyword = false,
                    Value = identificator
                });
            }
        }

        public CharacterType CheckCharacterType(char a) {
            return CharTypeResolver.Resolve(a);
        }

        public void CheckNextSymbol() {
            throw new NotImplementedException();
        }

        public void Start(string code) {
            foreach (var t in code) {
                GetChar(t);
            }
        }


        private void MapKeywords() {
            var arrayOfChars = ListOfChars.ToArray();
            if (arrayOfChars.Length != 0) {
                var str = new string(arrayOfChars);
                Lookup(str);
                ListOfChars.Clear();
            }
            var arraOfDelimiters = ListOfDelimeiters.ToArray();
            if (arraOfDelimiters.Length != 0) {
                var str = new string(arraOfDelimiters);
                Lookup(str);
                ListOfDelimeiters.Clear();
            }
        }
    }
}
