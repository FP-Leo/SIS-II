using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIS.Domain.Entities;
using SIS.Persistence.Databases.Context;
using Microsoft.EntityFrameworkCore;
using SIS.Infrastructure.Services;
using SIS.Application.Interfaces.Repositories;
using SIS.Persistence.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Infrastructure.ExceptionHandlers;
using Asp.Versioning;
using FluentValidation;
using SIS.Infrastructure.Validators.Users;
using SIS.Application.Interfaces.Validators;
using SIS.Infrastructure.Validators.Universities;
using SIS.Infrastructure.Validators.Faculty;
using SIS.Persistence.Databases.Data.SeedData;
using SIS.Infrastructure.Validators.Department;
using SIS.Infrastructure.Validators.Course;
using System.Text.Json.Serialization;
using SIS.Infrastructure.Validators.AdministratorProfile;
using SIS.Infrastructure.Validators.AdvisorProfile;
using SIS.Infrastructure.Validators.LecturerProfile;
using SIS.Infrastructure.Validators.StudentProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(null)); // preserves PascalCase
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "SIS API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
    options.User.RequireUniqueEmail = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

string signingKey = builder.Configuration["JWT:SigningKey"]
    ?? throw new InvalidOperationException("JWT:SigningKey is not configured.");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey))
    };
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IAcademicProgramRepository, AcademicProgramRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAdministratorProfileRepository, AdministratorProfileRepository>();
builder.Services.AddScoped<IAdvisorProfileRepository, AdvisorProfileRepository>();
builder.Services.AddScoped<ILecturerProfileRepository, LecturerProfileRepository>();
builder.Services.AddScoped<IStudentProfileRepository, StudentProfileRepository>();
builder.Services.AddScoped<IStudentProgramEnrollmentRepository, StudentProgramEnrollmentRepository>();

// Exception Handlers
builder.Services.AddExceptionHandler<DbUpdateExceptionHandler>();
builder.Services.AddExceptionHandler<InvalidInputExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Validators
builder.Services.AddScoped<IUserValidator, UserValidator>();
builder.Services.AddScoped<IUniversityValidator, UniversityValidator>();
builder.Services.AddScoped<IFacultyValidator, FacultyValidator>();
builder.Services.AddScoped<IDepartmentValidator, DepartmentValidator>();
builder.Services.AddScoped<ICourseValidator, CourseValidator>();
builder.Services.AddScoped<IAdministratorProfileValidator, AdministratorProfileValidator>();
builder.Services.AddScoped<IAdvisorProfileValidator, AdvisorProfileValidator>();
builder.Services.AddScoped<ILecturerProfileValidator, LecturerProfileValidator>();
builder.Services.AddScoped<IStudentProfileValidator, StudentProfileValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedUsersAsync(services);
    await AppSeeder.SeedCoreDataAsync(services);

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.ConfigObject.AdditionalItems["persistAuthorization"] = true;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

await app.RunAsync();
