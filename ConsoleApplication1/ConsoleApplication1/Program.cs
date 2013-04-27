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
        }

        public static void TestExcept()
        {

            int[] oldTag = new int[] { 1, 2, 3, 4 };
            int[] newTag = new int[] { 1, 2, 5 };

            var notExistsTags = oldTag.Except(newTag);

            foreach (var item in notExistsTags)
            {
                Console.WriteLine(item);
            }
        }


    }
}
