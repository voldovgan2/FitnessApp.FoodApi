﻿using System;
using System.Threading.Tasks;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.FoodApi.Models.Input;

namespace FitnessApp.FoodApi.Services.MessageBus
{
    public class UserFoodMessageTopicSubscribersService(
        IServiceBus serviceBus,
        Func<CreateUserFoodCollectionFileAggregatorModel, Task<string>> createItemMethod,
        IJsonSerializer serializer) : CollectionFileAggregatorServiceNewUserRegisteredSubscriberService<CreateUserFoodCollectionFileAggregatorModel>(
            serviceBus,
            createItemMethod,
            serializer);
}