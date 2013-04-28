using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestExcept();
            //TestListint();
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
