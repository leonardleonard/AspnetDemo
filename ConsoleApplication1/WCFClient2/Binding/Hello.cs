using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.ServiceModel;

namespace WCFClient2.Binding
{
    public class Hello
    {
        /// <summary>
        /// Hello
        /// </summary>
        /// <param name="name">名字</param>
        public string SayHello(string name)
        {
            // 写代码的方式做client
            // IHello proxy = ChannelFactory<IHello>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:54321/Binding/Hello"));

            var proxy = new BindingSvc.Hello.HelloClient();

            string tmp = (proxy.SayHello(name));

            proxy.Close();
            return tmp;
        }
    }
}
