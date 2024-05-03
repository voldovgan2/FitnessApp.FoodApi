using System;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.FoodApi.Services.MessageBus;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.DependencyInjection
{
    public static class UserFoodMessageTopicSubscribersServiceExtension
    {
        public static IServiceCollection AddFoodMessageTopicSubscribersService(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddTransient(
                sp =>
                {
                    return new UserFoodMessageTopicSubscribersService(
                        sp.GetRequiredService<IServiceBus>(),
                        sp.GetRequiredService<IUserFoodCollectionFileAggregatorService>().CreateUserFoods,
                        sp.GetRequiredService<IJsonSerializer>()
                    );
                }
            );

            return services;
        }
    }
}
