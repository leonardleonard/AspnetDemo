using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestExcept();
            //TestListint();

            //CreateProcess();

            if (TestIfAlreadyRunning())
            {
                System.Console.WriteLine("This app is already running");
            }
            else
            {
                System.Console.WriteLine("This app is not running");

            }



        }



        static bool TestIfAlreadyRunning()
        {
            Process processCurrent = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (processCurrent.Id != process.Id)
                {
                    if (processCurrent.ProcessName == process.ProcessName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 创建process
        /// </summary>
        public static void CreateProcess()
        {
            Process process = Process.Start("notepad.exe", "hello.txt");
            Thread.Sleep(1000);
            process.Kill();
        }

        public static void TestListint()
        {
            string gameids = "1,2,3";
            List<int> newGameIds = gameids.Split(',').Select(s => int.Parse(s)).ToList();

            foreach (var item in newGameIds)
            {
                Console.WriteLine(item);
            }

        }

        public static void TestExcept()
        {

            int[] oldTag = new int[] { 1, 2, 3 };
            int[] newTag = new int[] { 1, 2, 5 };

            var notExistsTags = oldTag.Except(newTag);

            foreach (var item in notExistsTags)
            {
                Console.WriteLine(item);
            }
        }


    }
}
