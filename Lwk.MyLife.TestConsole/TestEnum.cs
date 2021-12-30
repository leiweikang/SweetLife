using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lwk.MyLife.TestConsole
{
    /// <summary>
    /// 测试枚举
    /// </summary>
    internal enum TestEnum
    {

        [Description("TestA Description")]
        TestA = 11,

        [Description("TestB Description")]
        TestB = 99

    }
}
