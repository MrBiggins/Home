using System;

namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }

        public override void TurboBoost()
        {
            //Changes in carLib prject according to task!!
            Console.WriteLine("This is overwritten method here!");
        }
    }
}
