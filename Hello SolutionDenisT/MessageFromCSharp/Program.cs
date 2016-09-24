using System;

namespace MessageFromCSharp {
    internal class Program {
        private static void Main(string[] args) {
            var messageVb = new MessageFromVB.VbMessage();
            messageVb.Message();
            Console.WriteLine(@"This message comes from C# Layer");
            Console.ReadLine();
        }
    }
}
