﻿using CM4_Core.DataAccess;
using CM4_DataAccess.DBV1;
using Microsoft.Extensions.DependencyInjection;

namespace CM4_Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccessV1>();

            return services;
        }
    }
}
