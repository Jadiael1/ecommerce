using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi.Extensions;
/// <summary>
/// 
/// </summary>
public static class ServiceExtensions
{

    static string XmlCommentsFilePath
    {
        get
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            // var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var tt = Path.Combine(basePath, xmlFilename);
            return tt;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwaggerExtension(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(XmlCommentsFilePath);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WebApi",
                Description = "API responsável por manter os dados do sistema",
                //Contact = new OpenApiContact
                //{
                //    Name = "",
                //    Email = "",
                //    Url = new Uri(""),
                //}
            });
            /*
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Informe o token para realizar requisições na API. Ex.: Bearer {TOKEN}",
            });
            
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
            });
            */
        });
        /*
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSettings.Key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddControllersExtension(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    //Configure CORS to allow any origin, header and method. 
    //Change the CORS policy based on your requirements.
    //More info see: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0

    public static void AddCorsExtension(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddVersionedApiExplorerExtension(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public static void AddApiVersioningExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            // Specify the default API Version as 1.0
            config.DefaultApiVersion = new ApiVersion(1, 0);
            // If the client hasn't specified the API version in the request, use the default API version number 
            config.AssumeDefaultVersionWhenUnspecified = true;
            // Advertise the API versions supported for the particular endpoint
            config.ReportApiVersions = true;
        });
    }

}

