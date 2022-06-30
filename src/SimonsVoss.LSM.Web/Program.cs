using SimonsVoss.LSM.Core;
using SimonsVoss.LSM.DB;
using SimonsVoss.LSM.Web.Cors;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCustomCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgreSql(x =>
{
    x.ConnectionString = builder.Configuration.GetConnectionString("DB");
    x.SqlLoggerFactory = builder.Environment.IsDevelopment()
        ? LoggerFactory.Create(builder => builder.AddConsole())
        : null;
});
builder.Services.AddCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();