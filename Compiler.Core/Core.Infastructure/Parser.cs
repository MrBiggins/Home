using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infastructure.Interface;

namespace Core.Infastructure {
    public class Parser : ICompiler {


        public List<char> ListOfChars;
        public List<char> ListOfInts;
        public List<char> ListOfDelimeiters;

        public List<CharacterItem> GlobalIndexList;

        private readonly string _keyWordTable;



        public Parser() {
            ListOfChars = new List<char>();
            ListOfInts = new List<char>();
            ListOfDelimeiters = new List<char>();
            GlobalIndexList = new List<CharacterItem>();
            _keyWordTable = File.ReadAllText(@"C:/GIT/Compiler.Core/LexicalTest/bin/Debug/XML/keyWordList.xml");
        }

        public void GetChar(char a) {
            var type = CheckCharacterType(a);

            switch (type) {
                case CharacterType.WhiteSPace:
                    MapKeywords(type);
                    break;

                case CharacterType.Delimiter:
                    MapKeywords(type);
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



        public void Lookup(string lexem, CharacterType type) {
            //TODO: Check if keword or if delimiter in tables!
            // if type is delimeter but not found=> then throw exception error goto START

            var keyWordTable = KeyWords.Deserialize(_keyWordTable);
            var isKeword = keyWordTable.KeyWord.Any(e => e.value.ToUpper() == lexem.ToUpper());
            if (isKeword) {
                var keyWordsKeyWord = keyWordTable.KeyWord.FirstOrDefault(e => e.value == lexem);
                if (keyWordsKeyWord != null)
                    GlobalIndexList.Add(new CharacterItem {
                        LookupIndex = keyWordsKeyWord.index,
                        IsKeyword = true,
                        Value = lexem
                    });
            }
        }

        public void AddCharacter(string a) {

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


        private void MapKeywords(CharacterType type) {
            var arrayOfChars = ListOfChars.ToArray();
            var str = new string(arrayOfChars);
            Lookup(str, type);
            ListOfChars.Clear();
        }
    }
}
