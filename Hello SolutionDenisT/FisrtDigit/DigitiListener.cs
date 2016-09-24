using System;

namespace FisrtDigit {
    public class DigitiListener {
        public virtual int EnterDigit() {
            Console.WriteLine("Enter 1st number>25");
            var number = Console.ReadLine();
            if (number != null) {
                int result;
                var isPrsed = int.TryParse(number, out result);
                if (isPrsed) {
                    return result;
                }
            }
            return 0;
        }
    }
}
