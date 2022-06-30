namespace SimonsVoss.LSM.Web.Cors;

public static class Entry
{
    public static IServiceCollection AddCustomCors(this IServiceCollection serviceCollection) =>
        serviceCollection.AddCors(options => options.AddPolicy(CorsPolicies.AllowAny, x =>
        {
            x.AllowAnyOrigin();
            x.AllowAnyHeader();
            x.AllowAnyMethod();
        }));
}