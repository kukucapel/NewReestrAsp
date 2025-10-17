using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Services;
using NewReestrAsp.Profiles;

var builder = WebApplication.CreateBuilder(args);



//Бд
builder.Services.AddDbContext<ReestrContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

//свагер
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


//СЕРВИСЫ
//Общие
builder.Services.AddScoped<MetaService>(); //мета
builder.Services.AddAutoMapper(typeof(MappingProfile)); //маппер
//Сотрудники
builder.Services.AddScoped<EmployeesService>();
//Образование
builder.Services.AddScoped<EmployeeEducationService>();
//Архив сотрудников
builder.Services.AddScoped<EmployeesArchiveService>();
//Образование архива
builder.Services.AddScoped<EmployeeEducationArchiveService>();
//Юниты
builder.Services.AddScoped<UnitService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    app.MapOpenApi();
    
}

// app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();

app.Run();
