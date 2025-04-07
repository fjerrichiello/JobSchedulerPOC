using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Common.Jobs.Quartz;

public static class Registration
{
    public static IServiceCollection AddQuartzServices(this IServiceCollection services, IConfiguration configuration,
        bool forceOverwrite = false)
    {
        services.Configure<QuartzOptions>(options =>
        {
            options.Scheduling.IgnoreDuplicates = !forceOverwrite;
            options.Scheduling.OverWriteExistingData = forceOverwrite;
        });

        services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });

        services.AddQuartz(q => { q.AddClusteredQuartzConfiguration(configuration, "DefaultClusteredScheduler"); });

        return services;
    }

    private static void AddClusteredQuartzConfiguration(this IServiceCollectionQuartzConfigurator quartzConfigurator,
        IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString("JobSchedulersDatabase")!;

        quartzConfigurator.SchedulerId = $"{name}-{Dns.GetHostName()}";
        quartzConfigurator.SchedulerName = name;
        quartzConfigurator.InterruptJobsOnShutdown = false;
        quartzConfigurator.InterruptJobsOnShutdownWithWait = false;

        quartzConfigurator.UseDefaultThreadPool(x => x.MaxConcurrency = 1);

        quartzConfigurator.UsePersistentStore(x =>
        {
            x.UseClustering();
            x.UsePostgres(options => { options.ConnectionString = connectionString; });
            x.UseSystemTextJsonSerializer();
        });
    }

    public static IServiceCollection AddQuartzJobs(this IServiceCollection services)
    {
        services.AddSingleton<IWireTimeoutJobScheduler, WireTimeoutJobScheduler>();

        services.AddQuartz(q =>
        {
            q.AddJob<WireTimeoutJob>(job =>
                job.WithIdentity(JobConstants.WireTimeoutJob.Name, JobConstants.WireTimeoutJob.Group).StoreDurably());
        });

        return services;
    }
}