using Microsoft.EntityFrameworkCore;
using SportClubApi;
using SportClubApi.Controllers;
using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Mapper;
using SportClubApi.Repositoory;
using SportClubApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ApiExceptionFilter>();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("SportClub"));
builder.Services.AddScoped<ClubMapper>();
builder.Services.AddScoped<AthletMapper>();
builder.Services.AddScoped<RegistryDocumentMapper>();
builder.Services.AddScoped<RegistryClubService>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IExclusionRepository, ExcclusionRepository>();
builder.Services.AddScoped<IRegistryClubRepository, RegistryClubRepository>();
builder.Services.AddScoped<IAthletRepository, AthletRepository>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<DbInitializer>();

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
