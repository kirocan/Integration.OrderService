using Integration.OrderService.Data;
using Integration.OrderService.Mapping;
using Integration.OrderService.Middlewares;
using Integration.OrderService.Repositories.Impl;
using Integration.OrderService.Repositories.Interfaces;
using Integration.OrderService.Services.Impl;
using Integration.OrderService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Контроллеры (API).
builder.Services.AddControllers();

// Swagger (документация API).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Integration Order API",
        Version = "v1"
    });

    // Подключаем XML-комментарии (summary/param/returns) из кода.
    var xmlFileName = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// База данных (PostgreSQL).
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI: сервисы и репозитории.
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Клиенты внешних сервисов (заглушки для студентов).
builder.Services.AddScoped<IProductClient, ProductClient>();
builder.Services.AddScoped<IPaymentPublisher, PaymentPublisher>();
builder.Services.AddScoped<IAnalyticsPublisher, AnalyticsPublisher>();

// AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Миграции.
DbInitializer.MigrateAndSeed(app.Services);

// HTTP-конвейер (middleware).
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integration Order API");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
