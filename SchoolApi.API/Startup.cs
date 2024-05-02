using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolApi.API.Helper;
using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Services.AuthenticationServices;
using SchoolApi.Infrastructure.Services.AzureBlobServices;
using SchoolApi.Infrastructure.Services.BusinessServices;
using SchoolApi.Infrastructure.Services.SMTPServices;
using System.Text;

namespace SchoolApi.API
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigControllers();
            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigCORS();
            services.ConfigSwagger();
            services.ConfigDbContext(config);
            services.ConfigAuthentication(config);
            services.ConfigBusinessServices();

            //services.ConfigValidators();
            //services.ConfigEmail(configuration);
            //services.ConfigBackgroundServices();
            return services;
        }
        public static IServiceCollection ConfigDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("SchoolDatabaseConnection") ?? "";
            services.AddDbContext<SchoolDbContext>(
                options => options.UseSqlServer(connectionString));
            services.AddScoped<UnitOfWork>();
            return services;
        }
        public static IServiceCollection ConfigAuthentication(this IServiceCollection services, IConfiguration config)
        {
            AuthenticationConfigs authenticationConfigs = new AuthenticationConfigs();
            config.Bind("AuthenticationConfigs", authenticationConfigs);
            services.AddSingleton(authenticationConfigs);
            services.AddSingleton<TokenGenerator>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = authenticationConfigs.Issuer,
                        ValidAudience = authenticationConfigs.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfigs.AccessTokenSecret))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];
                            //Console.WriteLine(context.Token);
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization();
            return services;
        }
        public static IServiceCollection ConfigControllers(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                //options.JsonSerializerOptions.IncludeFields
            });
            // add model binder
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new TimeSpanFormBinderProvider());
            });

            return services;
        }
        public static IServiceCollection ConfigSMTP(this IServiceCollection services, IConfiguration config)
        {
            SMTPConfigs smtpConfigs = new SMTPConfigs();
            config.Bind("SMTPConfiguration", smtpConfigs);
            services.AddSingleton(smtpConfigs);
            services.AddSingleton<EmailUtil>();
            return services;
        }
        public static IServiceCollection ConfigCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(host => true) // allow any origin
                            .AllowCredentials();
                });
            });
            return services;
        }
        public static IServiceCollection ConfigAzureBlob(this IServiceCollection services, IConfiguration config)
        {
            AzureBlobConfigs azureBlobConfigs = new AzureBlobConfigs();
            config.GetSection("AzureBlobConfigs").Bind(azureBlobConfigs);
            azureBlobConfigs.Initialize();
            services.AddSingleton(azureBlobConfigs);
            services.AddSingleton<AzureBlobHandler>();
            return services;
        }
        public static IServiceCollection ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the " +
                        "Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
            });
            return services;
        }
        public static IServiceCollection ConfigBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILecturerService, LecturerService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISchoolClassService, SchoolClassService>();
            return services;
        }
    }
}
