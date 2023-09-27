using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Services.UserFoodCollection
{
    public interface IUserFoodCollectionService
        : ICollectionService<UserFoodCollectionModel, UserFoodCollectionItemModel, CreateUserFoodCollectionModel, UpdateUserFoodCollectionModel>
    {
    }
}
