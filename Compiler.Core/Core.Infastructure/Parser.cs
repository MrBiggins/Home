using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infastructure.Interface;

namespace Core.Infastructure {
    public class Parser : ICompiler {


        public List<char> ListOfChars;
        public List<char> ListOfInts;
        public List<char> ListOfDelimeiters;

        public Parser() {
            ListOfChars = new List<char>();
            ListOfInts = new List<char>();
            ListOfDelimeiters = new List<char>();
        }

        public void GetChar(char a) {
            var type = CheckCharacterType(a);
            if (type != CharacterType.WhiteSPace) {
                if (type == CharacterType.Letter) {
                    ListOfChars.Add(a);
                }
                if (type == CharacterType.Digit) {
                    ListOfInts.Add(a);
                }
                if (type == CharacterType.Delimiter) {
                    Lookup(a.ToString(), type);
                    ListOfDelimeiters.Add(a);
                }
            } else {
                var arrayOfChars = ListOfChars.ToArray();
                var str = new string(arrayOfChars);
                Lookup(str, type);
            }
        }

        public void Lookup(string lexem, CharacterType type) {
            //TODO: Check if keword or if delimiter in tables!
            // if type is delimeter but not found=> then throw exception error goto START
            if (type == CharacterType.Letter) {
               //KeywordCheck
            }
            if (type == CharacterType.Delimiter) {
                //delimier check if equals : save and get next if next equals =, then it wood be :=
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
    }
}
