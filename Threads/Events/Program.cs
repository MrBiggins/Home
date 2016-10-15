using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Events.Events;
using ManualResetEvent = Events.Events.ManualResetEvent;

namespace Events {
    internal class Program {
        private static readonly ManualResetEvent Event;

        static readonly int lowerRange = 1;
        static readonly int upperRange = 100;
        static readonly string filename = @"C:\\Development\test.dat";

        static Program() {
            Event = new ManualResetEvent();
            Event.OnFileReady += EventOnOnFileReady;
        }

        private static void Main(string[] args) {
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, eventArgs) => {

                var r = new Random();


                using (var writer = new StreamWriter(filename, false, Encoding.UTF8)) {
                    for (var i = 1; i < 100; i++) {
                        var number = r.Next(lowerRange, upperRange);

                        writer.Write($"{number} ");
                    }
                    writer.Flush();
                    writer.Close();
                }
                Event.SetReady(true);

            };

            bw.RunWorkerCompleted += (sender, eventArgs) => {
                if (eventArgs.Error != null) {
                    Console.WriteLine(eventArgs.Error.Message);
                }
            };

            bw.RunWorkerAsync();

            Console.ReadLine();

        }

        private static void EventOnOnFileReady(object sender, ManualResetEventArgs manualResetEventArgs) {
            var t1 = new Thread(ReadFile);
            t1.Start();
            var t2 = new Thread(Sum);
            t2.Start();
            t1.Join();
            t2.Join();
        }

        private static void ReadFile(object o) {
            var file = File.ReadAllText(filename);
            var array = file.Split(' ');
            foreach (var s in array) {
                Console.Write($"{s} ");
            }
        }

        private static void Sum(object o) {
            var file = File.ReadAllText(filename);
            var array = file.Split(' ');
            array = array.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var intArr = Array.ConvertAll(array, int.Parse);
            var sum = intArr.Sum();
            Console.WriteLine($"This is summ: {sum}");

        }
    }
}
