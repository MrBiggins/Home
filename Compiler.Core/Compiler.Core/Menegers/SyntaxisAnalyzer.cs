using System;
using System.Linq;
using Compiler.Core.Rules;

namespace Compiler.Core.Menegers {
    public class SyntaxisAnalyzer {

        public void CheckInputGrammar(string lineOfCode, int lineNumber) {
            if (String.IsNullOrEmpty(lineOfCode)) {
                return;}
                var splittedLineOfCode = lineOfCode.Split(' ');
                var list = splittedLineOfCode.ToList();
                list.RemoveAll(string.IsNullOrEmpty);
                switch (list[0].ToLower()) {
                    case "var":
                        CallAsignmentRule(lineOfCode, lineNumber);
                        break;
                    case "procedure":
                        CallProcedureRule(lineOfCode, lineNumber);
                        break;
                    case "begin":
                        CallBeginRule(lineOfCode, lineNumber);
                        break;
                    case "while":
                        CallWhileRule(lineOfCode, lineNumber);
                        break;
                    default:
                        CallFunctionRule(lineOfCode, lineNumber);
                        break;
                }
            
        }

        private static void CallFunctionRule(string lineOfCode, int lineNumber) {
            var isAssignRule = BnfRules.FunctionRule(lineOfCode);
            if (!isAssignRule) {
                throw new Exception(String.Format("Failed to compile. Error on line: {0}", lineNumber));
            }
        }

        private static void CallWhileRule(string lineOfCode, int lineNumber) {
            var isAssignRule = BnfRules.WhileRule(lineOfCode);
            if (!isAssignRule) {
                throw new Exception(String.Format("Failed to compile. Error on line: {0}", lineNumber));
            }
        }

        private static void CallBeginRule(string lineOfCode, int lineNumber) {
            var isAssignRule = BnfRules.BeginRule(lineOfCode);
            if (!isAssignRule) {
                throw new Exception(String.Format("Failed to compile. Error on line: {0}", lineNumber));
            }
        }

        private static void CallProcedureRule(string lineOfCode, int lineNumber) {
            //var linesOfCode = lineOfCode.Split(' ');
            //var list = linesOfCode.ToList();
            //list.RemoveAll(string.IsNullOrEmpty);
            var isAssignRule = BnfRules.ProcedureRule(lineOfCode);
            if (!isAssignRule) {
                throw new Exception(String.Format("Failed to compile. Error on line: {0}", lineNumber));
            }
        }

        private static void CallAsignmentRule(string lineOfCode, int lineNumber) {
            var splittedLineOfCode = lineOfCode.Split(';');
            var list = splittedLineOfCode.ToList();
            list.RemoveAll(string.IsNullOrEmpty);
            var isAssignRule = BnfRules.AsignmentRule(list.ToArray());
            if (!isAssignRule) {
                throw new Exception(String.Format("Failed to compile. Error on line: {0}", lineNumber));
            }
        }
    }
}
