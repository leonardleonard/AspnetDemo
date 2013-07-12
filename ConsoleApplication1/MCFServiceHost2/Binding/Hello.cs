using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace MCFServiceHost2.Binding
{
    /// <summary>
    /// host WCF.ServiceLib.Binding.Hello的类
    /// </summary>
    public class Hello
    {
        /// <summary>
        /// 启动WCF.ServiceLib.Binding.Hello服务
        /// </summary>
        public void Launch()
        {
            ServiceHost host = new ServiceHost(typeof(WcfLib.Binding.Hello));
            host.Open();

            Console.WriteLine("服务已启动(WCF.ServiceLib.Binding.Hello)");
        }
    }
}
