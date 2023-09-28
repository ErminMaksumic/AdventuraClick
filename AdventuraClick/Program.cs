using Microsoft.EntityFrameworkCore;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Implementation;
using AdventuraClick.Service.Mapper;
using Microsoft.OpenApi.Models;
using AdventuraClick.Authorization;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Authorization
builder.Services.AddSwaggerGen(opts =>
{
    opts.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic"
    });
    opts.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="basicAuth"}
            },
            new string[]{}
        }
    });
});
builder.Services.AddScoped<IBaseService<AdventuraClick.Model.Role, BaseSearchObject>, RoleService>();
builder.Services.AddTransient<ITravelService, TravelService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IIncludedItem, IncludedItemService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<ITravelInformationService, TravelInformationService>();
builder.Services.AddTransient<IAdditionalService, AdventuraClick.Service.Implementation.AdditionalService>();
// 
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null);

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
