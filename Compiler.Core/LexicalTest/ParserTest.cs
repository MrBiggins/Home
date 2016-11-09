using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexicalTest {
    [TestClass]
    public class ParserTest {
        [TestMethod]
        public void ParseInputCodeString()
        {
            var code = File.ReadAllText(@"Source.txt");
        }
    }
}
