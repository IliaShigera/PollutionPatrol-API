namespace PollutionPatrol.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCurrentUserAccessor(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUserAccessor, CurrentUserAccessor>();
    }

    public static void AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        SymmetricSecurityKey secretKey =
            new(Encoding.UTF8.GetBytes(configuration[$"{JwtOptions.SectionName}:{nameof(JwtOptions.SecretKey)}"]));

        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidIssuer = configuration[$"{JwtOptions.SectionName}:{nameof(JwtOptions.Issuer)}"],
                ValidAudience = configuration[$"{JwtOptions.SectionName}:{nameof(JwtOptions.Issuer)}"],
                IssuerSigningKey = secretKey,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddSwaggerDoc(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PollutionPatrol API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Please provide a valid token",
                BearerFormat = "JWT",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}