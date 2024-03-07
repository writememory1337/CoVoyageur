using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoVoyageur.API.Data;
using CoVoyageur.Core.Models;
using CoVoyageur.API.Repositories;
using CoVoyageur.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependancies();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FilRougeRefaitContext") ?? throw new InvalidOperationException("Connection string 'FilRougeRefaitContext' not found.")));

builder.Services.AddScoped<IRepository<Feedback>, FeedbackRepository>();
builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();
builder.Services.AddScoped<IRepository<Ride>, RideRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option =>
{
    option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
