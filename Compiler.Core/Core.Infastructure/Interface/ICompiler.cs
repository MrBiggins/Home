namespace Core.Infastructure.Interface {
    public interface ICompiler {
        void GetChar(char a);
        void Lookup(string lexem);
        void Add(string identificator, bool isKeyword);
        CharacterType CheckCharacterType(char a);
        void CheckNextSymbol();
        void Start(string code);
    }
}
