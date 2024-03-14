using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Repository;
using Repair.Database;
var builder = WebApplication.CreateBuilder(args);
//var MyPolicy= "MyPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<DatabaseContext>(
options =>options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr")));


// 
builder.Services.AddScoped<IGouvernoratRepository, GouvernoratRepository>();
builder.Services.AddScoped<IDelegationRepository, DelegationRepository>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();


var app = builder.Build();

//enable Cors
/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});*/




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(MyPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
