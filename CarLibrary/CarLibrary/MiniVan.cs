using System.Windows.Forms;

namespace CarLibrary
{
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }

        public override void TurboBoost()
        {
            egnState = EngineState.engineDead;
            MessageBox.Show("Your engine block exploded!", "Eek!");
        }
    }
}
