using Microsoft.EntityFrameworkCore;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Implementation;
using AdventuraClick.Service.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Services
builder.Services.AddScoped<IBaseService<AdventuraClick.Model.Role, BaseSearchObject>, RoleService>();
builder.Services.AddScoped<IBaseService<AdventuraClick.Model.Role, BaseSearchObject>, RoleService>();
builder.Services.AddTransient<ITravelService, TravelService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
// 
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AdventuraClickInitContext>(options =>
options.UseSqlServer(connectionString));

var app = builder.Build();

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
