namespace Generation_GC {
    public class Car {
        private readonly int _speed;
        private readonly string _name;
        public Car(string name, int speed) {
            _name = name;
            _speed = speed;
        }
        public override string ToString() {
            return $"{_name} едет со скоростью {_speed} Км/ч";
        }
    }
}
