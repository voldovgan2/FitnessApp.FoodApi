using System;
using System.Threading.Tasks;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus;
using FitnessApp.FoodApi.Models.Input;

namespace FitnessApp.FoodApi.Services.MessageBus
{
    public class UserFoodMessageTopicSubscribersService : CollectionBlobAggregatorServiceNewUserRegisteredSubscriberService<CreateUserFoodCollectionBlobAggregatorModel>
    {
        public UserFoodMessageTopicSubscribersService(
            Func<CreateUserFoodCollectionBlobAggregatorModel, Task<string>> createItemMethod,
            string subscription,
            IJsonSerializer serializer)
            : base(createItemMethod, subscription, serializer)
        { }
    }
}