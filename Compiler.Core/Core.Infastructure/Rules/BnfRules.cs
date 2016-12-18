using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compiler.Core.Rules {
    public class BnfRules {


        private static string _originalLineOfCode;

        public static bool AsignmentRule(string[] linesToCheck) {
            foreach (var codeline in linesToCheck) {
                _originalLineOfCode = codeline;
                var cdl = codeline.Split(' ');
                var list = cdl.ToList();
                list.RemoveAll(string.IsNullOrEmpty);
                var result1 = AsignmentRule1(list.ToArray());
                if (!result1) {
                    var result2 = AsignmentRuleWithArray(list.ToArray());
                    if (!result2) {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool BeginRule(string linesToCheck) {
            var arrayOflines = linesToCheck.Split(' ');
            var result = BeginRule1(arrayOflines);
            if (!result) {
                result = BeginRule2(arrayOflines);
            }
            return result;
        }

        public static bool ProcedureRule(string lineToCheck) {
            var arrayOflines = lineToCheck.Split('(', ')');
            var result = ProcedureRule1(arrayOflines);
            return result;
        }

        public static bool WhileRule(string linesToCheck) {
            var arrayOflines = linesToCheck.Split(' ');
            var result = WhileRule1(arrayOflines);
            return result;
        }

        public static bool FunctionRule(string linesToCheck) {
            var arrayOflines = linesToCheck.Split('(', ')');
            var result = FunctionRule1(arrayOflines);
            return result;
        }

        private static bool AsignmentRule1(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 0:
                        if (linesToCheck[i] != "var")
                            return false;
                        break;
                    case 1:
                        if (!Regex.IsMatch(linesToCheck[i], @"^[a-zA-Z]+\:?$"))
                            return false;
                        break;
                    case 2:
                        if (!Regex.IsMatch(linesToCheck[i], @"^[a-zA-Z]+\;?$"))
                            return false;
                        break;

                }
            }
            return true;
        }

        private static bool AsignmentRuleWithArray(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 0:
                        if (!Regex.IsMatch(linesToCheck[i], @"^[a-zA-Z]+\:?$"))
                            return false;
                        break;
                    case 1:
                        if (linesToCheck[i].ToLower().Contains("array")) {
                            var res = CheckArrayGrammar(_originalLineOfCode);
                            if (!res) {
                                return false;
                            }
                            return true;
                        }

                        break;
                }
            }
            return true;
        }

        private static bool ProcedureRule1(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 0:
                        var lines = linesToCheck[i].Split(' ');
                        for (var j = 0; j < lines.Count(); j++) {
                            switch (j) {
                                case 0:
                                    if (lines[j] != "procedure") {
                                        return false;
                                    }
                                    break;
                                case 1:
                                    var splitName = lines[j].Split('.');
                                    if (splitName.Count() > 1) {
                                        if (!Regex.IsMatch(splitName[0], @"^[a-zA-Z]+\;?$")) {
                                            return false;
                                        }
                                        if (!Regex.IsMatch(splitName[1], @"^[a-zA-Z]+\;?$")) {
                                            return false;
                                        }
                                    }
                                    else {
                                        if (!Regex.IsMatch(splitName[0], @"^[a-zA-Z]+\;?$")) {
                                            return false;
                                        }
                                    }
                                    break;
                            }
                        }

                        break;
                    case 1:
                        var splitetedVer = linesToCheck[i].Split(',', ';');
                        for (var j = 0; j < splitetedVer.Count(); j++) {
                            if (!Regex.IsMatch(splitetedVer[j], @"^[a-zA-Z]+\;?$")) {
                                var veriables = splitetedVer[j].Split(':');
                                foreach (var item in veriables) {
                                    if (!Regex.IsMatch(item.Replace(" ", string.Empty), @"^[a-zA-Z]+\;?$")) { return false; }
                                }
                            }
                        }
                        break;

                    case 2:
                        if (linesToCheck[i] != ";")
                            return false;
                        break;
                }
            }
            return true;
        }

        private static bool BeginRule1(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 0:
                        if (linesToCheck[i] != "begin") { return false; }
                        break;
                    case 1:
                        if (!Regex.IsMatch(linesToCheck[i], @"^[a-zA-Z]+\;?$")) {
                            return false;
                        }
                        break;
                    case 2:
                        if (linesToCheck[i] != ":=") { return false; }
                        break;
                    case 3:
                        if (!FunctionRule(linesToCheck[i])) { return false; }
                        break;
                }
            }
            return true;
        }

        private static bool BeginRule2(IReadOnlyList<string> linesToCheck) {

            //TODO check if lines has only begin!
            return true;
        }

        private static bool FunctionRule1(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 0:
                        if (!Regex.IsMatch(linesToCheck[i], @"[a-zA-Z]")) {
                            return false;
                        }
                        break;
                    case 1:
                        var splittedVeriables = linesToCheck[i].Split(',');
                        for (var j = 0; j < splittedVeriables.Count(); j++) {

                            if (!Regex.IsMatch(splittedVeriables[j], @"^[a-zA-Z0-9 ]")) {
                                if (!Regex.IsMatch(splittedVeriables[j], @"^[A-Za-z].[A-Za-z]")) {
                                    if (!Regex.IsMatch(splittedVeriables[j], @"^\$(?=.*\d)\d{0,10}")) {
                                        if (!Regex.IsMatch(splittedVeriables[j], @"/^[A-Za-z0-9.A-Za-z0-9 + ]+$/")) {
                                            return false;
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 2:
                        if (linesToCheck[i] != ";") {
                            return false;
                        }
                        break;

                }
            }
            return true;
        }

        private static bool WhileRule1(IReadOnlyList<string> linesToCheck) {
            for (var i = 0; i < linesToCheck.Count(); i++) {
                switch (i) {
                    case 1:
                        if (linesToCheck[i] != "while") { return false; }
                        break;
                    case 2:
                        if (!Regex.IsMatch(linesToCheck[i], @"^[a-zA-Z]+\;?$")) { return false; }
                        break;
                    case 3:
                        if (linesToCheck[i] != ">" /*| linesToCheck[i] != "<" | linesToCheck[i] != "=="*/) { return false; }
                        break;
                    case 4:
                        if (!Char.IsDigit(linesToCheck[i].ToCharArray().FirstOrDefault())) { return false; }
                        break;
                    case 5:
                        if (linesToCheck[i] != "do") { return false; }
                        break;
                }
            }
            return true;
        }

        #region ArrayGrammar

        private static bool CheckArrayGrammar(string arrayCodline) {
            var splittedCodeline = arrayCodline.Split(':');
            for (var i = 0; i < splittedCodeline.Count(); i++) {
                switch (i) {
                    case 0:
                        if (!Regex.IsMatch(splittedCodeline[i], @"[a-zA-Z]")) {
                            return false;
                        }
                        break;
                    case 1:
                        var transformArrayStructure = splittedCodeline[i].Split('[');
                        for (var j = 0; j < transformArrayStructure.Count(); j++) {
                            switch (j) {
                                case 0:
                                    if (transformArrayStructure[i].ToLower().Contains("array")) {
                                        return false;
                                    }
                                    break;
                                case 1:
                                    var splitArraybody = transformArrayStructure[i].Split(']');
                                    for (var k = 0; k < splitArraybody.Count(); k++) {
                                        switch (k) {
                                            case 0:
                                                var rangeCheck = splitArraybody[k].Split(' ');
                                                for (var l = 0; l < rangeCheck.Count(); l++) {
                                                    switch (l) {
                                                        case 0:
                                                            if (string.IsNullOrEmpty(rangeCheck[l])) {
                                                                return false;
                                                            }
                                                            break;
                                                        case 1:
                                                            if (rangeCheck[l] != "-") {
                                                                return false;
                                                            }
                                                            break;
                                                        case 2:
                                                            if (string.IsNullOrEmpty(rangeCheck[l])) {
                                                                return false;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                            case 1:
                                                var typecheck = splitArraybody[k].Split(' ');
                                                var list = typecheck.ToList();
                                                list.RemoveAll(string.IsNullOrEmpty);
                                                for (var l = 0; l < list.Count(); l++) {
                                                    switch (l) {
                                                        case 0:
                                                            if (list[l] != "of") {
                                                                return false;
                                                            }
                                                            break;
                                                        case 1:
                                                            if (string.IsNullOrEmpty(list[l])) {
                                                                return false;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }

                        break;
                }
            }
            return true;
        }

        #endregion
    }
}
