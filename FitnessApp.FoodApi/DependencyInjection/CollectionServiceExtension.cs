using System;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using FitnessApp.FoodApi.Services.UserFoodCollection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.DependencyInjection
{
    public static class CollectionServiceExtension
    {
        public static IServiceCollection ConfigureCollectionServices(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.Configure<CollectionFileAggregatorSettings>(configuration.GetSection("CollectionFileAggregatorSettings"));
            services.AddTransient<IUserFoodCollectionService, UserFoodCollectionService>();
            services.AddTransient<IUserFoodCollectionFileAggregatorService, UserFoodCollectionFileAggregatorService>();

            return services;
        }
    }
}
