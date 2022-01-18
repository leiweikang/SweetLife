using Lwk.MyLife;

var builder = WebApplication.CreateBuilder(args);
var serilogMsg = builder.Configuration["Serilog"];

builder.Logging.ClearProviders();//必须主动清除logging的提供器，否则自身的日志记录必然存在
//.net6 必须用Host.UseSerilog方法
builder.Host.UseSerilog((hbc, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(hbc.Configuration));

//builder.Services.AddTransient(typeof(DbContext));//非线程安全的使用AddTransient
builder.Services.AddSingleton(typeof(DbContext));//组件始终是共享的
//builder.Services.AddScoped(typeof(DbContext));//主要原因是从数据库获得的实体将附加到请求中的所有组件看到的相同上下文
builder.Services.AddControllers()
                .AddJsonOptions(config =>
                {
                    config.JsonSerializerOptions.PropertyNamingPolicy = null;//解决首字母小写问题
                });
builder.Services.AddMvcCore(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(new CustomerActionFilter());//自定义动作过滤器
    options.Filters.Add(new ExceptionFilter());//自定义异常处理
});
var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapControllers();
app.Run();