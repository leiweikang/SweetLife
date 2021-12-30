var builder = WebApplication.CreateBuilder(args);
var serilogMsg = builder.Configuration["Serilog"];

builder.Logging.ClearProviders();//必须主动清除logging的提供器，否则自身的日志记录必然存在
//.net6 必须用Host.UseSerilog方法
builder.Host.UseSerilog((hbc, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(hbc.Configuration));

builder.Services.AddControllers();
builder.Services.AddMvcCore(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(new CustomerActionFilter());
    options.Filters.Add(new ExceptionFilter());
});

var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapControllers();
app.Run();  