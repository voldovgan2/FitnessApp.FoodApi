using System;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.FoodApi.Services.MessageBus;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using FitnessApp.ServiceBus.AzureServiceBus.TopicSubscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.DependencyInjection
{
    public static class UserFoodMessageTopicSubscribersServiceExtension
    {
        public static IServiceCollection AddFoodMessageTopicSubscribersService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<ITopicSubscribers, UserFoodMessageTopicSubscribersService>(
                sp =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();
                    var subscription = configuration.GetValue<string>("ServiceBusSubscriptionName");
                    return new UserFoodMessageTopicSubscribersService(
                        sp.GetRequiredService<IUserFoodCollectionBlobAggregatorService>().CreateUserFoods,
                        subscription,
                        sp.GetRequiredService<IJsonSerializer>());
                }
            );

            return services;
        }
    }
}
