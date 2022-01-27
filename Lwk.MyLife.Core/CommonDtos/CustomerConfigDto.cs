using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lwk.MyLife.Core.CommonDtos
{
    /// <summary>
    /// 数据返回模型基类
    /// </summary>
    public class CustomerConfigDto
    {
        public static string Config { get { return "CustomerConfig"; } }

        public static string DbConn { get; set; }

        public static string DbType { get; set; }

        public static string Port { get; set; }
    }
}
