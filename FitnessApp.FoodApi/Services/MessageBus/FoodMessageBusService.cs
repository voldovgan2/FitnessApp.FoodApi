using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFood;
using FitnessApp.IntegrationEvents;
using FitnessApp.NatsServiceBus;
using FitnessApp.Serializer.JsonSerializer;

namespace FitnessApp.FoodApi.Services.MessageBus
{
    public class FoodMessageBusService : MessageBusService
    {
        private readonly IFoodService<UserFoodEntity, FoodItemEntity, UserFoodsModel, FoodItemModel, CreateUserFoodModel, UpdateUserFoodModel> _service;

        public FoodMessageBusService
        (
            IServiceBus serviceBus,
            IFoodService<UserFoodEntity, FoodItemEntity, UserFoodsModel, FoodItemModel, CreateUserFoodModel, UpdateUserFoodModel> service,
            IJsonSerializer serializer
        )
            : base(serviceBus, serializer)
        {
            _service = service;
        }

        protected override void HandleNewUserRegisteredEvent(NewUserRegisteredEvent integrationEvent)
        {
            _service.CreateItemAsync(new CreateUserFoodModel { UserId = integrationEvent.UserId });
        }
    }
}