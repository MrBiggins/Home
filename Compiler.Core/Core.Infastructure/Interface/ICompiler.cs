namespace Core.Infastructure.Interface {
    public interface ICompiler {
        void GetChar(char a);
        void Lookup(string lexem, CharacterType type);
        void AddCharacter(string a);
        CharacterType CheckCharacterType(char a);
        void CheckNextSymbol();
        void Start(string code);
    }
}
