﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;


namespace WCF.ServiceLib.Binding
{
    /// <summary>
    /// IHello接口
    /// </summary>
    [ServiceContract]
    public interface IHello
    {
        /// <summary>
        /// 打招呼方法
        /// </summary>
        /// <param name="name">人名</param>
        /// <returns></returns>
        [OperationContract]
        string SayHello(string name);
    }
}
