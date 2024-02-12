using Microsoft.Extensions.Configuration;
using Todo.Application;
using Todo.EFCore;
using Todo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
{
    throw new NullReferenceException(nameof(connectionString));
}

builder.Services
        .AddEfcore(connectionString)
        .AddApplication();

//builder.Services.AddCors(
//options =>
//{
//    options.AddPolicy("Any",
//    cors =>
//    {
//        cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});
var MyAllowSpecificOrigin = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigin,

        policy =>
        {
            policy.WithOrigins("https://localhost:7214")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
