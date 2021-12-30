// See https://aka.ms/new-console-template for more information


using Lwk.MyLife.Core.Extensions;
using Lwk.MyLife.TestConsole;
using SqlSugar;

//Console.WriteLine("测试枚举TestA");
//Console.WriteLine(TestEnum.TestA.GetEnumName());
//Console.WriteLine(TestEnum.TestA.GetEnumDescription());
//Console.WriteLine(TestEnum.TestA.GetEnumIntValue());
//Console.WriteLine(TestEnum.TestA.GetEnumStringValue());

//Console.WriteLine("测试枚举TestB");
//Console.WriteLine(TestEnum.TestB.GetEnumName());
//Console.WriteLine(TestEnum.TestB.GetEnumDescription());
//Console.WriteLine(TestEnum.TestB.GetEnumIntValue());
//Console.WriteLine(TestEnum.TestB.GetEnumIntValue().GetType().FullName);
//Console.WriteLine(TestEnum.TestB.GetEnumStringValue());
//Console.WriteLine(TestEnum.TestB.GetEnumStringValue().GetType().FullName);

//Console.WriteLine("Hello, World!");
//Console.ReadLine();
//Console.ReadLine();
//Console.ReadLine();

//创建数据库对象
SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
{
    ConnectionString = "server=sh-cdb-39u8tkva.sql.tencentcdb.com;database=test;uid=root;pwd=admin123;port=59588;",
    DbType = DbType.MySql,
    IsAutoCloseConnection = true
});

//调试SQL事件，可以删掉
db.Aop.OnLogExecuting = (sql, pars) =>
{
    Console.WriteLine(sql);//输出sql,查看执行sql
};

     //查询表的所有
var list = db.Queryable<Student>().ToList();

////插入
//db.Insertable(new Student() { SchoolId = 1, Name = "jack" }).ExecuteCommand();
////插入
//db.Insertable(new Student() { SchoolId = 2, Name = "jack1" }).ExecuteCommand();
////插入
//db.Insertable(new Student() { SchoolId = 3, Name = "jack2" }).ExecuteCommand();

//更新
//db.Updateable(new Student() { Id = 1, SchoolId = 2, Name = "jack3333333" }).ExecuteCommand();
//db.Updateable(new Student() { Id = 2, SchoolId = 3, Name = "jack3333333" }).ExecuteCommand();
//db.Updateable(new Student() { Id = 3, SchoolId = 4, Name = "jack3333333" }).ExecuteCommand();

//删除
db.Deleteable<Student>().Where(it => it.Id == 1).ExecuteCommand();