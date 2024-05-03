using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.FoodApi.Data;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Services.UserFoodCollection
{
    public class UserFoodCollectionService(IFoodRepository repository) : CollectionService<
        UserFoodCollectionModel,
        UserFoodCollectionItemModel,
        CreateUserFoodCollectionModel,
        UpdateUserFoodCollectionModel>(repository),
        IUserFoodCollectionService;
}
