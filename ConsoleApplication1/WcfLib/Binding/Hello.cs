﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfLib.Binding
{
    /// <summary>
    /// Hello类
    /// </summary>
    public class Hello : IHello
    {
        /// <summary>
        /// 打招呼方法
        /// </summary>
        /// <param name="name">人名</param>
        /// <returns></returns>
        public string SayHello(string name)
        {
            return "Hello: " + name;
        }
    }
}
