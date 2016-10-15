using System;
using System.Collections.Generic;
using System.Threading;

namespace Threads {
    internal class Program {

        public static List<Thread> TreadList = new List<Thread>();

        private static void Main(string[] args) {

            bool createdNew;

            var m = new Mutex(true, "myApp", out createdNew);

            if (!createdNew) {
                Console.WriteLine(  "myApp is already running! Multiple Instances");
                Console.ReadLine();
                return;
            }

            var t = new Thread(Function);
            TreadList.Add(t);
            t.Start();
            var t2 = new Thread(Function2);
            TreadList.Add(t2);
            t2.Start();

            var t3 = new Thread(FunctionMain);
            TreadList.Add(t3);
            t3.Start();
            
            foreach (var thread in TreadList) {
                thread.Join();
            }
           // ShowThreadInfo();
            Console.ReadLine();

        }

        public static void Function() {
            for (var i = 0; i < 100; i++) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {i}");
            }
        }

        public static void Function2() {
            for (var i = 0; i < 100; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {i}");
            }
        }

        public static void FunctionMain() {
            for (var i = 0; i < 100; i++) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {i}");
            }
        }

        private static void ShowThreadInfo() {
            int workerThreads;
            int completionPortThreads;
            Console.WriteLine("\n");
            
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine($"Max treads: {workerThreads}");
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine($"Available treads: {workerThreads}");

            Console.WriteLine("Начало работы программы");
            ShowThreadInfo();
            Console.WriteLine("Запускаем Task1 в потоке из пула потоков");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            ShowThreadInfo();
            Console.WriteLine("Запускаем Task2 в потоке из пула потоков");
            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem(Task2);
            ShowThreadInfo();
            Console.WriteLine("Главный поток.");
            Thread.Sleep(1000);
            Console.WriteLine("Главный поток завершен.\n");
            Console.WriteLine("Task1 и Task2 закончили работу");
            ShowThreadInfo();
            Console.ReadKey();

        }


        private static void Task1(object state) {
            Thread.CurrentThread.Name = "1";
            Console.WriteLine("Поток {0}:{1}", Thread.CurrentThread.Name,
            Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            Thread.Sleep(200);
        }

        private static void Task2(object state) {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine("Поток {0}:{1}", Thread.CurrentThread.Name,
            Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(200);
        }
    }
}
