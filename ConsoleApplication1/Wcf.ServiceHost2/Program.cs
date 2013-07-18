using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.ServiceHost2
{
    class Program
    {
        static void Main(string[] args)
        {
            // host WCF.ServiceLib.Binding.Hello
            new Wcf.ServiceHost2.Binding.Hello().Launch();

            Console.WriteLine("按<ENTER>停止服务");
            Console.ReadLine();

        }
    }
}
