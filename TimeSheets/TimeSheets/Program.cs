using Microsoft.EntityFrameworkCore;
using TimeSheets;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL;
using TimeSheets.DAL.Validation;
using TimeSheets.DAL.Validation.EmployeeValidation;
using TimeSheets.DAL.Validation.PersonValidation;
using TimeSheets.DAL.Validation.UserValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = Config.GetConnectionString("myDb");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(connectionString));


builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<ICreatePersonValidator, CreatePersonValidatior>();
builder.Services.AddScoped<IDeletePersonValidator,DeletePersonValidator>();
builder.Services.AddScoped<ICreateUserValidator, CreateUserValidatior>();
builder.Services.AddScoped<IDeleteUserValidator, DeleteUserValidator>();
builder.Services.AddScoped<ICreateEmployeeValidator,CreateEmployeeValidatior>();
builder.Services.AddScoped<IDeleteEmployeeValidator, DeleteEmployeeValidator>();

var app = builder.Build();

startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
