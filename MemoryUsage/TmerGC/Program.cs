using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TmerGC {
    class Program {
        static void Main(string[] args) {
            {
                var timer = new Timer(Method, "Hello", 0, 200);
                Console.ReadLine();
            }
           
        }

        static void Method(object state) {
            Console.WriteLine(state);
            GC.Collect();
        }
    }
}
