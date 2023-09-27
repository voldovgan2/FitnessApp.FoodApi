using System;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.FoodApi.Data;
using FitnessApp.FoodApi.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.DependencyInjection
{
    public static class FoodRepositoryExtension
    {
        public static IServiceCollection AddFoodRepository(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IFoodRepository, FoodRepository>(
                sp =>
                {
                    return new FoodRepository(
                        sp.GetRequiredService<IDbContext<UserFoodCollectionEntity>>(),
                        sp.GetRequiredService<IMapper>());
                }
            );

            return services;
        }
    }
}