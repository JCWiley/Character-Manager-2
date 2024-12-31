using CM4_Core.DataAccess;
using CM4_DataAccess.DBV1;
using Microsoft.Extensions.DependencyInjection;

namespace CM4_DataAccess.Service
{
    public static class ServiceCollectionDataAccessExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccessV1>();

            return services;
        }
    }
}
