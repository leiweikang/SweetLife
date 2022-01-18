using Lwk.MyLife;

var builder = WebApplication.CreateBuilder(args);
var serilogMsg = builder.Configuration["Serilog"];

builder.Logging.ClearProviders();//�����������logging���ṩ���������������־��¼��Ȼ����
//.net6 ������Host.UseSerilog����
builder.Host.UseSerilog((hbc, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(hbc.Configuration));

//builder.Services.AddTransient(typeof(DbContext));//���̰߳�ȫ��ʹ��AddTransient
builder.Services.AddSingleton(typeof(DbContext));//���ʼ���ǹ����
//builder.Services.AddScoped(typeof(DbContext));//��Ҫԭ���Ǵ����ݿ��õ�ʵ�彫���ӵ������е����������������ͬ������
builder.Services.AddControllers()
                .AddJsonOptions(config =>
                {
                    config.JsonSerializerOptions.PropertyNamingPolicy = null;//�������ĸСд����
                });
builder.Services.AddMvcCore(options =>
{
    options.EnableEndpointRouting = false;
    options.Filters.Add(new CustomerActionFilter());//�Զ��嶯��������
    options.Filters.Add(new ExceptionFilter());//�Զ����쳣����
});
var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapControllers();
app.Run();