using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Config;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        LogManager.Configuration = new XmlLoggingConfiguration(@"../nlog.config");

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}