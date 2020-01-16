using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosiacData
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseConnectot(this IServiceCollection services)
        {
            services.AddTransient<ISqlDataService, SqlDataService>();

            services.AddTransient<ISqlDataProvider, SqlDataProvider>();

            return services;
        }
    }
}
