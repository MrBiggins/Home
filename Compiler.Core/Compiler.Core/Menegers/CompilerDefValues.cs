using System.Xml;
using Compiler.UI;

namespace Compiler.Core.Menegers {
    public class CompilerDefValues {

        public static KeyWords AcceptableKeyWordList;
        public static SpecialCharacters AcceptableSpecSymbols;

        public static void LoadAllValues() {
            var xmldoc = new XmlDocument();
            xmldoc.Load("keyWordList.xml");
            AcceptableKeyWordList = KeyWords.Deserialize(xmldoc.InnerXml);

            var xmldoc2 = new XmlDocument();
            xmldoc2.Load("SpecialCharacters.xml");
            AcceptableSpecSymbols = SpecialCharacters.Deserialize(xmldoc2.InnerXml);

        }
    }
}
