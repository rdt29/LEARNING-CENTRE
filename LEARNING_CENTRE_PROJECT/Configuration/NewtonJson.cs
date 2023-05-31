namespace LEARNING_CENTRE_PROJECT.Configuration
{
    public static class  NewtonJson
    {
         public static IServiceCollection AddNewtonJson(this IServiceCollection services)
         {
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );
            return services;
        }
    }
}
