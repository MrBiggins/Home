namespace Core.Infastructure {
    public class CharacterItem {
        public int LookupIndex { get; set; }
        public string Value { get; set; }
        public bool IsKeyword { get; set; }
        public bool IsConstant { get; set; }
    }
}
