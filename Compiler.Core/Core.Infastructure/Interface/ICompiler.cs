namespace Core.Infastructure.Interface {
    public interface ICompiler {
        void GetChar(char a);
        bool Lookup(string lexem);
        void Add(string identificator, bool isKeyword);
        CharacterType CheckCharacterType(char a);
        bool CheckNextSymbol(char current);
        void Start(string code);
    }
}
