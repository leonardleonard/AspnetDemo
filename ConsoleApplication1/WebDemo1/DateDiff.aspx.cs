using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo1
{
    public partial class DateDiff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime expiredTime = DateTime.Parse("2013-5-20 12:00:00");
            DateTime createTime = DateTime.Parse("2013-5-18 13:00:00");

            TimeSpan ts_expiredTime = new TimeSpan(expiredTime.Ticks); //获取当前时间的刻度数
            TimeSpan ts_createTime = new TimeSpan(createTime.Ticks);

            TimeSpan ts = ts_expiredTime.Subtract(ts_createTime).Duration(); //时间差的绝对值
            int expiredSeconds = Convert.ToInt32(ts.TotalSeconds);

            Response.Write(expiredSeconds.ToString());
        }
    }
}