using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient2
{
    class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Binding.Hello().SayHello("iam lili"));


            Console.WriteLine("按<ENTER>停止服务");
            Console.ReadLine();
        }
    }
}
