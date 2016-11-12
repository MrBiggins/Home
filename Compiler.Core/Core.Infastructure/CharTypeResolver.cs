namespace Core.Infastructure {
    public class CharTypeResolver {
        public static CharacterType Resolve(char a) {

            if (char.IsDigit(a)) {
                return CharacterType.Digit;
            }
            if (char.IsLetter(a)) {
                return CharacterType.Letter;
            }
           /* if (char.IsSeparator(a)) {
                return CharacterType.Delimiter;
            }*/
            if (char.IsWhiteSpace(a)) {
                return CharacterType.WhiteSPace;
            }
            return CharacterType.Delimiter;
        }
    }


    public enum CharacterType {
        Digit,
        Letter,
        Delimiter,
        Uknown,
        WhiteSPace
    }
}
