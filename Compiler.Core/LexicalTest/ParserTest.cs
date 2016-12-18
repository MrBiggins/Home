using System;
using System.IO;
using System.Linq;
using Core.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexicalTest {
    [TestClass]
    public class ParserTest {
        [TestMethod]
        public void ParseInputCodeString() {
            var code = File.ReadAllText(@"Source.txt");

            var parser = new Parser();
            parser.Start(code);

            var keyWords = parser.GlobalIndexList.Where(e => e.IsKeyword).Select(d => d.Value).ToList();
            var ids = parser.GlobalIndexList.Where(e => !e.IsKeyword).Select(d => d.Value).ToList();
            var constants = parser.GlobalIndexList.Where(e => e.IsConstant).Select(d => d.Value).ToList();
        }

        [TestMethod]
        public void AnalyzeCode() {
            var code = File.ReadAllLines(@"Source.txt");
            var lineForAnalise = code.FirstOrDefault();
            var syntaxCheck = new Compiler.Core.Menegers.SyntaxisAnalyzer();
            syntaxCheck.CheckInputGrammar(lineForAnalise, 0);
        }
    }
}
