namespace Sample.Infrastructure;

public static class SampleServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        Assembly applicationAssembly)
    {
        services.AddCommon(applicationAssembly);
        services.AddSupabase(configuration);
        services.AddCors(configuration);
        services.AddPagination(configuration);
        services.AddSwagger();
        services.AddScoped<INoteService, NoteService>();
        return services;
    }
}
