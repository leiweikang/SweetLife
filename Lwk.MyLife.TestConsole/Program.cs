// See https://aka.ms/new-console-template for more information


using Lwk.MyLife.Core.Extensions;
using Lwk.MyLife.TestConsole;

Console.WriteLine("测试枚举TestA");
Console.WriteLine(TestEnum.TestA.GetEnumName());
Console.WriteLine(TestEnum.TestA.GetEnumDescription());
Console.WriteLine(TestEnum.TestA.GetEnumIntValue());
Console.WriteLine(TestEnum.TestA.GetEnumStringValue());

Console.WriteLine("测试枚举TestB");
Console.WriteLine(TestEnum.TestB.GetEnumName());
Console.WriteLine(TestEnum.TestB.GetEnumDescription());
Console.WriteLine(TestEnum.TestB.GetEnumIntValue());
Console.WriteLine(TestEnum.TestB.GetEnumIntValue().GetType().FullName);
Console.WriteLine(TestEnum.TestB.GetEnumStringValue());
Console.WriteLine(TestEnum.TestB.GetEnumStringValue().GetType().FullName);

Console.WriteLine("Hello, World!");
Console.ReadLine();
Console.ReadLine();
Console.ReadLine();