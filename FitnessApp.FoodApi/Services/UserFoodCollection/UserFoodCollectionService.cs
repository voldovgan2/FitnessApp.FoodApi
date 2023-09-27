using FitnessApp.Common.Abstractions.Services.Collection;
using FitnessApp.Common.Abstractions.Services.Search;
using FitnessApp.FoodApi.Data;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Services.UserFoodCollection
{
    public class UserFoodCollectionService
        : CollectionService<UserFoodCollectionModel, UserFoodCollectionItemModel, CreateUserFoodCollectionModel, UpdateUserFoodCollectionModel>,
        IUserFoodCollectionService
    {
        public UserFoodCollectionService(IFoodRepository repository, ISearchService searchService)
            : base(repository, searchService)
        {
        }
    }
}
