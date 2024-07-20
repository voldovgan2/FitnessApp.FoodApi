using System;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.FoodApi.Data;
using FitnessApp.FoodApi.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.DependencyInjection;

public static class FoodRepositoryExtension
{
    public static IServiceCollection ConfigureFoodRepository(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<IDbContext<UserFoodCollectionEntity>, DbContext<UserFoodCollectionEntity>>();
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