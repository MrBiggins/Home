using System;
using System.IO;
using Core.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexicalTest {
    [TestClass]
    public class ParserTest {
        [TestMethod]
        public void ParseInputCodeString()
        {
            var code = File.ReadAllText(@"Source.txt");
            var parser = new Parser();
            parser.Start(code);
        }
    }
}
