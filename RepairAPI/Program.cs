using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Repository;
using Repair.Database;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyPolicy = "MyPolicy";

// Configuration de la base de données
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr")));

// Ajout des services
builder.Services.AddControllers(); // Add this line

// Configuration du service CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyPolicy, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Ajout des services
builder.Services.AddScoped<IGouvernoratRepository, GouvernoratRepository>();
builder.Services.AddScoped<IDelegationRepository, DelegationRepository>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<ICauseRepository, CauseRepository>();
builder.Services.AddScoped<IObjetRepository, ObjetRepository>();
builder.Services.AddScoped<IMatiereRepository, MatiereRepository>();
builder.Services.AddScoped<ITypeDomageRepository, TypeDomageRepository>();
builder.Services.AddScoped<ILocalisationRepository, LocalisationRepository>();
builder.Services.AddScoped<ITypeBatimentRepository, TypeBatimentRepository>();
builder.Services.AddScoped<IDossierRepository, DossierRepository>();
builder.Services.AddScoped<ITypeRendezVousRepository, TypeRendezVousRepository>();
builder.Services.AddScoped<IDossierStatusRepository, DossierStatusRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

// Configuration de JWT Bearer Authentication si nécessaire
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "your_issuer",
//            ValidAudience = "your_audience",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
//        };
//    });

// Ajout de Swagger pour la documentation de l'API
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration de l'environnement de développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Utilisation du service CORS
app.UseCors(MyPolicy);

// Routage, authentification, autorisation et configuration des endpoints
app.UseRouting();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();