using Lwk.MyLife.Dtos;
using SqlSugar;

namespace Lwk.MyLife;
public class DbContext
{
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "server=sh-cdb-39u8tkva.sql.tencentcdb.com;database=test;uid=root;pwd=admin123;port=59588;",
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了
                                         //InitKey默认SystemTable
        });
    }
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
    public SimpleClient<StudentDto> StudentDto { get { return new SimpleClient<StudentDto>(Db); } }//用来处理Student表的常用操作
}
