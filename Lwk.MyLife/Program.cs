var builder = WebApplication.CreateBuilder(args);
var serilogMsg = builder.Configuration["Serilog"];

builder.Logging.ClearProviders();//�����������logging���ṩ���������������־��¼��Ȼ����
//.net6 ������Host.UseSerilog����
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