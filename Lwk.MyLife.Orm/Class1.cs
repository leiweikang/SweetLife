using SqlSugar;

namespace Lwk.MyLife.Orm
{
    public class Class1
    {
        //创建数据库对象 SqlSugarScope 用法小有区别
        static SqlSugarScope scope = new SqlSugarScope(new ConnectionConfig()
        {
            ConnectionString = "server=sh-cdb-39u8tkva.sql.tencentcdb.com;database=mydatabase;uid=root;pwd=root;port=59588;",//连接符字串
            DbType = DbType.MySql,//数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        },
         db => {

      //（A）这里配置参数：所有上下文都生效 
      // db.Aop.xxx=xxxx..
  });
    }
}