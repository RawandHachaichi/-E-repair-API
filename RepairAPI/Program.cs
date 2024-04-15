using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Repository;
using Repair.Database;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyPolicy = "MyPolicy";


//enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});


//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });

//Jwt configuration ends here

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
builder.Services.AddDbContext<DatabaseContext>(
options =>options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr")));




// dependency
builder.Services.AddScoped<IGouvernoratRepository, GouvernoratRepository>();
builder.Services.AddScoped<IDelegationRepository, DelegationRepository>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<ICauseRepository, CauseRepository>();
builder.Services.AddScoped<IObjetRepository, ObjetRepository>();
builder.Services.AddScoped<IMaterielRepository, MaterielRepository>();
builder.Services.AddScoped<ITypeDomageRepository, TypeDomageRepository>();
builder.Services.AddScoped<ILocalisationRepository,LocalisationRepository>();
builder.Services.AddScoped<ITypeBatimentRepository, TypeBatimentRepository>();
builder.Services.AddScoped<IDossierRepository, DossierRepository>();
builder.Services.AddScoped<ITypeRendezVousRepository, TypeRendezVousRepository>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyPolicy);
app.UseRouting();

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
   
});


app.MapControllers();

app.Run();
