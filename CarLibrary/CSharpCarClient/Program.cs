using CarLibrary;
using System;

namespace CSharpCarClient {
    internal class Program {
        static void Main(string[] args) {
            var viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();
            var mv = new MiniVan();
            mv.TurboBoost();
            Console.WriteLine("Done. Press Enter to terminate");
            Console.ReadLine();
        }
    }
}
