namespace DeslandesApp.API.Configurations
{
    public class CorsConfiguration
    {
        public static string PolicyName = "DefautPolicy";
        public static void Configure(IServiceCollection services)
        {
            services.AddCors(cfg => cfg.AddPolicy(PolicyName,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                   // builder.WithOrigins("http://169.150.1.179:310")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }));
        }
    }
}

